using C.ImGuiGLFW.Data;
using CefSharp;
using CefSharp.Handler;
using CefSharp.Internals;
using CefSharp.OffScreen;
using CefSharp.Web;
using Hexa.NET.GLFW;
using Hexa.NET.Mathematics;
using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.ImGuiMethods.Web;

/// <summary>
/// Provides an ImGui-integrated web browser control using Chromium Embedded Framework (CEF)
/// with support for input handling, smooth scrolling, and focus management.
/// </summary>
/// <remarks>
/// This partial class implements a complete web browser widget that can be embedded within ImGui interfaces.
/// It handles all aspects of browser integration including input events (mouse, keyboard, scroll),
/// focus management, rendering through a render handler, and provides smooth scrolling capabilities.
/// The class automatically manages CEF initialization, browser lifecycle, and integrates with ImGui's
/// event system for seamless user interaction. It supports both URL-based and HTML string initialization.
/// </remarks>
public partial class WebView : IRenderWebBrowser, IDisposable
{
    private readonly ChromiumWebBrowser browser;
    private readonly RenderHandlerBase renderHandler;
    private IBrowserHost? host;
    private Point2 size;
    private Point2 position;
    private CefEventFlags eventFlags;

    private float wheelDeltaAccumulatorX = 0f;
    private float wheelDeltaAccumulatorY = 0f;
    private Point2 scrollScale = new(120);

    private bool smoothScroll = false;
    private Point2 scrollPosition;
    private float scrollSpeed = 120f * 40;

    private bool isHovered;
    private bool hasFocus;
    private uint windowId;

    private bool disposedValue;

    /// <summary>
    /// Initializes a new instance of the WebView class with default settings.
    /// </summary>
    /// <remarks>
    /// This constructor creates a WebView without an initial URL, resulting in a blank browser.
    /// The browser can be navigated programmatically after creation. CEF initialization,
    /// default browser settings, and render handler creation are handled automatically.
    /// </remarks>
    public WebView() : this(address: null) { }

    /// <summary>
    /// Initializes a new instance of the WebView class with the specified configuration.
    /// </summary>
    /// <param name="address">The initial URL to navigate to, or null for a blank browser.</param>
    /// <param name="settings">Browser settings to use, or null to use default settings.</param>
    /// <param name="requestContext">The request context for the browser, or null to use the global context.</param>
    /// <param name="renderHandler">Custom render handler, or null to use the default OpenGL renderer.</param>
    /// <remarks>
    /// This constructor provides full control over browser initialization. It ensures CEF is initialized,
    /// creates necessary handlers for browser lifecycle events, and sets up input event processing.
    /// The browser will automatically navigate to the specified address if provided. Default settings
    /// are optimized for ImGui integration with appropriate frame rates and feature enablement.
    /// </remarks>
    public WebView(string? address = null, BrowserSettings? settings = null, IRequestContext? requestContext = null, RenderHandlerBase? renderHandler = null)
    {
        CefManager.Initialize();

        this.renderHandler = renderHandler ??= CefManager.CreateRenderer();

        var refreshRate = Display.GetDesktopRefreshRate(0);

        settings ??= CefManager.GetDefaultBrowserSettings();

        browser = new(address, settings, requestContext)
        {
            RenderHandler = renderHandler,
            LifeSpanHandler = new LifeSpanHandler(),
            LoadHandler = new LoadHandler(),
            DisplayHandler = new DisplayHandler(),
            AudioHandler = new AudioHandler(),
        };

        OnCreateBrowser(browser);

        browser.BrowserInitialized += OnBrowserInitialized;

        RegisterCallbacks();
    }

    /// <summary>
    /// Initializes a new instance of the WebView class with HTML content.
    /// </summary>
    /// <param name="htmlString">The HTML content to display in the browser.</param>
    /// <param name="settings">Browser settings to use, or null to use default settings.</param>
    /// <param name="requestContext">The request context for the browser, or null to use the global context.</param>
    /// <param name="renderHandler">Custom render handler, or null to use the default OpenGL renderer.</param>
    /// <remarks>
    /// This constructor creates a browser that displays the provided HTML content directly
    /// instead of loading from a URL. This is useful for displaying dynamic HTML content
    /// or embedding HTML-based UI elements. The HTML is processed immediately and supports
    /// all standard web technologies including CSS, JavaScript, and external resource loading.
    /// </remarks>
    public WebView(HtmlString htmlString, BrowserSettings? settings = null, IRequestContext? requestContext = null, RenderHandlerBase? renderHandler = null)
    {
        CefManager.Initialize();

        this.renderHandler = renderHandler ??= CefManager.CreateRenderer();

        var refreshRate = Display.GetDesktopRefreshRate(0);

        settings ??= CefManager.GetDefaultBrowserSettings();

        browser = new(htmlString, settings, requestContext)
        {
            RenderHandler = renderHandler,
            LifeSpanHandler = new LifeSpanHandler(),
            LoadHandler = new LoadHandler(),
            DisplayHandler = new DisplayHandler(),
            AudioHandler = new AudioHandler(),
        };

        OnCreateBrowser(browser);

        browser.BrowserInitialized += OnBrowserInitialized;

        RegisterCallbacks();
    }

    /// <summary>
    /// Gets the underlying ChromiumWebBrowser instance.
    /// </summary>
    /// <remarks>
    /// This property provides access to the underlying CEF browser instance for advanced operations
    /// such as navigation, JavaScript execution, or accessing browser-specific functionality.
    /// Direct manipulation of the browser should be done carefully to avoid interfering with
    /// the WebView's input handling and rendering integration.
    /// </remarks>
    public ChromiumWebBrowser Browser => browser;

    /// <summary>
    /// Gets or sets the scroll speed for smooth scrolling operations.
    /// </summary>
    /// <remarks>
    /// This property controls how fast smooth scrolling animations occur when enabled.
    /// The value represents scroll units per second. Higher values result in faster scrolling.
    /// This setting only affects smooth scrolling mode; immediate scrolling uses the
    /// raw scroll wheel delta values. Default value is optimized for typical desktop usage.
    /// </remarks>
    public float ScrollSpeed { get => scrollSpeed; set => scrollSpeed = value; }

    /// <summary>
    /// Gets or sets a value indicating whether smooth scrolling is enabled.
    /// </summary>
    /// <remarks>
    /// When enabled, scroll wheel input is accumulated and smoothly animated over time
    /// instead of being immediately applied to the browser. This provides a more polished
    /// user experience but introduces slight input latency. When disabled, scroll events
    /// are immediately sent to the browser for responsive but potentially jerky scrolling.
    /// </remarks>
    public bool SmoothScroll { get => smoothScroll; set => smoothScroll = value; }

    /// <summary>
    /// Gets or sets the scaling factor applied to scroll wheel input.
    /// </summary>
    /// <remarks>
    /// This property controls how scroll wheel movement is translated to browser scroll events.
    /// The X component affects horizontal scrolling, and the Y component affects vertical scrolling.
    /// Values greater than 1 amplify scroll sensitivity, while values less than 1 reduce it.
    /// Default values are optimized for standard mouse wheel behavior.
    /// </remarks>
    public Point2 ScrollScale { get => scrollScale; set => scrollScale = value; }

    /// <summary>
    /// Gets or sets the size of the browser viewport in pixels.
    /// </summary>
    /// <remarks>
    /// Changing this property triggers browser resize operations and invalidates the view
    /// to ensure proper rendering at the new dimensions. The size affects both the browser's
    /// internal viewport and the ImGui rendering area. Layout and content may reflow when
    /// the size changes, similar to resizing a regular browser window.
    /// </remarks>
    public Point2 Size
    {
        get => size;
        set
        {
            size = value;
            renderHandler.SetSize(value.X, value.Y);

            host?.WasResized();

            host?.Invalidate(PaintElementType.View);
        }
    }

    /// <summary>
    /// Called when the browser has completed initialization and is ready for use.
    /// </summary>
    /// <param name="sender">The browser instance that was initialized.</param>
    /// <param name="e">Event arguments.</param>
    /// <remarks>
    /// This virtual method is invoked when the underlying CEF browser completes its
    /// initialization process. At this point, the browser host is available and ready
    /// for operations such as navigation, input handling, and rendering. Override this
    /// method to perform custom initialization logic that depends on a fully initialized browser.
    /// </remarks>
    protected virtual void OnBrowserInitialized(object? sender, EventArgs e)
    {
        browser.BrowserInitialized -= OnBrowserInitialized;
        host = browser.GetBrowserHost();
    }

    /// <summary>
    /// Called during browser creation to allow custom configuration.
    /// </summary>
    /// <param name="browser">The browser instance being created.</param>
    /// <remarks>
    /// This virtual method is called immediately after browser creation but before
    /// initialization. It provides an opportunity to configure additional browser
    /// properties, attach custom handlers, or perform setup that should occur
    /// before the browser becomes active. Override this method for advanced
    /// browser customization scenarios.
    /// </remarks>
    protected virtual void OnCreateBrowser(ChromiumWebBrowser browser) { }

    /// <summary>
    /// Called when the browser loses focus.
    /// </summary>
    /// <remarks>
    /// This virtual method handles focus loss events by updating internal focus state
    /// and notifying the browser host. When focus is lost, the browser stops receiving
    /// keyboard input and may change visual appearance (such as hiding the text cursor).
    /// Override this method to implement custom focus loss handling or UI updates.
    /// </remarks>
    protected virtual void OnFocusLost()
    {
        hasFocus = false;
        host?.SendFocusEvent(false);
    }

    /// <summary>
    /// Called when the browser gains focus.
    /// </summary>
    /// <remarks>
    /// This virtual method handles focus gain events by updating internal focus state,
    /// notifying the browser host, and setting ImGui keyboard focus. When focused,
    /// the browser begins receiving keyboard input and may show active visual elements
    /// like text cursors. Override this method to implement custom focus handling or
    /// UI state changes.
    /// </remarks>
    protected virtual void OnFocusGained()
    {
        hasFocus = true;
        host?.SendFocusEvent(true);
        ImGui.SetKeyboardFocusHere();
    }

    /// <summary>
    /// Called when the mouse cursor leaves the browser area.
    /// </summary>
    /// <remarks>
    /// This virtual method handles mouse leave events by updating hover state and
    /// sending a mouse move event to the browser with the leave flag set. This allows
    /// the browser to properly handle hover state changes, tooltip hiding, and
    /// cursor restoration. Override this method to implement custom mouse leave handling.
    /// </remarks>
    protected virtual void OnLeave()
    {
        isHovered = false;
        var pos = GetMousePos();
        host?.SendMouseMoveEvent(new(pos.X, pos.Y, eventFlags), true);
    }

    /// <summary>
    /// Called when the mouse cursor enters the browser area.
    /// </summary>
    /// <remarks>
    /// This virtual method handles mouse enter events by updating the internal hover state.
    /// When the mouse enters the browser area, hover effects, tooltips, and interactive
    /// elements become available. Override this method to implement custom mouse enter
    /// handling or UI feedback.
    /// </remarks>
    protected virtual void OnEnter() => isHovered = true;

    private void RegisterCallbacks()
    {
        ImGuiController.OnCursorPos += HandleMouseMove;
        ImGuiController.OnScroll += HandleMouseWheel;
        ImGuiController.OnMouseButton += HandleMouseButton;
        ImGuiController.OnKey += HandleKeyboard;
        ImGuiController.OnChar += HandleTextInput;
        ImGuiController.OnDrop += HandleDragDrop;
    }

    private void UnRegisterCallbacks()
    {
        ImGuiController.OnCursorPos -= HandleMouseMove;
        ImGuiController.OnScroll -= HandleMouseWheel;
        ImGuiController.OnMouseButton -= HandleMouseButton;
        ImGuiController.OnKey -= HandleKeyboard;
        ImGuiController.OnChar -= HandleTextInput;
        ImGuiController.OnDrop -= HandleDragDrop;
    }

    private void HandleMouseMove(double xpos, double ypos)
    {
        MouseEvent mouseEvent = new((int)xpos, (int)ypos, eventFlags);
        host!.SendMouseMoveEvent(mouseEvent, mouseLeave: false);
    }

    private void HandleMouseWheel(double xoffset, double yoffset)
    {
        var point = GetMousePos();
        if (smoothScroll)
        {
            wheelDeltaAccumulatorX += (float)xoffset * scrollScale.X;
            wheelDeltaAccumulatorY += (float)yoffset * scrollScale.Y;
            scrollPosition = new(point.X, point.Y);
        }
        else
        {
            MouseEvent mouseEvent = new(point.X, point.Y, eventFlags);
            host!.SendMouseWheelEvent(mouseEvent, (int)(xoffset * scrollScale.X), (int)(yoffset * scrollScale.Y));
        }
    }

    private void HandleMouseButton(GlfwMouse button, InputState state, GlfwMod mods)
    {
        var pos = GetMousePos();
        MouseEvent mouseEvent = new(pos.X, pos.Y, CefEventFlags.None);
        MouseButtonType type = button switch
        {
            GlfwMouse.ButtonLeft => MouseButtonType.Left,
            GlfwMouse.ButtonRight => MouseButtonType.Right,
            GlfwMouse.ButtonMiddle => MouseButtonType.Middle,
            _ => 0
        };

        bool isUp = state == InputState.Released;
        if (isUp)
        {
            if (type == MouseButtonType.Left)
            {
                eventFlags &= ~CefEventFlags.LeftMouseButton;
            }

            if (type == MouseButtonType.Right)
            {
                eventFlags &= ~CefEventFlags.RightMouseButton;
            }

            if (type == MouseButtonType.Middle)
            {
                eventFlags &= ~CefEventFlags.MiddleMouseButton;
            }
        }
        else
        {
            if (type == MouseButtonType.Left)
            {
                eventFlags |= CefEventFlags.LeftMouseButton;
            }

            if (type == MouseButtonType.Right)
            {
                eventFlags |= CefEventFlags.RightMouseButton;
            }

            if (type == MouseButtonType.Middle)
            {
                eventFlags |= CefEventFlags.MiddleMouseButton;
            }
        }

        host!.SendMouseClickEvent(mouseEvent, type, isUp, 1);
    }

    private void HandleKeyboard(GlfwKey key, int scancode, InputState state, GlfwMod mods)
    {
        GetCefModifiers(mods);
        var flags = eventFlags;

        if (state == InputState.Repeat)
        {
            flags |= CefEventFlags.IsRepeat;
        }

        KeyEvent keyEvent = new()
        {
            Type = state == InputState.Pressed ? KeyEventType.KeyDown : KeyEventType.KeyUp,
            NativeKeyCode = scancode,
            WindowsKeyCode = (int)CefHelper.MapKeyCodeToVirtualKey(key),
            IsSystemKey = false,
            Modifiers = flags,
        };

        host!.SendKeyEvent(keyEvent);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void HandleTextInput(uint codepoint) => SendCharEvent((int)codepoint);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void HandleDragDrop(int pathCount, List<string> filePaths) { }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void GetCefModifiers(GlfwMod mods)
    {
        if (mods.HasFlag(GlfwMod.Shift))
        {
            eventFlags |= CefEventFlags.ShiftDown;
        }
        else
        {
            eventFlags &= ~CefEventFlags.ShiftDown;
        }

        if (mods.HasFlag(GlfwMod.Control))
        {
            eventFlags |= CefEventFlags.ControlDown;
        }
        else
        {
            eventFlags &= ~CefEventFlags.ControlDown;
        }

        if (mods.HasFlag(GlfwMod.Alt))
        {
            eventFlags |= CefEventFlags.AltDown;
        }
        else
        {
            eventFlags &= ~CefEventFlags.AltDown;
        }

        if (mods.HasFlag(GlfwMod.Super))
        {
            eventFlags |= CefEventFlags.CommandDown;
        }
        else
        {
            eventFlags &= ~CefEventFlags.CommandDown;
        }

        if (mods.HasFlag(GlfwMod.CapsLock))
        {
            eventFlags |= CefEventFlags.CapsLockOn;
        }
        else
        {
            eventFlags &= ~CefEventFlags.CapsLockOn;
        }

        if (mods.HasFlag(GlfwMod.NumLock))
        {
            eventFlags |= CefEventFlags.NumLockOn;
        }
        else
        {
            eventFlags &= ~CefEventFlags.NumLockOn;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private unsafe Point2 GetMousePos()
    {
        (double xpos, double ypos) = ImGuiController.GetCursorPos();
        Point2 point = new((int)(xpos - position.X), (int)(ypos - position.Y));
        return point;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SendCharEvent(int utf32Code)
    {
        KeyEvent charEvent = new()
        {
            Type = KeyEventType.Char,
            WindowsKeyCode = utf32Code,
            NativeKeyCode = utf32Code,
            IsSystemKey = false,
            Modifiers = eventFlags
        };

        host!.SendKeyEvent(charEvent);
    }

    /// <summary>
    /// Updates smooth scroll animation progress for the specified wheel delta accumulator.
    /// </summary>
    /// <param name="wheelDeltaAccumulator">The accumulated wheel delta to process.</param>
    /// <remarks>
    /// This virtual method processes accumulated scroll wheel input over time to create
    /// smooth scrolling animations. It calculates the appropriate scroll delta based on
    /// the current frame time and scroll speed, then sends scroll events to the browser.
    /// The accumulator is reduced by the processed amount, allowing for gradual scrolling
    /// over multiple frames. Override this method to customize smooth scrolling behavior.
    /// </remarks>
    protected virtual void UpdateScroll(ref float wheelDeltaAccumulator)
    {
        if (host != null && Math.Abs(wheelDeltaAccumulator) > 0)
        {
            float maxScrollDelta = scrollSpeed * ImGui.GetIO().DeltaTime;
            float scrollDelta = Math.Sign(wheelDeltaAccumulator) * Math.Min(Math.Abs(wheelDeltaAccumulator), Math.Max(maxScrollDelta, 1));
            int intScrollDelta = (int)scrollDelta;
            MouseEvent mouseEvent = new(scrollPosition.X, scrollPosition.Y, eventFlags);
            host.SendMouseWheelEvent(mouseEvent, 0, intScrollDelta);

            wheelDeltaAccumulator -= intScrollDelta;
        }
    }

    /// <summary>
    /// Renders the web browser within an ImGui context using the specified string identifier.
    /// </summary>
    /// <param name="strId">The string identifier for ImGui item identification.</param>
    /// <remarks>
    /// This method handles the complete rendering pipeline for the web browser within ImGui.
    /// It processes smooth scrolling, updates position tracking, manages hover and focus states,
    /// handles input event routing, and renders the browser content. The method integrates
    /// with ImGui's item system for proper input handling and provides visual feedback
    /// for user interactions. This is the primary method for displaying the browser in an ImGui interface.
    /// </remarks>
    public unsafe void Draw(string strId)
    {
        byte* pStr0 = null;
        int strSize0 = 0;
        if (strId != null)
        {
            strSize0 = HexaGen.Runtime.Utils.GetByteCountUTF8(strId);
            if (strSize0 > HexaGen.Runtime.Utils.MaxStackallocSize)
            {
                pStr0 = HexaGen.Runtime.Utils.Alloc<byte>(strSize0 + 1);
            }
            else
            {
                byte* pStrStack0 = stackalloc byte[strSize0 + 1];
                pStr0 = pStrStack0;
            }
            HexaGen.Runtime.Utils.EncodeStringUTF8(strId, pStr0, strSize0);
        }

        Draw(pStr0);

        if (strSize0 > HexaGen.Runtime.Utils.MaxStackallocSize)
        {
            HexaGen.Runtime.Utils.Free(pStr0);
        }
    }

    /// <summary>
    /// Renders the web browser within an ImGui context using the specified byte span identifier.
    /// </summary>
    /// <param name="strId">The UTF-8 encoded string identifier as a byte span.</param>
    /// <remarks>
    /// This overload provides efficient rendering for scenarios where the identifier is already
    /// available as UTF-8 encoded bytes, avoiding string conversion overhead. It delegates to
    /// the pointer-based Draw method for actual rendering operations while ensuring proper
    /// memory management of the byte data.
    /// </remarks>
    public unsafe void Draw(ReadOnlySpan<byte> strId)
    {
        fixed (byte* pStrId = strId)
        {
            Draw(pStrId);
        }
    }

    /// <summary>
    /// Renders the web browser within an ImGui context using the specified byte pointer identifier.
    /// </summary>
    /// <param name="strId">Pointer to a null-terminated UTF-8 string identifier.</param>
    /// <remarks>
    /// This unsafe method performs the core rendering logic for the web browser within ImGui.
    /// It handles smooth scrolling updates, position change detection, bounding box calculation,
    /// hover and focus state management, input event ownership, and delegates actual content
    /// rendering to the render handler. This method should be called once per frame when
    /// the browser should be visible in the ImGui interface.
    /// </remarks>
    public unsafe void Draw(byte* strId)
    {
        var window = ImGuiP.GetCurrentWindow();
        if (window.SkipItems)
        {
            return;
        }

        uint id = ImGui.GetID(strId);

        UpdateScroll(ref wheelDeltaAccumulatorX);
        UpdateScroll(ref wheelDeltaAccumulatorY);

        Point2 newPos = (Point2)ImGui.GetCursorScreenPos();

        if (newPos != position)
        {
            host?.NotifyMoveOrResizeStarted();
        }

        position = newPos;
        ImRect bb = new(position, position + size);
        ImGuiP.ItemSize(bb);

        if (!ImGuiP.ItemAdd(bb, id, ref bb, 0))
        {
            return;
        }

        bool hovered = ImGuiP.ItemHoverable(bb, id, ImGuiItemFlags.None);

        bool focused = ImGui.IsItemFocused();

        bool clicked = hovered && ImGui.IsMouseClicked(ImGuiMouseButton.Left);

        var viewport = ImGui.GetWindowViewport();

        windowId = (uint)viewport.PlatformHandle;

        if (isHovered != hovered)
        {
            if (hovered)
            {
                OnEnter();
            }
            else
            {
                OnLeave();
            }
        }

        if (clicked && !hasFocus)
        {
            OnFocusGained();
        }

        if (!focused && hasFocus)
        {
            OnFocusLost();
        }

        if (hovered)
        {
            ImGui.SetItemKeyOwner(ImGuiKey.MouseWheelY);
            ImGui.SetItemKeyOwner(ImGuiKey.MouseWheelX);
            ImGui.SetItemKeyOwner(ImGuiKey.Tab);
            ImGui.SetItemKeyOwner(ImGuiKey.UpArrow);
            ImGui.SetItemKeyOwner(ImGuiKey.DownArrow);
            ImGui.SetItemKeyOwner(ImGuiKey.LeftArrow);
            ImGui.SetItemKeyOwner(ImGuiKey.RightArrow);
        }

        var draw = ImGui.GetWindowDrawList();

        renderHandler.Draw(draw, bb, hovered);
    }

    /// <summary>
    /// Performs cleanup of browser resources and event handlers.
    /// </summary>
    /// <remarks>
    /// This virtual method unregisters all input event handlers and disposes of the browser
    /// instance to free resources. It ensures proper cleanup of the CEF browser and prevents
    /// memory leaks or dangling event handlers. Override this method to perform additional
    /// cleanup operations specific to derived classes while ensuring the base cleanup is called.
    /// </remarks>
    protected virtual void DisposeCore()
    {
        UnRegisterCallbacks();
        browser.Dispose();
    }

    /// <summary>
    /// Releases all resources used by the WebView.
    /// </summary>
    /// <remarks>
    /// This method implements the IDisposable pattern and ensures that DisposeCore is called
    /// only once. It handles proper cleanup of the browser, event handlers, and related resources.
    /// After disposal, the WebView should not be used for any operations. The method also
    /// suppresses finalization since all cleanup is handled explicitly.
    /// </remarks>
    public void Dispose()
    {
        if (!disposedValue)
        {
            DisposeCore();
            disposedValue = true;
        }

        GC.SuppressFinalize(this);
    }
}
