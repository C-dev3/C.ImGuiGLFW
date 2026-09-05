using C.ImGuiGLFW.Data;
using C.ImGuiGLFW.ImGuiMethods;
using C.ImGuiGLFW.ImGuiMethods.Tab;
using C.ImGuiGLFW.Text.FontAwesome;
using Serilog.Events;

namespace C.ImGuiGLFW.Logging;

/// <summary>
/// Provides an app logging system with message storage, filtering, and ImGui rendering capabilities.
/// </summary>
/// <remarks>
/// The <see cref="AppLog"/> class is a static logging utility designed to collect log messages of various severity levels in a fixed-size circular buffer.
/// It supports filtering messages by log level, autoscrolling, and provides a graphical user interface rendering method compatible with ImGui.
/// This class is intended for internal diagnostic and debugging purposes within an ImGui GLFW environment.
/// </remarks>
public class AppLog
{
    private const int MaxLogCount = 1000;

    private static readonly Dictionary<LogEventLevel, Vector4> LevelColors = new()
    {
        [LogEventLevel.Verbose] = new Vector4(0.43f, 0.43f, 0.43f, 1f),
        [LogEventLevel.Debug] = new Vector4(0.60f, 0.60f, 0.60f, 1f),
        [LogEventLevel.Information] = new Vector4(0.36f, 0.66f, 0.91f, 1f),
        [LogEventLevel.Warning] = new Vector4(0.90f, 0.66f, 0.24f, 1f),
        [LogEventLevel.Error] = new Vector4(0.90f, 0.28f, 0.30f, 1f),
        [LogEventLevel.Fatal] = new Vector4(1.00f, 0.23f, 0.36f, 1f),
    };

    /// <summary>
    /// Sets the display color used in the log viewer UI for a specific log level.
    /// </summary>
    /// <param name="level">The log level whose display color is being set.</param>
    /// <param name="color">The RGBA color to associate with the specified log level.</param>
    public static void SetLevelColor(LogEventLevel level, Vector4 color)
    {
        LevelColors[level] = color;
        isDirty = true;
    }

    internal static Vector4 GetColor(LogEventLevel level) =>
        LevelColors.TryGetValue(level, out var color) ? color : new Vector4(0.7f, 0.7f, 0.7f, 1);

    private static readonly Dictionary<LogEventLevel, Vector4> RowBgColors = new()
    {
        [LogEventLevel.Error] = new Vector4(0.45f, 0.10f, 0.10f, 0.30f),
        [LogEventLevel.Fatal] = new Vector4(0.45f, 0.10f, 0.10f, 0.55f),
    };

    /// <summary>
    /// Sets the row background color used in the log viewer UI for a specific log level.
    /// </summary>
    /// <param name="level">The log level whose row background color is being set.</param>
    /// <param name="color">The RGBA color to use as the row background for the specified log level.</param>
    public static void SetBgColor(LogEventLevel level, Vector4 color) => RowBgColors[level] = color;

    internal static bool TryGetRowBgColor(LogEventLevel level, out Vector4 color) =>
        RowBgColors.TryGetValue(level, out color);

    /// <summary>
    /// Sets the format used to render timestamps for log entries in the log viewer UI.
    /// </summary>
    /// <param name="format">The timestamp format to apply.</param>
    public static void SetTimestampFormat(TimestampFormat format)
    {
        timestampFormat = format;
        isDirty = true;
    }

    private static readonly CircularBuffer<LogEntry> Logs = new(MaxLogCount);

    private static bool isDirty = true;


    internal static void Log(LogEventLevel level, string message, string category = "System")
    {
        Logs.PushBack(new LogEntry(level, message, category));
        isDirty = true;
    }

    /// <summary>
    /// Logs a message at the <see cref="LogEventLevel.Verbose"/> level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="category">The category associated with the log entry. Defaults to "System".</param>
    public static void Verbose(string message, string category = "System") => Log(LogEventLevel.Verbose, message, category);

    /// <summary>
    /// Logs a message at the <see cref="LogEventLevel.Debug"/> level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="category">The category associated with the log entry. Defaults to "System".</param>
    public static void Debug(string message, string category = "System") => Log(LogEventLevel.Debug, message, category);

    /// <summary>
    /// Logs a message at the <see cref="LogEventLevel.Information"/> level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="category">The category associated with the log entry. Defaults to "System".</param>
    public static void Info(string message, string category = "System") => Log(LogEventLevel.Information, message, category);

    /// <summary>
    /// Logs a message at the <see cref="LogEventLevel.Information"/> level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="category">The category associated with the log entry. Defaults to "System".</param>
    public static void Information(string message, string category = "System") => Log(LogEventLevel.Information, message, category);

    /// <summary>
    /// Logs a message at the <see cref="LogEventLevel.Warning"/> level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="category">The category associated with the log entry. Defaults to "System".</param>
    public static void Warning(string message, string category = "System") => Log(LogEventLevel.Warning, message, category);

    /// <summary>
    /// Logs a message at the <see cref="LogEventLevel.Error"/> level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="category">The category associated with the log entry. Defaults to "System".</param>
    public static void Error(string message, string category = "System") => Log(LogEventLevel.Error, message, category);

    /// <summary>
    /// Logs a message at the <see cref="LogEventLevel.Fatal"/> level.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="category">The category associated with the log entry. Defaults to "System".</param>
    public static void Fatal(string message, string category = "System") => Log(LogEventLevel.Fatal, message, category);

    private static readonly List<LogEntry> filteredCache = new(MaxLogCount);
    private static FilterType Filter = FilterType.Default;
    internal static TimestampFormat timestampFormat = TimestampFormat.TimeOnly;
    private static string searchFilter = string.Empty;
    private static bool AutoScroll = true;
    private static SortColumn currentSortColumn = SortColumn.Time;
    private static bool currentSortAscending = true;
    private static float prevScrollY = -1f;

    /// <summary>
    /// Provides an ImGui tab descriptor for rendering the internal log window.
    /// </summary>
    /// <param name="draw">If true, the tab should be drawn; otherwise null is returned.</param>
    /// <returns>
    /// A tuple containing the tab label (or null), the draw action delegate, optional tab color, and a boolean indicating 
    /// if the tab is closable.
    /// </returns>
    public static (string?, Action, Vector4?, bool) ImGuiTab(bool draw = true) => (draw ? "AppLog" : null, LogViewer, null, false);

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
    public static (string?, Action) CTab(bool draw = true) => (draw ? "AppLog" : null, LogViewer);

    /// <summary>
    /// Renders the ImGui interface for the app log, including controls for autoscroll, filtering, clearing, and displaying messages.
    /// </summary>
    public static void LogViewer()
    {
        ImGuiC.Icon(FontAwesomeIcon.Search);

        ImGui.SameLine();
        float style_spacing = ImGui.GetStyle().ItemSpacing.X;
        float trailingControlsWidth =
            ImGui.GetFrameHeight()      // Filter icon button
            + style_spacing
            + ImGui.GetFrameHeight()    // AutoScroll checkbox
            + style_spacing
            + 20f                       // Dummy spacer
            + style_spacing
            + ImGui.GetFrameHeight()    // Copy icon button
            + style_spacing
            + ImGui.GetFrameHeight()    // Clear icon button
            + style_spacing
            + ImGui.GetFrameHeight()    // Timestamp format icon button
            + style_spacing;

        float searchWidth = ImGui.GetContentRegionAvail().X - trailingControlsWidth;
        const float MinSearchWidth = 120f;
        if (searchWidth < MinSearchWidth) searchWidth = MinSearchWidth;

        ImGui.SetNextItemWidth(searchWidth);
        isDirty |= ImGui.InputTextWithHint("##AppLogSearch", "Filter...", ref searchFilter, 0xFF);

        ImGui.SameLine();
        if (ImGuiC.IconButton(FontAwesomeIcon.Filter, "##AppLogFilter")) ImGui.OpenPopup("filter_window");

        ImGui.SameLine();
        if (ImGuiC.IconButton(FontAwesomeIcon.Clock, "##AppLogTimestampFormat")) ImGui.OpenPopup("timestamp_format_popup");
        ImGuiC.Tooltip("Timestamp Format");

        if (ImGui.BeginPopup("timestamp_format_popup", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.Popup))
        {
            isDirty |= DrawTimestampFormatPopup();
            ImGui.EndPopup();
        }

        ImGui.SameLine();
        bool prevAutoScroll = AutoScroll;
        ImGui.Checkbox("##AutoScroll", ref AutoScroll);
        ImGuiC.Tooltip("AutoScroll");
        bool userJustEnabledAutoScroll = AutoScroll && !prevAutoScroll;

        ImGui.SameLine();
        ImGui.Dummy(new Vector2(20, 0));

        ImGui.SameLine();
        if (ImGuiC.IconButton(FontAwesomeIcon.Copy, "##AppLogCopyAll"))
        {
            var text = string.Join(Environment.NewLine,
        filteredCache.Select(log => $"[{log.TimestampText}] [{log.LevelText}] [{log.Category}] {log.Message}"));
            ImGui.SetClipboardText(text);
        }
        ImGuiC.Tooltip("Copy");

        ImGui.SameLine();
        if (ImGuiC.IconButton(FontAwesomeIcon.Trash, "##AppLogClear"))
        {
            Logs.Clear();
            isDirty = true;
        }
        ImGuiC.Tooltip("Clear");

        if (ImGui.BeginPopup("filter_window", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.Popup))
        {
            isDirty |= DrawFilterPopup();
            ImGui.EndPopup();
        }

        if (isDirty)
        {
            RebuildFilteredCache();
            isDirty = false;
        }

        ImGui.Spacing();

        ImGuiTableFlags flags = ImGuiTableFlags.RowBg |
            ImGuiTableFlags.Borders |
            ImGuiTableFlags.ScrollY |
            ImGuiTableFlags.SizingFixedFit |
            ImGuiTableFlags.Sortable;

        if (ImGui.BeginTable("AppLogTable", 4, flags))
        {
            ImGui.TableSetupColumn("Time");
            ImGui.TableSetupColumn("Level");
            ImGui.TableSetupColumn("Category");
            ImGui.TableSetupColumn("Message", ImGuiTableColumnFlags.WidthStretch);

            ImGui.TableSetupScrollFreeze(0, 1);

            ImGui.TableHeadersRow();

            UpdateSortSpecsIfDirty(ImGui.TableGetSortSpecs());

            foreach (var log in filteredCache)
            {
                ImGui.TableNextRow();

                if (TryGetRowBgColor(log.Level, out var bgColor))
                {
                    ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0,
                        ImGui.ColorConvertFloat4ToU32(bgColor));
                }

                ImGui.TableNextColumn();
                ImGuiC.TextCopy(log.Color, log.TimestampText);

                ImGui.TableNextColumn();
                ImGuiC.TextCopy(log.Color, log.LevelText);

                ImGui.TableNextColumn();
                ImGuiC.TextCopy(log.Color, log.Category);

                ImGui.TableNextColumn();
                ImGuiC.TextCopy(log.Color, log.Message);
            }

            const float ScrollEpsilon = 1f;
            float scrollY = ImGui.GetScrollY();
            float scrollMaxY = ImGui.GetScrollMaxY();
            bool atBottom = scrollMaxY <= 0f || scrollY >= scrollMaxY - ScrollEpsilon;
            bool wasAtBottom = scrollMaxY <= 0f || prevScrollY >= scrollMaxY - ScrollEpsilon;

            if (AutoScroll)
            {
                if (!atBottom && !userJustEnabledAutoScroll)
                {
                    AutoScroll = false;
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
                    AutoScroll = true;
                }
            }

            prevScrollY = scrollY;

            ImGui.EndTable();
        }
    }

    private enum SortColumn : uint
    {
        Time,
        Level,
        Category,
        Message
    }

    private static void UpdateSortSpecsIfDirty(ImGuiTableSortSpecsPtr sortSpecs)
    {
        if (sortSpecs.IsNull) return;
        if (sortSpecs.SpecsCount == 0) return;
        if (!sortSpecs.SpecsDirty) return;

        var spec = sortSpecs.Specs[0];
        currentSortColumn = (SortColumn)spec.ColumnUserID;
        currentSortAscending = spec.SortDirection == ImGuiSortDirection.Ascending;

        sortSpecs.SpecsDirty = false;
        RebuildFilteredCache();
    }

    private static void ApplySort()
    {
        Comparison<LogEntry> comparer = currentSortColumn switch
        {
            SortColumn.Time => (a, b) => a.Timestamp.CompareTo(b.Timestamp),
            SortColumn.Level => (a, b) => a.Level.CompareTo(b.Level),
            SortColumn.Category => (a, b) => string.Compare(a.Category, b.Category, StringComparison.OrdinalIgnoreCase),
            SortColumn.Message => (a, b) => string.Compare(a.Message, b.Message, StringComparison.OrdinalIgnoreCase),
            _ => (a, b) => 0
        };

        filteredCache.Sort((a, b) => currentSortAscending ? comparer(a, b) : comparer(b, a));
    }

    private static void RebuildFilteredCache()
    {
        filteredCache.Clear();

        foreach (var log in Logs.AsEnumerable())
        {
            if (!ShouldDisplayLog(log.Level))
                continue;

            if (!string.IsNullOrEmpty(searchFilter) &&
                !(log.Message.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ||
                  log.Category.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ||
                  log.LevelText.Contains(searchFilter, StringComparison.OrdinalIgnoreCase)))
                continue;

            log.UpdateColor();
            log.UpdateTimestampText();
            filteredCache.Add(log);
        }

        ApplySort();
    }

    private static bool DrawTimestampFormatPopup()
    {
        bool changed = false;

        foreach (TimestampFormat format in Enum.GetValues<TimestampFormat>())
        {
            bool selected = timestampFormat == format;
            var displayLabel = (selected ? "[✓] " : "[    ] ") + format.ToPattern();

            if (ImGui.Selectable(displayLabel, selected, ImGuiSelectableFlags.NoAutoClosePopups) && !selected)
            {
                SetTimestampFormat(format);
                changed = true;
            }
        }

        return changed;
    }

    private static bool DrawFilterPopup()
    {
        bool changed = false;
        changed |= FlagSelectable("Verbose", FilterType.Verbose);
        changed |= FlagSelectable("Debug", FilterType.Debug);
        changed |= FlagSelectable("Info", FilterType.Info);
        changed |= FlagSelectable("Warning", FilterType.Warning);
        changed |= FlagSelectable("Error", FilterType.Error);
        changed |= FlagSelectable("Fatal", FilterType.Fatal);
        return changed;
    }

    private static bool FlagSelectable(string label, FilterType flag)
    {
        var b = Filter.HasFlag(flag);
        var displayLabel = (b ? "[✓] " : "[    ] ") + label;

        if (!ImGui.Selectable(displayLabel, ref b, ImGuiSelectableFlags.NoAutoClosePopups))
            return false;

        if (b)
            Filter |= flag;
        else
            Filter &= ~flag;
        return true;
    }

    private static bool ShouldDisplayLog(LogEventLevel level) => level switch
    {
        LogEventLevel.Verbose => Filter.HasFlag(FilterType.Verbose),
        LogEventLevel.Debug => Filter.HasFlag(FilterType.Debug),
        LogEventLevel.Information => Filter.HasFlag(FilterType.Info),
        LogEventLevel.Warning => Filter.HasFlag(FilterType.Warning),
        LogEventLevel.Error => Filter.HasFlag(FilterType.Error),
        LogEventLevel.Fatal => Filter.HasFlag(FilterType.Fatal),
        _ => false
    };
}
