using C.ImGuiGLFW.Data;
using C.ImGuiGLFW.Imaging;
using C.ImGuiGLFW.Manager;
using Hexa.NET.GLFW;
using Serilog;
using System.Diagnostics;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
    private const double ResetInterval = 3600.0d;
    internal const double MaxFrequency = 500.0d;
    private const double callbackFrameThreshold = 1.0d / 60.0d;

    private GLFWwindowPtr window;
    private GL GL = null!;
    private BindingsContext bindingsContext = null!;
    private readonly WindowSettings WindowSettings = WindowSettings.Default;

    private bool isIconified = false;

    private readonly Stopwatch _watchUpdate = new();
    private double lastUpdateTime = 0.0d;
    private double lastFrameDeltaTime = 0.0d;
    private readonly double frameTimeThreshold;
    private double lastCallbackTime = 0.0d;
    private double callbackFrameDeltaTime = 0.0d;

    private Vector4 lastBackgroundColor;

    private ImGuiManager imGuiManager = null!;

    /// <summary>
    /// Occurs when the application is about to exit.
    /// </summary>
    /// <remarks>
    /// This event is raised during the application shutdown process, allowing subscribers
    /// to perform cleanup operations or save state before the application terminates.
    /// Handlers should execute quickly to avoid delaying the shutdown process.
    /// This is a static event, so it persists across all instances and should be
    /// unsubscribed properly to avoid memory leaks.
    /// </remarks>
    public static event Action? Exiting;
    private int monitorIndex = -1;

    /// <summary>
    /// Gets the FontBuilder instance used for configuring and building fonts for the ImGui application.
    /// </summary>
    /// <value>A FontBuilder instance that provides methods and properties for font configuration.</value>
    /// <remarks>
    /// This property provides access to the internal FontBuilder instance, allowing external code to configure font settings such as enabling/disabling specific font types and adding custom fonts. The FontBuilder instance is created internally and cannot be instantiated directly by external code. Use this property to customize font loading behavior before the font setup process is executed.
    /// </remarks>
    public static readonly FontBuilder FontBuilder = FontBuilder.Create();
    private readonly Module[] Modules = [];

    private void InitializeGLFW()
    {
        Log.Information("Starting GLFW Initialization");
        GLFW.Init();

        GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MAJOR, 4);
        GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MINOR, 6);
        GLFW.WindowHint(GLFW.GLFW_OPENGL_PROFILE, GLFW.GLFW_OPENGL_CORE_PROFILE);
        GLFW.WindowHint(GLFW.GLFW_TRANSPARENT_FRAMEBUFFER, GLFW.GLFW_TRUE);
        GLFW.WindowHint(GLFW.GLFW_SAMPLES, 4);
        GLFW.WindowHint(GLFW.GLFW_REFRESH_RATE, GLFW.GLFW_DONT_CARE);
        GLFW.WindowHint(GLFW.GLFW_SRGB_CAPABLE, GLFW.GLFW_TRUE);

        Log.Information("OpenGL context configured: Version 4.6 Core Profile, MSAA=4x");

        if (OperatingSystem.IsMacOS())
        {
            GLFW.WindowHint(GLFW.GLFW_OPENGL_FORWARD_COMPAT, GLFW.GLFW_TRUE);
            Log.Debug("Applied macOS forward compatibility settings");
        }

        ConfigureWindowHints();

        window = GLFW.CreateWindow(WindowSettings.Width, WindowSettings.Height, WindowSettings.Title, null, null);

        // Fallback
        if (window.IsNull)
        {
            Log.Warning("Failed to create OpenGL 4.6 context, attempting fallback to OpenGL 3.3");
            GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MAJOR, 3);
            GLFW.WindowHint(GLFW.GLFW_CONTEXT_VERSION_MINOR, 3);
            window = GLFW.CreateWindow(WindowSettings.Width, WindowSettings.Height, WindowSettings.Title, null, null);

            if (!window.IsNull)
            {
                Log.Information("Fallback window created successfully with OpenGL 3.3");
            }
        }
        else
        {
            Log.Information("GLFW window created: {Width}x{Height} '{Title}' (OpenGL 4.6)",
                WindowSettings.Width, WindowSettings.Height, WindowSettings.Title);
        }

        if (window.IsNull)
        {
            Log.Error($"Failed to create window: {WindowSettings.Title}");
            throw new InvalidOperationException($"Failed to create window: {WindowSettings.Title}");
        }
        Log.Information("GLFW window created successfully: {Width}x{Height} '{Title}'",
        WindowSettings.Width, WindowSettings.Height, WindowSettings.Title);

        if (WindowSettings.Iconified) IconifyWindow();

        InitializeCallback();
        SetWindowIcon();

        GLFW.MakeContextCurrent(window);
        bindingsContext = new BindingsContext(window);
        GL = new(bindingsContext);

        monitorIndex = GetCurrentWindowIndex();

        Log.Information("GLFW initialization completed successfully");
    }

    private void ConfigureWindowHints()
    {
        if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
        {
            var hints = new
            {
                WindowSettings.FocusedOnStartup,
                WindowSettings.Resizable,
                Position = WindowSettings.Position?.ToString() ?? "Default"
            };
            Log.Debug("Configuring window hints {@WindowHints}", hints);
        }

        if (WindowSettings.FocusedOnStartup)
            GLFW.WindowHint(GLFW.GLFW_FOCUSED, GLFW.GLFW_TRUE);
        if (WindowSettings.Resizable) GLFW.WindowHint(GLFW.GLFW_RESIZABLE, GLFW.GLFW_TRUE);
        if (WindowSettings.Maximized) GLFW.WindowHint(GLFW.GLFW_MAXIMIZED, GLFW.GLFW_TRUE);
        if (WindowSettings.Position.HasValue)
        {
            GLFW.WindowHint(GLFW.GLFW_POSITION_X, (int)WindowSettings.Position.Value.X);
            GLFW.WindowHint(GLFW.GLFW_POSITION_Y, (int)WindowSettings.Position.Value.Y);
        }
        GLFW.WindowHint(GLFW.GLFW_DECORATED, WindowSettings.ShowTitleBar ? GLFW.GLFW_TRUE : GLFW.GLFW_FALSE);
    }

    private unsafe void SetWindowIcon()
    {
        Log.Information("Starting set window icon");
        string iconPath = Path.Combine(AppContext.BaseDirectory, "icon.png");
        if (!File.Exists(iconPath))
        {
            Log.Error($"Icon file not found");
            return;
        }

        try
        {
            byte[] iconBytes = ImageConverter.ConvertImageToRgba(iconPath, out int width, out int height);
            GLFWimage image = new() { Width = width, Height = height, Pixels = iconBytes.ToPtr() };
            GLFWimagePtr icon = new() { Handle = &image, Pixels = image.Pixels };
            GLFW.SetWindowIcon(window, 1, icon);
            Log.Information("Set window icon completed successfully");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to set window icon");
        }
    }

    private void InitializeImGui()
    {
        imGuiManager = new ImGuiManager(GL, Modules, WindowSettings);
        imGuiManager.Initialize(window);
    }

    private void InitializeOpenGL()
    {
        Log.Information("Starting OpenGL Initialization");

        GL.Enable(GLEnableCap.Blend);
        GL.BlendFunc(GLBlendingFactor.SrcAlpha, GLBlendingFactor.OneMinusSrcAlpha);

        topMostChanged = true;
        resizableChanged = true;
        autoIconifyChanged = true;
        showTitleBarChanged = true;
        windowSizeLimitsChanged = true;
        backgroundColorChanged = true;
        imGuiManager.InitializeConfigFlags();

        Log.Information("OpenGL initialization completed successfully");
    }

    private void RunMainLoop()
    {
        Log.Information("Starting main loop");
        _watchUpdate.Start();

        while (GLFW.WindowShouldClose(window) == 0)
        {
            if (!ProcessFrameTiming()) continue;

            GLFW.PollEvents();

            if (UpdateIconifiedState()) continue;

            RenderFrame();
        }

        Log.Information("Dispose requested");
    }

    private bool ProcessFrameTiming()
    {
        if (AnyConfigurationChanged)
        {
            UpdateWindowAttributes();
        }

        if (imGuiManager.AnyConfigFlagsChanged)
        {
            imGuiManager.UpdateImGuiConfigFlags();
        }

        double currentTime = _watchUpdate.Elapsed.TotalSeconds;
        if (currentTime > 86400.0)
        {
            _watchUpdate.Restart();
            lastUpdateTime = 0.0d;
            currentTime = 0.0d;
        }

        double deltaTime = currentTime - lastUpdateTime;
        if (deltaTime < frameTimeThreshold)
        {
            if (frameTimeThreshold - deltaTime > 0.001)
            {
                Thread.Sleep((int)((frameTimeThreshold - deltaTime) * 1000));
            }
            return false;
        }

        lastFrameDeltaTime = deltaTime;
        lastUpdateTime = currentTime;
        return true;
    }

    private bool UpdateIconifiedState()
    {
        bool currentIconified = GLFW.GetWindowAttrib(window, GLFW.GLFW_ICONIFIED) != 0;
        if (currentIconified != isIconified)
        {
            isIconified = currentIconified;
        }

        if (isIconified)
        {
            Thread.Sleep(16);
            return true;
        }

        return false;
    }

    private void RenderFrame()
    {
        double deltaTime = lastFrameDeltaTime;

        UpdateBackgroundColor();
        GL.Clear(GLClearBufferMask.ColorBufferBit);

        imGuiManager.NewFrame();

        _updateFrameCallback?.Invoke();

        imGuiManager.UpdateImGuiIO((float)deltaTime);

        try
        {
            InternalDraw();
            _renderFrameCallback?.Invoke(deltaTime);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"An Error occured in draw frame");
            throw new Exception($"An Error occurred in draw frame: {ex.Message}\n{ex.StackTrace}");
        }

        CleanOldTextures();

        imGuiManager.Render();
    }

    private bool ProcessCallbackFrameTiming()
    {
        double currentTime = _watchUpdate.Elapsed.TotalSeconds;
        if (currentTime > 86400.0) // 24hour
        {
            _watchUpdate.Restart();
            lastCallbackTime = 0.0d;
            currentTime = 0.0d;
        }
        double deltaTime = currentTime - lastCallbackTime;

        if (deltaTime < callbackFrameThreshold)
        {
            return false;
        }
        callbackFrameDeltaTime = deltaTime;
        lastCallbackTime = currentTime;
        return true;
    }

    private void RenderFrameFromCallback()
    {
        if (!ProcessCallbackFrameTiming()) return;

        double deltaTime = callbackFrameDeltaTime;
        UpdateBackgroundColor();
        GL.Clear(GLClearBufferMask.ColorBufferBit);

        imGuiManager.NewFrame();
        _updateFrameCallback?.Invoke();

        imGuiManager.UpdateImGuiIO((float)deltaTime);

        try
        {
            InternalDraw();
            _renderFrameCallback?.Invoke(deltaTime);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"An Error occured in draw frame");
            throw new Exception($"An Error occurred in draw frame: {ex.Message}\n{ex.StackTrace}");
        }
        CleanOldTextures();

        imGuiManager.Render();
    }

    private void UpdateWindowAttributes()
    {
        if (topMostChanged)
        {
            GLFW.SetWindowAttrib(window, GLFW.GLFW_FLOATING, WindowSettings.TopMost ? GLFW.GLFW_TRUE : GLFW.GLFW_FALSE);
            topMostChanged = false;
        }
        if (resizableChanged)
        {
            GLFW.SetWindowAttrib(window, GLFW.GLFW_RESIZABLE, WindowSettings.Resizable ? GLFW.GLFW_TRUE : GLFW.GLFW_FALSE);
            if (WindowSettings.Resizable)
            {
                GLFW.SetWindowSizeLimits(window,
                                     (int)WindowSettings.MinSize.X,
                                     (int)WindowSettings.MinSize.Y,
                                     (int)WindowSettings.MaxSize.X,
                                     (int)WindowSettings.MaxSize.Y);
            }
            resizableChanged = false;
        }
        if (windowMaximizeChanged)
        {
            GLFW.SetWindowAttrib(window, GLFW.GLFW_MAXIMIZED, WindowSettings.Maximized ? GLFW.GLFW_TRUE : GLFW.GLFW_FALSE);
            if (WindowSettings.Maximized) MaximizeWindow();
            else RestoreWindow();
            windowMaximizeChanged = false;
        }
        if (windowIconifyChanged)
        {
            GLFW.SetWindowAttrib(window, GLFW.GLFW_ICONIFIED, WindowSettings.Iconified ? GLFW.GLFW_TRUE : GLFW.GLFW_FALSE);
            if (WindowSettings.Iconified) IconifyWindow();
            else RestoreWindow();
            windowIconifyChanged = false;
        }
        if (autoIconifyChanged)
        {
            GLFW.SetWindowAttrib(window, GLFW.GLFW_AUTO_ICONIFY, WindowSettings.AutoIconify ? GLFW.GLFW_TRUE : GLFW.GLFW_FALSE);
            autoIconifyChanged = false;
        }
        if (showTitleBarChanged)
        {
            GLFW.SetWindowAttrib(window, GLFW.GLFW_DECORATED, WindowSettings.ShowTitleBar ? GLFW.GLFW_TRUE : GLFW.GLFW_FALSE);
            showTitleBarChanged = false;
        }
        if (windowSizeLimitsChanged)
        {
            GLFW.SetWindowSizeLimits(window,
                                     (int)WindowSettings.MinSize.X,
                                     (int)WindowSettings.MinSize.Y,
                                     (int)WindowSettings.MaxSize.X,
                                     (int)WindowSettings.MaxSize.Y);
            windowSizeLimitsChanged = false;
        }
    }

    private void UpdateBackgroundColor()
    {
        if (backgroundColorChanged || !lastBackgroundColor.Equals(WindowSettings.BackgroundColor))
        {
            GL.ClearColor(WindowSettings.BackgroundColor.X,
                         WindowSettings.BackgroundColor.Y,
                         WindowSettings.BackgroundColor.Z,
                         WindowSettings.BackgroundColor.W);
            lastBackgroundColor = WindowSettings.BackgroundColor;
            backgroundColorChanged = false;
        }
    }

    private void CleanUp()
    {
        Log.Information("Starting cleanup process");

        try
        {
            Log.Debug("Cleaning old textures");
            DisposeTextures();

            Log.Debug("Executing cleanup callback");
            CleanUpCallback();

            Exiting?.Invoke();

            imGuiManager.Shutdown();

            if (GL != null)
            {
                Log.Debug("Disposing OpenGL context");
                GL.Dispose();
                GL = null!;
            }

            if (!window.IsNull)
            {
                Log.Debug("Destroying GLFW window");
                GLFW.DestroyWindow(window);
            }

            Log.Debug("Terminating GLFW");
            GLFW.Terminate();
            Log.Information("Cleanup process completed successfully");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred during cleanup process");
            throw;
        }
    }
}
