using Hexa.NET.GLFW;
using Serilog;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
    private readonly Dictionary<string, Delegate> _callbacks = [];
    private unsafe readonly List<CallbackInfo> _windowCallbacks =
    [
        new("char", typeof(GLFWcharfun), (w, cb) => { GLFW.SetCharCallback(w, (GLFWcharfun)cb!); }),
        new("charmods", typeof(GLFWcharmodsfun), (w, cb) => { GLFW.SetCharModsCallback(w, (GLFWcharmodsfun)cb!); }),
        new("cursorenter", typeof(GLFWcursorenterfun), (w, cb) => { GLFW.SetCursorEnterCallback(w,(GLFWcursorenterfun) cb!); }),
        new("cursorpos", typeof(GLFWcursorposfun), (w, cb) => { GLFW.SetCursorPosCallback(w,(GLFWcursorposfun) cb!); }),
        new("drop", typeof(GLFWdropfun), (w, cb) => { GLFW.SetDropCallback(w,(GLFWdropfun) cb!); }),
        new("framebuffersize", typeof(GLFWframebuffersizefun), (w, cb) => { GLFW.SetFramebufferSizeCallback(w,(GLFWframebuffersizefun) cb!); }),
        new("key", typeof(GLFWkeyfun), (w, cb) => { GLFW.SetKeyCallback(w,(GLFWkeyfun) cb!); }),
        new("mousebutton", typeof(GLFWmousebuttonfun), (w, cb) => { GLFW.SetMouseButtonCallback(w,(GLFWmousebuttonfun) cb!); }),
        new("scroll", typeof(GLFWscrollfun), (w, cb) => { GLFW.SetScrollCallback(w,(GLFWscrollfun) cb!); }),
        new("windowclose", typeof(GLFWwindowclosefun), (w, cb) => { GLFW.SetWindowCloseCallback(w,(GLFWwindowclosefun) cb!); }),
        new("windowcontentscale", typeof(GLFWwindowcontentscalefun), (w, cb) => { GLFW.SetWindowContentScaleCallback(w,(GLFWwindowcontentscalefun) cb!); }),
        new("windowfocus", typeof(GLFWwindowfocusfun), (w, cb) => { GLFW.SetWindowFocusCallback(w,(GLFWwindowfocusfun) cb!); }),
        new("windowiconify", typeof(GLFWwindowiconifyfun), (w, cb) => { GLFW.SetWindowIconifyCallback(w,(GLFWwindowiconifyfun) cb!); }),
        new("windowmaximize", typeof(GLFWwindowmaximizefun), (w, cb) => { GLFW.SetWindowMaximizeCallback(w,(GLFWwindowmaximizefun) cb!); }),
        new("windowpos", typeof(GLFWwindowposfun), (w, cb) => { GLFW.SetWindowPosCallback(w,(GLFWwindowposfun) cb!); }),
        new("windowrefresh", typeof(GLFWwindowrefreshfun), (w, cb) => { GLFW.SetWindowRefreshCallback(w,(GLFWwindowrefreshfun) cb!); }),
        new("windowsize", typeof(GLFWwindowsizefun), (w, cb) => { GLFW.SetWindowSizeCallback(w,(GLFWwindowsizefun) cb!); }),
    ];

    private unsafe readonly List<GlobalCallbackInfo> _globalCallbacks =
    [
        new("error", typeof(GLFWerrorfun), cb => GLFW.SetErrorCallback((GLFWerrorfun)cb!)),
        new("joystick", typeof(GLFWjoystickfun), cb => GLFW.SetJoystickCallback((GLFWjoystickfun)cb!)),
        new("monitor", typeof(GLFWmonitorfun), cb => GLFW.SetMonitorCallback((GLFWmonitorfun)cb!))
    ];

    private readonly Dictionary<string, Func<Delegate>> _callbackMethods = [];

    private unsafe void InitializeCallbackMethods()
    {
        _callbackMethods["char"] = () => (GLFWcharfun)CharCallback;
        _callbackMethods["charmods"] = () => (GLFWcharmodsfun)CharModsCallback;
        _callbackMethods["cursorenter"] = () => (GLFWcursorenterfun)CursorEnterCallback;
        _callbackMethods["cursorpos"] = () => (GLFWcursorposfun)CursorPosCallback;
        _callbackMethods["drop"] = () => (GLFWdropfun)DropCallback;
        _callbackMethods["error"] = () => (GLFWerrorfun)GLFWErrorCallback;
        _callbackMethods["framebuffersize"] = () => (GLFWframebuffersizefun)FrameBufferSizeCallback;
        _callbackMethods["joystick"] = () => (GLFWjoystickfun)JoystickCallback;
        _callbackMethods["key"] = () => (GLFWkeyfun)KeyCallback;
        _callbackMethods["monitor"] = () => (GLFWmonitorfun)MonitorCallback;
        _callbackMethods["mousebutton"] = () => (GLFWmousebuttonfun)MouseButtonCallback;
        _callbackMethods["scroll"] = () => (GLFWscrollfun)ScrollCallback;
        _callbackMethods["windowclose"] = () => (GLFWwindowclosefun)WindowCloseCallback;
        _callbackMethods["windowcontentscale"] = () => (GLFWwindowcontentscalefun)WindowContentScaleCallback;
        _callbackMethods["windowfocus"] = () => (GLFWwindowfocusfun)WindowFocusCallback;
        _callbackMethods["windowiconify"] = () => (GLFWwindowiconifyfun)WindowIconifyCallback;
        _callbackMethods["windowmaximize"] = () => (GLFWwindowmaximizefun)WindowMaximizeCallback;
        _callbackMethods["windowpos"] = () => (GLFWwindowposfun)WindowPosCallback;
        _callbackMethods["windowrefresh"] = () => (GLFWwindowrefreshfun)WindowRefreshCallback;
        _callbackMethods["windowsize"] = () => (GLFWwindowsizefun)WindowResizeCallback;
    }

    private unsafe void InitializeCallback()
    {
        Log.Information("Starting callback initialization process");

        try
        {
            Log.Debug("Initializing callback methods");
            InitializeCallbackMethods();
            Log.Debug("Callback methods initialization completed");

            // Initialize window callbacks
            Log.Debug("Initializing window callbacks, count: {WindowCallbackCount}", _windowCallbacks.Count);

            var processedCount = 0;
            foreach (var callbackInfo in _windowCallbacks)
            {
                try
                {
                    Log.Verbose("Creating window callback: {CallbackName}", callbackInfo.Name);

                    if (!_callbackMethods.ContainsKey(callbackInfo.Name))
                    {
                        Log.Error("Callback method not found for window callback: {CallbackName}", callbackInfo.Name);
                        continue;
                    }

                    var callback = _callbackMethods[callbackInfo.Name]();
                    _callbacks[callbackInfo.Name] = callback;
                    callbackInfo.SetCallback(window, callback);

                    Log.Verbose("Successfully initialized window callback: {CallbackName}", callbackInfo.Name);
                    processedCount++;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to initialize window callback: {CallbackName}", callbackInfo.Name);
                }
            }

            Log.Debug("Successfully initialized {ProcessedCount} out of {TotalCount} window callbacks",
                processedCount, _windowCallbacks.Count);

            // Initialize global callbacks
            Log.Debug("Initializing global callbacks, count: {GlobalCallbackCount}", _globalCallbacks.Count);

            processedCount = 0;
            foreach (var callbackInfo in _globalCallbacks)
            {
                try
                {
                    Log.Verbose("Creating global callback: {CallbackName}", callbackInfo.Name);

                    if (!_callbackMethods.ContainsKey(callbackInfo.Name))
                    {
                        Log.Error("Callback method not found for global callback: {CallbackName}", callbackInfo.Name);
                        continue;
                    }

                    var callback = _callbackMethods[callbackInfo.Name]();
                    _callbacks[callbackInfo.Name] = callback;
                    callbackInfo.SetCallback(callback);

                    Log.Verbose("Successfully initialized global callback: {CallbackName}", callbackInfo.Name);
                    processedCount++;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to initialize global callback: {CallbackName}", callbackInfo.Name);
                }
            }

            Log.Debug("Successfully initialized {ProcessedCount} out of {TotalCount} global callbacks",
                processedCount, _globalCallbacks.Count);

            Log.Information("Callback initialization process completed successfully. Total callbacks in registry: {TotalCallbacks}",
                _callbacks.Count);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred during callback initialization process");
            throw;
        }
    }

    private unsafe void CleanUpCallback()
    {
        Log.Information("Starting callback cleanup process");
        foreach (var callbackInfo in _windowCallbacks)
        {
            Log.Verbose("Clearing window callback: {CallbackType}", callbackInfo.Name);
            callbackInfo.SetCallback(window, null);
        }

        Log.Debug("Successfully cleared window callbacks");

        foreach (var callbackInfo in _globalCallbacks)
        {
            Log.Verbose("Clearing global callback: {CallbackType}", callbackInfo.Name);
            callbackInfo.SetCallback(null);
        }

        Log.Debug("Successfully cleared global callbacks");

        Log.Debug("Clearing callbacks collection");
        _callbacks.Clear();
        Log.Debug("Clearing all event handlers");
        ClearAllEventHandlers();
        Log.Information("Callback cleanup process completed successfully");
    }

    private record CallbackInfo(
        string Name,
        Type CallbackType,
        Action<GLFWwindowPtr, Delegate?> SetCallback
    );

    private record GlobalCallbackInfo(
        string Name,
        Type CallbackType,
        Action<Delegate?> SetCallback
    );
}
