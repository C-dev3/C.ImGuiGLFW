using C.ImGuiGLFW.Color;
using C.ImGuiGLFW.Data;
using C.ImGuiGLFW.ImGuiMethods;
using Serilog.Events;

namespace C.ImGuiGLFW.Logging;

public class InternalLog
{
    public static readonly CircularBuffer<LogMessage> Messages = new(1000);

    public static void Verbose(string message) => Messages.PushBack(new LogMessage(message, LogEventLevel.Verbose));

    public static void Debug(string message) => Messages.PushBack(new LogMessage(message, LogEventLevel.Debug));

    public static void Information(string message) => Messages.PushBack(new LogMessage(message));

    public static void Warning(string message) => Messages.PushBack(new LogMessage(message, LogEventLevel.Warning));

    public static void Error(string message) => Messages.PushBack(new LogMessage(message, LogEventLevel.Error));

    public static void Fatal(string message) => Messages.PushBack(new LogMessage(message, LogEventLevel.Fatal));

    public static void Clear() => Messages.Clear();

    public static (string?, Action, Vector4?, bool) ImGuiTab(bool draw = true) => (draw ? "Log" : null, PrintImGui, null, false);

    private static string Search = string.Empty;
    private static bool Autoscroll = true;
    private static FilterType FilterType = FilterType.Default;

    private const int ButtonMod = -30;
    private const string FilterPopupName = "filter_window";

    public static void PrintImGui()
    {
        ImGui.Checkbox("##Autoscroll", ref Autoscroll);
        ImGuiC.Tooltip("Autoscroll");
        ImGui.SameLine();
        if (ImGui.Button("Clear")) Messages.Clear();
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
        if (Autoscroll) ImGui.SetScrollHereY();
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

    private static Vector4 GetTextColor(LogEventLevel level)
    {
        return level switch
        {
            LogEventLevel.Error => ErrorColor,
            LogEventLevel.Warning => WarningColor,
            LogEventLevel.Debug or LogEventLevel.Verbose => DebugColor,
            _ => EzColor.White,
        };
    }
}
