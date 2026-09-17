using C.ImGuiGLFW.Color;
using C.ImGuiGLFW.Data;
using C.ImGuiGLFW.ImGuiMethods;
using C.ImGuiGLFW.ImGuiMethods.Tab;
using Serilog;
using Serilog.Events;
using System.Collections.Concurrent;

namespace C.ImGuiGLFW.Logging;

/// <summary>
/// Provides an internal logging system with message storage, filtering, and ImGui rendering capabilities.
/// </summary>
/// <remarks>
/// The <see cref="InternalLog"/> class is a static logging utility designed to collect log messages of various severity levels in a fixed-size circular buffer.
/// It supports filtering messages by log level, autoscrolling, and provides a graphical user interface rendering method compatible with ImGui.
/// This class is intended for internal diagnostic and debugging purposes within an ImGui GLFW environment.
/// </remarks>
public class InternalLog
{
    private static int MaxLogCount = 1000;

    /// <summary>
    /// The circular buffer holding the logged messages, with a capacity of 1000 messages.
    /// </summary>
    public static readonly CircularBuffer<LogMessage> Messages = new(MaxLogCount);
    private static ConcurrentQueue<LogMessage> PendingLogs = [];

    private static void Log(string message, LogEventLevel level) => PendingLogs.Enqueue(new LogMessage(message, level));

    /// <summary>
    /// Logs a message with verbose level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Verbose(string message) => Log(message, LogEventLevel.Verbose);

    /// <summary>
    /// Logs a message with debug level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Debug(string message) => Log(message, LogEventLevel.Debug);

    /// <summary>
    /// Logs a message with information level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Information(string message) => Log(message, LogEventLevel.Information);

    /// <summary>
    /// Logs a message with warning level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Warning(string message) => Log(message, LogEventLevel.Warning);

    /// <summary>
    /// Logs a message with error level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Error(string message) => Log(message, LogEventLevel.Error);

    /// <summary>
    /// Logs a message with fatal level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Fatal(string message) => Log(message, LogEventLevel.Fatal);

    /// <summary>
    /// Clears all stored log messages.
    /// </summary>
    public static void Clear()
    {
        PendingLogs.Clear();
        Messages.Clear();
    }

    /// <summary>
    /// Provides an ImGui tab descriptor for rendering the internal log window.
    /// </summary>
    /// <param name="draw">If true, the tab should be drawn; otherwise null is returned.</param>
    /// <returns>
    /// A tuple containing the tab label (or null), the draw action delegate, optional tab color, and a boolean indicating 
    /// if the tab is closable.
    /// </returns>
    public static (string?, Action, Vector4?, bool) ImGuiTab(bool draw = true) => (draw ? "Log" : null, PrintImGui, null, false);

    /// <summary>
    /// Creates a console tab configuration for use with CTabBar.
    /// </summary>
    /// <param name="draw">If true, creates a tab with the title "Log" and its rendering action. If false, returns null for the tab title to skip this tab. Default is true.</param>
    /// <returns>A tuple containing the tab title (or null if draw is false) and the PrintImGui action for rendering the console content when the tab is active.</returns>
    /// <remarks>
    /// This helper method is designed to work with <see cref="CTabBar.BeginTabBar(string, Vector2, ValueTuple{string, Action}[])"/>
    /// to easily add a console/log tab to a tab bar. When draw is false, the returned null title will cause
    /// the tab to be skipped during tab bar creation.
    /// </remarks>
    public static (string?, Action) CTab(bool draw = true) => (draw ? "Log" : null, PrintImGui);

    private static string Search = string.Empty;
    private static bool Autoscroll = true;
    private static FilterType FilterType = FilterType.Default;

    private const int ButtonMod = -30;
    private static float prevScrollY = -1f;
    private const string FilterPopupName = "filter_window";

    /// <summary>
    /// Renders the ImGui interface for the internal log, including controls for autoscroll, filtering, clearing, and displaying messages.
    /// </summary>
    public static void PrintImGui()
    {
        int processed = 0;

        while (processed < MaxLogCount && PendingLogs.TryDequeue(out var entry))
        {
            Messages.PushBack(entry);
            processed++;
        }

        bool prevAutoScroll = Autoscroll;
        ImGui.Checkbox("##Autoscroll", ref Autoscroll);
        ImGuiC.Tooltip("Autoscroll");
        bool userJustEnabledAutoScroll = Autoscroll && !prevAutoScroll;
        ImGui.SameLine();
        if (ImGui.Button("Clear"))
        {
            PendingLogs.Clear();
            Messages.Clear();
        }
        ImGui.SameLine();
        ImGuiC.SetNextItemFullWidth(ButtonMod);
        ImGui.InputTextWithHint("##Filter", "Filter...", ref Search, 100);
        ImGui.SameLine();
        if (ImGuiC.IconButton(Text.FontAwesome.FontAwesomeIcon.Filter, "##LogFilter")) ImGui.OpenPopup(FilterPopupName);

        if (ImGui.BeginPopup(FilterPopupName, ImGuiWindowFlags.NoMove | ImGuiWindowFlags.Popup))
        {
            DrawFilterPopup();
            ImGui.EndPopup();
        }

        ImGui.BeginChild("InternalLogs", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Borders);
        foreach (var message in Messages)
        {
            if (!ShouldDisplayLog(message.Level)) continue;
            var color = GetTextColor(message.Level);
            if (Search == string.Empty || message.Level.ToString().Equals(Search, StringComparison.OrdinalIgnoreCase) || message.Message.Contains(Search, StringComparison.OrdinalIgnoreCase))
                ImGuiC.TextWrappedCopy(color, $"> [{message.TimeStr}] {message.Message}");
        }

        const float ScrollEpsilon = 1f;
        float scrollY = ImGui.GetScrollY();
        float scrollMaxY = ImGui.GetScrollMaxY();
        bool atBottom = scrollMaxY <= 0f || scrollY >= scrollMaxY - ScrollEpsilon;
        bool wasAtBottom = scrollMaxY <= 0f || prevScrollY >= scrollMaxY - ScrollEpsilon;

        if (Autoscroll)
        {
            if (!atBottom && !userJustEnabledAutoScroll)
            {
                Autoscroll = false;
            }
            else
            {
                ImGui.SetScrollHereY(1.0f);
            }
        }
        else
        {
            if (atBottom && !wasAtBottom)
            {
                Autoscroll = true;
            }
        }

        prevScrollY = scrollY;

        ImGui.EndChild();
    }

    private static void DrawFilterPopup()
    {
        static void FlagCheckbox(string label, FilterType flag)
        {
            var b = FilterType.HasFlag(flag);
            if (!ImGui.Checkbox(label, ref b))
                return;
            if (b)
                FilterType |= flag;
            else
                FilterType &= ~flag;
        }
        FlagCheckbox("Verbose", FilterType.Verbose);
        FlagCheckbox("Debug", FilterType.Debug);
        FlagCheckbox("Information", FilterType.Info);
        FlagCheckbox("Warning", FilterType.Warning);
        FlagCheckbox("Error", FilterType.Error);
        FlagCheckbox("Fatal", FilterType.Fatal);
    }

    private static bool ShouldDisplayLog(LogEventLevel level)
    {
        switch (level)
        {
            case LogEventLevel.Verbose:
                if (FilterType.HasFlag(FilterType.Verbose)) return true;
                break;
            case LogEventLevel.Debug:
                if (FilterType.HasFlag(FilterType.Debug)) return true;
                break;
            case LogEventLevel.Information:
                if (FilterType.HasFlag(FilterType.Info)) return true;
                break;
            case LogEventLevel.Warning:
                if (FilterType.HasFlag(FilterType.Warning)) return true;
                break;
            case LogEventLevel.Error:
                if (FilterType.HasFlag(FilterType.Error)) return true;
                break;
            case LogEventLevel.Fatal:
                if (FilterType.HasFlag(FilterType.Fatal)) return true;
                break;
            default:
                break;
        }
        return false;
    }

    private static readonly Vector4 ErrorColor = new(1f, 0f, 0f, 1f);
    private static readonly Vector4 WarningColor = new(1f, 0.709f, 0f, 1f);
    private static readonly Vector4 DebugColor = new(0.7f, 0.7f, 0.7f, 1f);

    private static Vector4 GetTextColor(LogEventLevel level) => level switch
    {
        LogEventLevel.Error => ErrorColor,
        LogEventLevel.Warning => WarningColor,
        LogEventLevel.Debug or LogEventLevel.Verbose => DebugColor,
        _ => EzColor.White,
    };
}
