using Serilog.Events;

namespace C.ImGuiGLFW.Logging;

internal record LogEntry
{
    private static long _nextId;

    public long Id { get; }
    public DateTime Timestamp { get; set; }

    public LogEventLevel Level { get; set; }

    public string Message { get; set; }

    public string Category { get; set; }

    internal string TimestampText { get; private set; }

    internal string LevelText { get; }

    internal Vector4 Color { get; private set; }

    public LogEntry(LogEventLevel level, string message, string category = "System")
    {
        Id = Interlocked.Increment(ref _nextId);
        Timestamp = DateTime.Now;
        Level = level;
        Message = message;
        Category = category;
        TimestampText = Timestamp.ToString(AppLog.timestampFormat.ToPattern());
        LevelText = level.ToString();
        Color = AppLog.GetColor(level);
    }

    public void UpdateColor() => Color = AppLog.GetColor(Level);

    public void UpdateTimestampText() => TimestampText = Timestamp.ToString(AppLog.timestampFormat.ToPattern());
}
