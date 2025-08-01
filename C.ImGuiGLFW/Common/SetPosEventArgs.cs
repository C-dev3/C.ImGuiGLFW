namespace C.ImGuiGLFW.Common;

/// <summary>
/// Provides data for a window position change event, including the new position in screen coordinates.
/// </summary>
public readonly struct SetPosEventArgs(Vector2 position)
{
    /// <summary>
    /// Gets the new position of the window as a <see cref="Vector2"/> (X, Y).
    /// </summary>
    public Vector2 Position { get; } = position;

    /// <summary>
    /// Gets the new X-coordinate of the window's position in screen space.
    /// </summary>
    public int X => (int)Position.X;

    /// <summary>
    /// Gets the new Y-coordinate of the window's position in screen space.
    /// </summary>
    public int Y => (int)Position.Y;

    /// <summary>
    /// Initializes a new instance of the <see cref="SetPosEventArgs"/> struct
    /// with the specified X and Y coordinates.
    /// </summary>
    /// <param name="x">The new X-coordinate of the window's position.</param>
    /// <param name="y">The new Y-coordinate of the window's position.</param>
    public SetPosEventArgs(int x, int y) : this(new Vector2(x, y)) { }
}
