namespace C.ImGuiGLFW.Events;


#region Frame delegates

/// <summary>
/// Delegate for updating frame.
/// </summary>
public delegate void UpdateFrameCallback();

/// <summary>
/// Delegate for rendering a frame.
/// </summary>
/// <param name="deltaTime">Time elapsed since the last frame, in seconds.</param>
public delegate void RenderFrameCallback(double deltaTime);

/// <summary>
/// Delegate for rendering the main menu bar.
/// </summary>
public delegate void OnMainMenuBarRenderCallback();

#endregion

#region Input delegates

/// <summary>
/// Delegate invoked when a Unicode character is input.
/// </summary>
/// <param name="codepoint">The Unicode codepoint of the character input.</param>
public delegate void OnCharCallback(uint codepoint);

/// <summary>
/// Delegate invoked when a Unicode character is input with modifier keys.
/// </summary>
/// <param name="codepoint">The Unicode codepoint of the character input.</param>
/// <param name="mods">Modifier keys bitfield (e.g., Shift, Ctrl).</param>
public delegate void OnCharModsCallback(uint codepoint, int mods);

/// <summary>
/// Delegate invoked when the cursor enters or leaves the window.
/// </summary>
/// <param name="entered">True if the cursor entered the window, false if it left.</param>
public delegate void OnCursorEnterCallback(bool entered);

/// <summary>
/// Delegate invoked when the cursor moves.
/// </summary>
/// <param name="xpos">The new cursor x-position.</param>
/// <param name="ypos">The new cursor y-position.</param>
public delegate void OnCursorPosCallback(double xpos, double ypos);

/// <summary>
/// Delegate invoked when files are dropped onto the window.
/// </summary>
/// <param name="pathCount">The number of file paths dropped.</param>
/// <param name="filePaths">List of dropped file paths.</param>
public delegate void OnDropCallback(int pathCount, List<string> filePaths);

/// <summary>
/// Delegate invoked on keyboard key events.
/// </summary>
/// <param name="key">The keyboard key code.</param>
/// <param name="scancode">The platform-specific scancode.</param>
/// <param name="action">The action (press, release, repeat).</param>
/// <param name="mods">Modifier keys bitfield.</param>
public delegate void OnKeyCallback(int key, int scancode, int action, int mods);

/// <summary>
/// Delegate invoked on mouse button events.
/// </summary>
/// <param name="button">Mouse button identifier.</param>
/// <param name="action">The action (press, release).</param>
/// <param name="mods">Modifier keys bitfield.</param>
public delegate void OnMouseButtonCallback(int button, int action, int mods);

/// <summary>
/// Delegate invoked when the mouse wheel is scrolled.
/// </summary>
/// <param name="xoffset">Scroll offset along the x-axis.</param>
/// <param name="yoffset">Scroll offset along the y-axis.</param>
public delegate void OnScrollCallback(double xoffset, double yoffset);

#endregion

#region Window delegates

/// <summary>
/// Delegate invoked when the window is requested to close.
/// </summary>
public delegate void OnWindowCloseCallback();

/// <summary>
/// Delegate invoked when the window content scale changes (e.g., DPI change).
/// </summary>
/// <param name="xscale">New content scale along the x-axis.</param>
/// <param name="yscale">New content scale along the y-axis.</param>
public delegate void OnWindowContentScaleCallback(float xscale, float yscale);

/// <summary>
/// Delegate invoked when the window gains or loses focus.
/// </summary>
/// <param name="focused">True if window gained focus, false if lost.</param>
public delegate void OnWindowFocusCallback(bool focused);

/// <summary>
/// Delegate invoked when the window is iconified (minimized) or restored.
/// </summary>
/// <param name="iconified">True if window is iconified, false if restored.</param>
public delegate void OnWindowIconifyCallback(bool iconified);

/// <summary>
/// Delegate invoked when the window is maximized or restored.
/// </summary>
/// <param name="maximized">True if window is maximized, false if restored.</param>
public delegate void OnWindowMaximizeCallback(bool maximized);

/// <summary>
/// Delegate invoked when the window position changes.
/// </summary>
/// <param name="args">Event arguments containing the new position.</param>
public delegate void OnSetPosCallback(SetPosEventArgs args);

/// <summary>
/// Delegate invoked when the window needs to refresh its contents.
/// </summary>
public delegate void OnWindowRefreshCallback();

/// <summary>
/// Delegate invoked when the window is resized.
/// </summary>
/// <param name="args">Event arguments containing the new size.</param>
public delegate void OnResizeCallback(ResizeEventArgs args);

/// <summary>
/// Delegate invoked when the framebuffer size changes.
/// </summary>
/// <param name="width">New framebuffer width in pixels.</param>
/// <param name="height">New framebuffer height in pixels.</param>
public delegate void OnFrameBufferSizeCallback(int width, int height);

#endregion

#region System delegates

/// <summary>
/// Delegate invoked on GLFW errors.
/// </summary>
/// <param name="errorCode">The GLFW error code.</param>
/// <param name="reason">Description of the error.</param>
public delegate void OnGLFWErrorCallback(int errorCode, string reason);

/// <summary>
/// Delegate invoked when a joystick event occurs.
/// </summary>
/// <param name="jid">Joystick ID.</param>
/// <param name="eventid">Event ID indicating the type of joystick event.</param>
public delegate void OnJoystickCallback(int jid, int eventid);

/// <summary>
/// Delegate invoked when a monitor event occurs.
/// </summary>
/// <param name="evnt">The monitor event code.</param>
public delegate void OnMonitorCallback(int evnt);

#endregion