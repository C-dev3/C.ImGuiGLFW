namespace C.ImGuiGLFW.Data;

/// <summary>
/// Represents log message severity levels used for filtering output.
/// Supports bitwise combination of values due to the <see cref="FlagsAttribute"/>.
/// </summary>
/// <remarks>
/// You can combine multiple flags using bitwise OR (e.g., <c>FilterType.Warning | FilterType.Error</c>) to filter multiple log levels.
/// </remarks>
[Flags]
public enum FilterType : long
{
    /// <summary>
    /// Indicates highly detailed diagnostic messages intended for internal development use.
    /// </summary>
    Verbose = 1L << 0,

    /// <summary>
    /// Indicates debug-level messages used during development for tracing application behavior.
    /// </summary>
    Debug = 1L << 1,

    /// <summary>
    /// Indicates informational messages that highlight the progress of the application.
    /// </summary>
    Info = 1L << 2,

    /// <summary>
    /// Indicates potentially harmful situations that do not necessarily cause errors.
    /// </summary>
    Warning = 1L << 3,

    /// <summary>
    /// Indicates error events that might still allow the application to continue running.
    /// </summary>
    Error = 1L << 4,

    /// <summary>
    /// Indicates very severe error events that will presumably lead the application to abort.
    /// </summary>
    Fatal = 1L << 5,

    /// <summary>
    /// The default filter, combining <see cref="Info"/>, <see cref="Warning"/>, <see cref="Error"/>, and <see cref="Fatal"/> levels.
    /// </summary>
    /// <remarks>
    /// This preset is typically used to suppress lower-level debug and verbose output in production environments.
    /// </remarks>
    Default = Info | Warning | Error | Fatal,

    /// <summary>
    /// A special filter value that includes all possible flags, including <see cref="Verbose"/> and <see cref="Debug"/>.
    /// </summary>
    /// <remarks>
    /// This flag is typically used during development to enable maximum verbosity in logging output.  
    /// Because its value is the bitwise complement of zero (~0), it ensures all defined and future flags are matched.
    /// Use with caution in production environments, as it may result in very large or sensitive output.
    /// </remarks>
    Develop = ~0L
}
