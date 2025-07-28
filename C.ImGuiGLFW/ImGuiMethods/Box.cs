namespace C.ImGuiGLFW.ImGuiMethods;

public class Box<T>(T value)
{
    public T Value = value;

    public Box<T> Clone() => new(Value);
}
