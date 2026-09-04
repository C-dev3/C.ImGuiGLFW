using C.ImGuiGLFW.Data;
using Hexa.NET.ImGui.Backends.GLFW;
using Hexa.NET.ImGuizmo;
using Hexa.NET.ImNodes;
using Hexa.NET.ImPlot;
using Hexa.NET.ImPlot3D;
using Serilog;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
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

    internal static readonly Queue<CaptureRequest> _pendingCapture = [];

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

    private static void SetupFonts()
    {
        Log.Information("Starting setup font");
        ImGuiController.FontBuilder.SetupFonts();
    }

    private void ConfigureImGuiSettings()
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

        if (Modules.Any(x => x is Module.All or Module.Plot3D))
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

        ProcessPendingCapture();
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

    private void ProcessPendingCapture()
    {
        if (_pendingCapture.Count == 0) return;

        const int maxCapturesPerFrame = 10;
        int processedCount = 0;

        while (_pendingCapture.Count > 0 && processedCount < maxCapturesPerFrame)
        {
            var capture = _pendingCapture.Dequeue();
            processedCount++;

            try
            {
                ImGuiViewportPtr targetViewport = Utility.FindViewport(capture.ViewportID);
                if (targetViewport.IsNull)
                {
#if DEBUG
                    Log.Error($"Viewport {capture.ViewportID} not found, skipping capture.");
#endif
                    continue;
                }

                bool contextSwitched = false;
                if (capture.ViewportID != ImGui.GetMainViewport().ID)
                {
                    contextSwitched = Utility.SetViewportContext(targetViewport);
                }

                byte[] pixels = Utility.CaptureFramebuffer(capture.X, capture.Y, capture.Width, capture.Height, targetViewport);

                using var image = Image.LoadPixelData<Rgba32>(pixels, capture.Width, capture.Height);
                if (!string.IsNullOrWhiteSpace(capture.filePath))
                    image.Save(capture.filePath);

                if (capture.SetClipboard)
                    SetClipboardImage(image);

                if (contextSwitched) GL.MakeCurrent();
            }
            catch (Exception ex)
            {
                Log.Error($"Screenshot failed for {capture.filePath}: {ex.Message}");
            }
        }

#if DEBUG
        if (_pendingCapture.Count > 0)
            Log.Verbose($"Remaining captures: {_pendingCapture.Count} (will process next frame)");
#endif

    }

    internal static void SetClipboardImage(Image<Rgba32> image)
    {
        if (OperatingSystem.IsWindows())
            SetClipboardImageWindows(image);
        else if (OperatingSystem.IsLinux())
            SetClipboardImageLinux(image);
#if DEBUG
        else
            Log.Error("Clipboard image copy is not supported on this platform.");
#endif
    }

    private static void SetClipboardImageWindows(Image<Rgba32> image)
    {
        using var ms = new MemoryStream();
        image.SaveAsBmp(ms);
        byte[] bmpBytes = ms.ToArray();

        const int BmpFileHeaderSize = 14;
        byte[] dibBytes = new byte[bmpBytes.Length - BmpFileHeaderSize];
        Array.Copy(bmpBytes, BmpFileHeaderSize, dibBytes, 0, dibBytes.Length);

        Win32Clipboard.SetImage(dibBytes);
    }

    private static void SetClipboardImageLinux(Image<Rgba32> image)
    {
        using var ms = new MemoryStream();
        image.SaveAsPng(ms);
        byte[] pngBytes = ms.ToArray();

        bool isWayland = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAYLAND_DISPLAY"));

        string fileName = isWayland ? "wl-copy" : "xclip";
        string arguments = isWayland ? "--type image/png" : "-selection clipboard -t image/png";

        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var process = Process.Start(psi);
            if (process == null)
            {
#if DEBUG
                Log.Error($"Failed to start {fileName}. Is it installed?");
#endif
                return;
            }

            process.StandardInput.BaseStream.Write(pngBytes, 0, pngBytes.Length);
            process.StandardInput.BaseStream.Flush();
            process.StandardInput.Close();

            process.WaitForExit(3000);
        }
        catch (System.ComponentModel.Win32Exception)
        {
#if DEBUG
            Log.Error($"'{fileName}' not found. Install it with your package manager (e.g. apt install xclip / wl-clipboard).");
#endif
        }
    }
}
