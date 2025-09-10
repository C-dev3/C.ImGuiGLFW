namespace C.ImGuiGLFW.ImGuiMethods.Knob;

/// <summary>
/// Specifies flags that control the behavior and appearance of ImGui knob controls.
/// </summary>
/// <remarks>
/// This flags enumeration allows for fine-grained control over knob control behavior
/// including visual elements, interaction modes, and value handling. Multiple flags
/// can be combined using bitwise operations to customize the knob's appearance and
/// functionality. The flags cover aspects such as title display, input field visibility,
/// drag direction preferences, scaling modes, and value constraints.
/// </remarks>
[Flags]
public enum ImGuiKnobFlags : int
{
    /// <summary>
    /// Hides the title/label text above the knob control.
    /// </summary>
    /// <remarks>
    /// When this flag is set, the knob will not display its label text, creating a more
    /// compact visual appearance. This is useful when the knob's purpose is clear from
    /// context or when space is limited.
    /// </remarks>
    NoTitle = 1 << 0,

    /// <summary>
    /// Disables the input field below the knob control.
    /// </summary>
    /// <remarks>
    /// When this flag is set, the text input field that normally appears below the knob
    /// for direct value entry is hidden. This creates a cleaner appearance and forces
    /// interaction through the visual knob interface only.
    /// </remarks>
    NoInput = 1 << 1,

    /// <summary>
    /// Enables a tooltip that displays the current value when hovering over or interacting with the knob.
    /// </summary>
    /// <remarks>
    /// When this flag is set, a tooltip showing the formatted current value appears when
    /// the user hovers over the knob or actively manipulates it. This provides immediate
    /// feedback about the exact value without requiring the input field to be visible.
    /// </remarks>
    ValueTooltip = 1 << 2,

    /// <summary>
    /// Prioritizes horizontal mouse movement for value adjustment over vertical movement.
    /// </summary>
    /// <remarks>
    /// When this flag is set, horizontal mouse dragging becomes the preferred method for
    /// adjusting the knob value, overriding the default behavior that typically favors
    /// vertical dragging. This can be useful for specific UI layouts or user preferences.
    /// </remarks>
    DragHorizontal = 1 << 3,

    /// <summary>
    /// Forces vertical mouse movement for value adjustment.
    /// </summary>
    /// <remarks>
    /// When this flag is set, vertical mouse dragging is enforced for adjusting the knob
    /// value. This provides consistent behavior regardless of the mouse movement pattern
    /// and is useful when vertical dragging is preferred for the application's interface.
    /// </remarks>
    DragVertical = 1 << 4,

    /// <summary>
    /// Enables logarithmic scaling for the knob's value range.
    /// </summary>
    /// <remarks>
    /// When this flag is set, the knob uses logarithmic scaling instead of linear scaling
    /// for value interpolation. This is particularly useful for parameters that have
    /// exponential characteristics, such as audio frequencies, gain values, or other
    /// parameters where equal visual spacing should represent equal ratios rather than
    /// equal differences. Note that minimum values will be adjusted to avoid log(0) errors.
    /// </remarks>
    Logarithmic = 1 << 5,

    /// <summary>
    /// Forces the knob value to always be clamped within the specified minimum and maximum range.
    /// </summary>
    /// <remarks>
    /// When this flag is set, the knob value is strictly constrained to remain within
    /// the specified vMin and vMax bounds, even during rapid mouse movements or when
    /// using logarithmic scaling. This ensures that the value never exceeds the defined
    /// range, providing predictable behavior for critical parameters.
    /// </remarks>
    AlwaysClamp = 1 << 6,

    /// <summary>
    /// Combines NoInput and ValueTooltip flags for a knob without input field but with value tooltip.
    /// </summary>
    /// <remarks>
    /// This is a convenience flag that combines NoInput and ValueTooltip, creating a knob
    /// that has no text input field but displays the current value in a tooltip when
    /// hovered or manipulated. This provides a clean visual appearance while still
    /// offering value feedback to the user.
    /// </remarks>
    NoInputAndValueTooltip = NoInput | ValueTooltip,
}
