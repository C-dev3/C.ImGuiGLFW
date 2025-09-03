using Hexa.NET.GLFW;
using Serilog;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
    internal static unsafe int GetCurrentWindowIndex()
    {
        if (Instance.window.IsNull) return -1;

        try
        {
            int windowX = 0, windowY = 0;
            GLFW.GetWindowPos(Instance.window, ref windowX, ref windowY);

            int windowWidth = 0, windowHeight = 0;
            GLFW.GetWindowSize(Instance.window, ref windowWidth, ref windowHeight);

            int count = 0;
            var monitors = GLFW.GetMonitors(ref count);
            int monitorIndex = -1;
            int maxOverlapArea = 0;

            for (int i = 0; i < count; ++i)
            {
                var monitor = monitors[i];

                int monitorX = 0, monitorY = 0;
                GLFW.GetMonitorPos(monitor, ref monitorX, ref monitorY);
                var videoMode = GLFW.GetVideoMode(monitor);
                int monitorWidth = videoMode.Width;
                int monitorHeight = videoMode.Height;

                int overlapArea = Utility.CalculateIntersectionArea(
                    windowX, windowY, windowWidth, windowHeight,
                    monitorX, monitorY, monitorWidth, monitorHeight);

                if (overlapArea > maxOverlapArea)
                {
                    maxOverlapArea = overlapArea;
                    monitorIndex = i;
                }
            }

            return monitorIndex;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to get monitor index");
            return -1;
        }
    }
}
