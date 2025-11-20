using C.ImGuiGLFW.Events;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
#pragma warning disable IDE1006
    private static event InitializeCompletedCallback? _initializeCompletedCallback;
    /// <summary>
    /// Occurs when the initialization process is completed.
    /// </summary>
    /// <remarks>
    /// This event is raised after all initialization steps (GLFW, ImGui, OpenGL) have finished successfully,
    /// and before the main loop starts running. Subscribers can use this event to perform additional setup
    /// or configuration that depends on the completed initialization.
    /// </remarks>
    public static event InitializeCompletedCallback OnInitializeCompleted
    {
        add => _initializeCompletedCallback += value;
        remove => _initializeCompletedCallback -= value;
    }

    private static event UpdateFrameCallback? _updateFrameCallback;
    /// <summary>
    /// Triggered during the update phase of the frame loop. Receives FrameEventArgs containing frame timing information.
    /// </summary>
    public static event UpdateFrameCallback OnUpdateFrame
    {
        add => _updateFrameCallback += value;
        remove => _updateFrameCallback -= value;
    }

    private static event RenderFrameCallback? _renderFrameCallback;
    /// <summary>
    /// Triggered during the render phase of the frame loop. Receives FrameEventArgs containing frame timing information.
    /// </summary>
    public static event RenderFrameCallback OnRenderFrame
    {
        add => _renderFrameCallback += value;
        remove => _renderFrameCallback -= value;
    }

    private static event OnMainMenuBarRenderCallback? _onMainMenuBarRenderCallback;
    /// <summary>
    /// Triggered when the main menu bar needs to be rendered.
    /// </summary>
    public static event OnMainMenuBarRenderCallback OnMainMenuBarRender
    {
        add => _onMainMenuBarRenderCallback += value;
        remove => _onMainMenuBarRenderCallback -= value;
    }

    #region NativeCallbacks
    private static event OnCharCallback? _onCharCallback;
    /// <summary>
    /// Triggered when a Unicode character is input. Receives the codepoint of the character.
    /// </summary>
    public static event OnCharCallback OnChar
    {
        add => _onCharCallback += value;
        remove => _onCharCallback -= value;
    }

    private static event OnCharModsCallback? _onCharModsCallback;
    /// <summary>
    /// Triggered when a Unicode character is input with modifier keys pressed. Receives the character codepoint and modifier key states.
    /// </summary>
    public static event OnCharModsCallback OnCharMods
    {
        add => _onCharModsCallback += value;
        remove => _onCharModsCallback -= value;
    }

    private static event OnCursorEnterCallback? _onCursorEnterCallback;
    /// <summary>
    /// Triggered when the mouse cursor enters or leaves the window. Receives true when entering, false when leaving.
    /// </summary>
    public static event OnCursorEnterCallback OnCursorEnter
    {
        add => _onCursorEnterCallback += value;
        remove => _onCursorEnterCallback -= value;
    }

    private static event OnCursorPosCallback? _onCursorPosCallback;
    /// <summary>
    /// Triggered when the mouse cursor position changes. Receives the new X and Y coordinates.
    /// </summary>
    public static event OnCursorPosCallback OnCursorPos
    {
        add => _onCursorPosCallback += value;
        remove => _onCursorPosCallback -= value;
    }

    private static event OnDropCallback? _onDropCallback;
    /// <summary>
    /// Triggered when files or folders are dragged and dropped onto the window. Receives the count of dropped files and an array of file paths.
    /// </summary>
    public static event OnDropCallback OnDrop
    {
        add => _onDropCallback += value;
        remove => _onDropCallback -= value;
    }

    private static event OnGLFWErrorCallback? _onGLFWErrorCallback;
    /// <summary>
    /// Triggered when an error occurs in the GLFW library. Receives the error code and error reason.
    /// </summary>
    public static event OnGLFWErrorCallback OnGLFWError
    {
        add => _onGLFWErrorCallback += value;
        remove => _onGLFWErrorCallback -= value;
    }

    private static event OnFrameBufferSizeCallback? _onFrameBufferSizeCallback;
    /// <summary>
    /// Triggered when the framebuffer size changes. Receives the new width and height.
    /// </summary>
    public static event OnFrameBufferSizeCallback OnFrameBufferSize
    {
        add => _onFrameBufferSizeCallback += value;
        remove => _onFrameBufferSizeCallback -= value;
    }

    private static event OnJoystickCallback? _onJoystickCallback;
    /// <summary>
    /// Triggered when a joystick is connected or disconnected. Receives the joystick ID and event ID.
    /// </summary>
    public static event OnJoystickCallback OnJoystick
    {
        add => _onJoystickCallback += value;
        remove => _onJoystickCallback -= value;
    }

    private static event OnKeyCallback? _onKeyCallback;
    /// <summary>
    /// Triggered when a keyboard key is pressed, released, or held down. Receives the key code, scancode, action, and modifier keys.
    /// </summary>
    public static event OnKeyCallback OnKey
    {
        add => _onKeyCallback += value;
        remove => _onKeyCallback -= value;
    }

    private static event OnMonitorCallback? _onMonitorCallback;
    /// <summary>
    /// Triggered when a monitor is connected or disconnected. Receives the event type.
    /// </summary>
    public static event OnMonitorCallback OnMonitor
    {
        add => _onMonitorCallback += value;
        remove => _onMonitorCallback -= value;
    }

    private static event OnMouseButtonCallback? _onMouseButtonCallback;
    /// <summary>
    /// Triggered when a mouse button is pressed or released. Receives the button, action, and modifier keys.
    /// </summary>
    public static event OnMouseButtonCallback OnMouseButton
    {
        add => _onMouseButtonCallback += value;
        remove => _onMouseButtonCallback -= value;
    }

    private static event OnScrollCallback? _onScrollCallback;
    /// <summary>
    /// Triggered when the mouse wheel is scrolled. Receives the X and Y offset values.
    /// </summary>
    public static event OnScrollCallback OnScroll
    {
        add => _onScrollCallback += value;
        remove => _onScrollCallback -= value;
    }

    private static event OnWindowCloseCallback? _onWindowCloseCallback;
    /// <summary>
    /// Triggered when the window close button is clicked or close is requested.
    /// </summary>
    public static event OnWindowCloseCallback OnWindowClose
    {
        add => _onWindowCloseCallback += value;
        remove => _onWindowCloseCallback -= value;
    }

    private static event OnWindowContentScaleCallback? _onWindowContentScaleCallback;
    /// <summary>
    /// Triggered when the window content scale changes. Receives the X and Y scale factors.
    /// </summary>
    public static event OnWindowContentScaleCallback OnWindowContentScale
    {
        add => _onWindowContentScaleCallback += value;
        remove => _onWindowContentScaleCallback -= value;
    }

    private static event OnWindowFocusCallback? _onWindowFocusCallback;
    /// <summary>
    /// Triggered when the window gains or loses focus. Receives true when focused, false when unfocused.
    /// </summary>
    public static event OnWindowFocusCallback OnWindowFocus
    {
        add => _onWindowFocusCallback += value;
        remove => _onWindowFocusCallback -= value;
    }

    private static event OnWindowIconifyCallback? _onWindowIconifyCallback;
    /// <summary>
    /// Triggered when the window is minimized or restored. Receives true when minimized, false when restored.
    /// </summary>
    public static event OnWindowIconifyCallback OnWindowIconify
    {
        add => _onWindowIconifyCallback += value;
        remove => _onWindowIconifyCallback -= value;
    }

    private static event OnWindowMaximizeCallback? _onWindowMaximizeCallback;
    /// <summary>
    /// Triggered when the window is maximized or restored. Receives true when maximized, false when restored.
    /// </summary>
    public static event OnWindowMaximizeCallback OnWindowMaximize
    {
        add => _onWindowMaximizeCallback += value;
        remove => _onWindowMaximizeCallback -= value;
    }

    private static event OnSetPosCallback? _onSetPosCallback;
    /// <summary>
    /// Triggered when the window position is changed. Receives SetPosEventArgs containing position information.
    /// </summary>
    public static event OnSetPosCallback OnSetPos
    {
        add => _onSetPosCallback += value;
        remove => _onSetPosCallback -= value;
    }

    private static event OnWindowRefreshCallback? _onWindowRefreshCallback;
    /// <summary>
    /// Triggered when the window needs to be refreshed or redrawn.
    /// </summary>
    public static event OnWindowRefreshCallback OnWindowRefresh
    {
        add => _onWindowRefreshCallback += value;
        remove => _onWindowRefreshCallback -= value;
    }

    private static event OnResizeCallback? _onResizeCallback;
    /// <summary>
    /// Triggered when the window is resized. Receives ResizeEventArgs containing size information.
    /// </summary>
    public static event OnResizeCallback OnResize
    {
        add => _onResizeCallback += value;
        remove => _onResizeCallback -= value;
    }

    private static void ClearAllEventHandlers()
    {
        // InitializeCompleted event
        _initializeCompletedCallback = null;

        // Frame events
        _updateFrameCallback = null;
        _renderFrameCallback = null;
        _onMainMenuBarRenderCallback = null;

        // Input events
        _onCharCallback = null;
        _onCharModsCallback = null;
        _onKeyCallback = null;
        _onMouseButtonCallback = null;
        _onScrollCallback = null;
        _onCursorEnterCallback = null;
        _onCursorPosCallback = null;
        _onDropCallback = null;

        // Window events
        _onWindowCloseCallback = null;
        _onWindowContentScaleCallback = null;
        _onWindowFocusCallback = null;
        _onWindowIconifyCallback = null;
        _onWindowMaximizeCallback = null;
        _onSetPosCallback = null;
        _onWindowRefreshCallback = null;
        _onResizeCallback = null;
        _onFrameBufferSizeCallback = null;

        // System events
        _onGLFWErrorCallback = null;
        _onJoystickCallback = null;
        _onMonitorCallback = null;
    }
    #endregion
}
