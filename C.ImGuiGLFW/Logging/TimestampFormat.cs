namespace C.ImGuiGLFW.Logging;

/// <summary>
/// Defines the available formats for rendering a log entry's timestamp.
/// </summary>
public enum TimestampFormat
{
    /// <summary>Time only, e.g. "14:23:05".</summary>
    TimeOnly,

    /// <summary>Time with milliseconds, e.g. "14:23:05.123".</summary>
    TimeWithMs,

    /// <summary>Date and time separated by slashes, e.g. "2026/09/04 14:23:05".</summary>
    DateTimeSlash,

    /// <summary>Date and time separated by dashes, e.g. "2026-09-04 14:23:05".</summary>
    DateTimeDash,

    /// <summary>Month, day, and time without the year, e.g. "09/04 14:23:05".</summary>
    MonthDayTime,

    /// <summary>ISO 8601 date and time, e.g. "2026-09-04T14:23:05".</summary>
    Iso8601
}

/// <summary>
/// Provides conversion helpers for <see cref="TimestampFormat"/>.
/// </summary>
public static class TimestampFormatExtensions
{
    /// <summary>
    /// Converts a <see cref="TimestampFormat"/> value into its corresponding
    /// .NET custom date and time format string.
    /// </summary>
    /// <param name="format">The timestamp format to convert.</param>
    /// <returns>
    /// A format string suitable for use with <see cref="DateTime.ToString(string)"/>.
    /// Falls back to "HH:mm:ss" for any unrecognized value.
    /// </returns>
    public static string ToPattern(this TimestampFormat format) => format switch
    {
        TimestampFormat.TimeOnly => "HH:mm:ss",
        TimestampFormat.TimeWithMs => "HH:mm:ss.fff",
        TimestampFormat.DateTimeSlash => "yyyy/MM/dd HH:mm:ss",
        TimestampFormat.DateTimeDash => "yyyy-MM-dd HH:mm:ss",
        TimestampFormat.MonthDayTime => "MM/dd HH:mm:ss",
        TimestampFormat.Iso8601 => "yyyy-MM-ddTHH:mm:ss",
        _ => "HH:mm:ss"
    };
}
