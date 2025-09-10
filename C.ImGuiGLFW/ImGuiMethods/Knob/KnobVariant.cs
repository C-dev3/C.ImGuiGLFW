namespace C.ImGuiGLFW.ImGuiMethods.Knob;

/// <summary>
/// Defines the visual appearance variants available for ImGui knob controls.
/// </summary>
/// <remarks>
/// The KnobVariant enumeration specifies different visual styles for rendering knob controls,
/// each providing a distinct method for indicating the current value position. The variants
/// range from simple indicators like ticks and dots to more complex designs like wiper arcs
/// and space-themed visualizations.
/// 
/// Each variant is implemented as a bit flag to potentially allow for future combinations,
/// though the current implementation treats them as mutually exclusive options. The visual
/// complexity and rendering performance varies between variants, with simpler variants like
/// Tick and Dot being more performant than complex ones like Space.
/// 
/// The choice of variant affects both the visual appearance and the user's ability to precisely
/// read the current value, with some variants better suited for coarse adjustments (Space)
/// and others for precise control (Tick, Stepped).
/// </remarks>
public enum KnobVariant : int
{
    /// <summary>
    /// Displays a line extending from the center to the edge of the knob, indicating the current value position.
    /// </summary>
    /// <remarks>
    /// The Tick variant renders a solid circular base with a straight line (tick mark) that rotates
    /// around the center point to indicate the current value. This is the most traditional and
    /// recognizable knob style, similar to physical potentiometers and volume controls.
    /// The tick provides precise visual feedback and is easy to read at any angle.
    /// Performance: High - Simple geometry with minimal draw calls.
    /// </remarks>
    Tick = 1 << 0,

    /// <summary>
    /// Displays a small circular dot on the perimeter of the knob to indicate the current value position.
    /// </summary>
    /// <remarks>
    /// The Dot variant renders a solid circular base with a small filled circle positioned on the
    /// outer edge to show the current value. This style offers a clean, minimalist appearance
    /// while maintaining good readability. The dot moves along the circumference as the value changes.
    /// Performance: High - Simple geometry with two circle draw operations.
    /// </remarks>
    Dot = 1 << 1,

    /// <summary>
    /// Displays both a circular base and an arc that sweeps from the minimum angle to the current value position.
    /// </summary>
    /// <remarks>
    /// The Wiper variant combines a filled circular base with an arc segment that extends from the
    /// minimum position to the current value position, resembling a windshield wiper motion.
    /// This style provides excellent visual feedback for the amount of "fill" or progress,
    /// making it easy to see both the current value and how much of the range is utilized.
    /// Performance: Medium - Requires arc rendering with multiple segments.
    /// </remarks>
    Wiper = 1 << 2,

    /// <summary>
    /// Displays only a wiper-style arc without a base circle, creating a minimalist arc indicator.
    /// </summary>
    /// <remarks>
    /// The WiperOnly variant shows just the arc segment from minimum to current position without
    /// any background circle, creating a clean, minimal appearance. This style is useful when
    /// screen space is limited or when a subtle indicator is preferred. The track arc is always
    /// visible to show the full range, with the value arc overlaying it.
    /// Performance: Medium - Arc rendering without the base circle draw call.
    /// </remarks>
    WiperOnly = 1 << 3,

    /// <summary>
    /// Combines a wiper-style arc track with a dot indicator at the current value position.
    /// </summary>
    /// <remarks>
    /// The WiperDot variant provides dual visual feedback by showing both a circular base,
    /// an arc track indicating the full range, and a dot positioned at the exact current value.
    /// This combination offers both the "fill amount" feedback of the wiper and the precise
    /// position indication of the dot, making it excellent for applications requiring both
    /// coarse and fine value reading.
    /// Performance: Medium - Combines arc rendering with dot positioning.
    /// </remarks>
    WiperDot = 1 << 4,

    /// <summary>
    /// Displays discrete tick marks around the perimeter with a dot indicator, ideal for stepped or discrete values.
    /// </summary>
    /// <remarks>
    /// The Stepped variant renders multiple small tick marks evenly distributed around the knob's
    /// circumference, along with a dot indicator showing the current position. The number of
    /// tick marks is determined by the 'steps' parameter. This style is particularly effective
    /// for discrete value ranges, enumerated options, or when users need to see available
    /// positions at a glance.
    /// Performance: Low - Multiple tick mark draw calls based on step count.
    /// </remarks>
    Stepped = 1 << 5,

    /// <summary>
    /// Features a futuristic design with a size-changing center circle and multiple concentric arcs.
    /// </summary>
    /// <remarks>
    /// The Space variant creates a unique, science-fiction inspired appearance with a central circle
    /// that changes size based on the current value, surrounded by multiple concentric arcs that
    /// create a dynamic, animated-looking effect. This style is visually striking and well-suited
    /// for modern, futuristic, or gaming interfaces where visual impact is important.
    /// The complexity of this variant makes it the most resource-intensive option.
    /// Performance: Low - Multiple arc rendering operations with dynamic sizing calculations.
    /// </remarks>
    Space = 1 << 6
}
