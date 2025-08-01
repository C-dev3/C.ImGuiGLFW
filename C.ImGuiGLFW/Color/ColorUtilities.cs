namespace C.ImGuiGLFW.Color;

/// <summary>
/// Provides utility methods for color format conversions and color palette access in ImGui applications.
/// </summary>
/// <remarks>
/// This static class offers a comprehensive set of extension methods for converting between different color formats
/// commonly used in graphics programming and ImGui applications. It supports conversions between:
/// 
/// - 32-bit unsigned integer colors and Vector4 RGBA values
/// - 24-bit RGB values to Vector4 with configurable alpha
/// - ARGB and RGBA packed integer formats
/// - Access to predefined color palettes from EzColor and UIColor classes
/// 
/// All Vector4 color representations use normalized floating-point values in the range [0.0, 1.0] for each
/// RGBA component, following ImGui's standard color format. The class leverages ImGui's built-in color
/// conversion functions where available for optimal performance and consistency.
/// 
/// The utility methods are implemented as extension methods, allowing for fluent and intuitive usage
/// patterns when working with color data in ImGui-based applications.
/// </remarks>
public static class ColorUtilities
{
    /// <summary>
    /// Converts a 32-bit unsigned integer color value to a Vector4 using ImGui's color conversion.
    /// </summary>
    /// <param name="input">The 32-bit color value to convert.</param>
    /// <returns>A Vector4 representing the color with RGBA components in the range [0.0, 1.0].</returns>
    public static Vector4 U32ToFloat4(this uint input) => ImGui.ColorConvertU32ToFloat4(input);

    /// <summary>
    /// Converts a Vector4 color value to a 32-bit unsigned integer using ImGui's color conversion.
    /// </summary>
    /// <param name="input">The Vector4 color to convert with RGBA components in the range [0.0, 1.0].</param>
    /// <returns>A 32-bit unsigned integer representing the color.</returns>
    public static uint Float4ToU32(this Vector4 input) => ImGui.ColorConvertFloat4ToU32(input);

    /// <summary>
    /// Converts a 24-bit RGB color value to a Vector4 with a specified alpha channel.
    /// </summary>
    /// <param name="rgbColor">The 24-bit RGB color value (e.g., 0x1AAAFF where R=0x1A, G=0xAA, B=0xFF).</param>
    /// <param name="alpha">The alpha (transparency) value in the range [0.0, 1.0]. Default is 1.0 (fully opaque).</param>
    /// <returns>A Vector4 with RGB components extracted from the input and the specified alpha value, all normalized to [0.0, 1.0].</returns>
    public static Vector4 ToVector4FromRGB(this uint rgbColor, float alpha = 1.0f)
    {
        float r = (rgbColor >> 16 & 0xFF) / 255.0f;
        float g = (rgbColor >> 8 & 0xFF) / 255.0f;
        float b = (rgbColor & 0xFF) / 255.0f;

        return new Vector4(r, g, b, Math.Clamp(alpha, 0, 1));
    }

    /// <summary>
    /// Converts a 32-bit RGBA color value to a Vector4.
    /// </summary>
    /// <param name="rgbaColor">The 32-bit RGBA color value (e.g., 0x80AABBFF where R=0x80, G=0xAA, B=0xBB, A=0xFF).</param>
    /// <returns>A Vector4 with RGBA components extracted from the input, all normalized to [0.0, 1.0].</returns>
    public static Vector4 ToVector4FromRGBA(this uint rgbaColor)
    {
        float r = (rgbaColor >> 24 & 0xFF) / 255.0f;  // Red
        float g = (rgbaColor >> 16 & 0xFF) / 255.0f;  // Green
        float b = (rgbaColor >> 8 & 0xFF) / 255.0f;   // Blue
        float a = (rgbaColor & 0xFF) / 255.0f; // Alpha
        return new Vector4(r, g, b, a);
    }

    /// <summary>
    /// Converts a Vector4 RGBA color to a packed ARGB uint value.
    /// </summary>
    /// <param name="rgba">The RGBA color vector where each component is in the range [0, 1].</param>
    /// <returns>A packed ARGB uint value where alpha is in the most significant byte.</returns>
    /// <remarks>
    /// This method converts normalized floating-point RGBA values to an ARGB packed integer.
    /// The Vector4 components are mapped as follows: X=Red, Y=Green, Z=Blue, W=Alpha.
    /// Each component is multiplied by 255 and packed into the appropriate byte position.
    /// </remarks>
    public static uint RgbaToArgb(this Vector4 rgba)
    {
        uint a = (uint)(rgba.W * 255) << 24;
        uint r = (uint)(rgba.X * 255) << 16;
        uint g = (uint)(rgba.Y * 255) << 8;
        uint b = (uint)(rgba.Z * 255);
        return a | r | g | b;
    }

    /// <summary>
    /// Converts a packed RGBA uint value to a packed ARGB uint value.
    /// </summary>
    /// <param name="rgba">The RGBA packed uint value where red is in the most significant byte.</param>
    /// <returns>A packed ARGB uint value where alpha is in the most significant byte.</returns>
    /// <remarks>
    /// This method reorders the byte positions from RGBA format to ARGB format.
    /// Input format: RRGGBBAA (red in bits 31-24, green in bits 23-16, blue in bits 15-8, alpha in bits 7-0)
    /// Output format: AARRGGBB (alpha in bits 31-24, red in bits 23-16, green in bits 15-8, blue in bits 7-0)
    /// </remarks>
    public static uint RgbaToArgb(this uint rgba)
    {
        uint r = (rgba >> 24) & 0xFF;
        uint g = (rgba >> 16) & 0xFF;
        uint b = (rgba >> 8) & 0xFF;
        uint a = rgba & 0xFF;

        return (a << 24) | (r << 16) | (g << 8) | b;
    }

    /// <summary>
    /// Converts a packed ARGB uint value to a Vector4 RGBA color.
    /// </summary>
    /// <param name="argb">The ARGB packed uint value where alpha is in the most significant byte.</param>
    /// <returns>A Vector4 representing the RGBA color with each component normalized to the range [0, 1].</returns>
    /// <remarks>
    /// This method extracts the individual color components from the packed ARGB value and
    /// normalizes them to floating-point values in the range [0, 1].
    /// The returned Vector4 components are mapped as follows: X=Red, Y=Green, Z=Blue, W=Alpha.
    /// </remarks>
    public static Vector4 ArgbToRgba(this uint argb)
    {
        float a = ((argb >> 24) & 0xFF) / 255f;
        float r = ((argb >> 16) & 0xFF) / 255f;
        float g = ((argb >> 8) & 0xFF) / 255f;
        float b = (argb & 0xFF) / 255f;
        return new Vector4(r, g, b, a);
    }

    /// <summary>
    /// Converts a packed ARGB uint value to a packed RGBA uint value.
    /// </summary>
    /// <param name="argb">The ARGB packed uint value where alpha is in the most significant byte.</param>
    /// <returns>A packed RGBA uint value where red is in the most significant byte.</returns>
    /// <remarks>
    /// This method reorders the byte positions from ARGB format to RGBA format.
    /// Input format: AARRGGBB (alpha in bits 31-24, red in bits 23-16, green in bits 15-8, blue in bits 7-0)
    /// Output format: RRGGBBAA (red in bits 31-24, green in bits 23-16, blue in bits 15-8, alpha in bits 7-0)
    /// </remarks>
    public static uint ArgbToRgbaUint(this uint argb)
    {
        uint a = (argb >> 24) & 0xFF;
        uint r = (argb >> 16) & 0xFF;
        uint g = (argb >> 8) & 0xFF;
        uint b = argb & 0xFF;

        return (r << 24) | (g << 16) | (b << 8) | a;
    }

    /// <summary>
    /// Gets all named colors from the EzColor class as a list of tuples containing the color name and its RGBA Vector4 value.
    /// </summary>
    /// <returns>A list of tuples where each tuple contains the field name and its corresponding RGBA Vector4 color value.</returns>
    public static List<(string name, Vector4 color)> GetEzColors() => GetValues(typeof(EzColor));

    /// <summary>
    /// Gets all named colors from the UIColor class as a list of tuples containing the color name and its RGBA Vector4 value.
    /// </summary>
    /// <returns>A list of tuples where each tuple contains the field name and its corresponding RGBA Vector4 color value.</returns>
    public static List<(string name, Vector4 color)> GetUIColors() => GetValues(typeof(UIColor));

    private static List<(string name, Vector4 obj)> GetValues(Type type)
    {
        var fileds = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        List<(string, Vector4)> ret = [];
        foreach (var field in fileds)
        {
            if (field.FieldType == typeof(Vector4) && field.GetValue(null) is Vector4 obj)
            {
                ret.Add((field.Name, obj));
            }
        }
        return ret;
    }
}
