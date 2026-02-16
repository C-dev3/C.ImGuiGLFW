using Hexa.NET.GLFW;
using System.Runtime.InteropServices;
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

    internal static void FlipVerticallyBytes(byte[] pixels, int width, int height)
    {
        const int comp = 4; // RGBA
        int stride = width * comp;
        byte[] lineTmp = new byte[stride];

        int lineA = 0;
        int lineB = stride * (height - 1);

        while (lineA < lineB)
        {
            Array.Copy(pixels, lineA, lineTmp, 0, stride);
            Array.Copy(pixels, lineB, pixels, lineA, stride);
            Array.Copy(lineTmp, 0, pixels, lineB, stride);

            lineA += stride;
            lineB -= stride;
        }
    }

    internal static unsafe bool SetViewportContext(ImGuiViewportPtr viewport)
    {
        if ((IntPtr)viewport.PlatformHandle != IntPtr.Zero)
        {
            GLFW.MakeContextCurrent((GLFWwindowPtr)viewport.PlatformHandle);
            return true;
        }
        return false;
    }

    internal static byte[] CaptureFramebuffer(int x, int y, int width, int height, ImGuiViewportPtr viewport)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Thread.Sleep(1);
        }

        int viewportHeight = (int)viewport.Size.Y;
        int y2 = viewportHeight - (y + height);

        byte[] pixels = ImGuiController.ReadPixelRegionBytes(x, y2, width, height);

        FlipVerticallyBytes(pixels, width, height);
        return pixels;
    }

    internal static ImGuiViewportPtr FindViewport(uint viewportID)
    {
        unsafe
        {
            ImGuiPlatformIOPtr platformIO = ImGui.GetPlatformIO();

            for (int i = 0; i < platformIO.Viewports.Size; i++)
            {
                if (viewportID == platformIO.Viewports[i].ID)
                    return platformIO.Viewports[i];
            }
        }

        return default;
    }

    internal static void ValidateRegion(int x, int y, int width, int height, int maxWidth, int maxHeight, string regionName)
    {
        if (x < 0)
            throw new ArgumentOutOfRangeException(nameof(x), $"X coordinate must be 0 or greater: {x}");
        if (y < 0)
            throw new ArgumentOutOfRangeException(nameof(y), $"Y coordinate must be 0 or greater: {y}");
        if (width <= 0)
            throw new ArgumentOutOfRangeException(nameof(width), $"Width must be 1 or greater: {width}");
        if (height <= 0)
            throw new ArgumentOutOfRangeException(nameof(height), $"Height must be 1 or greater: {height}");
        if (x >= maxWidth)
            throw new ArgumentOutOfRangeException(nameof(x),
                $"X coordinate is outside the {regionName} bounds: x={x}, {regionName} width={maxWidth}");
        if (y >= maxHeight)
            throw new ArgumentOutOfRangeException(nameof(y),
                $"Y coordinate is outside the {regionName} bounds: y={y}, {regionName} height={maxHeight}");
        if (x + width > maxWidth)
            throw new ArgumentOutOfRangeException(nameof(width),
                $"Crop region exceeds {regionName} width: x={x}, width={width}, {regionName} width={maxWidth}");
        if (y + height > maxHeight)
            throw new ArgumentOutOfRangeException(nameof(height),
                $"Crop region exceeds {regionName} height: y={y}, height={height}, {regionName} height={maxHeight}");
    }
}
