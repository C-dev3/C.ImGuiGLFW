using CefSharp;
using CefSharp.OffScreen;

namespace C.ImGuiGLFW.Web;

/// <summary>
/// Provides centralized management and configuration for the Chromium Embedded Framework (CEF)
/// within an ImGui GLFW application context.
/// </summary>
/// <remarks>
/// This static class handles the initialization, configuration, and lifecycle management of CEF.
/// It ensures that CEF is initialized only once and properly shut down when the application exits.
/// The class is specifically designed for off-screen rendering scenarios and integrates with
/// ImGui controller events for proper cleanup. All public methods are thread-safe for initialization
/// but should be called from the main UI thread.
/// </remarks>
public static class CefManager
{
    private static bool initialized;

    /// <summary>
    /// Creates a new render handler instance for off-screen CEF rendering.
    /// </summary>
    /// <returns>A new <see cref="OpenGLRenderHandler"/> instance configured for OpenGL rendering.</returns>
    /// <remarks>
    /// This method creates a render handler that is specifically designed to work with OpenGL contexts.
    /// The returned handler should be assigned to CEF browser instances that require off-screen rendering
    /// capabilities. Each browser instance typically needs its own render handler instance.
    /// </remarks>
    public static RenderHandlerBase CreateRenderer() => new OpenGLRenderHandler();

    /// <summary>
    /// Creates and returns default browser settings optimized for off-screen rendering.
    /// </summary>
    /// <returns>A <see cref="BrowserSettings"/> instance with recommended default values.</returns>
    /// <remarks>
    /// The returned settings are configured with the desktop refresh rate for optimal performance,
    /// and enable essential web technologies including JavaScript, WebGL, databases, and local storage.
    /// These settings are suitable for most web content scenarios and provide a good balance between
    /// functionality and performance. The windowless frame rate is automatically set to match the
    /// primary display's refresh rate for smooth rendering.
    /// </remarks>
    public static BrowserSettings GetDefaultBrowserSettings()
    {
        var refreshRate = Display.GetDesktopRefreshRate(0);
        return new BrowserSettings
        {
            WindowlessFrameRate = refreshRate,
            Javascript = CefState.Enabled,
            WebGl = CefState.Enabled,
            Databases = CefState.Enabled,
            LocalStorage = CefState.Enabled,
        };
    }

    /// <summary>
    /// Initializes the Chromium Embedded Framework with optimized settings for off-screen rendering.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when CEF initialization fails due to configuration issues or system constraints.
    /// </exception>
    /// <remarks>
    /// This method performs a one-time initialization of CEF with settings optimized for performance
    /// and off-screen rendering. It configures caching, disables unnecessary features like crash reporting
    /// and metrics, and enables audio support. The method is idempotent - subsequent calls will be ignored
    /// if CEF is already initialized. The method also registers for application exit events to ensure
    /// proper CEF shutdown. This method should be called before creating any CEF browser instances.
    /// </remarks>
    public static void Initialize()
    {
        if (initialized)
        {
            return;
        }

        CefSettings settings = new()
        {
            LogSeverity = LogSeverity.Disable,
            CachePath = Path.GetFullPath("cefcache"),
            WindowlessRenderingEnabled = true,
            PersistSessionCookies = true,
            RemoteDebuggingPort = 0,
        };

        //settings.SetOffScreenRenderingBestPerformanceArgs();

        settings.CefCommandLineArgs.Add("disable-breakpad", "1");
        settings.CefCommandLineArgs.Add("disable-metrics", "1");
        settings.CefCommandLineArgs.Add("disable-metrics-reporting", "1");

        settings.EnableAudio();
        bool success = Cef.Initialize(settings);
        if (!success)
        {
            throw new InvalidOperationException("Failed to initialize CEF.");
        }

        ImGuiController.Exiting += Exiting;

        initialized = true;
    }

    private static void Exiting() => Cef.Shutdown();
}
