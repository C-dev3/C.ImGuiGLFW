using System.Data;
using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Text.SeIcon;

public static class SeIconCharExtentions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToIconChar(this SeIconChar icon) => (char)icon;

    public static string ToIconString(this SeIconChar icon) => string.Empty + (char)icon;

    public static readonly uint[] GlyphRange =
    [
        (uint)Enum.GetValues<SeIconChar>().Where(x => x > 0).Min(),
        (uint)Enum.GetValues<SeIconChar>().Where(x => x > 0).Max(),
        0
    ];
}
