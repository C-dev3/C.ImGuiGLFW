namespace C.ImGuiGLFW.ImGuiMethods.Knob;

/// <summary>
/// Represents a set of colors for different UI element states in ImGui controls.
/// </summary>
/// <remarks>
/// The ColorSet struct provides a convenient way to group related colors that represent
/// different interaction states of UI elements such as knobs, buttons, and other controls.
/// It stores Vector4 colors for base, hovered, and active states, allowing for smooth
/// visual transitions and consistent theming across UI components. The struct supports
/// both individual color specification and uniform color application across all states.
/// </remarks>
internal struct ColorSet
{
    /// <summary>
    /// The base color used when the UI element is in its default, non-interactive state.
    /// </summary>
    /// <remarks>
    /// This color is displayed when the user is not interacting with the UI element.
    /// It represents the neutral or resting appearance of the control.
    /// </remarks>
    public Vector4 Base;

    /// <summary>
    /// The color used when the UI element is being hovered over by the mouse cursor.
    /// </summary>
    /// <remarks>
    /// This color provides visual feedback to indicate that the UI element is interactive
    /// and ready to respond to user input. It's typically a lighter or more vibrant
    /// variant of the base color.
    /// </remarks>
    public Vector4 Hovered;

    /// <summary>
    /// The color used when the UI element is actively being interacted with (clicked, dragged, etc.).
    /// </summary>
    /// <remarks>
    /// This color indicates that the user is currently manipulating the UI element.
    /// It's usually the most prominent color in the set to provide clear visual feedback
    /// during active interaction.
    /// </remarks>
    public Vector4 Active;

    /// <summary>
    /// Initializes a new instance of the ColorSet struct with distinct colors for each state.
    /// </summary>
    /// <param name="baseColor">The color for the default state.</param>
    /// <param name="hoveredColor">The color for the hovered state.</param>
    /// <param name="activeColor">The color for the active state.</param>
    /// <remarks>
    /// This constructor allows for full customization of the color set, enabling different
    /// colors for each interaction state. This is useful for creating dynamic and responsive
    /// UI elements with distinct visual feedback for each state.
    /// </remarks>
    public ColorSet(Vector4 baseColor, Vector4 hoveredColor, Vector4 activeColor)
    {
        Base = baseColor;
        Hovered = hoveredColor;
        Active = activeColor;
    }

    /// <summary>
    /// Initializes a new instance of the ColorSet struct with the same color for all states.
    /// </summary>
    /// <param name="color">The color to use for base, hovered, and active states.</param>
    /// <remarks>
    /// This constructor creates a uniform color set where all interaction states use the same color.
    /// This is useful for creating static or minimally interactive UI elements that don't require
    /// visual state feedback, or for creating consistent color themes across different controls.
    /// </remarks>
    public ColorSet(Vector4 color)
    {
        Base = color;
        Hovered = color;
        Active = color;
    }
}
