using System.Runtime.CompilerServices;
using System.Text;

namespace C.ImGuiGLFW;

public static class Utility
{
    public static unsafe string PtrToUtf8String(byte* ptr)
    {
        if (ptr == null) return string.Empty;
        int len = 0;
        byte* temp = ptr;
        while (*temp != 0)
        {
            len++;
            temp++;
        }
        return Encoding.UTF8.GetString(ptr, len);
    }

    internal static bool HasConsoleWindow()
    {
        try
        {
            var _ = Console.WindowWidth;
            return true;
        }
        catch (IOException)
        {
            return false;
        }
        catch (PlatformNotSupportedException)
        {
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsAny<T>(this T obj, params T[] values) => values.Any(x => x?.Equals(obj) ?? false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsAny<T>(this T obj, IEnumerable<T> values) => values.Any(x => x?.Equals(obj) ?? false);
}
