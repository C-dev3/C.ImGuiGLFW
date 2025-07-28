using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Text.NotoEmojis;

public static class NotoEmojiExtentions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconString(this NotoEmoji icon)
    {
        var value = (int)icon;
        if (value <= 0xFFFF) return ((char)value).ToString();
        return char.ConvertFromUtf32(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToIconChar(this NotoEmoji icon) => char.ConvertFromUtf32((int)icon);

    public static readonly uint[] GlyphRange =
        [
        (uint)Enum.GetValues<NotoEmoji>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<NotoEmoji>().Where(x => x > 0).Max(),
        0
        ];
}
