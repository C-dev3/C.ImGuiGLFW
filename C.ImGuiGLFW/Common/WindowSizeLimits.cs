namespace C.ImGuiGLFW.Common;

public struct WindowSizeLimits(int minWidth, int minHeight, int maxWidth, int maxHeight)
{
    public int MinWidth { readonly get; set; } = minWidth;
    public int MinHeight { readonly get; set; } = minHeight;
    public int MaxWidth { readonly get; set; } = maxWidth;
    public int MaxHeight { readonly get; set; } = maxHeight;

    public readonly bool Equals(WindowSizeLimits source) => MinWidth == source.MinWidth && MinHeight == source.MinHeight &&
               MaxWidth == source.MaxWidth && MaxHeight == source.MaxHeight;
}
