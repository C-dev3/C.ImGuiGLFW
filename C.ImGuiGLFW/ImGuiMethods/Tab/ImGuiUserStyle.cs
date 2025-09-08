namespace C.ImGuiGLFW.ImGuiMethods.Tab;

/// <summary>
/// Manages custom styling colors for ImGui user interface elements.
/// </summary>
/// <remarks>
/// This class provides a centralized way to manage custom colors for tab bars and other UI elements.
/// It initializes with default color values that provide a cohesive visual theme.
/// </remarks>
public class ImGuiUserStyle
{
    /// <summary>
    /// Gets the array of colors indexed by ImGuiUserCol enumeration values.
    /// </summary>
    /// <remarks>
    /// This array contains Vector4 color values where each component represents RGBA values in the range 0.0 to 1.0.
    /// Colors are automatically initialized with default values when the style is created.
    /// </remarks>
    public Vector4[] Colors { get; private set; }

    /// <summary>
    /// Initializes a new instance of the ImGuiUserStyle class with default color values.
    /// </summary>
    /// <remarks>
    /// The constructor sets up a complete color scheme for tab bar rendering with a gray-based theme.
    /// Normal tab color is set to a medium gray, with lighter variants for borders and hover states,
    /// and darker variants for shadows. Text colors are configured for both normal and selected states
    /// to ensure proper contrast and readability.
    /// </remarks>
    public ImGuiUserStyle()
    {
        Colors = new Vector4[(int)ImGuiUserCol.Count];

        var tabNormalColor = new Vector4(0.65f, 0.65f, 0.68f, 1.00f);
        Colors[(int)ImGuiUserCol.TabNormal] = tabNormalColor;

        Colors[(int)ImGuiUserCol.TabTitleTextNormal] = new Vector4(0.0f, 0.0f, 0.0f, 0.5f);
        Colors[(int)ImGuiUserCol.TabTitleTextSelected] = new Vector4(1.0f, 1.0f, 1.0f, 1.00f);

        var lightMultiplier = new Vector4(1.15f, 1.15f, 1.15f, 1.0f);
        var darkMultiplier = new Vector4(0.65f, 0.65f, 0.65f, 1.0f);

        Colors[(int)ImGuiUserCol.TabBorder] = tabNormalColor * lightMultiplier;
        Colors[(int)ImGuiUserCol.TabBorderShadow] = tabNormalColor * darkMultiplier;
        Colors[(int)ImGuiUserCol.TabHover] = tabNormalColor * lightMultiplier;
    }
}
