using Hexa.NET.GLFW;

namespace C.ImGuiGLFW;

/// <summary>
/// Provides utilities for retrieving display-related information from the system.
/// </summary>
/// <remarks>
/// This class uses GLFW to interact with system monitors and retrieve their properties.
/// All methods are static and the class cannot be instantiated.
/// </remarks>
public static class Display
{
    /// <summary>
    /// Gets the refresh rate of the specified display monitor.
    /// </summary>
    /// <param name="displayIndex">The zero-based index of the display monitor to query.</param>
    /// <returns>
    /// The refresh rate of the specified display in Hz. Returns 60 Hz as a fallback value 
    /// if the monitor is not found or the refresh rate cannot be determined.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no monitors are found, or when the specified display index is out of range.
    /// </exception>
    /// <remarks>
    /// This method uses GLFW to enumerate available monitors and retrieve video mode information.
    /// The display index is zero-based, where 0 represents the primary display.
    /// If the video mode cannot be retrieved or contains invalid data, a default refresh rate 
    /// of 60 Hz is returned to ensure stable operation.
    /// </remarks>
    public static int GetDesktopRefreshRate(int displayIndex)
    {
        int count = 0;
        var monitors = GLFW.GetMonitors(ref count);

        if (monitors.IsNull || count == 0) throw new InvalidOperationException("Monitor not found.");

        if (count < 0 || displayIndex > count) throw new InvalidOperationException($"Invalid Display index : vallid index is 0 - {count}");

        unsafe
        {
            var monitor = (GLFWmonitorPtr)monitors[displayIndex];
            if (monitor.IsNull) return 60;

            var videoMode = GLFW.GetVideoMode(monitor);

            if (videoMode.IsNull || videoMode.RefreshRate <= 0) return 60;

            return videoMode.RefreshRate;
        }
    }
}
