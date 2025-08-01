namespace C.ImGuiGLFW.Common;

/// <summary>
/// Provides data for a window resize event, including the new size in pixels.
/// </summary>
public readonly struct ResizeEventArgs(Vector2 size)
{
    /// <summary>
    /// Gets the new size of the window as a <see cref="Vector2"/> (Width, Height).
    /// </summary>
    public Vector2 Size { get; } = size;

    /// <summary>
    /// Gets the new width of the window in pixels.
    /// </summary>
    public int Width => (int)Size.X;

    /// <summary>
    /// Gets the new height of the window in pixels.
    /// </summary>
    public int Height => (int)Size.Y;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResizeEventArgs"/> struct
    /// with the specified width and height.
    /// </summary>
    /// <param name="width">The new width of the window in pixels.</param>
    /// <param name="height">The new height of the window in pixels.</param>
    public ResizeEventArgs(int width, int height) : this(new Vector2(width, height)) { }
}
