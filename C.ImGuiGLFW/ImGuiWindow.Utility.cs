using C.ImGuiGLFW.Manager;
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

    internal static void RequestViewportScreenshot(string filePath, int x = 0, int y = 0, int? width = null, int? height = null)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File must be not null");

        ImGuiViewportPtr viewport = ImGui.GetWindowViewport();

        int viewportWidth = (int)viewport.Size.X;
        int viewportHeight = (int)viewport.Size.Y;

        int captureWidth = width ?? viewportWidth;
        int captureHeight = height ?? viewportHeight;

        Utility.ValidateRegion(x, y, captureWidth, captureHeight, viewportWidth, viewportHeight, "Viewport");

        ImGuiManager._pendingCapture.Enqueue(new CaptureRequest()
        {
            filePath = filePath,
            ViewportID = viewport.ID,
            X = x,
            Y = y,
            Width = captureWidth,
            Height = captureHeight,
        });
    }

    internal static void RequestMainViewportScreenshot(string filePath, int x = 0, int y = 0, int? width = null, int? height = null)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File must be not null");

        ImGuiViewportPtr viewport = ImGui.GetMainViewport();

        int viewportWidth = (int)viewport.Size.X;
        int viewportHeight = (int)viewport.Size.Y;

        int captureWidth = width ?? viewportWidth;
        int captureHeight = height ?? viewportHeight;

        Utility.ValidateRegion(x, y, captureWidth, captureHeight, viewportWidth, viewportHeight, "MainViewport");

        ImGuiManager._pendingCapture.Enqueue(new CaptureRequest()
        {
            filePath = filePath,
            ViewportID = viewport.ID,
            X = x,
            Y = y,
            Width = captureWidth,
            Height = captureHeight,
        });
    }
}
