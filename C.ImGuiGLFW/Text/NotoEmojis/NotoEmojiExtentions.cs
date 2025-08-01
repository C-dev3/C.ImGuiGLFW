using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Text.NotoEmojis;

/// <summary>
/// Provides extension methods and data for <see cref="NotoEmoji"/> enum.
/// </summary>
public static class NotoEmojiExtentions
{
    /// <summary>
    /// Converts the specified <see cref="NotoEmoji"/> value to its corresponding string representation.
    /// </summary>
    /// <param name="icon">The emoji enum value to convert.</param>
    /// <returns>
    /// A string representing the emoji character. 
    /// Handles both BMP (Basic Multilingual Plane) and supplementary Unicode code points.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconString(this NotoEmoji icon)
    {
        var value = (int)icon;
        if (value <= 0xFFFF) return ((char)value).ToString();
        return char.ConvertFromUtf32(value);
    }

    /// <summary>
    /// Converts the specified <see cref="NotoEmoji"/> value to its corresponding string representation.
    /// </summary>
    /// <param name="icon">The emoji enum value to convert.</param>
    /// <returns>A string representing the emoji character.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconChar(this NotoEmoji icon) => char.ConvertFromUtf32((int)icon);

    /// <summary>
    /// Gets the Unicode glyph range for the <see cref="NotoEmoji"/> enum values.
    /// </summary>
    /// <remarks>
    /// This array contains three elements:
    /// - The minimum <see cref="NotoEmoji"/> value greater than zero.
    /// - The maximum <see cref="NotoEmoji"/> value.
    /// - A terminating zero value.
    /// This range is useful for font glyph loading or filtering operations.
    /// </remarks>
    public static readonly uint[] GlyphRange =
        [
        (uint)Enum.GetValues<NotoEmoji>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<NotoEmoji>().Where(x => x > 0).Max(),
        0
        ];
}
