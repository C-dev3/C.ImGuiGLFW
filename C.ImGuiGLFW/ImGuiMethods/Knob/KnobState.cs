namespace C.ImGuiGLFW.ImGuiMethods.Knob;

/// <summary>
/// Represents the internal state and calculated properties of an ImGui knob control during rendering and interaction.
/// </summary>
/// <remarks>
/// The KnobState struct encapsulates all the computed values needed to render and handle interactions
/// for knob controls. It contains geometric calculations (center position, angles, trigonometric values),
/// interaction states (active, hovered), and normalized value representations. This struct is created
/// and populated by the CreateKnobState method and consumed by various drawing methods within the CKnob class.
/// 
/// The struct is designed to be passed by reference to drawing methods to avoid unnecessary copying of
/// the data, as it contains multiple fields that are accessed frequently during the rendering process.
/// All angle calculations are performed in radians, and the normalized value (T) represents the knob's
/// position as a value between 0.0 and 1.0 regardless of the actual value range.
/// </remarks>
internal struct KnobState
{
    /// <summary>
    /// Gets or sets the radius of the knob control in pixels.
    /// </summary>
    /// <remarks>
    /// This value represents half the width/height of the knob's interaction area and is used
    /// as a base measurement for calculating all other geometric properties of the knob.
    /// </remarks>
    public float Radius;

    /// <summary>
    /// Gets or sets a value indicating whether the knob's value was modified during the current frame.
    /// </summary>
    /// <remarks>
    /// This flag is set to true when the user interacts with the knob (via mouse dragging or input field)
    /// and changes the underlying value. It's used as the return value for knob methods to indicate
    /// whether the calling code should respond to the value change.
    /// </remarks>
    public bool ValueChanged;

    /// <summary>
    /// Gets or sets the center position of the knob in screen coordinates.
    /// </summary>
    /// <remarks>
    /// This Vector2 represents the pixel position of the knob's center point on the screen,
    /// calculated from ImGui's cursor position plus the radius offset. All drawing operations
    /// for the knob elements are positioned relative to this center point.
    /// </remarks>
    public Vector2 Center;

    /// <summary>
    /// Gets or sets a value indicating whether the knob is currently being actively manipulated by the user.
    /// </summary>
    /// <remarks>
    /// This property is true when the user is actively dragging the knob with the mouse.
    /// It's used to determine visual feedback (active color state) and to process mouse drag events
    /// for value modification.
    /// </remarks>
    public bool IsActive;

    /// <summary>
    /// Gets or sets a value indicating whether the mouse cursor is currently hovering over the knob.
    /// </summary>
    /// <remarks>
    /// This property is true when the mouse is positioned over the knob's interaction area.
    /// It's used to provide visual feedback (hover color state) and to determine when to show
    /// tooltips or other hover-based UI elements.
    /// </remarks>
    public bool IsHovered;

    /// <summary>
    /// Gets or sets the minimum angle of the knob's range in radians.
    /// </summary>
    /// <remarks>
    /// This angle defines the starting position of the knob's rotational range. The angle is measured
    /// in radians with 0 pointing to the right, increasing counter-clockwise. If not specified,
    /// defaults to PI * 0.75 (135 degrees), which positions the minimum at the bottom-left.
    /// </remarks>
    public float AngleMin;

    /// <summary>
    /// Gets or sets the maximum angle of the knob's range in radians.
    /// </summary>
    /// <remarks>
    /// This angle defines the ending position of the knob's rotational range. The angle is measured
    /// in radians with 0 pointing to the right, increasing counter-clockwise. If not specified,
    /// defaults to PI * 2.25 (405 degrees), which positions the maximum at the bottom-right after
    /// completing more than a full rotation.
    /// </remarks>
    public float AngleMax;

    /// <summary>
    /// Gets or sets the normalized position of the knob value within its range (0.0 to 1.0).
    /// </summary>
    /// <remarks>
    /// This value represents the knob's current position as a normalized float between 0.0 (minimum value)
    /// and 1.0 (maximum value), regardless of the actual numeric range of the knob. For logarithmic knobs,
    /// this represents the position in logarithmic space. This normalized value is used to calculate
    /// the visual angle and position of knob indicators.
    /// </remarks>
    public float T;

    /// <summary>
    /// Gets or sets the current angle of the knob indicator in radians.
    /// </summary>
    /// <remarks>
    /// This is the calculated angle where the knob's visual indicator (tick, dot, etc.) should be positioned,
    /// computed by interpolating between AngleMin and AngleMax based on the normalized value T.
    /// This angle is used by all drawing methods to position visual elements correctly.
    /// </remarks>
    public float Angle;

    /// <summary>
    /// Gets or sets the cosine of the current knob angle.
    /// </summary>
    /// <remarks>
    /// This pre-calculated trigonometric value is used for positioning elements along the X-axis
    /// relative to the knob's center. Computing this once and storing it avoids repeated
    /// trigonometric calculations during the drawing process, improving performance.
    /// </remarks>
    public float AngleCos;

    /// <summary>
    /// Gets or sets the sine of the current knob angle.
    /// </summary>
    /// <remarks>
    /// This pre-calculated trigonometric value is used for positioning elements along the Y-axis
    /// relative to the knob's center. Computing this once and storing it avoids repeated
    /// trigonometric calculations during the drawing process, improving performance.
    /// </remarks>
    public float AngleSin;
}
