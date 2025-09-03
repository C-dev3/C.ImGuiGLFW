namespace C.ImGuiGLFW.Data;

/// <summary>
/// Represents the current state of an input device such as a keyboard key or mouse button.
/// </summary>
/// <remarks>
/// This enumeration is typically used in input handling systems to track and respond to 
/// user interactions. The values correspond to standard input states found in most 
/// input frameworks and windowing systems.
/// </remarks>
public enum InputState
{
    /// <summary>
    /// Indicates that the input is not currently active or has been released.
    /// </summary>
    /// <remarks>
    /// This is the default state when no input is being applied.
    /// </remarks>
    Released = 0,

    /// <summary>
    /// Indicates that the input has just been activated or pressed down.
    /// </summary>
    /// <remarks>
    /// This state typically occurs for a single frame or event when the input transitions 
    /// from Released to an active state.
    /// </remarks>
    Pressed = 1,

    /// <summary>
    /// Indicates that the input is being held down and is generating repeat events.
    /// </summary>
    /// <remarks>
    /// This state occurs when an input remains active for an extended period, typically 
    /// generating continuous events at regular intervals. Common in text input scenarios 
    /// where holding a key produces repeated characters.
    /// </remarks>
    Repeat = 2,
}
