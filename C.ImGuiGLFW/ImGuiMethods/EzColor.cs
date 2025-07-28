namespace C.ImGuiGLFW.ImGuiMethods;

public static class EzColor
{
    public static Vector4 U32ToFloat4(this uint input) => ImGui.ColorConvertU32ToFloat4(input);
    public static uint Float4ToU32(this Vector4 input) => ImGui.ColorConvertFloat4ToU32(input);

    public static readonly Vector4 RedBright = 0xFF0000FF.U32ToFloat4();
    public static readonly Vector4 Red = 0xAA0000FF.U32ToFloat4();
    public static readonly Vector4 RedDark = U32ToFloat4(0x440000FF);
    public static readonly Vector4 GreenBright = U32ToFloat4(0x00FF00FF);
    public static readonly Vector4 Green = U32ToFloat4(0x00AA00FF);
    public static readonly Vector4 GreenDark = U32ToFloat4(0x004400FF);
    public static readonly Vector4 BlueBright = U32ToFloat4(0x0000ffFF);
    public static readonly Vector4 Blue = U32ToFloat4(0x0000AAFF);
    public static readonly Vector4 White = 0xFFFFFFFF.U32ToFloat4();
    public static readonly Vector4 Black = U32ToFloat4(0x000000FF);
    public static readonly Vector4 YellowBright = 0xFFFF00FF.U32ToFloat4();
    public static readonly Vector4 Yellow = 0xAAAA00FF.U32ToFloat4();
    public static readonly Vector4 YellowDark = U32ToFloat4(0x444400FF);
    public static readonly Vector4 OrangeBright = 0xFF7F00FF.U32ToFloat4();
    public static readonly Vector4 Orange = 0xAA5400FF.U32ToFloat4();
    public static readonly Vector4 CyanBright = U32ToFloat4(0x00FFFFFF);
    public static readonly Vector4 Cyan = U32ToFloat4(0x00AAAAFF);
    public static readonly Vector4 VioletBright = 0xFF00FFFF.U32ToFloat4();
    public static readonly Vector4 Violet = 0xAA00AAFF.U32ToFloat4();
    public static readonly Vector4 VioletDark = U32ToFloat4(0x440044FF);
    public static readonly Vector4 BlueSky = U32ToFloat4(0x0085FFFF);
    public static readonly Vector4 BlueSea = U32ToFloat4(0x0058AAFF);
    public static readonly Vector4 PurpleBright = 0xFF0084FF.U32ToFloat4();
    public static readonly Vector4 Purple = 0xAA0058FF.U32ToFloat4();
    public static readonly Vector4 PinkLight = 0xFFABD6FF.U32ToFloat4();

    public static readonly Vector4 Gray = new(0.627f, 0.627f, 0.627f, 1);
    public static readonly Vector4 WhiteText = new(0.933f, 0.882f, 0.773f, 1);
    public static readonly Vector4 GreenText = new(0.459f, 0.733f, 0, 1);
    public static readonly Vector4 PinkText = new(0.757f, 0.482f, 0.718f, 1);
}

public static class MaterialColors
{
    public static readonly Vector4 Primary = new(0.38f, 0.48f, 0.96f, 1.0f);
    public static readonly Vector4 PrimaryVariant = new(0.24f, 0.32f, 0.71f, 1.0f);
    public static readonly Vector4 Secondary = new(0.02f, 0.66f, 0.56f, 1.0f);
    public static readonly Vector4 Surface = new(1.0f, 1.0f, 1.0f, 1.0f);
    public static readonly Vector4 Background = new(0.98f, 0.98f, 0.98f, 1.0f);
    public static readonly Vector4 Error = new(0.73f, 0.17f, 0.18f, 1.0f);
    public static readonly Vector4 OnPrimary = new(1.0f, 1.0f, 1.0f, 1.0f);
    public static readonly Vector4 OnSurface = new(0.13f, 0.13f, 0.13f, 1.0f);
    public static readonly Vector4 OnBackground = new(0.13f, 0.13f, 0.13f, 1.0f);
    public static readonly Vector4 Outline = new(0.46f, 0.46f, 0.46f, 1.0f);
    public static readonly Vector4 Shadow = new(0.0f, 0.0f, 0.0f, 0.2f);
}
