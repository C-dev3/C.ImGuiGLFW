using C.ImGuiGLFW.Color;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    public static readonly Vector4 OFF_COLOR_NORMAL = new(0.85f, 0.85f, 0.85f, 1.0f);
    public static readonly Vector4 OFF_COLOR_HOVERED = new(0.78f, 0.78f, 0.78f, 1.0f);
    public static readonly Vector4 ON_COLOR_NORMAL = new(0.56f, 0.83f, 0.26f, 1.0f);
    public static readonly Vector4 ON_COLOR_HOVERED = new(0.64f, 0.83f, 0.34f, 1.0f);

    /// <summary>
    /// Creates a customizable toggle button with smooth animation and circular slider.
    /// </summary>
    /// <param name="label">The label for the button (displayed next to the toggle).</param>
    /// <param name="v">Reference to the boolean value to toggle.</param>
    /// <param name="scale">Scale factor for the button size. Default is 1.0f.</param>
    /// <param name="activeColor">Background color when the button is in active/on state. If null, uses default green.</param>
    /// <param name="inactiveColor">Background color when the button is in inactive/off state. If null, uses default gray.</param>
    /// <param name="activeHoverColor">Background color when hovering over active button. If null, uses slightly darker green.</param>
    /// <param name="inactiveHoverColor">Background color when hovering over inactive button. If null, uses slightly darker gray.</param>
    /// <param name="sliderColor">Color of the circular slider indicator. If null, uses white.</param>
    /// <returns>True if the button state was changed, false otherwise.</returns>
    public static bool ToggleButton(string label, ref bool v,
        float scale = 1.0f,
        Vector4? activeColor = null,
        Vector4? inactiveColor = null,
        Vector4? activeHoverColor = null,
        Vector4? inactiveHoverColor = null,
        Vector4? sliderColor = null)
    {
        bool changed = false;
        var p = ImGui.GetCursorScreenPos();
        var drawList = ImGui.GetWindowDrawList();

        // Scale all size-related values
        float height = ImGui.GetFrameHeight() * scale;
        float width = height * 1.55f;
        float radius = height * 0.50f;

        ImGui.InvisibleButton(label, new Vector2(width, height));
        var itemId = ImGui.GetItemID();

        if (ImGui.IsItemClicked())
        {
            changed = true;
            v ^= true;
        }

        ImGui.SameLine();
        ImGui.TextUnformatted(label);

        float t = v ? 1.0f : 0.0f;
        const float animSpeed = 0.08f;
        var context = ImGui.GetCurrentContext();

        if (context.LastActiveId == itemId)
        {
            float t_anim = ImGuiP.ImSaturate(context.LastActiveIdTimer / animSpeed);
            t = v ? t_anim : (1.0f - t_anim);
        }

        // Set default colors if not provided
        activeColor ??= ON_COLOR_NORMAL;      // Green
        inactiveColor ??= OFF_COLOR_NORMAL;    // Light gray
        activeHoverColor ??= ON_COLOR_HOVERED; // Lighter green
        inactiveHoverColor ??= OFF_COLOR_HOVERED; // Darker gray
        sliderColor ??= EzColor.White;         // White

        // Calculate background color with interpolation
        uint bgColor;
        if (ImGui.IsItemHovered())
        {
            bgColor = ImGui.GetColorU32(ImGuiP.ImLerp(inactiveHoverColor.Value, activeHoverColor.Value, t));
        }
        else
        {
            bgColor = ImGui.GetColorU32(ImGuiP.ImLerp(inactiveColor.Value, activeColor.Value, t));
        }

        // Draw background with rounded corners
        drawList.AddRectFilled(p, new Vector2(p.X + width, p.Y + height), bgColor, height * 0.5f);

        // Draw circular slider with scaled radius and padding
        float sliderRadius = radius - (1.5f * scale);
        drawList.AddCircleFilled(
            new Vector2(p.X + radius + t * (width - radius * 2.0f), p.Y + radius),
            sliderRadius,
            ImGui.GetColorU32(sliderColor.Value));

        return changed;
    }

    /// <summary>
    /// Creates a customizable square toggle button with smooth animation.
    /// </summary>
    /// <param name="label">The label for the button (used for identification).</param>
    /// <param name="v">Reference to the boolean value to toggle.</param>
    /// <param name="scale">Scale factor for the button size. Default is 1.0f.</param>
    /// <param name="activeColor">Color when the button is in active/on state. If null, uses default ImGui button color.</param>
    /// <param name="inactiveColor">Color when the button is in inactive/off state. If null, uses default gray color.</param>
    /// <param name="activeHoverColor">Color when hovering over active button. If null, uses default ImGui button active color.</param>
    /// <param name="inactiveHoverColor">Color when hovering over inactive button. If null, uses slightly darker gray.</param>
    /// <param name="sliderColor">Color of the sliding indicator. If null, uses white.</param>
    /// <returns>True if the button state was changed, false otherwise.</returns>
    public static bool ToggleButtonSquare(string label, ref bool v,
        float scale = 1.0f,
        Vector4? activeColor = null,
        Vector4? inactiveColor = null,
        Vector4? activeHoverColor = null,
        Vector4? inactiveHoverColor = null,
        Vector4? sliderColor = null)
    {
        bool changed = false;
        var colors = ImGui.GetStyle().Colors;
        var p = ImGui.GetCursorScreenPos();
        var drawList = ImGui.GetWindowDrawList();

        // Scale all size-related values
        float height = ImGui.GetFrameHeight() * scale;
        float width = height * 1.55f;
        float radius = height * 0.5f;
        const float rounding = 0.2f;

        ImGui.InvisibleButton(label, new Vector2(width, height));
        var itemId = ImGui.GetItemID();

        if (ImGui.IsItemClicked())
        {
            changed = true;
            v ^= true;
        }

        var context = ImGui.GetCurrentContext();
        const float animSpeed = 0.08f;
        float t = v ? 1.0f : 0.0f;

        if (context.LastActiveId == itemId)
        {
            float t_anim = ImGuiP.ImSaturate(context.LastActiveIdTimer / animSpeed);
            t = v ? t_anim : (1.0f - t_anim);
        }

        // Set default colors if not provided
        activeColor ??= colors[(int)ImGuiCol.Button];
        inactiveColor ??= OFF_COLOR_NORMAL;
        activeHoverColor ??= colors[(int)ImGuiCol.ButtonActive];
        inactiveHoverColor ??= OFF_COLOR_HOVERED;
        sliderColor ??= EzColor.White;

        // Draw background based on hover state
        if (ImGui.IsItemHovered())
        {
            drawList.AddRectFilled(p, new Vector2(p.X + width, p.Y + height),
                ImGui.GetColorU32(v ? activeHoverColor.Value : inactiveHoverColor.Value),
                height * rounding);
        }
        else
        {
            drawList.AddRectFilled(p, new Vector2(p.X + width, p.Y + height),
                ImGui.GetColorU32(v ? activeColor.Value : inactiveColor.Value),
                height * rounding);
        }

        // Draw slider with scaled dimensions
        var center = new Vector2(radius + t * (width - radius * 2.0f), radius);
        float sliderWidth = (width / 2) * scale;
        float sliderPadding = 1.5f * scale;

        drawList.AddRectFilled(
            new Vector2(p.X + center.X - (9.0f * scale), p.Y + sliderPadding),
            new Vector2(p.X + center.X - (9.0f * scale) + sliderWidth, p.Y + height - sliderPadding),
            ImGui.GetColorU32(sliderColor.Value),
            height * rounding);

        return changed;
    }

    /// <summary>
    /// Creates a radio button that acts as a toggle switch with customizable colors based on its state.
    /// </summary>
    /// <param name="label">The text label to display next to the radio button.</param>
    /// <param name="v">A reference to the boolean value that will be toggled when the radio button is clicked.</param>
    /// <param name="activeColor">The color to use when the toggle is in the active (true) state. If null, defaults to magenta (16711935u).</param>
    /// <param name="disableColor">The color to use when the toggle is in the inactive (false) state. If null, defaults to dark gray (4278190335u).</param>
    /// <returns>True if the toggle state was changed during this frame, false otherwise.</returns>
    /// <remarks>
    /// This method creates a radio button that visually represents a toggle state using different colors.
    /// The radio button always appears selected but changes color based on the boolean value.
    /// The color values are expected to be in packed ARGB uint format.
    /// The method temporarily overrides the ImGui frame background colors for the duration of the radio button.
    /// Default colors: Active = 16711935u (magenta), Inactive = 4278190335u (dark gray).
    /// </remarks>
    public static bool ToggleRadio(string label, ref bool v, uint? activeColor = null, uint? disableColor = null)
    {
        bool changed = false;
        activeColor ??= 16711935u;
        disableColor ??= 4278190335u;
        var color = v ? activeColor.Value : disableColor.Value;
        ImGui.PushStyleColor(ImGuiCol.FrameBg, color);
        ImGui.PushStyleColor(ImGuiCol.FrameBgActive, color);
        ImGui.PushStyleColor(ImGuiCol.FrameBgHovered, color);
        if (ImGui.RadioButton(label, true))
        {
            changed = true;
            v ^= true;
        }
        ImGui.PopStyleColor(3);
        return changed;
    }

    /// <summary>
    /// Creates a radio button that acts as a toggle switch with customizable Vector4 colors based on its state.
    /// </summary>
    /// <param name="label">The text label to display next to the radio button.</param>
    /// <param name="v">A reference to the boolean value that will be toggled when the radio button is clicked.</param>
    /// <param name="activeColor">The color to use when the toggle is in the active (true) state as a Vector4 RGBA value. If null, defaults to bright green.</param>
    /// <param name="disableColor">The color to use when the toggle is in the inactive (false) state as a Vector4 RGBA value. If null, defaults to bright red.</param>
    /// <returns>True if the toggle state was changed during this frame, false otherwise.</returns>
    /// <remarks>
    /// This method creates a radio button that visually represents a toggle state using different Vector4 colors.
    /// The radio button always appears selected but changes color based on the boolean value.
    /// The color values are expected to be Vector4 RGBA values with components in the range [0, 1].
    /// The method temporarily overrides the ImGui frame background colors for the duration of the radio button.
    /// Default colors: Active = EzColor.GreenBright, Inactive = EzColor.RedBright.
    /// This overload provides more convenient color specification using Vector4 values instead of packed uint values.
    /// </remarks>
    public static bool ToggleRadio(string label, ref bool v, Vector4? activeColor = null, Vector4? disableColor = null)
    {
        activeColor ??= EzColor.GreenBright;
        disableColor ??= EzColor.RedBright;
        bool changed = false;
        var color = v ? activeColor.Value : disableColor.Value;
        ImGui.PushStyleColor(ImGuiCol.FrameBg, color);
        ImGui.PushStyleColor(ImGuiCol.FrameBgActive, color);
        ImGui.PushStyleColor(ImGuiCol.FrameBgHovered, color);
        if (ImGui.RadioButton(label, true))
        {
            changed = true;
            v ^= true;
        }
        ImGui.PopStyleColor(3);
        return changed;
    }
}
