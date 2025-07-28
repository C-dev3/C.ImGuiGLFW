namespace C.ImGuiGLFW.Events;


// Frame delegates
public delegate void UpdateFrameCallback();
public delegate void RenderFrameCallback(double deltaTime);
public delegate void OnMainMenuBarRenderCallback();

// Input delegates
public delegate void OnCharCallback(uint codepoint);
public delegate void OnCharModsCallback(uint codepoint, int mods);
public delegate void OnCursorEnterCallback(bool entered);
public delegate void OnCursorPosCallback(double xpos, double ypos);
public delegate void OnDropCallback(int pathCount, List<string> filePaths);
public delegate void OnKeyCallback(int key, int scancode, int action, int mods);
public delegate void OnMouseButtonCallback(int button, int action, int mods);
public delegate void OnScrollCallback(double xoffset, double yoffset);

// Window delegates
public delegate void OnWindowCloseCallback();
public delegate void OnWindowContentScaleCallback(float xscale, float yscale);
public delegate void OnWindowFocusCallback(bool focused);
public delegate void OnWindowIconifyCallback(bool iconified);
public delegate void OnWindowMaximizeCallback(bool maximized);
public delegate void OnSetPosCallback(SetPosEventArgs args);
public delegate void OnWindowRefreshCallback();
public delegate void OnResizeCallback(ResizeEventArgs args);
public delegate void OnFrameBufferSizeCallback(int width, int height);

// System delegates
public delegate void OnGLFWErrorCallback(int errorCode, string reason);
public delegate void OnJoystickCallback(int jid, int eventid);
public delegate void OnMonitorCallback(int evnt);