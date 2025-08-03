using System.Runtime.CompilerServices;
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
}
