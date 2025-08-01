namespace C.ImGuiGLFW.Data;

/// <summary>
/// Represents the various modules available within the application.
/// </summary>
/// <remarks>
/// This enum is useful for identifying or filtering log entries, configurations, or behaviors by module type.
/// </remarks>
public enum Module
{
    /// <summary>
    /// Represents all modules collectively.
    /// </summary>
    All,

    /// <summary>
    /// Represents the Guizmo module, typically for graphical gizmos or manipulators.
    /// </summary>
    Guizmo,

    /// <summary>
    /// Represents the Nodes module, usually for node-based editors or graphs.
    /// </summary>
    Nodes,

    /// <summary>
    /// Represents the Plot module, used for rendering plots or graphs.
    /// </summary>
    Plot,
}
