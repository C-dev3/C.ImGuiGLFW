using C.ImGuiGLFW.ImGuiMethods;
using System.Runtime.InteropServices;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
    private readonly List<Window> windows = [];
    private readonly Dictionary<Type, int> windowIds = [];
    private readonly HashSet<Window> setupCompletedWindows = [];
    private readonly List<Action> postDraw = [];

    private void InternalDraw()
    {
        if (!ready || windows.Count == 0)
        {
            var pos = imGuiManager.iOPtr.ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable) ? Position : Vector2.Zero;
            ImGui.SetNextWindowPos(pos);
            ImGui.SetNextWindowSize(ImGui.GetIO().DisplaySize);

            if (ImGui.Begin("Loading"u8, ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.AlwaysAutoResize))
            {
                double time = ImGui.GetTime();
                int dotCount = (int)(time * 3) % 4;
                string dots = new('.', dotCount);
                string text = LoadingText + dots;

                var textSize = ImGui.CalcTextSize(text);
                var windowSize = ImGui.GetWindowSize();

                var cursorPos = new Vector2(
                    (windowSize.X - textSize.X) / 2,
                    (windowSize.Y - textSize.Y) / 2
                );
                ImGui.SetCursorPos(cursorPos);
                ImGui.TextUnformatted(text);

                ImGui.End();
            }
        }

        ModalHelper.RenderModals();

        if (_onMainMenuBarRenderCallback != null)
        {
            if (ImGui.BeginMainMenuBar())
            {
                _onMainMenuBarRenderCallback.Invoke();
                ImGui.EndMainMenuBar();
            }
        }

        var sortedWindows = windows
            .OrderByDescending(w => w.Priority)
            .ThenBy(w => w.Name)
            .ToList();

        foreach (var window in sortedWindows)
        {
            if (ready && !setupCompletedWindows.Contains(window))
            {
                window.OnLoad();
                setupCompletedWindows.Add(window);
            }
            window.InternalDraw();
        }

        if (postDraw.Count > 0)
        {
            foreach (var ac in postDraw)
                ac();
            postDraw.Clear();
        }
    }

    /// <summary>
    /// Adds an action to be executed after all windows have been drawn in the current frame.
    /// </summary>
    /// <param name="action">The action to execute after drawing.</param>
    public static void AddPostdrawAction(Action action) => Instance.postDraw.Add(action);

    /// <summary>
    /// Adds a window to the ImGuiController for rendering and management.
    /// </summary>
    /// <param name="window">The window to add.</param>
    /// <param name="isOpen">Whether the window should be initially open.</param>
    public static void AddWindow(Window window, bool isOpen = true)
    {
        SetId(window);
        Instance.windows.Add(window);
        window.IsOpen = isOpen;
    }

    private static void SetId(Window window)
    {
        var windowType = window.GetType();
        ref var id = ref CollectionsMarshal.GetValueRefOrAddDefault(Instance.windowIds, windowType, out _);
        window.Id = ++id;
    }

    /// <summary>
    /// Removes a window from the ImGuiController. The removal is deferred until after the current frame.
    /// </summary>
    /// <param name="window">The window to remove.</param>
    public static void RemoveWindow(Window window) => Instance.postDraw.Add(() =>
                                                           {
                                                               if (Instance.windows.Remove(window))
                                                               {
                                                                   Instance.setupCompletedWindows.Remove(window);
                                                                   window.OnClose();
                                                               }
                                                           });

    /// <summary>
    /// Removes all windows from the ImGuiController.
    /// </summary>
    public static void RemoveAllWindows() => Instance.windows.Clear();

    /// <summary>
    /// Writes the current window settings to file.
    /// </summary>
    /// <returns>True if the settings were successfully written; otherwise, false.</returns>
    public static bool WriteWindowSettings() => Instance.WindowSettings.Write();
}
