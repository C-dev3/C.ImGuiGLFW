using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Text.FontAwesome;

/// <summary>
/// Extension methods for <see cref="FontAwesomeIcon"/>.
/// </summary>
public static class FontAwesomeExtensions
{
    /// <summary>
    /// Convert the FontAwesomeIcon to a <see cref="char"/> type.
    /// </summary>
    /// <param name="icon">The icon to convert.</param>
    /// <returns>The converted icon.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToIconChar(this FontAwesomeIcon icon) => (char)icon;

    /// <summary>
    /// Convert the FontAwesomeIcon to a <see cref="string"/> type.
    /// </summary>
    /// <param name="icon">The icon to convert.</param>
    /// <returns>The converted icon.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconString(this FontAwesomeIcon icon) => string.Empty + (char)icon;

    /// <summary>
    /// Gets the Unicode glyph range for the <see cref="FontAwesomeIcon"/> enum values.
    /// </summary>
    /// <remarks>
    /// This array contains three elements:
    /// - The minimum <see cref="FontAwesomeIcon"/> value greater than zero.
    /// - The maximum <see cref="FontAwesomeIcon"/> value.
    /// - A terminating zero value.
    /// This range is useful for font glyph loading or filtering operations.
    /// </remarks>
    public static readonly uint[] GlyphRange =
    [
        (uint)Enum.GetValues<FontAwesomeIcon>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<FontAwesomeIcon>().Where(x => x > 0).Max(),
        0
    ];
}
