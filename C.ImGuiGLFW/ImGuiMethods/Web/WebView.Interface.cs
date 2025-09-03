using CefSharp;
using CefSharp.Enums;
using CefSharp.Internals;
using CefSharp.Structs;

namespace C.ImGuiGLFW.ImGuiMethods.Web;

public partial class WebView
{
    /// <summary>
    /// Occurs when the browser outputs a console message.
    /// </summary>
    /// <remarks>
    /// This event is triggered when JavaScript code running in the browser writes to the console
    /// using methods like console.log(), console.error(), or console.warn().
    /// The event provides access to the console message content, source, and severity level.
    /// </remarks>
    public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage
    {
        add => browser.ConsoleMessage += value;
        remove => browser.ConsoleMessage -= value;
    }

    /// <summary>
    /// Occurs when the browser status message changes.
    /// </summary>
    /// <remarks>
    /// This event is typically triggered when hovering over links or during page loading operations.
    /// The status message usually contains information like link URLs or loading progress.
    /// </remarks>
    public event EventHandler<StatusMessageEventArgs> StatusMessage
    {
        add => browser.StatusMessage += value;
        remove => browser.StatusMessage -= value;
    }

    /// <summary>
    /// Occurs when a frame begins loading content.
    /// </summary>
    /// <remarks>
    /// This event is fired at the start of the loading process for each frame in the browser.
    /// It can be used to track loading progress or perform initialization tasks when navigation begins.
    /// </remarks>
    public event EventHandler<FrameLoadStartEventArgs> FrameLoadStart
    {
        add => browser.FrameLoadStart += value;
        remove => browser.FrameLoadStart -= value;
    }

    /// <summary>
    /// Occurs when a frame completes loading content.
    /// </summary>
    /// <remarks>
    /// This event is fired when a frame has finished loading all content, including sub-resources.
    /// It indicates that the frame is ready for interaction and JavaScript execution.
    /// </remarks>
    public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd
    {
        add => browser.FrameLoadEnd += value;
        remove => browser.FrameLoadEnd -= value;
    }

    /// <summary>
    /// Occurs when an error is encountered during page loading.
    /// </summary>
    /// <remarks>
    /// This event provides information about loading errors such as network failures,
    /// invalid URLs, or server errors. It can be used to implement custom error handling
    /// or display user-friendly error messages.
    /// </remarks>
    public event EventHandler<LoadErrorEventArgs> LoadError
    {
        add => browser.LoadError += value;
        remove => browser.LoadError -= value;
    }

    /// <summary>
    /// Occurs when the loading state of the browser changes.
    /// </summary>
    /// <remarks>
    /// This event is triggered when the browser transitions between loading and idle states.
    /// It provides information about whether the browser is currently loading content,
    /// can navigate back or forward, and other state-related properties.
    /// </remarks>
    public event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged
    {
        add => browser.LoadingStateChanged += value;
        remove => browser.LoadingStateChanged -= value;
    }

    /// <summary>
    /// Occurs when a JavaScript message is received from the web page.
    /// </summary>
    /// <remarks>
    /// This event enables communication between the web page's JavaScript code and the host application.
    /// JavaScript code can send messages using the CefSharp binding mechanism, which are then
    /// received through this event handler.
    /// </remarks>
    public event EventHandler<JavascriptMessageReceivedEventArgs> JavascriptMessageReceived
    {
        add
        {
            ((IWebBrowser)browser).JavascriptMessageReceived += value;
        }

        remove
        {
            ((IWebBrowser)browser).JavascriptMessageReceived -= value;
        }
    }


    /// <summary>
    /// A flag that indicates whether the WebBrowser is initialized (true) or not (false).
    /// </summary>
    /// <value><c>true</c> if this instance is browser initialized; otherwise, <c>false</c>.</value>
    public bool IsBrowserInitialized => browser.IsBrowserInitialized;

    /// <summary>
    /// Gets a value indicating whether this instance is disposed.
    /// </summary>
    /// <value><see langword="true" /> if this instance is disposed; otherwise, <see langword="false" />.</value>
    public bool IsDisposed => browser.IsDisposed;

    /// <summary>
    /// A flag that indicates whether the control is currently loading one or more web pages (true) or not (false).
    /// </summary>
    /// <value><c>true</c> if this instance is loading; otherwise, <c>false</c>.</value>
    /// <remarks>In the WPF control, this property is implemented as a Dependency Property and fully supports data
    /// binding.</remarks>
    public bool IsLoading => browser.IsLoading;

    /// <summary>
    /// A flag that indicates whether the state of the control current supports the GoBack action (true) or not (false).
    /// </summary>
    /// <value><c>true</c> if this instance can go back; otherwise, <c>false</c>.</value>
    /// <remarks>In the WPF control, this property is implemented as a Dependency Property and fully supports data
    /// binding.</remarks>
    public bool CanGoBack => browser.CanGoBack;

    /// <summary>
    /// A flag that indicates whether the state of the control currently supports the GoForward action (true) or not (false).
    /// </summary>
    /// <value><c>true</c> if this instance can go forward; otherwise, <c>false</c>.</value>
    /// <remarks>In the WPF control, this property is implemented as a Dependency Property and fully supports data
    /// binding.</remarks>
    public bool CanGoForward => browser.CanGoForward;

    /// <summary>
    /// The address (URL) which the browser control is currently displaying.
    /// Will automatically be updated as the user navigates to another page (e.g. by clicking on a link).
    /// </summary>
    /// <value>The address.</value>
    /// <remarks>In the WPF control, this property is implemented as a Dependency Property and fully supports data
    /// binding.</remarks>
    public string Address => browser.Address;

    /// <summary>
    /// Get access to the core <see cref="IBrowser"/> instance.
    /// Maybe null if the underlying CEF Browser has not yet been
    /// created or if this control has been disposed. Check
    /// <see cref="IBrowser.IsDisposed"/> before accessing.
    /// </summary>
    public IBrowser BrowserCore => browser.BrowserCore;

    /// <summary>
    /// Gets the accessibility handler for the browser control.
    /// </summary>
    /// <value>The <see cref="IAccessibilityHandler"/> implementation, or <c>null</c> if not set.</value>
    /// <remarks>
    /// The accessibility handler provides support for assistive technologies and screen readers.
    /// Setting this property enables accessibility features for the web content.
    /// </remarks>
    public IAccessibilityHandler AccessibilityHandler { get => ((IRenderWebBrowser)browser).AccessibilityHandler; set => ((IRenderWebBrowser)browser).AccessibilityHandler = value; }

    /// <summary>
    /// Gets the browser adapter used for low-level browser operations.
    /// </summary>
    /// <value>The <see cref="IBrowserAdapter"/> instance associated with this browser.</value>
    /// <remarks>
    /// The browser adapter provides access to internal browser functionality and is typically
    /// used by the CefSharp framework itself rather than application code.
    /// </remarks>
    public IBrowserAdapter BrowserAdapter => ((IWebBrowserInternal)browser).BrowserAdapter;

    /// <summary>
    /// Gets or sets a value indicating whether this browser has a parent window.
    /// </summary>
    /// <value><c>true</c> if the browser has a parent; otherwise, <c>false</c>.</value>
    /// <remarks>
    /// This property affects how the browser handles certain operations like focus management
    /// and window positioning. It is typically managed internally by the framework.
    /// </remarks>
    public bool HasParent { get => ((IWebBrowserInternal)browser).HasParent; set => ((IWebBrowserInternal)browser).HasParent = value; }

    /// <summary>
    /// Gets or sets the DevTools context for debugging functionality.
    /// </summary>
    /// <value>An <see cref="IDisposable"/> representing the DevTools context, or <c>null</c> if not active.</value>
    /// <remarks>
    /// This property manages the lifetime of developer tools windows and debugging sessions.
    /// When set, it should be properly disposed to clean up debugging resources.
    /// </remarks>
    public IDisposable DevToolsContext { get => ((IWebBrowserInternal)browser).DevToolsContext; set => ((IWebBrowserInternal)browser).DevToolsContext = value; }

    /// <summary>
    /// Gets the JavaScript object repository for managing bound objects.
    /// </summary>
    /// <value>The <see cref="IJavascriptObjectRepository"/> instance for this browser.</value>
    /// <remarks>
    /// The repository manages JavaScript objects that have been bound to the browser context,
    /// enabling communication between .NET code and JavaScript running in the web page.
    /// </remarks>
    public IJavascriptObjectRepository JavascriptObjectRepository => ((IWebBrowser)browser).JavascriptObjectRepository;

    /// <summary>
    /// Gets or sets the dialog handler for managing browser dialogs.
    /// </summary>
    /// <value>The <see cref="IDialogHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The dialog handler allows customization of browser dialogs such as JavaScript alerts,
    /// confirms, prompts, and file selection dialogs.
    /// </remarks>
    public IDialogHandler DialogHandler { get => ((IWebBrowser)browser).DialogHandler; set => ((IWebBrowser)browser).DialogHandler = value; }

    /// <summary>
    /// Gets or sets the request handler for managing network requests.
    /// </summary>
    /// <value>The <see cref="IRequestHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The request handler enables interception and modification of network requests,
    /// including the ability to block requests, modify headers, or provide custom responses.
    /// </remarks>
    public IRequestHandler RequestHandler { get => ((IWebBrowser)browser).RequestHandler; set => ((IWebBrowser)browser).RequestHandler = value; }

    /// <summary>
    /// Gets or sets the display handler for managing browser display events.
    /// </summary>
    /// <value>The <see cref="IDisplayHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The display handler manages events related to browser display changes such as
    /// address changes, title updates, favicon changes, and status messages.
    /// </remarks>
    public IDisplayHandler DisplayHandler { get => ((IWebBrowser)browser).DisplayHandler; set => ((IWebBrowser)browser).DisplayHandler = value; }

    /// <summary>
    /// Gets or sets the load handler for managing page loading events.
    /// </summary>
    /// <value>The <see cref="ILoadHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The load handler provides fine-grained control over page loading events,
    /// including load start, load end, and error handling for individual frames.
    /// </remarks>
    public ILoadHandler LoadHandler { get => ((IWebBrowser)browser).LoadHandler; set => ((IWebBrowser)browser).LoadHandler = value; }

    /// <summary>
    /// Gets or sets the life span handler for managing browser window lifecycle.
    /// </summary>
    /// <value>The <see cref="ILifeSpanHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The life span handler controls browser window creation, destruction, and popup handling.
    /// It allows customization of how new windows are created and managed.
    /// </remarks>
    public ILifeSpanHandler LifeSpanHandler { get => ((IWebBrowser)browser).LifeSpanHandler; set => ((IWebBrowser)browser).LifeSpanHandler = value; }

    /// <summary>
    /// Gets or sets the keyboard handler for managing keyboard input.
    /// </summary>
    /// <value>The <see cref="IKeyboardHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The keyboard handler enables interception and customization of keyboard input,
    /// including the ability to handle specific key combinations or override default browser shortcuts.
    /// </remarks>
    public IKeyboardHandler KeyboardHandler { get => ((IWebBrowser)browser).KeyboardHandler; set => ((IWebBrowser)browser).KeyboardHandler = value; }

    /// <summary>
    /// Gets or sets the JavaScript dialog handler for managing JavaScript dialogs.
    /// </summary>
    /// <value>The <see cref="IJsDialogHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The JavaScript dialog handler manages dialogs created by JavaScript code such as
    /// alert(), confirm(), and prompt() functions, as well as beforeunload dialogs.
    /// </remarks>
    public IJsDialogHandler JsDialogHandler { get => ((IWebBrowser)browser).JsDialogHandler; set => ((IWebBrowser)browser).JsDialogHandler = value; }

    /// <summary>
    /// Gets or sets the drag handler for managing drag and drop operations.
    /// </summary>
    /// <value>The <see cref="IDragHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The drag handler controls drag and drop behavior within the browser and between
    /// the browser and external applications.
    /// </remarks>
    public IDragHandler DragHandler { get => ((IWebBrowser)browser).DragHandler; set => ((IWebBrowser)browser).DragHandler = value; }

    /// <summary>
    /// Gets or sets the download handler for managing file downloads.
    /// </summary>
    /// <value>The <see cref="IDownloadHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The download handler enables customization of download behavior, including
    /// the ability to intercept downloads, change download locations, or provide custom download UI.
    /// </remarks>
    public IDownloadHandler DownloadHandler { get => ((IWebBrowser)browser).DownloadHandler; set => ((IWebBrowser)browser).DownloadHandler = value; }

    /// <summary>
    /// Gets or sets the context menu handler for managing right-click menus.
    /// </summary>
    /// <value>The <see cref="IContextMenuHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The menu handler allows customization of context menus that appear when right-clicking
    /// in the browser, including adding custom menu items or modifying existing ones.
    /// </remarks>
    public IContextMenuHandler MenuHandler { get => ((IWebBrowser)browser).MenuHandler; set => ((IWebBrowser)browser).MenuHandler = value; }

    /// <summary>
    /// Gets or sets the focus handler for managing focus events.
    /// </summary>
    /// <value>The <see cref="IFocusHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The focus handler manages focus-related events and allows customization of
    /// focus behavior within the browser control.
    /// </remarks>
    public IFocusHandler FocusHandler { get => ((IWebBrowser)browser).FocusHandler; set => ((IWebBrowser)browser).FocusHandler = value; }

    /// <summary>
    /// Gets or sets the resource request handler factory for managing resource requests.
    /// </summary>
    /// <value>The <see cref="IResourceRequestHandlerFactory"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The factory creates resource request handlers for individual requests, enabling
    /// fine-grained control over resource loading, caching, and response handling.
    /// </remarks>
    public IResourceRequestHandlerFactory ResourceRequestHandlerFactory { get => ((IWebBrowser)browser).ResourceRequestHandlerFactory; set => ((IWebBrowser)browser).ResourceRequestHandlerFactory = value; }

    /// <summary>
    /// Gets or sets the render process message handler for inter-process communication.
    /// </summary>
    /// <value>The <see cref="IRenderProcessMessageHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The message handler enables communication between the browser process and render processes,
    /// allowing for advanced scenarios like custom JavaScript extensions.
    /// </remarks>
    public IRenderProcessMessageHandler RenderProcessMessageHandler { get => ((IWebBrowser)browser).RenderProcessMessageHandler; set => ((IWebBrowser)browser).RenderProcessMessageHandler = value; }

    /// <summary>
    /// Gets or sets the find handler for managing text search operations.
    /// </summary>
    /// <value>The <see cref="IFindHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The find handler manages text search functionality within web pages,
    /// including search result highlighting and navigation.
    /// </remarks>
    public IFindHandler FindHandler { get => ((IWebBrowser)browser).FindHandler; set => ((IWebBrowser)browser).FindHandler = value; }

    /// <summary>
    /// Gets or sets the audio handler for managing audio-related events.
    /// </summary>
    /// <value>The <see cref="IAudioHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The audio handler provides control over audio playback and can be used to
    /// implement custom audio policies or notifications.
    /// </remarks>
    public IAudioHandler AudioHandler { get => ((IWebBrowser)browser).AudioHandler; set => ((IWebBrowser)browser).AudioHandler = value; }

    /// <summary>
    /// Gets or sets the frame handler for managing frame-related operations.
    /// </summary>
    /// <value>The <see cref="IFrameHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The frame handler manages frame creation, destruction, and navigation events
    /// for individual frames within the browser.
    /// </remarks>
    public IFrameHandler FrameHandler { get => ((IWebBrowser)browser).FrameHandler; set => ((IWebBrowser)browser).FrameHandler = value; }

    /// <summary>
    /// Gets or sets the permission handler for managing web API permissions.
    /// </summary>
    /// <value>The <see cref="IPermissionHandler"/> implementation, or <c>null</c> to use default handling.</value>
    /// <remarks>
    /// The permission handler manages permission requests for web APIs such as
    /// geolocation, camera, microphone, and notifications.
    /// </remarks>
    public IPermissionHandler PermissionHandler { get => ((IWebBrowser)browser).PermissionHandler; set => ((IWebBrowser)browser).PermissionHandler = value; }

    /// <summary>
    /// Gets the current tooltip text displayed by the browser.
    /// </summary>
    /// <value>The tooltip text as a string, or <c>null</c> if no tooltip is active.</value>
    /// <remarks>
    /// This property reflects the current tooltip content, typically displayed when
    /// hovering over elements with title attributes or interactive content.
    /// </remarks>
    public string TooltipText => ((IWebBrowser)browser).TooltipText;

    /// <summary>
    /// Gets a value indicating whether JavaScript can be executed in the main frame.
    /// </summary>
    /// <value><c>true</c> if JavaScript execution is allowed in the main frame; otherwise, <c>false</c>.</value>
    /// <remarks>
    /// This property indicates the current state of JavaScript execution permissions
    /// for the main frame, which may change based on security policies and page content.
    /// </remarks>
    public bool CanExecuteJavascriptInMainFrame => ((IWebBrowser)browser).CanExecuteJavascriptInMainFrame;

    /// <summary>
    /// Gets the request context associated with this browser instance.
    /// </summary>
    /// <value>The <see cref="IRequestContext"/> for this browser.</value>
    /// <remarks>
    /// The request context manages settings like cookies, cache, and other browser-specific
    /// configuration that applies to requests made by this browser instance.
    /// </remarks>
    public IRequestContext RequestContext => ((IWebBrowser)browser).RequestContext;

    /// <summary>
    /// Loads the specified URL in the browser.
    /// </summary>
    /// <param name="url">The URL to load.</param>
    /// <remarks>
    /// This method initiates navigation to the specified URL. The method returns immediately
    /// while the loading occurs asynchronously. Use the LoadingStateChanged event to monitor progress.
    /// </remarks>
    public void LoadUrl(string url) => browser.LoadUrl(url);

    /// <summary>
    /// Asynchronously loads the specified URL and returns when the operation completes.
    /// </summary>
    /// <param name="url">The URL to load.</param>
    /// <returns>A task that represents the asynchronous load operation, containing load result information.</returns>
    /// <remarks>
    /// This method provides asynchronous loading with completion notification, allowing
    /// the caller to await the result and handle any loading errors that occur.
    /// </remarks>
    public Task<LoadUrlAsyncResponse> LoadUrlAsync(string url) => browser.LoadUrlAsync(url);

    /// <summary>
    /// Asynchronously waits for navigation to complete within the specified timeout.
    /// </summary>
    /// <param name="timeout">The maximum time to wait for navigation completion, or <c>null</c> for no timeout.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the wait operation.</param>
    /// <returns>A task that represents the wait operation, containing navigation result information.</returns>
    /// <remarks>
    /// This method is useful for waiting for navigation completion after programmatic navigation
    /// or for synchronizing with user-initiated navigation events.
    /// </remarks>
    public Task<WaitForNavigationAsyncResponse> WaitForNavigationAsync(TimeSpan? timeout = null, CancellationToken cancellationToken = default) => browser.WaitForNavigationAsync(timeout, cancellationToken);

    /// <summary>
    /// Attempts to set focus to the browser control.
    /// </summary>
    /// <returns><c>false</c> in this implementation, indicating focus was not set.</returns>
    /// <remarks>
    /// This implementation always returns false, suggesting that focus management
    /// should be handled by the parent control or application framework.
    /// </remarks>
    public bool Focus() => false;

    /// <summary>
    /// Gets screen information for the browser's display.
    /// </summary>
    /// <returns>Screen information structure, or <c>null</c> if not available.</returns>
    /// <remarks>
    /// This method provides display-related information such as screen dimensions,
    /// DPI settings, and color depth for proper rendering coordination.
    /// </remarks>
    public ScreenInfo? GetScreenInfo() => ((IRenderWebBrowser)browser).GetScreenInfo();

    /// <summary>
    /// Gets the view rectangle for the browser's rendering area.
    /// </summary>
    /// <returns>A <see cref="Rect"/> representing the browser's view bounds.</returns>
    /// <remarks>
    /// The view rectangle defines the area where browser content is rendered,
    /// typically used for offscreen rendering scenarios.
    /// </remarks>
    public Rect GetViewRect() => ((IRenderWebBrowser)browser).GetViewRect();

    /// <summary>
    /// Converts view coordinates to screen coordinates.
    /// </summary>
    /// <param name="viewX">The X coordinate in view space.</param>
    /// <param name="viewY">The Y coordinate in view space.</param>
    /// <param name="screenX">The resulting X coordinate in screen space.</param>
    /// <param name="screenY">The resulting Y coordinate in screen space.</param>
    /// <returns><c>true</c> if the conversion was successful; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method is used to convert coordinates from the browser's view coordinate system
    /// to screen coordinates, typically for popup positioning or coordinate translation.
    /// </remarks>
    public bool GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY) => ((IRenderWebBrowser)browser).GetScreenPoint(viewX, viewY, out screenX, out screenY);

    /// <summary>
    /// Handles accelerated paint events for GPU-accelerated rendering.
    /// </summary>
    /// <param name="type">The type of element being painted.</param>
    /// <param name="dirtyRect">The area that needs to be repainted.</param>
    /// <param name="acceleratedPaintInfo">Information about the accelerated paint operation.</param>
    /// <remarks>
    /// This method is called when hardware acceleration is available and provides
    /// optimized rendering through GPU resources.
    /// </remarks>
    public void OnAcceleratedPaint(PaintElementType type, Rect dirtyRect, AcceleratedPaintInfo acceleratedPaintInfo) => ((IRenderWebBrowser)browser).OnAcceleratedPaint(type, dirtyRect, acceleratedPaintInfo);

    /// <summary>
    /// Handles paint events for software rendering.
    /// </summary>
    /// <param name="type">The type of element being painted.</param>
    /// <param name="dirtyRect">The area that needs to be repainted.</param>
    /// <param name="buffer">Pointer to the pixel buffer containing the rendered content.</param>
    /// <param name="width">The width of the rendered area in pixels.</param>
    /// <param name="height">The height of the rendered area in pixels.</param>
    /// <remarks>
    /// This method is used for software-based rendering when hardware acceleration
    /// is not available or disabled.
    /// </remarks>
    public void OnPaint(PaintElementType type, Rect dirtyRect, nint buffer, int width, int height) => ((IRenderWebBrowser)browser).OnPaint(type, dirtyRect, buffer, width, height);

    /// <summary>
    /// Handles cursor change events.
    /// </summary>
    /// <param name="cursor">Handle to the system cursor.</param>
    /// <param name="type">The type of cursor being set.</param>
    /// <param name="customCursorInfo">Information about custom cursors, if applicable.</param>
    /// <remarks>
    /// This method is called when the browser wants to change the cursor appearance,
    /// typically in response to hovering over different types of content.
    /// </remarks>
    public void OnCursorChange(nint cursor, CursorType type, CursorInfo customCursorInfo) => ((IRenderWebBrowser)browser).OnCursorChange(cursor, type, customCursorInfo);

    /// <summary>
    /// Initiates a drag operation with the specified data and parameters.
    /// </summary>
    /// <param name="dragData">The data being dragged.</param>
    /// <param name="mask">The allowed drag operations.</param>
    /// <param name="x">The X coordinate where the drag started.</param>
    /// <param name="y">The Y coordinate where the drag started.</param>
    /// <returns><c>true</c> if the drag operation was initiated successfully; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method is called when the user begins dragging content from the browser,
    /// enabling drag-and-drop operations to external targets.
    /// </remarks>
    public bool StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y) => ((IRenderWebBrowser)browser).StartDragging(dragData, mask, x, y);

    /// <summary>
    /// Updates the cursor during drag operations.
    /// </summary>
    /// <param name="operation">The current drag operation being performed.</param>
    /// <remarks>
    /// This method is called during drag operations to update the cursor appearance
    /// based on the current drag state and available drop targets.
    /// </remarks>
    public void UpdateDragCursor(DragOperationsMask operation) => ((IRenderWebBrowser)browser).UpdateDragCursor(operation);

    /// <summary>
    /// Handles popup visibility changes.
    /// </summary>
    /// <param name="show"><c>true</c> to show the popup; <c>false</c> to hide it.</param>
    /// <remarks>
    /// This method is called when popup elements need to be shown or hidden,
    /// such as dropdown menus or tooltip popups.
    /// </remarks>
    public void OnPopupShow(bool show) => ((IRenderWebBrowser)browser).OnPopupShow(show);

    /// <summary>
    /// Handles popup size changes.
    /// </summary>
    /// <param name="rect">The new size and position of the popup.</param>
    /// <remarks>
    /// This method is called when popup elements need to be resized or repositioned,
    /// ensuring proper display of popup content.
    /// </remarks>
    public void OnPopupSize(Rect rect) => ((IRenderWebBrowser)browser).OnPopupSize(rect);

    /// <summary>
    /// Handles IME composition range changes for text input.
    /// </summary>
    /// <param name="selectedRange">The currently selected text range.</param>
    /// <param name="characterBounds">Bounds for individual characters in the composition.</param>
    /// <remarks>
    /// This method supports Input Method Editor (IME) functionality for complex text input,
    /// particularly important for international keyboards and languages.
    /// </remarks>
    public void OnImeCompositionRangeChanged(CefSharp.Structs.Range selectedRange, Rect[] characterBounds) => ((IRenderWebBrowser)browser).OnImeCompositionRangeChanged(selectedRange, characterBounds);

    /// <summary>
    /// Handles virtual keyboard requests for touch interfaces.
    /// </summary>
    /// <param name="browser">The browser instance requesting the virtual keyboard.</param>
    /// <param name="inputMode">The requested input mode for the virtual keyboard.</param>
    /// <remarks>
    /// This method is called when the browser needs to display a virtual keyboard,
    /// typically on touch devices when text input fields are focused.
    /// </remarks>
    public void OnVirtualKeyboardRequested(IBrowser browser, TextInputMode inputMode) => ((IRenderWebBrowser)this.browser).OnVirtualKeyboardRequested(browser, inputMode);

    /// <summary>
    /// Called after the browser instance has been created.
    /// </summary>
    /// <param name="browser">The newly created browser instance.</param>
    /// <remarks>
    /// This method provides an opportunity to perform initialization tasks
    /// once the underlying browser has been fully created and is ready for use.
    /// </remarks>
    public void OnAfterBrowserCreated(IBrowser browser) => ((IWebBrowserInternal)this.browser).OnAfterBrowserCreated(browser);

    /// <summary>
    /// Updates the browser's address display.
    /// </summary>
    /// <param name="args">Event arguments containing the new address information.</param>
    /// <remarks>
    /// This method is called internally to update the displayed address when
    /// navigation occurs or the URL changes.
    /// </remarks>
    public void SetAddress(AddressChangedEventArgs args) => ((IWebBrowserInternal)browser).SetAddress(args);

    /// <summary>
    /// Updates the browser's loading state.
    /// </summary>
    /// <param name="args">Event arguments containing the new loading state information.</param>
    /// <remarks>
    /// This method is called internally to update loading indicators and navigation
    /// button states when the loading state changes.
    /// </remarks>
    public void SetLoadingStateChange(LoadingStateChangedEventArgs args) => ((IWebBrowserInternal)browser).SetLoadingStateChange(args);

    /// <summary>
    /// Updates the browser's title display.
    /// </summary>
    /// <param name="args">Event arguments containing the new title information.</param>
    /// <remarks>
    /// This method is called internally to update the displayed title when
    /// the page title changes, typically from the HTML title element.
    /// </remarks>
    public void SetTitle(TitleChangedEventArgs args) => ((IWebBrowserInternal)browser).SetTitle(args);

    /// <summary>
    /// Updates the browser's tooltip text.
    /// </summary>
    /// <param name="tooltipText">The new tooltip text to display.</param>
    /// <remarks>
    /// This method is called internally to update tooltip display when
    /// hovering over elements with tooltip information.
    /// </remarks>
    public void SetTooltipText(string tooltipText) => ((IWebBrowserInternal)browser).SetTooltipText(tooltipText);

    /// <summary>
    /// Updates JavaScript execution permissions for the main frame.
    /// </summary>
    /// <param name="frameId">The identifier of the frame being updated.</param>
    /// <param name="canExecute"><c>true</c> if JavaScript execution should be allowed; otherwise, <c>false</c>.</param>
    /// <remarks>
    /// This method is called internally to update JavaScript execution permissions
    /// based on security policies and frame context.
    /// </remarks>
    public void SetCanExecuteJavascriptOnMainFrame(string frameId, bool canExecute) => ((IWebBrowserInternal)browser).SetCanExecuteJavascriptOnMainFrame(frameId, canExecute);

    /// <summary>
    /// Processes received JavaScript messages.
    /// </summary>
    /// <param name="args">Event arguments containing the JavaScript message information.</param>
    /// <remarks>
    /// This method is called internally to handle JavaScript messages sent from
    /// web page code to the host application.
    /// </remarks>
    public void SetJavascriptMessageReceived(JavascriptMessageReceivedEventArgs args) => ((IWebBrowserInternal)browser).SetJavascriptMessageReceived(args);

    /// <summary>
    /// Processes frame load start events.
    /// </summary>
    /// <param name="args">Event arguments containing frame load start information.</param>
    /// <remarks>
    /// This method is called internally when a frame begins loading,
    /// triggering the appropriate event handlers and state updates.
    /// </remarks>
    public void OnFrameLoadStart(FrameLoadStartEventArgs args) => ((IWebBrowserInternal)browser).OnFrameLoadStart(args);

    /// <summary>
    /// Processes frame load end events.
    /// </summary>
    /// <param name="args">Event arguments containing frame load end information.</param>
    /// <remarks>
    /// This method is called internally when a frame completes loading,
    /// triggering the appropriate event handlers and state updates.
    /// </remarks>
    public void OnFrameLoadEnd(FrameLoadEndEventArgs args) => ((IWebBrowserInternal)browser).OnFrameLoadEnd(args);

    /// <summary>
    /// Processes console message events.
    /// </summary>
    /// <param name="args">Event arguments containing console message information.</param>
    /// <remarks>
    /// This method is called internally when the browser outputs console messages,
    /// triggering the ConsoleMessage event for application handling.
    /// </remarks>
    public void OnConsoleMessage(ConsoleMessageEventArgs args) => ((IWebBrowserInternal)browser).OnConsoleMessage(args);

    /// <summary>
    /// Processes status message events.
    /// </summary>
    /// <param name="args">Event arguments containing status message information.</param>
    /// <remarks>
    /// This method is called internally when the browser status changes,
    /// triggering the StatusMessage event for application handling.
    /// </remarks>
    public void OnStatusMessage(StatusMessageEventArgs args) => ((IWebBrowserInternal)browser).OnStatusMessage(args);

    /// <summary>
    /// Processes load error events.
    /// </summary>
    /// <param name="args">Event arguments containing load error information.</param>
    /// <remarks>
    /// This method is called internally when loading errors occur,
    /// triggering the LoadError event for application error handling.
    /// </remarks>
    public void OnLoadError(LoadErrorEventArgs args) => ((IWebBrowserInternal)browser).OnLoadError(args);

    /// <summary>
    /// Loads the specified URL using the legacy Load method.
    /// </summary>
    /// <param name="url">The URL to load.</param>
    /// <remarks>
    /// This method provides compatibility with legacy code that uses the Load method name.
    /// It functions identically to LoadUrl for backward compatibility.
    /// </remarks>
    public void Load(string url) => ((IWebBrowser)browser).Load(url);

    /// <summary>
    /// Asynchronously waits for the browser's initial load to complete.
    /// </summary>
    /// <returns>A task that represents the initial load operation, containing load result information.</returns>
    /// <remarks>
    /// This method is useful for ensuring the browser is ready for interaction
    /// after initial creation and setup.
    /// </remarks>
    public Task<LoadUrlAsyncResponse> WaitForInitialLoadAsync() => ((IWebBrowser)browser).WaitForInitialLoadAsync();

    /// <summary>
    /// Gets the underlying browser instance.
    /// </summary>
    /// <returns>The <see cref="IBrowser"/> instance, or <c>null</c> if not available.</returns>
    /// <remarks>
    /// This method provides access to the core browser functionality for advanced scenarios.
    /// Check that the returned value is not null and not disposed before use.
    /// </remarks>
    public IBrowser GetBrowser() => ((IWebBrowser)browser).GetBrowser();

    /// <summary>
    /// Attempts to retrieve a browser instance by its identifier.
    /// </summary>
    /// <param name="browserId">The unique identifier of the browser to retrieve.</param>
    /// <param name="browser">When successful, contains the browser instance; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the browser was found; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method is useful in multi-browser scenarios where multiple browser instances
    /// need to be managed and accessed by their unique identifiers.
    /// </remarks>
    public bool TryGetBrowserCoreById(int browserId, out IBrowser browser) => ((IWebBrowser)this.browser).TryGetBrowserCoreById(browserId, out browser);

    /// <summary>
    /// Asynchronously gets the content size of the currently loaded page.
    /// </summary>
    /// <returns>A task that represents the operation, containing the content size information.</returns>
    /// <remarks>
    /// This method provides the dimensions of the page content, which may differ from
    /// the visible viewport size, especially for pages with scrollable content.
    /// </remarks>
    public Task<DomRect> GetContentSizeAsync() => ((IWebBrowser)browser).GetContentSizeAsync();
}
