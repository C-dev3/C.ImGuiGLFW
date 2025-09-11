using C.ImGuiGLFW.Data;
using Hexa.NET.ImGui.Backends.GLFW;
using Hexa.NET.ImGuizmo;
using Hexa.NET.ImNodes;
using Hexa.NET.ImPlot;
using Hexa.NET.ImPlot3D;
using Serilog;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GLFWwindowPtr = Hexa.NET.GLFW.GLFWwindowPtr;

namespace C.ImGuiGLFW.Manager;

internal class ImGuiManager
{

    private ImGuiContextPtr guiContext;
    private readonly GL GL;
    private const string glslVersion = "#version 460 core";

    private static readonly Vector2 ScaleFactor = Vector2.One;

    private ImPlotContextPtr? plotContextPtr = null;
    private ImNodesContextPtr? nodesContextPtr = null;
    private ImPlot3DContextPtr? plot3DContextPtr = null;
    private bool GuizmoInstalled = false;

    private readonly Module[] Modules;
    private readonly WindowSettings windowSettings;

    internal ImGuiIOPtr iOPtr = null;

    internal bool navEnableKeyboardChanged = false;
    internal bool navEnableGamepadChanged = false;
    internal bool dockingEnableChanged = false;

    internal bool AnyConfigFlagsChanged => navEnableKeyboardChanged
        || navEnableGamepadChanged
        || dockingEnableChanged;

    internal ImGuiManager(GL gl, Module[] modules, WindowSettings settings)
    {
        GL = gl;
        Modules = modules;
        windowSettings = settings;
    }

    public void Initialize(GLFWwindowPtr window)
    {
        Log.Information("Starting ImGui Initialization");

        guiContext = ImGui.CreateContext();
        ImGui.SetCurrentContext(guiContext);

        iOPtr = ImGui.GetIO();

        InitializeModules();
        SetupFonts();
        ConfigureImGuiSettings();
        InitializeImGuiBackends(window);
        Log.Information("ImGui initialization completed successfully");
    }

    private static unsafe void SetupFonts()
    {
        Log.Information("Starting setup font");
        ImGuiController.FontBuilder.SetupFonts();
    }

    private unsafe void ConfigureImGuiSettings()
    {
        if (windowSettings.NavEnableKeyboard) iOPtr.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        if (windowSettings.NavEnableGamepad) iOPtr.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;
        if (windowSettings.DockingEnable) iOPtr.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        if (windowSettings.ViewportsEnable) iOPtr.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

        ConfigureStylesColor();

        iOPtr.ConfigViewportsNoAutoMerge = true;
        iOPtr.ConfigViewportsNoTaskBarIcon = false;
        iOPtr.ConfigErrorRecovery = true;
        iOPtr.ConfigErrorRecoveryEnableAssert = false;
        iOPtr.ConfigErrorRecoveryEnableTooltip = true;
        iOPtr.ConfigDebugIsDebuggerPresent = Debugger.IsAttached;
    }

    private void InitializeImGuiBackends(GLFWwindowPtr window)
    {
        Log.Information("Starting ImGuiBackends Initialization");
        ImGuiImplGLFW.SetCurrentContext(guiContext);

        if (!ImGuiImplGLFW.InitForOpenGL(Unsafe.BitCast<GLFWwindowPtr, Hexa.NET.ImGui.Backends.GLFW.GLFWwindowPtr>(window), true))
        {
            Log.Error("Failed to init ImGui Impl GLFW");
            throw new InvalidOperationException("Failed to init ImGui Impl GLFW");
        }

        ImGuiImplOpenGL3.SetCurrentContext(guiContext);
        if (!ImGuiImplOpenGL3.Init(glslVersion))
        {
            Log.Error("Failed to init ImGui Impl OpenGL3");
            throw new InvalidOperationException("Failed to init ImGui Impl OpenGL3");
        }

        ImGuiImplGLFW.SetCallbacksChainForAllWindows(true);
        Log.Information("ImGuiBackends initialization completed successfully");
    }

    internal void ConfigureStylesColor()
    {
        switch (windowSettings.StyleColors)
        {
            case StyleColors.Dark:
                ImGui.StyleColorsDark();
                break;
            case StyleColors.Light:
                ImGui.StyleColorsLight();
                break;
            case StyleColors.Classic:
                ImGui.StyleColorsClassic();
                break;
        }
    }

    private void InitializeModules()
    {
        if (Modules.Length == 0)
        {
            Log.Information("Install modules not specified. Skipping");
            return;
        }

        int count = 0;
        Log.Information("Starting Install Modules Initialization");

        if (Modules.Any(x => x is Module.All or Module.Guizmo))
        {
            ImGuizmo.SetImGuiContext(guiContext);
            GuizmoInstalled = true;
            Log.Debug("ImGuizmo module installed successfully");
            count++;
        }

        if (Modules.Any(x => x is Module.All or Module.Nodes))
        {
            ImNodes.SetImGuiContext(guiContext);
            nodesContextPtr = ImNodes.CreateContext();
            ImNodes.SetCurrentContext(nodesContextPtr.Value);
            ImNodes.StyleColorsDark(ImNodes.GetStyle());
            Log.Debug("ImNodes module installed successfully");
            count++;
        }

        if (Modules.Any(x => x is Module.All or Module.Plot))
        {
            ImPlot.SetImGuiContext(guiContext);
            plotContextPtr = ImPlot.CreateContext();
            ImPlot.SetCurrentContext(plotContextPtr.Value);
            ImPlot.StyleColorsDark(ImPlot.GetStyle());
            Log.Debug("ImPlot module installed successfully");
            count++;
        }

        if(Modules.Any(x => x is Module.All or Module.Plot3D))
        {
            ImPlot3D.SetImGuiContext(guiContext);
            plot3DContextPtr = ImPlot3D.CreateContext();
            ImPlot3D.SetCurrentContext(plot3DContextPtr.Value);
            ImPlot3D.StyleColorsDark(ImPlot3D.GetStyle());
            Log.Debug("ImPlot3D module installed successfully");
            count++;
        }

        Log.Information($"Installed {count} Modules completed successfully");
    }

    public void NewFrame()
    {
        ImGuiImplOpenGL3.NewFrame();
        ImGuiImplGLFW.NewFrame();
        ImGui.NewFrame();
        if (GuizmoInstalled) ImGuizmo.BeginFrame();
    }

    public void UpdateImGuiIO(float deltaTime)
    {
        iOPtr.DisplayFramebufferScale = ScaleFactor;
        iOPtr.DeltaTime = (float)deltaTime;
    }

    public void Render()
    {
        ImGui.Render();
        ImGui.EndFrame();

        ImGuiImplOpenGL3.RenderDrawData(ImGui.GetDrawData());

        if ((iOPtr.ConfigFlags & ImGuiConfigFlags.ViewportsEnable) != 0)
        {
            ImGui.UpdatePlatformWindows();
            ImGui.RenderPlatformWindowsDefault();
            GL.MakeCurrent();
        }

        GL.SwapBuffers();
    }

    private void CleanupModules()
    {
        if (Modules.Length == 0) return;
        Log.Information("Starting module cleanup process");

        if (GuizmoInstalled)
        {
            ImGuizmo.SetImGuiContext(null);
            GuizmoInstalled = false;
        }

        if (plotContextPtr.HasValue)
        {
            ImPlot.SetImGuiContext(null);
            ImPlot.DestroyContext(plotContextPtr.Value);
        }

        if (nodesContextPtr.HasValue)
        {
            ImNodes.SetImGuiContext(null);
            ImNodes.DestroyContext(nodesContextPtr.Value);
        }

        if (plot3DContextPtr.HasValue)
        {
            ImPlot3D.SetImGuiContext(null);
            ImPlot3D.DestroyContext(plot3DContextPtr.Value);
        }

        Log.Information("Module cleanup process completed successfully");
    }

    internal void Shutdown()
    {
        Log.Debug("Disposing font builder");
        ImGuiController.FontBuilder.Dispose();

        Log.Debug("Shutting down ImGui OpenGL3 implementation");
        ImGuiImplOpenGL3.Shutdown();
        ImGuiImplOpenGL3.SetCurrentContext(null);

        Log.Debug("Shutting down ImGui GLFW implementation");
        ImGuiImplGLFW.Shutdown();
        ImGuiImplGLFW.SetCurrentContext(null);

        Log.Debug("Destroying ImGui context");
        ImGui.SetCurrentContext(null);
        CleanupModules();
        ImGui.DestroyContext(guiContext);
    }

    internal void InitializeConfigFlags()
    {
        navEnableKeyboardChanged = true;
        navEnableGamepadChanged = true;
        dockingEnableChanged = true;
    }

    internal void UpdateImGuiConfigFlags()
    {
        if (navEnableKeyboardChanged)
        {
            if (windowSettings.NavEnableKeyboard) iOPtr.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            else iOPtr.ConfigFlags &= ~ImGuiConfigFlags.NavEnableKeyboard;
            navEnableKeyboardChanged = false;
        }

        if (navEnableGamepadChanged)
        {
            if (windowSettings.NavEnableGamepad) iOPtr.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;
            else iOPtr.ConfigFlags &= ~ImGuiConfigFlags.NavEnableGamepad;
            navEnableGamepadChanged = false;
        }

        if (dockingEnableChanged)
        {
            if (windowSettings.DockingEnable) iOPtr.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            else iOPtr.ConfigFlags &= ~ImGuiConfigFlags.DockingEnable;
            dockingEnableChanged = false;
        }
    }
}
