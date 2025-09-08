namespace C.ImGuiGLFW.ImGuiMethods.Tab;

/// <summary>
/// Represents the edges of a rectangle that can be combined using bitwise operations.
/// </summary>
/// <remarks>
/// This enumeration is used to specify which edges of a rectangle should be drawn or processed.
/// Multiple edges can be combined using the bitwise OR operator.
/// </remarks>
[Flags]
public enum EdgeType : byte
{
    /// <summary>
    /// Specifies no edges.
    /// </summary>
    None = 0,

    /// <summary>
    /// Specifies the left edge.
    /// </summary>
    Left = 1 << 0,

    /// <summary>
    /// Specifies the top edge.
    /// </summary>
    Top = 1 << 1,

    /// <summary>
    /// Specifies the right edge.
    /// </summary>
    Right = 1 << 2,

    /// <summary>
    /// Specifies the bottom edge.
    /// </summary>
    Bottom = 1 << 3
}
