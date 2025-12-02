namespace C.ImGuiGLFW.ImGuiMethods.MemoryEditor;

/// <summary>
/// Specifies the data format for displaying or interpreting numeric values.
/// </summary>
public enum DataFormat
{
    /// <summary>
    /// Binary format (base 2).
    /// </summary>
    Bin = 0,

    /// <summary>
    /// Decimal format (base 10).
    /// </summary>
    Dec = 1,

    /// <summary>
    /// Hexadecimal format (base 16).
    /// </summary>
    Hex = 2,

    /// <summary>
    /// Represents the total number of available data formats.
    /// </summary>
    COUNT
}
