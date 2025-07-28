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

    public static readonly uint[] GlyphRange =
    [
        (uint)Enum.GetValues<FontAwesomeIcon>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<FontAwesomeIcon>().Where(x => x > 0).Max(),
        0
    ];

    public static uint[] GetGlyphRange()
    {
        var definedIcons = Enum.GetValues<FontAwesomeIcon>()
            .Where(x => x > 0)
            .Select(x => (uint)x)
            .ToHashSet()
            .OrderBy(x => x)
            .ToList();

        var ranges = new List<uint>();
        uint start = definedIcons[0];
        uint end = definedIcons[0];

        for (int i = 1; i < definedIcons.Count; i++)
        {
            if (definedIcons[i] == end + 1)
            {
                end = definedIcons[i];
            }
            else
            {
                ranges.Add(start);
                ranges.Add(end);
                start = definedIcons[i];
                end = definedIcons[i];
            }
        }

        ranges.Add(start);
        ranges.Add(end);
        ranges.Add(0);

        return [.. ranges];
    }
}
