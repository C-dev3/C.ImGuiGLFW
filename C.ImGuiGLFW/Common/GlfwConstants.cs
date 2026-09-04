namespace C.ImGuiGLFW.Common;

internal static class GlfwConstants
{
    // Input mode
    public const int Cursor = 0x00033001; // GLFW_CURSOR

    // Cursor mode values (for GLFW_CURSOR)
    public const int CursorNormal = 0x00034001;
    public const int CursorHidden = 0x00034002;
    public const int CursorDisabled = 0x00034003;

    // Standard cursor shapes
    public const int ArrowCursor = 0x00036001;
    public const int IBeamCursor = 0x00036002;
    public const int CrosshairCursor = 0x00036003;
    public const int HandCursor = 0x00036004;
    public const int HResizeCursor = 0x00036005;
    public const int VResizeCursor = 0x00036006;
    public const int ResizeAllCursor = 0x00036008;
    public const int ResizeNESWCursor = 0x00036009;
    public const int ResizeNWSECursor = 0x0003600A;
    public const int NotAllowedCursor = 0x0003600B;
}
