namespace C.ImGuiGLFW.Common;

public readonly struct ResizeEventArgs(Vector2 size)
{
    public Vector2 Size { get; } = size;

    public int Width => (int)Size.X;
    public int Height => (int)Size.Y;

    public ResizeEventArgs(int width, int height) : this(new Vector2(width, height)) { }
}
