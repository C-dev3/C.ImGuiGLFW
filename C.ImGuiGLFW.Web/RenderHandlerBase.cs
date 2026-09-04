using CefSharp;
using CefSharp.Enums;
using CefSharp.OffScreen;
using CefSharp.Structs;
using Hexa.NET.ImGui;
using Hexa.NET.Utilities;
using System.Collections.Concurrent;

namespace C.ImGuiGLFW.Web;

/// <summary>
/// Provides a base implementation for CEF render handlers that manage off-screen browser rendering
/// with ImGui integration and cursor management.
/// </summary>
/// <remarks>
/// This abstract class implements the IRenderHandler interface and provides common functionality
/// for off-screen browser rendering. It manages a concurrent queue for draw data, handles cursor
/// mapping between CEF and ImGui cursor types, and provides size management for the render buffer.
/// Derived classes must implement specific rendering logic, popup handling, and drag operations.
/// The class is designed to be thread-safe for paint operations through the use of concurrent collections.
/// </remarks>
public abstract class RenderHandlerBase : IRenderHandler
{
    /// <summary>
    /// A concurrent queue that stores draw data from paint operations for thread-safe processing.
    /// </summary>
    /// <remarks>
    /// This protected field provides thread-safe storage for CefDrawData instances that are
    /// generated during paint operations and consumed during Draw calls. The concurrent queue
    /// ensures that paint data can be safely enqueued from CEF's rendering thread and dequeued
    /// from the UI thread without synchronization issues.
    /// </remarks>
    protected readonly ConcurrentQueue<CefDrawData> drawQueue = new();

    /// <summary>
    /// Stores the currently requested mouse cursor that should be applied when hovering over the browser area.
    /// </summary>
    /// <remarks>
    /// This protected field holds the ImGui cursor type that was last requested by the browser
    /// through cursor change notifications. The cursor is applied during the Draw method when
    /// the mouse is hovering over the browser content area.
    /// </remarks>
    protected ImGuiMouseCursor requestedCursor;
    private bool disposedValue;
    private int width;
    private int height;

    /// <summary>
    /// Gets a value indicating whether this instance has been disposed.
    /// </summary>
    /// <remarks>
    /// This property returns true after the Dispose method has been called, indicating that
    /// the render handler is no longer usable and all resources have been released.
    /// Once disposed, the render handler should not be used for any operations.
    /// </remarks>
    public bool IsDisposed => disposedValue;

    /// <summary>
    /// Gets the current width of the render buffer in pixels.
    /// </summary>
    /// <remarks>
    /// This property represents the current width of the rendering area. The value is updated
    /// when SetSize is called and is used by various rendering and coordinate calculation methods.
    /// The width corresponds to the browser's viewport width for rendering purposes.
    /// </remarks>
    public int Width => width;

    /// <summary>
    /// Gets the current height of the render buffer in pixels.
    /// </summary>
    /// <remarks>
    /// This property represents the current height of the rendering area. The value is updated
    /// when SetSize is called and is used by various rendering and coordinate calculation methods.
    /// The height corresponds to the browser's viewport height for rendering purposes.
    /// </remarks>
    public int Height => height;

    /// <summary>
    /// Sets the size of the render buffer, triggering buffer resize operations if dimensions have changed.
    /// </summary>
    /// <param name="width">The new width in pixels.</param>
    /// <param name="height">The new height in pixels.</param>
    /// <remarks>
    /// This method updates the render buffer dimensions and calls SetBufferSize when the size actually changes.
    /// If the new dimensions are the same as current dimensions, the method returns early without
    /// performing any operations. This method is typically called when the browser window is resized
    /// or when the rendering area changes due to UI layout modifications.
    /// </remarks>
    public void SetSize(int width, int height)
    {
        if (this.width == width && this.height == height) return;
        int oldWidth = width;
        int oldHeight = height;
        this.width = width;
        this.height = height;
        SetBufferSize(oldWidth, oldHeight, width, height);
    }

    /// <summary>
    /// When overridden in a derived class, handles buffer size changes for render target management.
    /// </summary>
    /// <param name="oldWidth">The previous buffer width.</param>
    /// <param name="oldHeight">The previous buffer height.</param>
    /// <param name="width">The new buffer width.</param>
    /// <param name="height">The new buffer height.</param>
    /// <remarks>
    /// This protected abstract method is called when the render buffer size changes.
    /// Implementations should handle render target resizing, texture recreation,
    /// or other size-dependent resource management. This method is called from SetSize
    /// only when the dimensions actually change.
    /// </remarks>
    protected abstract void SetBufferSize(int oldWidth, int oldHeight, int width, int height);

    /// <summary>
    /// When overridden in a derived class, renders the browser content using the specified ImGui draw context.
    /// </summary>
    /// <param name="draw">The ImGui draw list for rendering operations.</param>
    /// <param name="bb">The bounding rectangle defining the rendering area.</param>
    /// <param name="hovered">Indicates whether the mouse is hovering over the browser area.</param>
    /// <remarks>
    /// This method is called to render the browser content within the specified bounding rectangle.
    /// Implementations should process queued draw data, update textures or render targets as needed,
    /// and handle mouse cursor changes when hovering. The method should integrate with ImGui's
    /// rendering pipeline to display the browser content within the user interface.
    /// </remarks>
    public abstract void Draw(ImDrawListPtr draw, ImRect bb, bool hovered);

    /// <summary>
    /// Gets screen information for the render handler, including scale factor, dimensions, and color depth.
    /// </summary>
    /// <returns>A ScreenInfo structure containing display properties, or null if not available.</returns>
    /// <remarks>
    /// This virtual method returns screen information that CEF uses for rendering decisions.
    /// The default implementation provides standard values including a device scale factor of 1,
    /// 32-bit color depth, and dimensions matching the current buffer size. Derived classes
    /// can override this method to provide more accurate screen information based on the
    /// actual display characteristics.
    /// </remarks>
    public virtual ScreenInfo? GetScreenInfo()
    {
        ScreenInfo info = new()
        {
            DeviceScaleFactor = 1,
            Rect = new(0, 0, width, height),
            AvailableRect = new Rect(0, 0, width, height),
            Depth = 32,
            DepthPerComponent = 8,
            IsMonochrome = false,
        };
        return info;
    }

    /// <summary>
    /// Gets the view rectangle that defines the browser's visible area.
    /// </summary>
    /// <returns>A Rect structure representing the view area from (0,0) to the current buffer dimensions.</returns>
    /// <remarks>
    /// This virtual method returns the rectangle that defines the browser's viewport.
    /// The default implementation returns a rectangle starting at (0,0) with dimensions
    /// matching the current buffer size. This rectangle is used by CEF to determine
    /// the rendering area and coordinate system for the browser content.
    /// </remarks>
    public virtual Rect GetViewRect() => new(0, 0, width, height);

    /// <summary>
    /// Converts view coordinates to screen coordinates.
    /// </summary>
    /// <param name="viewX">The X coordinate in view space.</param>
    /// <param name="viewY">The Y coordinate in view space.</param>
    /// <param name="screenX">The converted X coordinate in screen space.</param>
    /// <param name="screenY">The converted Y coordinate in screen space.</param>
    /// <returns>True if the conversion was successful, false otherwise.</returns>
    /// <remarks>
    /// This virtual method converts coordinates from the browser's view space to screen space.
    /// The default implementation performs a 1:1 mapping without transformation, which is
    /// suitable for most off-screen rendering scenarios. Override this method when coordinate
    /// transformation is needed, such as when the browser is embedded within a larger UI
    /// with coordinate offsets or scaling.
    /// </remarks>
    public virtual bool GetScreenPoint(int viewX, int viewY, out int screenX, out int screenY)
    {
        screenX = viewX;
        screenY = viewY;
        return true;
    }

    /// <summary>
    /// Handles accelerated paint operations for GPU-accelerated content.
    /// </summary>
    /// <param name="type">The type of paint element being rendered.</param>
    /// <param name="dirtyRect">The rectangle area that needs updating.</param>
    /// <param name="acceleratedPaintInfo">Information about the accelerated paint operation.</param>
    /// <remarks>
    /// This virtual method is called when CEF uses hardware acceleration for rendering.
    /// The default implementation provides a no-op placeholder. Override this method
    /// when supporting GPU-accelerated rendering scenarios, such as WebGL content
    /// or video playback with hardware acceleration.
    /// </remarks>
    public virtual void OnAcceleratedPaint(PaintElementType type, Rect dirtyRect, AcceleratedPaintInfo acceleratedPaintInfo) { }

    /// <summary>
    /// Handles cursor change notifications from the browser and maps them to ImGui cursor types.
    /// </summary>
    /// <param name="cursor">The native cursor handle.</param>
    /// <param name="type">The CEF cursor type.</param>
    /// <param name="customCursorInfo">Additional information for custom cursors.</param>
    /// <remarks>
    /// This virtual method processes cursor change requests from the browser and maps CEF cursor types
    /// to corresponding ImGui cursor types. The mapping covers most standard cursor types including
    /// arrows, text input, resize cursors, and interaction cursors. Some CEF cursor types that don't
    /// have direct ImGui equivalents are mapped to the closest available alternative. The mapped cursor
    /// is stored and applied during the Draw method when the mouse is hovering over the browser area.
    /// </remarks>
    public virtual void OnCursorChange(nint cursor, CursorType type, CursorInfo customCursorInfo) => requestedCursor = type switch
    {
        CursorType.Pointer => ImGuiMouseCursor.Arrow,
        CursorType.Cross => ImGuiMouseCursor.Arrow,
        CursorType.Hand => ImGuiMouseCursor.Hand,
        CursorType.IBeam => ImGuiMouseCursor.TextInput,
        CursorType.Wait => ImGuiMouseCursor.NotAllowed, // ImGui doesn't have a "Wait" cursor, closest might be NotAllowed
        CursorType.Help => ImGuiMouseCursor.Arrow, // Custom or unsupported in ImGui by default
        CursorType.EastResize => ImGuiMouseCursor.ResizeEw,
        CursorType.NorthResize => ImGuiMouseCursor.ResizeNs,
        CursorType.NortheastResize => ImGuiMouseCursor.ResizeNesw,
        CursorType.NorthwestResize => ImGuiMouseCursor.ResizeNwse,
        CursorType.SouthResize => ImGuiMouseCursor.ResizeNs,
        CursorType.SoutheastResize => ImGuiMouseCursor.ResizeNwse,
        CursorType.SouthwestResize => ImGuiMouseCursor.ResizeNesw,
        CursorType.WestResize => ImGuiMouseCursor.ResizeEw,
        CursorType.NorthSouthResize => ImGuiMouseCursor.ResizeNs,
        CursorType.EastWestResize => ImGuiMouseCursor.ResizeEw,
        CursorType.NortheastSouthwestResize => ImGuiMouseCursor.ResizeNesw,
        CursorType.NorthwestSoutheastResize => ImGuiMouseCursor.ResizeNwse,
        CursorType.ColumnResize => ImGuiMouseCursor.ResizeEw,
        CursorType.RowResize => ImGuiMouseCursor.ResizeNs,
        CursorType.MiddlePanning => ImGuiMouseCursor.ResizeAll, // Best guess for panning
        CursorType.EastPanning => ImGuiMouseCursor.ResizeEw,
        CursorType.NorthPanning => ImGuiMouseCursor.ResizeNs,
        CursorType.NortheastPanning => ImGuiMouseCursor.ResizeNesw,
        CursorType.NorthwestPanning => ImGuiMouseCursor.ResizeNwse,
        CursorType.SouthPanning => ImGuiMouseCursor.ResizeNs,
        CursorType.SoutheastPanning => ImGuiMouseCursor.ResizeNwse,
        CursorType.SouthwestPanning => ImGuiMouseCursor.ResizeNesw,
        CursorType.WestPanning => ImGuiMouseCursor.ResizeEw,
        CursorType.Move => ImGuiMouseCursor.ResizeAll,
        CursorType.VerticalText => ImGuiMouseCursor.TextInput, // ImGui doesn't have vertical text specifically
        CursorType.Cell => ImGuiMouseCursor.Arrow, // Best match as ImGui doesn't have a dedicated Cell cursor
        CursorType.ContextMenu => ImGuiMouseCursor.Arrow, // ImGui doesn't support this directly
        CursorType.Alias => ImGuiMouseCursor.Arrow, // No alias cursor in ImGui
        CursorType.Progress => ImGuiMouseCursor.Arrow, // No dedicated progress in ImGui
        CursorType.NoDrop => ImGuiMouseCursor.NotAllowed,
        CursorType.Copy => ImGuiMouseCursor.Arrow, // No direct copy cursor in ImGui
        CursorType.None => ImGuiMouseCursor.None,
        CursorType.NotAllowed => ImGuiMouseCursor.NotAllowed,
        CursorType.ZoomIn => ImGuiMouseCursor.Arrow, // No zoom in/out in ImGui
        CursorType.ZoomOut => ImGuiMouseCursor.Arrow, // No zoom in/out in ImGui
        CursorType.Grab => ImGuiMouseCursor.Hand, // Hand is closest to grab in ImGui
        CursorType.Grabbing => ImGuiMouseCursor.Hand, // Same as grab in ImGui
        CursorType.MiddlePanningVertical => ImGuiMouseCursor.ResizeNs,
        CursorType.MiddlePanningHorizontal => ImGuiMouseCursor.ResizeEw,
        CursorType.Custom => ImGuiMouseCursor.Arrow, // ImGui doesn't support custom cursors natively
        CursorType.DndNone => ImGuiMouseCursor.None,
        CursorType.DndMove => ImGuiMouseCursor.ResizeAll,
        CursorType.DndCopy => ImGuiMouseCursor.Arrow, // ImGui doesn't differentiate DnD cursor types
        CursorType.DndLink => ImGuiMouseCursor.Arrow, // Same limitation as above
        _ => ImGuiMouseCursor.Arrow // Default fallback
    };

    /// <summary>
    /// Handles paint operations by copying browser pixel data and queuing it for rendering.
    /// </summary>
    /// <param name="type">The type of paint element (View or Popup).</param>
    /// <param name="dirtyRect">The rectangle area that was painted.</param>
    /// <param name="buffer">Pointer to the source pixel data buffer.</param>
    /// <param name="width">The width of the pixel data.</param>
    /// <param name="height">The height of the pixel data.</param>
    /// <remarks>
    /// This virtual unsafe method is called when CEF has new pixel data to display. It copies
    /// the pixel data from the CEF buffer to a managed buffer and queues it for processing
    /// during the next Draw call. The method handles memory allocation and copying safely,
    /// ensuring that the pixel data remains valid until it's processed and released.
    /// The queuing mechanism allows for thread-safe handling of paint operations.
    /// </remarks>
    public virtual unsafe void OnPaint(PaintElementType type, Rect dirtyRect, nint buffer, int width, int height)
    {
        int sizeInBytes = width * 4 * height;
        byte* buf = Utils.AllocT<byte>(sizeInBytes);
        Utils.Memcpy((void*)buffer, buf, sizeInBytes);

        CefDrawData data = new(type, dirtyRect, width, height, buf);

        drawQueue.Enqueue(data);
    }

    /// <summary>
    /// When overridden in a derived class, handles popup visibility changes.
    /// </summary>
    /// <param name="show">True to show the popup, false to hide it.</param>
    /// <remarks>
    /// This abstract method is called when CEF needs to show or hide popup elements
    /// such as dropdown menus, context menus, or tooltips. Implementations should
    /// manage popup rendering and visibility state according to the application's
    /// UI framework requirements.
    /// </remarks>
    public abstract void OnPopupShow(bool show);

    /// <summary>
    /// When overridden in a derived class, handles popup size and position changes.
    /// </summary>
    /// <param name="rect">The rectangle defining the popup's bounds.</param>
    /// <remarks>
    /// This abstract method is called when CEF popups need to be repositioned or resized.
    /// Implementations should update popup rendering areas and ensure proper positioning
    /// within the application's coordinate system.
    /// </remarks>
    public abstract void OnPopupSize(Rect rect);

    /// <summary>
    /// Handles virtual keyboard requests from the browser.
    /// </summary>
    /// <param name="browser">The browser instance requesting the virtual keyboard.</param>
    /// <param name="inputMode">The input mode for the virtual keyboard.</param>
    /// <remarks>
    /// This virtual method is called when the browser requests a virtual keyboard,
    /// typically on touch devices or in specific input contexts. The default implementation
    /// provides a no-op placeholder. Override this method to integrate with platform-specific
    /// virtual keyboard systems when supporting touch-based input scenarios.
    /// </remarks>
    public virtual void OnVirtualKeyboardRequested(IBrowser browser, TextInputMode inputMode) { }

    /// <summary>
    /// Handles IME composition range changes for international text input.
    /// </summary>
    /// <param name="selectedRange">The currently selected text range.</param>
    /// <param name="characterBounds">Array of rectangles defining character positions.</param>
    /// <remarks>
    /// This virtual method is called during IME (Input Method Editor) text composition
    /// to provide information about text selection and character positioning. The default
    /// implementation provides a no-op placeholder. Override this method when supporting
    /// complex text input scenarios, particularly for languages that require composition
    /// during input such as Chinese, Japanese, or Korean.
    /// </remarks>
    public virtual void OnImeCompositionRangeChanged(CefSharp.Structs.Range selectedRange, Rect[] characterBounds) { }

    /// <summary>
    /// When overridden in a derived class, initiates a drag operation.
    /// </summary>
    /// <param name="dragData">The data being dragged.</param>
    /// <param name="mask">The allowed drag operations.</param>
    /// <param name="x">The X coordinate where dragging started.</param>
    /// <param name="y">The Y coordinate where dragging started.</param>
    /// <returns>True if the drag operation is accepted, false otherwise.</returns>
    /// <remarks>
    /// This abstract method is called when the browser initiates a drag operation.
    /// Implementations should return true to accept the drag operation and handle
    /// the dragging logic, or false to reject it. The method provides the drag data,
    /// allowed operations, and starting coordinates for proper drag handling.
    /// </remarks>
    public abstract bool StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y);

    /// <summary>
    /// When overridden in a derived class, updates the cursor during drag operations.
    /// </summary>
    /// <param name="operation">The current drag operation type.</param>
    /// <remarks>
    /// This abstract method is called to update the mouse cursor appearance during
    /// active drag operations. Implementations should change the cursor to reflect
    /// the current drag state (copy, move, link, etc.) to provide appropriate
    /// visual feedback to the user.
    /// </remarks>
    public abstract void UpdateDragCursor(DragOperationsMask operation);

    /// <summary>
    /// When overridden in a derived class, performs cleanup of render handler resources.
    /// </summary>
    /// <remarks>
    /// This protected abstract method is called during disposal to clean up render handler
    /// specific resources such as textures, buffers, or graphics contexts. Implementations
    /// should release all managed and unmanaged resources and prepare for safe disposal.
    /// This method is called only once during the disposal process.
    /// </remarks>
    protected abstract void DisposeCore();

    /// <summary>
    /// Releases all resources used by the render handler.
    /// </summary>
    /// <remarks>
    /// This method implements the IDisposable pattern and ensures that DisposeCore is called
    /// only once. It also suppresses finalization since all cleanup is handled explicitly.
    /// After calling Dispose, the render handler should not be used for any operations.
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
