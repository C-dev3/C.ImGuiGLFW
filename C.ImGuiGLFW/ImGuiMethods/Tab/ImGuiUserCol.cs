namespace C.ImGuiGLFW.ImGuiMethods.Tab;

/// <summary>
/// Defines custom color indices for ImGui user interface elements.
/// </summary>
/// <remarks>
/// These color indices are used to customize the appearance of tab bars and related UI elements.
/// The Count value represents the total number of color entries available.
/// </remarks>
public enum ImGuiUserCol
{
    /// <summary>
    /// Color index for tab borders.
    /// </summary>
    TabBorder = 0,

    /// <summary>
    /// Color index for tab border shadows.
    /// </summary>
    TabBorderShadow,

    /// <summary>
    /// Color index for normal tab background.
    /// </summary>
    TabNormal,

    /// <summary>
    /// Color index for tab background when hovered.
    /// </summary>
    TabHover,

    /// <summary>
    /// Color index for normal tab title text.
    /// </summary>
    TabTitleTextNormal,

    /// <summary>
    /// Color index for selected tab title text.
    /// </summary>
    TabTitleTextSelected,

    /// <summary>
    /// Total number of available color indices.
    /// </summary>
    Count
}
