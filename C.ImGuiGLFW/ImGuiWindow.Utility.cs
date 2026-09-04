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

    internal static void CaptureViewport(string filePath, int x = 0, int y = 0, int? width = null, int? height = null)
    => EnqueueCapture(ImGui.GetWindowViewport(), "Viewport", filePath, x, y, width, height, setClipboard: false);

    internal static void CaptureMainViewport(string filePath, int x = 0, int y = 0, int? width = null, int? height = null)
        => EnqueueCapture(ImGui.GetMainViewport(), "MainViewport", filePath, x, y, width, height, setClipboard: false);

    internal static void CaptureViewportToClipboard(string? filePath = null, int x = 0, int y = 0, int? width = null, int? height = null)
        => EnqueueCapture(ImGui.GetWindowViewport(), "Viewport", filePath, x, y, width, height, setClipboard: true);

    internal static void CaptureMainViewportToClipboard(string? filePath = null, int x = 0, int y = 0, int? width = null, int? height = null)
        => EnqueueCapture(ImGui.GetMainViewport(), "MainViewport", filePath, x, y, width, height, setClipboard: true);

    private static void EnqueueCapture(ImGuiViewportPtr viewport, string label, string? filePath, int x, int y, int? width, int? height, bool setClipboard)
    {
        if (!setClipboard && string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File must be not null");

        int viewportWidth = (int)viewport.Size.X;
        int viewportHeight = (int)viewport.Size.Y;

        int captureWidth = width ?? viewportWidth;
        int captureHeight = height ?? viewportHeight;

        Utility.ValidateRegion(x, y, captureWidth, captureHeight, viewportWidth, viewportHeight, label);

        ImGuiManager._pendingCapture.Enqueue(new CaptureRequest()
        {
            filePath = filePath!,
            ViewportID = viewport.ID,
            X = x,
            Y = y,
            Width = captureWidth,
            Height = captureHeight,
            SetClipboard = setClipboard,
        });
    }
}
