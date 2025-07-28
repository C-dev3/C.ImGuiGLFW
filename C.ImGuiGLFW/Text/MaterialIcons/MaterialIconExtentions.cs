using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Text.MaterialIcons;

public static class MaterialIconExtentions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconString(this MaterialIcon icon)
    {
        var value = (int)icon;
        if (value <= 0xFFFF) return ((char)value).ToString();
        return char.ConvertFromUtf32(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconChar(this MaterialIcon icon) => char.ConvertFromUtf32((int)icon);

    public static readonly uint[] GlyphRange =
    [
        (uint)Enum.GetValues<MaterialIcon>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<MaterialIcon>().Where(x => x > 0).Max(),
        0
    ];
}
