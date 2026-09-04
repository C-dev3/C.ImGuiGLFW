using CefSharp;
using CefSharp.Enums;
using CefSharp.Structs;
using Hexa.NET.ImGui;
using Hexa.NET.OpenGL;

namespace C.ImGuiGLFW.Web;

/// <summary>
/// Provides OpenGL-based rendering capabilities for CEF off-screen browser instances within ImGui contexts.
/// This handler manages OpenGL textures and efficiently updates them with browser paint data.
/// </summary>
/// <remarks>
/// This unsafe class extends RenderHandlerBase to provide optimized OpenGL rendering for CEF browsers.
/// It maintains an internal OpenGL texture that is updated with browser content and rendered through ImGui.
/// The class handles both full texture updates and partial dirty rectangle updates for optimal performance.
/// It integrates with ImGui's drawing system and manages mouse cursor updates when hovering over browser content.
/// The class automatically handles texture creation, updates, and cleanup through its lifecycle.
/// </remarks>
public unsafe class OpenGLRenderHandler() : RenderHandlerBase
{
    private readonly GL GL = ImGuiController.GetGL();
    //private readonly BindingsContext context = ImGuiController.GetBindingsContext();
    private uint textureId;
    private int width;
    private int height;

    /// <summary>
    /// Renders the browser content to the specified ImGui draw list within the given bounding rectangle.
    /// </summary>
    /// <param name="draw">The ImGui draw list to render the browser content to.</param>
    /// <param name="bb">The bounding rectangle defining the rendering area.</param>
    /// <param name="hovered">Indicates whether the mouse is hovering over the browser area.</param>
    /// <remarks>
    /// This method processes queued draw data from the browser, updates the OpenGL texture with new content,
    /// and renders it through ImGui. It handles both full texture recreation for size changes and efficient
    /// partial updates for dirty rectangles. When the mouse is hovering and a cursor change is requested,
    /// it updates the ImGui cursor accordingly. The method ensures proper cleanup of processed draw data
    /// and maintains optimal rendering performance through texture reuse and partial updates.
    /// </remarks>
    public override void Draw(ImDrawListPtr draw, ImRect bb, bool hovered)
    {
        while (drawQueue.TryDequeue(out CefDrawData result))
        {
            if (result.Type == PaintElementType.View)
            {
                if (textureId == 0)
                {
                    textureId = GL.GenTexture();
                    GL.BindTexture(GLTextureTarget.Texture2D, textureId);
                    GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MinFilter, (int)GLTextureMinFilter.Nearest);
                    GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MagFilter, (int)GLTextureMinFilter.Nearest);
                    GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapS, (int)GLTextureWrapMode.ClampToEdge);
                    GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapT, (int)GLTextureWrapMode.ClampToEdge);
                }
                else
                {
                    GL.BindTexture(GLTextureTarget.Texture2D, textureId);
                }

                GL.PixelStorei(GLPixelStoreParameter.UnpackRowLength, result.Width);
                if (result.Width != width || result.Height != height)
                {
                    GL.PixelStorei(GLPixelStoreParameter.UnpackSkipPixels, 0);
                    GL.PixelStorei(GLPixelStoreParameter.UnpackSkipRows, 0);
                    GL.TexImage2D(GLTextureTarget.Texture2D, 0, GLInternalFormat.Rgba, result.Width, result.Height, 0, GLPixelFormat.Bgra, GLPixelType.UnsignedInt8888Rev, result.Data);
                    width = result.Width;
                    height = result.Height;
                }
                else
                {
                    GL.PixelStorei(GLPixelStoreParameter.UnpackSkipPixels, result.DirtyRect.X);
                    GL.PixelStorei(GLPixelStoreParameter.UnpackSkipRows, result.DirtyRect.Y);
                    GL.TexSubImage2D(GLTextureTarget.Texture2D, 0, result.DirtyRect.X, result.DirtyRect.Y, result.DirtyRect.Width, result.DirtyRect.Height, GLPixelFormat.Bgra, GLPixelType.UnsignedInt8888Rev, result.Data);
                }
                GL.BindTexture(GLTextureTarget.Texture2D, 0);
            }

            result.Release();
        }

        if (hovered && requestedCursor != ImGuiMouseCursor.None)
        {
            ImGui.SetMouseCursor(requestedCursor);
        }

        draw.AddImage(new ImTextureRef() { TexID = new ImTextureID(textureId) }, bb.Min, bb.Max);
    }

    /// <summary>
    /// Handles buffer size changes for the render handler.
    /// </summary>
    /// <param name="oldWidth">The previous buffer width in pixels.</param>
    /// <param name="oldHeight">The previous buffer height in pixels.</param>
    /// <param name="width">The new buffer width in pixels.</param>
    /// <param name="height">The new buffer height in pixels.</param>
    /// <remarks>
    /// This method is called when the browser's rendering buffer needs to be resized,
    /// typically in response to browser window size changes or zoom level modifications.
    /// The current implementation provides a no-op placeholder since buffer size changes
    /// are handled automatically during the Draw method when texture dimensions change.
    /// This method can be overridden to perform additional cleanup or preparation when
    /// buffer dimensions change.
    /// </remarks>
    protected override void SetBufferSize(int oldWidth, int oldHeight, int width, int height) { }

    /// <summary>
    /// Handles popup visibility changes for the browser instance.
    /// </summary>
    /// <param name="show">True if the popup should be shown, false if it should be hidden.</param>
    /// <remarks>
    /// This method is called when CEF needs to show or hide popup elements such as dropdown menus,
    /// context menus, or other overlay content. The current implementation provides a no-op
    /// placeholder for popup handling that can be extended based on specific application requirements.
    /// </remarks>
    public override void OnPopupShow(bool show) { }

    /// <summary>
    /// Handles popup size and position changes for the browser instance.
    /// </summary>
    /// <param name="rect">The rectangle defining the popup's position and dimensions.</param>
    /// <remarks>
    /// This method is invoked when CEF popups need to be resized or repositioned, such as when
    /// dropdown menus change size or move to different screen locations. The current implementation
    /// provides a no-op placeholder that can be extended to handle popup positioning and rendering
    /// based on specific application needs.
    /// </remarks>
    public override void OnPopupSize(Rect rect) { }

    /// <summary>
    /// Initiates a drag operation for the browser content.
    /// </summary>
    /// <param name="dragData">The data being dragged.</param>
    /// <param name="mask">The allowed drag operations.</param>
    /// <param name="x">The X coordinate where the drag started.</param>
    /// <param name="y">The Y coordinate where the drag started.</param>
    /// <returns>Always returns false, indicating that drag operations are not supported.</returns>
    /// <remarks>
    /// This method is called when CEF attempts to start a drag operation, such as dragging text,
    /// images, or files from web content. The current implementation always returns false,
    /// effectively disabling drag-and-drop functionality. This can be extended to support
    /// drag operations by implementing the necessary drag handling logic and returning true
    /// when drag operations should be allowed.
    /// </remarks>
    public override bool StartDragging(IDragData dragData, DragOperationsMask mask, int x, int y) => false;

    /// <summary>
    /// Updates the cursor appearance during drag operations.
    /// </summary>
    /// <param name="operation">The current drag operation type.</param>
    /// <remarks>
    /// This method is called to update the mouse cursor appearance during active drag operations
    /// to provide visual feedback about the current drag state (copy, move, link, etc.).
    /// The current implementation provides a no-op placeholder since drag operations are not
    /// currently supported, but can be extended when implementing drag-and-drop functionality.
    /// </remarks>
    public override void UpdateDragCursor(DragOperationsMask operation) { }

    /// <summary>
    /// Performs cleanup of OpenGL resources when the render handler is being disposed.
    /// </summary>
    /// <remarks>
    /// This method is called during the disposal process to ensure proper cleanup of
    /// OpenGL resources, specifically the texture used for rendering browser content.
    /// It safely deletes the OpenGL texture if one was created and resets the texture ID
    /// to prevent resource leaks. This method is automatically called by the base class
    /// disposal mechanism and should not be called directly by user code.
    /// </remarks>
    protected override void DisposeCore()
    {
        if (textureId != 0)
        {
            GL.DeleteTexture(textureId);
            textureId = 0;
        }
    }
}
