namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// Represents a generic container that holds a single value of type T.
/// </summary>
/// <typeparam name="T">The type of the value contained in the box.</typeparam>
/// <param name="value">The initial value to store in the box.</param>
public class Box<T>(T value)
{
    /// <summary>
    /// Gets or sets the value stored in the box.
    /// </summary>
    /// <value>The value of type T contained in this box.</value>
    public T Value = value;

    /// <summary>
    /// Creates a shallow copy of the current Box instance.
    /// </summary>
    /// <returns>A new Box&lt;T&gt; instance containing the same value as the current instance.</returns>
    /// <remarks>
    /// This method performs a shallow copy. If T is a reference type, 
    /// both the original and cloned box will reference the same object.
    /// </remarks>
    public Box<T> Clone() => new(Value);
}
