using Serilog.Events;

namespace C.ImGuiGLFW.Logging;

/// <summary>
/// Represents a log message with its content, timestamp, and severity level.
/// </summary>
/// <param name="message">The content of the log message.</param>
/// <param name="level">The severity level of the log message. Defaults to Information.</param>
/// <remarks>
/// This struct encapsulates a single log entry with its message, timestamp (both formatted string and raw), and the log event level according to Serilog conventions.
/// It is designed to be immutable in terms of construction and lightweight for efficient logging in the application.
/// </remarks>
public struct LogMessage(string message, LogEventLevel level = LogEventLevel.Information)
{
    /// <summary>
    /// The content of the log message.
    /// </summary>
    public string Message = message;

    /// <summary>
    /// The timestamp of the log message formatted as "yyyy/MM/dd HH:mm:ss".
    /// </summary>
    public string TimeStr = DateTimeOffset.Now.ToString("yyyy/MM/dd HH:mm:ss");

    /// <summary>
    /// The exact timestamp of the log message.
    /// </summary>
    public DateTimeOffset Time = DateTimeOffset.Now;

    /// <summary>
    /// The severity level of the log message.
    /// </summary>
    public LogEventLevel Level = level;
}