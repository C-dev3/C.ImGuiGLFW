namespace C.ImGuiGLFW.Color;

/// <summary>
/// Provides a collection of predefined colors as Vector4 values for easy use in graphics and UI applications.
/// All colors are converted from 32-bit RGBA values to Vector4 format using the U32ToFloat4() extension method.
/// </summary>
public static class EzColor
{
    /// <summary>
    /// Gets a bright red color (RGB: 255, 0, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 RedBright = 0xFF0000FF.U32ToFloat4();

    /// <summary>
    /// Gets a standard red color (RGB: 255, 0, 0, Alpha: 170).
    /// </summary>
    public static readonly Vector4 Red = 0xFF0000AA.U32ToFloat4();

    /// <summary>
    /// Gets a dark red color (RGB: 255, 0, 0, Alpha: 68).
    /// </summary>
    public static readonly Vector4 RedDark = 0xFF000044.U32ToFloat4();

    /// <summary>
    /// Gets a bright green color (RGB: 0, 255, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 GreenBright = 0xFF00FF00.U32ToFloat4();

    /// <summary>
    /// Gets a standard green color (RGB: 0, 170, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Green = 0xFF00AA00.U32ToFloat4();

    /// <summary>
    /// Gets a dark green color (RGB: 0, 68, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 GreenDark = 0xFF004400.U32ToFloat4();

    /// <summary>
    /// Gets a bright blue color (RGB: 0, 0, 255, Alpha: 255).
    /// </summary>
    public static readonly Vector4 BlueBright = 0xFFFF0000.U32ToFloat4();

    /// <summary>
    /// Gets a standard blue color (RGB: 0, 0, 170, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Blue = 0xFFAA0000.U32ToFloat4();

    /// <summary>
    /// Gets a white color (RGB: 255, 255, 255, Alpha: 255).
    /// </summary>
    public static readonly Vector4 White = 0xFFFFFFFF.U32ToFloat4();

    /// <summary>
    /// Gets a black color (RGB: 0, 0, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Black = 0xFF000000.U32ToFloat4();

    /// <summary>
    /// Gets a bright yellow color (RGB: 255, 255, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 YellowBright = 0xFF00FFFF.U32ToFloat4();

    /// <summary>
    /// Gets a standard yellow color (RGB: 170, 170, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Yellow = 0xFF00AAAA.U32ToFloat4();

    /// <summary>
    /// Gets a dark yellow color (RGB: 68, 68, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 YellowDark = 0xFF004444.U32ToFloat4();

    /// <summary>
    /// Gets a bright orange color (RGB: 255, 127, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 OrangeBright = 0xFF007FFF.U32ToFloat4();

    /// <summary>
    /// Gets a standard orange color (RGB: 170, 84, 0, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Orange = 0xFF0054AA.U32ToFloat4();

    /// <summary>
    /// Gets a bright cyan color (RGB: 0, 255, 255, Alpha: 255).
    /// </summary>
    public static readonly Vector4 CyanBright = 0xFFFFFF00.U32ToFloat4();

    /// <summary>
    /// Gets a standard cyan color (RGB: 0, 170, 170, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Cyan = 0xFFAAAA00.U32ToFloat4();

    /// <summary>
    /// Gets a bright violet color (RGB: 255, 0, 255, Alpha: 255).
    /// </summary>
    public static readonly Vector4 VioletBright = 0xFFFF00FF.U32ToFloat4();

    /// <summary>
    /// Gets a standard violet color (RGB: 170, 0, 170, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Violet = 0xFFAA00AA.U32ToFloat4();

    /// <summary>
    /// Gets a dark violet color (RGB: 68, 0, 68, Alpha: 255).
    /// </summary>
    public static readonly Vector4 VioletDark = 0xFF440044.U32ToFloat4();

    /// <summary>
    /// Gets a sky blue color (RGB: 0, 133, 255, Alpha: 255).
    /// </summary>
    public static readonly Vector4 BlueSky = 0xFFFF8500.U32ToFloat4();

    /// <summary>
    /// Gets a sea blue color (RGB: 0, 88, 170, Alpha: 255).
    /// </summary>
    public static readonly Vector4 BlueSea = 0xFFAA5800.U32ToFloat4();

    /// <summary>
    /// Gets a bright purple color (RGB: 132, 0, 255, Alpha: 255).
    /// </summary>
    public static readonly Vector4 PurpleBright = 0xFF8400FF.U32ToFloat4();

    /// <summary>
    /// Gets a standard purple color (RGB: 88, 0, 170, Alpha: 255).
    /// </summary>
    public static readonly Vector4 Purple = 0xFF5800AA.U32ToFloat4();

    /// <summary>
    /// Gets a light pink color (RGB: 255, 171, 214, Alpha: 255).
    /// </summary>
    public static readonly Vector4 PinkLight = 0xFFD6ABFF.U32ToFloat4();

    /// <summary>
    /// Gets a completely transparent color (RGB: 0, 0, 0, Alpha: 0).
    /// </summary>
    public static readonly Vector4 Transparent = 0x00000000u.U32ToFloat4();
}
