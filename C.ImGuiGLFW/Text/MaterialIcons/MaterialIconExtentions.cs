using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Text.MaterialIcons;

/// <summary>
/// Provides extension methods and data for <see cref="MaterialIcon"/> enum.
/// </summary>
public static class MaterialIconExtentions
{
    /// <summary>
    /// Converts the specified <see cref="MaterialIcon"/> value to its corresponding string representation.
    /// </summary>
    /// <param name="icon">The material icon enum value to convert.</param>
    /// <returns>
    /// A string representing the icon character.
    /// Handles both BMP (Basic Multilingual Plane) and supplementary Unicode code points.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconString(this MaterialIcon icon)
    {
        var value = (int)icon;
        if (value <= 0xFFFF) return ((char)value).ToString();
        return char.ConvertFromUtf32(value);
    }

    /// <summary>
    /// Converts the specified <see cref="MaterialIcon"/> value to its corresponding string representation.
    /// </summary>
    /// <param name="icon">The material icon enum value to convert.</param>
    /// <returns>A string representing the icon character.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconChar(this MaterialIcon icon) => char.ConvertFromUtf32((int)icon);

    /// <summary>
    /// Gets the Unicode glyph range for the <see cref="MaterialIcon"/> enum values.
    /// </summary>
    /// <remarks>
    /// This array contains three elements:
    /// - The minimum <see cref="MaterialIcon"/> value greater than zero.
    /// - The maximum <see cref="MaterialIcon"/> value.
    /// - A terminating zero value.
    /// This range is useful for font glyph loading or filtering operations.
    /// </remarks>
    public static readonly uint[] GlyphRange =
    [
        (uint)Enum.GetValues<MaterialIcon>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<MaterialIcon>().Where(x => x > 0).Max(),
        0
    ];
}
