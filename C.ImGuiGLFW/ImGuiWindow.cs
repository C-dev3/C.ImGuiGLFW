using C.ImGuiGLFW.Data;
using Hexa.NET.GLFW;
using Serilog;

namespace C.ImGuiGLFW;

/// <summary>
/// Provides a singleton controller for managing ImGui applications with GLFW window management.
/// </summary>
/// <remarks>
/// The ImGuiController class implements a singleton pattern to manage the lifecycle of ImGui applications.
/// It provides comprehensive window management through GLFW integration and supports modular architecture
/// through the Module system.
/// 
/// Key features:
/// - Singleton pattern ensures only one controller instance exists
/// - Multiple initialization overloads for flexible window configuration
/// - Automatic window settings persistence to file
/// - Integrated logging with Serilog
/// - Module-based architecture for extensibility
/// - Complete lifecycle management from initialization to cleanup
/// 
/// The controller handles:
/// - GLFW window creation and management
/// - ImGui context initialization and rendering
/// - OpenGL rendering context setup
/// - Frame rate control and timing
/// - Window event handling (resize, position changes)
/// - Resource cleanup and disposal
/// 
/// Usage pattern:
/// 1. Call one of the Initialize() methods to create and configure the controller
/// 2. Call Run() to start the main application loop
/// 3. The controller automatically handles cleanup on termination
/// 
/// Thread safety: The Initialize() method is thread-safe using a lock mechanism.
/// However, once initialized, the controller should be used from the main thread only.
/// </remarks>
public partial class ImGuiController
{
    const string LoadingText = "Loading";
    private static readonly Lock _lock = new();

    /// <summary>
    /// Gets a value indicating whether the ImGuiController has been initialized.
    /// </summary>
    public static bool IsInitialized => _instance != null;
    private static ImGuiController? _instance = null;

    private static ImGuiController Instance => _instance ?? throw new InvalidOperationException($"{nameof(ImGuiController)} is not initialized. Call Initialize() first.");

    /// <summary>
    /// Gets a value indicating whether the ImGuiController is currently running.
    /// </summary>
    /// <remarks>
    /// This field is set to true when the Run() method is called and the main application loop begins.
    /// It remains true throughout the execution of the main loop and is set back to false when
    /// the application terminates or the main loop exits. This field can be used by derived classes
    /// to check the running state of the controller.
    /// </remarks>
    protected bool IsRunning = false;
    private bool ready;

    /// <summary>
    /// Initializes the ImGuiController with the specified window settings and modules.
    /// </summary>
    /// <param name="windowSettings">The window settings to use. If null, settings will be read from file.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(WindowSettings? windowSettings = null, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            _instance = new(windowSettings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title, resizable flag and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="resizable">Whether the window should be resizable.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, bool resizable, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            settings.Resizable = resizable;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title, dimensions, and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, int width, int height, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            settings.Width = width;
            settings.Height = height;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title, dimensions, resizable flag and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="resizable">Whether the window should be resizable.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, int width, int height, bool resizable, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            settings.Width = width;
            settings.Height = height;
            settings.Resizable = resizable;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified dimensions and modules.
    /// </summary>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(int width, int height, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Width = width;
            settings.Height = height;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified dimensions, resizable flag and modules.
    /// </summary>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="resizable">Whether the window should be resizable.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(int width, int height, bool resizable, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Width = width;
            settings.Height = height;
            settings.Resizable = resizable;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified dimensions, position, and modules.
    /// </summary>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="position">The window position as a Vector2.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(int width, int height, Vector2 position, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Width = width;
            settings.Height = height;
            settings.Position = position;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title, dimensions, position, and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="position">The window position as a Vector2.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, int width, int height, Vector2 position, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            settings.Width = width;
            settings.Height = height;
            settings.Position = position;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified dimensions, position, resizable flag, and modules.
    /// </summary>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="position">The window position as a Vector2.</param>
    /// <param name="resizable">Whether the window should be resizable.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(int width, int height, Vector2 position, bool resizable, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Width = width;
            settings.Height = height;
            settings.Position = position;
            settings.Resizable = resizable;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title, dimensions, position, resizable flag, and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="position">The window position as a Vector2.</param>
    /// <param name="resizable">Whether the window should be resizable.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, int width, int height, Vector2 position, bool resizable, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            settings.Width = width;
            settings.Height = height;
            settings.Position = position;
            settings.Resizable = resizable;
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified dimensions, position coordinates, and modules.
    /// </summary>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="positionX">The X coordinate of the window position.</param>
    /// <param name="positionY">The Y coordinate of the window position.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(int width, int height, int positionX, int positionY, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Width = width;
            settings.Height = height;
            settings.Position = new Vector2(positionX, positionY);
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title, dimensions, position coordinates, and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="positionX">The X coordinate of the window position.</param>
    /// <param name="positionY">The Y coordinate of the window position.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, int width, int height, int positionX, int positionY, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            settings.Width = width;
            settings.Height = height;
            settings.Position = new Vector2(positionX, positionY);
            _instance = new(settings, modules);
        }
    }

    /// <summary>
    /// Initializes the ImGuiController with the specified title, dimensions, position coordinates, resizable flag, and modules.
    /// </summary>
    /// <param name="title">The window title to use.</param>
    /// <param name="width">The window width in pixels.</param>
    /// <param name="height">The window height in pixels.</param>
    /// <param name="positionX">The X coordinate of the window position.</param>
    /// <param name="positionY">The Y coordinate of the window position.</param>
    /// <param name="resizable">Whether the window should be resizable.</param>
    /// <param name="modules">The modules to initialize with the controller.</param>
    public static void Initialize(string title, int width, int height, int positionX, int positionY, bool resizable, params Module[] modules)
    {
        lock (_lock)
        {
            if (_instance != null) throw new InvalidOperationException($"{nameof(ImGuiController)} is already initialized.");
            var settings = WindowSettings.ReadFromFile();
            settings.Title = !string.IsNullOrEmpty(title) ? title : WindowSettings.DefaultWindowName;
            settings.Width = width;
            settings.Height = height;
            settings.Position = new Vector2(positionX, positionY);
            settings.Resizable = resizable;
            _instance = new(settings, modules);
        }
    }

    private ImGuiController(WindowSettings? windowSettings = null, params Module[] modules)
    {
        WindowSettings = windowSettings ?? WindowSettings.ReadFromFile();
        Modules = modules;
        Log.Information("Application initializing");
        Log.Information($"Initializing {nameof(ImGuiController)}");
        InitializeLogger();
        frameTimeThreshold = WindowSettings.FrameRate == 0 ? 0.0 : 1.0 / WindowSettings.FrameRate;
        Log.Information($"Application initialized with title: {WindowSettings.Title}, size: <{WindowSettings.Width}, {WindowSettings.Height}>, position: {WindowSettings.Position}, topmost: {WindowSettings.TopMost}, frequency: {WindowSettings.FrameRate}");
    }

    private static void InitializeLogger()
    {
        var dir = Path.Combine(AppContext.BaseDirectory, "logs");
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        var logFilePath = Path.Combine(dir, "app-.log");
        bool hasConsole = Utility.HasConsoleWindow();
        if (hasConsole)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
#endif
                .WriteTo.Console()
                .WriteTo.File(logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                fileSizeLimitBytes: 50 * 1024 * 1024,
                rollOnFileSizeLimit: true)
                .CreateLogger();
            Log.Debug("Logger initialized with console output");
        }
        else
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
#endif
                .WriteTo.File(logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                fileSizeLimitBytes: 50 * 1024 * 1024,
                rollOnFileSizeLimit: true)
                .CreateLogger();
            Log.Debug("Logger initialized without console output");
        }
    }

    /// <summary>
    /// Starts the main application loop and runs the ImGuiController until termination.
    /// </summary>
    /// <remarks>
    /// This method will block the calling thread until the application is terminated.
    /// It handles the complete lifecycle of the ImGui application including initialization,
    /// main loop execution, and cleanup. If the controller is already running, this method
    /// returns immediately without taking any action.
    /// 
    /// The method performs the following operations:
    /// - Initializes GLFW for window management
    /// - Sets up ImGui context and configuration
    /// - Initializes OpenGL rendering context
    /// - Runs the main render loop
    /// - Handles cleanup and disposal of resources
    /// 
    /// Any exceptions during startup will be logged and re-thrown after cleanup.
    /// </remarks>
    /// <exception cref="InvalidOperationException">Thrown when the ImGuiController has not been initialized.</exception>
    /// <exception cref="Exception">Thrown when initialization or main loop execution fails.</exception>
    public static void Run()
    {
        if (Instance.IsRunning) return;
        Log.Information("Starting application");

        Instance.IsRunning = true;

        OnResize += Instance.OnWindowResize;
        OnSetPos += Instance.OnWindowSetPos;
        OnUpdateFrame += Instance.WindowUpdateFrame;
        Instance.ready = true;
        Instance.Start();

        Instance.IsRunning = false;

        Instance.Terminate();
    }

    private void Start()
    {
        try
        {
            InitializeGLFW();
            InitializeImGui();
            InitializeOpenGL();

            _initializeCompletedCallback?.Invoke();
            Log.Information("Initialization completed successfully");

            RunMainLoop();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to start window");
            throw;
        }
        finally
        {
            CleanUp();
        }
    }

    private void Terminate()
    {
        Log.Information("Start disposing");
        OnUpdateFrame -= WindowUpdateFrame;
        OnResize -= OnWindowResize;
        OnSetPos -= OnWindowSetPos;
        windows.ForEach(w =>
        {
            w.OnClose();
            w.OnDispose();
        });
        windows.Clear();
        windowIds.Clear();
        postDraw.Clear();
        ready = false;
        bool success = WindowSettings.Write();
        Log.Information($"WindowSettings saved {(success ? "successfully" : "failed")}");
        Log.Information("Application disposed");
        Log.CloseAndFlush();
        _instance = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    private void WindowUpdateFrame() => windows.ForEach(w => w.Update());

    private void OnWindowSetPos(SetPosEventArgs args)
    {
        if (GetWindowAttrib(GLFW.GLFW_MAXIMIZED) != 1 && GetWindowAttrib(GLFW.GLFW_ICONIFIED) != 1)
            WindowSettings.Position = args.Position;
    }

    private void OnWindowResize(ResizeEventArgs args)
    {
        if (GetWindowAttrib(GLFW.GLFW_MAXIMIZED) != 1 && GetWindowAttrib(GLFW.GLFW_ICONIFIED) != 1)
        {
            WindowSettings.Width = args.Width;
            WindowSettings.Height = args.Height;
        }
    }
}
