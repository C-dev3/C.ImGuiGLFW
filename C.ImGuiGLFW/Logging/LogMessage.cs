using Serilog.Events;

namespace C.ImGuiGLFW.Logging;

public struct LogMessage(string message, LogEventLevel level = LogEventLevel.Information)
{
    public string Message = message;
    public string TimeStr = DateTimeOffset.Now.ToString("yyyy/MM/dd HH:mm:ss");
    public DateTimeOffset Time = DateTimeOffset.Now;
    public LogEventLevel Level = level;
}