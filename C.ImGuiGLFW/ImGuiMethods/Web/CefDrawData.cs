using CefSharp;
using CefSharp.Structs;

namespace C.ImGuiGLFW.ImGuiMethods.Web;

/// <summary>
/// Represents drawing data from the Chromium Embedded Framework (CEF) paint events.
/// This structure contains information about painted regions including the paint type,
/// affected area, dimensions, and raw pixel data.
/// </summary>
/// <remarks>
/// This is an unsafe struct that directly manages unmanaged memory through a void pointer.
/// The Data pointer must be properly released using the Release() method to prevent memory leaks.
/// The struct is typically used in CEF paint callbacks to handle browser rendering updates.
/// </remarks>
/// <remarks>
/// Initializes a new instance of the CefDrawData structure with the specified parameters.
/// </remarks>
/// <param name="type">The type of paint element.</param>
/// <param name="dirtyRect">The rectangular area that needs to be updated.</param>
/// <param name="width">The width of the paint data in pixels.</param>
/// <param name="height">The height of the paint data in pixels.</param>
/// <param name="data">A pointer to the raw pixel data buffer.</param>
/// <remarks>
/// The constructor takes ownership of the data pointer. The caller should not free
/// the data pointer directly; instead, use the Release() method to properly dispose of it.
/// </remarks>
public unsafe struct CefDrawData(PaintElementType type, Rect dirtyRect, int width, int height, void* data)
{
    /// <summary>
    /// Gets or sets the type of paint element being drawn.
    /// </summary>
    /// <remarks>
    /// This property indicates whether the paint data represents a view or popup element.
    /// </remarks>
    public PaintElementType Type = type;

    /// <summary>
    /// Gets or sets the rectangular area that needs to be updated.
    /// </summary>
    /// <remarks>
    /// This rectangle defines the region within the browser view that has been invalidated
    /// and needs to be repainted. Coordinates are relative to the browser view origin.
    /// </remarks>
    public Rect DirtyRect = dirtyRect;

    /// <summary>
    /// Gets or sets the width of the paint data in pixels.
    /// </summary>
    /// <remarks>
    /// This represents the total width of the pixel buffer, which may be larger than
    /// the dirty rectangle width for optimization purposes.
    /// </remarks>
    public int Width = width;

    /// <summary>
    /// Gets or sets the height of the paint data in pixels.
    /// </summary>
    /// <remarks>
    /// This represents the total height of the pixel buffer, which may be larger than
    /// the dirty rectangle height for optimization purposes.
    /// </remarks>
    public int Height = height;

    /// <summary>
    /// Gets or sets a pointer to the raw pixel data buffer.
    /// </summary>
    /// <remarks>
    /// This is an unmanaged memory pointer containing BGRA pixel data.
    /// The pointer must be released using the Release() method when no longer needed.
    /// The data represents pixels in 32-bit BGRA format (4 bytes per pixel).
    /// </remarks>
    public void* Data = data;

    /// <summary>
    /// Releases the unmanaged memory associated with the pixel data and sets the Data pointer to null.
    /// </summary>
    /// <remarks>
    /// This method should be called when the CefDrawData is no longer needed to prevent memory leaks.
    /// It is safe to call this method multiple times; subsequent calls will have no effect.
    /// After calling this method, the Data pointer will be null and should not be accessed.
    /// </remarks>
    public void Release()
    {
        if (Data != null)
        {
            Utils.Free(Data);
            Data = null;
        }
    }
}
