using System.Text;

namespace C.ImGuiGLFW;

/// <summary>
/// Provides utility methods for general use within the application.
/// </summary>
public static class Utility
{
    /// <summary>
    /// Converts a null-terminated UTF-8 encoded byte pointer to a managed <see cref="string"/>.
    /// </summary>
    /// <param name="ptr">A pointer to the start of a UTF-8 encoded null-terminated byte sequence.</param>
    /// <returns>
    /// The decoded string from the UTF-8 byte sequence.
    /// Returns an empty string if the pointer is null.
    /// </returns>
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

    /// <summary>
    /// Checks whether the current process has an attached console window.
    /// </summary>
    /// <remarks>
    /// This method attempts to access <see cref="Console.WindowWidth"/>,
    /// which throws an exception if no console is attached.
    /// </remarks>
    /// <returns><c>true</c> if a console window is available; otherwise, <c>false</c>.</returns>
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

    /// <summary>
    /// Calculates the intersection area between two rectangles
    /// </summary>
    internal static int CalculateIntersectionArea(
        int x1, int y1, int w1, int h1,
        int x2, int y2, int w2, int h2)
    {
        int left = Math.Max(x1, x2);
        int top = Math.Max(y1, y2);
        int right = Math.Min(x1 + w1, x2 + w2);
        int bottom = Math.Min(y1 + h1, y2 + h2);

        if (right <= left || bottom <= top)
            return 0;

        return (right - left) * (bottom - top);
    }
}
