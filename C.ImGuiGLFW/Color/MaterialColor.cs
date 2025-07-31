using MaterialColorUtilities.Palettes;

namespace C.ImGuiGLFW.Color;

/// <summary>
/// Represents a Material Design color palette containing primary, secondary, tertiary, neutral, and error colors.
/// </summary>
/// <remarks>
/// This struct provides a complete Material Design color scheme generated from a seed color.
/// All colors are stored as Vector4 RGBA values with components normalized to the range [0, 1].
/// </remarks>
public struct MaterialColor
{
    /// <summary>
    /// The primary color of the Material Design palette.
    /// </summary>
    public Vector4 Primary;

    /// <summary>
    /// The secondary color of the Material Design palette.
    /// </summary>
    public Vector4 Secondary;

    /// <summary>
    /// The tertiary color of the Material Design palette.
    /// </summary>
    public Vector4 Tertiary;

    /// <summary>
    /// The neutral color of the Material Design palette.
    /// </summary>
    public Vector4 Neutral;

    /// <summary>
    /// The neutral variant color of the Material Design palette.
    /// </summary>
    public Vector4 NeutralVariant;

    /// <summary>
    /// The error color of the Material Design palette.
    /// </summary>
    public Vector4 Error;

    /// <summary>
    /// The seed color used to generate this Material Design palette, stored as a packed ARGB uint value.
    /// </summary>
    public uint Seed;

    /// <summary>
    /// Generates a Material Design color palette from a Vector4 RGBA seed color.
    /// </summary>
    /// <param name="rgba">The seed color as a Vector4 RGBA value where each component is in the range [0, 1].</param>
    /// <param name="tone">The tone value to use for all palette colors. Default is 40. Valid range is typically 0-100.</param>
    /// <returns>A MaterialColor instance containing the complete Material Design palette derived from the seed color.</returns>
    /// <remarks>
    /// This method converts the input RGBA color to ARGB format and uses it as a seed for generating
    /// a complete Material Design color palette. The tone parameter controls the lightness/darkness
    /// of the generated colors, where lower values produce darker colors and higher values produce lighter colors.
    /// Common tone values: 10 (very dark), 40 (default), 50 (medium), 90 (very light).
    /// </remarks>
    public static MaterialColor Get(Vector4 rgba, uint tone = 40)
    {
        uint seed = rgba.RgbaToArgb();
        CorePalette palette = CorePalette.Of(seed);

        return new MaterialColor
        {
            Primary = palette.Primary[tone].ArgbToRgba(),
            Secondary = palette.Secondary[tone].ArgbToRgba(),
            Tertiary = palette.Tertiary[tone].ArgbToRgba(),
            Neutral = palette.Neutral[tone].ArgbToRgba(),
            NeutralVariant = palette.NeutralVariant[tone].ArgbToRgba(),
            Error = palette.Error[tone].ArgbToRgba(),
            Seed = seed,
        };
    }

    /// <summary>
    /// Generates a Material Design color palette from a packed RGBA uint seed color.
    /// </summary>
    /// <param name="rgba">The seed color as a packed RGBA uint value where red is in the most significant byte.</param>
    /// <param name="tone">The tone value to use for all palette colors. Default is 40. Valid range is typically 0-100.</param>
    /// <returns>A MaterialColor instance containing the complete Material Design palette derived from the seed color.</returns>
    /// <remarks>
    /// This method converts the input RGBA uint to ARGB format and uses it as a seed for generating
    /// a complete Material Design color palette. The tone parameter controls the lightness/darkness
    /// of the generated colors, where lower values produce darker colors and higher values produce lighter colors.
    /// Common tone values: 10 (very dark), 40 (default), 50 (medium), 90 (very light).
    /// Input format expected: RRGGBBAA (red in bits 31-24, green in bits 23-16, blue in bits 15-8, alpha in bits 7-0).
    /// </remarks>
    public static MaterialColor Get(uint rgba, uint tone = 40)
    {
        uint seed = rgba.RgbaToArgb();
        CorePalette palette = CorePalette.Of(seed);

        return new MaterialColor
        {
            Primary = palette.Primary[tone].ArgbToRgba(),
            Secondary = palette.Secondary[tone].ArgbToRgba(),
            Tertiary = palette.Tertiary[tone].ArgbToRgba(),
            Neutral = palette.Neutral[tone].ArgbToRgba(),
            NeutralVariant = palette.NeutralVariant[tone].ArgbToRgba(),
            Error = palette.Error[tone].ArgbToRgba(),
            Seed = seed,
        };
    }
}
