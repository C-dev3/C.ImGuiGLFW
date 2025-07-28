namespace C.ImGuiGLFW.Common;

public readonly struct SetPosEventArgs(Vector2 position)
{
    public Vector2 Position { get; } = position;
    public int X => (int)Position.X;
    public int Y => (int)Position.Y;

    public SetPosEventArgs(int x, int y) : this(new Vector2(x, y)) { }
}
