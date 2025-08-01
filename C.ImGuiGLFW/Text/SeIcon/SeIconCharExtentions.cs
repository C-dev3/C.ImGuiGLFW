using System.Data;
using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Text.SeIcon;

/// <summary>
/// Provides extension methods and data for <see cref="SeIconChar"/> enum.
/// </summary>
public static class SeIconCharExtentions
{
    /// <summary>
    /// Converts the specified <see cref="SeIconChar"/> value to its corresponding Unicode character.
    /// </summary>
    /// <param name="icon">The icon enum value to convert.</param>
    /// <returns>The Unicode character representation of the icon.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToIconChar(this SeIconChar icon) => (char)icon;

    /// <summary>
    /// Converts the specified <see cref="SeIconChar"/> value to its corresponding string representation.
    /// </summary>
    /// <param name="icon">The icon enum value to convert.</param>
    /// <returns>A string containing the single character representation of the icon.</returns>
    public static string ToIconString(this SeIconChar icon) => string.Empty + (char)icon;

    /// <summary>
    /// Gets the Unicode glyph range for the <see cref="SeIconChar"/> enum values.
    /// </summary>
    /// <remarks>
    /// This array contains three elements:
    /// - The minimum <see cref="SeIconChar"/> value greater than zero.
    /// - The maximum <see cref="SeIconChar"/> value.
    /// - A terminating zero value.
    /// This range is useful for font glyph loading or filtering operations.
    /// </remarks>
    public static readonly uint[] GlyphRange =
    [
        (uint)Enum.GetValues<SeIconChar>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<SeIconChar>().Where(x => x > 0).Max(),
        0
    ];
}
