namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// Provides custom group box functionality for Dear ImGui with support for borders, collapsible sections, and flexible sizing.
/// </summary>
/// <remarks>
/// The GroupBox class allows you to create bordered containers in ImGui with optional headers and collapsible functionality.
/// It uses a stack-based system to handle nested group boxes and provides automatic width calculation based on parent containers.
/// The class maintains proper clipping and cursor positioning to ensure consistent layout behavior within ImGui windows.
/// </remarks>
public static class GroupBox
{
    private static readonly Stack<GroupBoxOptions> groupBoxOptionsStack = new();

    /// <summary>
    /// Begins a new group box with optional header text and customizable appearance.
    /// </summary>
    /// <param name="id">Optional header text to display at the top of the group box. If null or empty, no header is shown.</param>
    /// <param name="minimumWindowPercent">The minimum width as a percentage of the available content region (0.0 to 1.0). Values 	&lt;= 0 enable auto-sizing.</param>
    /// <param name="options">Optional configuration object containing border color, padding, and other visual properties. If null, default options are used.</param>
    /// <returns>True if the group box content should be rendered; false if the group box is collapsed (when collapsible).</returns>
    /// <remarks>
    /// This method must be paired with a corresponding End() call. If the group box is collapsible and currently collapsed,
    /// this method returns false and automatically calls End() internally, displaying "..." to indicate collapsed content.
    /// The width calculation considers nested group boxes and applies proper spacing and padding.
    /// </remarks>
    public static bool Begin(string? id = null, float minimumWindowPercent = 1.0f, GroupBoxOptions? options = null)
    {
        options ??= new GroupBoxOptions();
        ImGui.BeginGroup();

        var open = true;
        if (!string.IsNullOrEmpty(id))
        {
            if (!options.Collapsible)
            {
                ImGui.TextColored(ImGui.ColorConvertU32ToFloat4(options.HeaderTextColor), id);
            }
            else
            {
                ImGui.PushStyleColor(ImGuiCol.Text, options.HeaderTextColor);
                open = ImGui.TreeNodeEx(id, ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.DefaultOpen);
                ImGui.PopStyleColor();
            }

            options.HeaderTextAction?.Invoke();

            // This prevents rounding issues caused by ImGui flooring the cursor position after items
            ImGui.Indent();
            ImGui.Unindent();
        }

        var style = ImGui.GetStyle();
        var spacing = style.ItemSpacing.X * (1 - minimumWindowPercent);
        var contentRegionWidth = groupBoxOptionsStack.TryPeek(out var parent) ? parent.Width - parent.BorderPadding.X * 2 : ImGui.GetContentRegionAvail().X;
        var width = Math.Max(contentRegionWidth * minimumWindowPercent - spacing, 1);
        options.Width = minimumWindowPercent > 0 ? width : 0;

        ImGui.BeginGroup();
        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, Vector2.Zero);
        ImGui.Dummy(options.BorderPadding with { X = width });
        ImGui.PopStyleVar();

        var max = ImGui.GetItemRectMax();
        options.MaxX = max.X;

        if (options.Width > 0)
            ImGui.PushClipRect(ImGui.GetItemRectMin(), max with { Y = 10000 }, true);

        ImGui.Indent(Math.Max(options.BorderPadding.X, 0.01f));
        ImGui.PushItemWidth(MathF.Floor((width - options.BorderPadding.X * 2) * 0.65f));

        groupBoxOptionsStack.Push(options);
        if (open) return true;

        ImGui.TextDisabled(". . .");
        End();
        return false;
    }

    /// <summary>
    /// Begins a new group box with specified text and options, using full width (100%).
    /// </summary>
    /// <param name="text">The header text to display at the top of the group box.</param>
    /// <param name="options">Configuration object containing border color, padding, and other visual properties.</param>
    /// <returns>True if the group box content should be rendered; false if the group box is collapsed (when collapsible).</returns>
    /// <remarks>
    /// This is a convenience overload that sets the minimum window percentage to 1.0 (100% width).
    /// </remarks>
    public static bool Begin(string text, GroupBoxOptions options) => Begin(text, 1.0f, options);

    /// <summary>
    /// Begins a new group box with a custom border color and no header text.
    /// </summary>
    /// <param name="borderColor">The color of the group box border as a 32-bit RGBA value.</param>
    /// <param name="minimumWindowPercent">The minimum width as a percentage of the available content region (0.0 to 1.0). Values &lt;= 0 enable auto-sizing.</param>
    /// <returns>True (always returns true since this overload doesn't support collapsible functionality).</returns>
    /// <remarks>
    /// This is a convenience overload for creating simple bordered containers without header text.
    /// The group box will not be collapsible when using this overload.
    /// </remarks>
    public static bool Begin(uint borderColor, float minimumWindowPercent = 1.0f) => Begin(null, minimumWindowPercent, new GroupBoxOptions { BorderColor = borderColor });

    /// <summary>
    /// Ends the current group box and draws its border.
    /// </summary>
    /// <remarks>
    /// This method must be called after a corresponding Begin() call to properly close the group box.
    /// It handles cleanup of ImGui state, draws the final border rectangle, and manages cursor positioning.
    /// The method automatically handles both auto-sized and fixed-width group boxes, adjusting clipping
    /// and cursor positions accordingly. The border is drawn using the properties specified in the
    /// GroupBoxOptions that were active when Begin() was called.
    /// </remarks>
    public static void End()
    {
        var options = groupBoxOptionsStack.Pop();
        var autoAdjust = options.Width <= 0;
        ImGui.PopItemWidth();
        ImGui.Unindent(Math.Max(options.BorderPadding.X, 0.01f));

        if (!autoAdjust)
            ImGui.PopClipRect();

        ImGui.SetCursorPosY(ImGui.GetCursorPosY() - ImGui.GetStyle().ItemSpacing.Y);
        ImGui.Dummy(options.BorderPadding with { X = 0 });

        if (!autoAdjust)
        {
            var window = ImGuiP.GetCurrentWindow().DC;
            window.CursorMaxPos = window.CursorMaxPos with { X = options.MaxX };
        }

        ImGui.EndGroup();

        var min = ImGui.GetItemRectMin();
        var max = autoAdjust ? ImGui.GetItemRectMax() : ImGui.GetItemRectMax() with { X = options.MaxX };

        ImGui.GetWindowDrawList().AddRect(min, max, options.BorderColor, options.BorderRounding, options.DrawFlags, options.BorderThickness);

        ImGui.EndGroup();
    }
}

/// <summary>
/// Configuration options for customizing the appearance and behavior of a GroupBox.
/// </summary>
/// <remarks>
/// This record provides all the customization options for GroupBox appearance including colors, padding, borders,
/// and behavioral settings like collapsibility. Default values are derived from the current ImGui style settings
/// to ensure consistency with the application's theme. The Width and MaxX properties are set internally by the
/// GroupBox class and should not be modified by user code.
/// </remarks>
public record GroupBoxOptions
{
    /// <summary>
    /// Gets or initializes a value indicating whether the group box can be collapsed when it has a header.
    /// </summary>
    /// <value>
    /// <c>true</c> if the group box should be collapsible (renders as a tree node); <c>false</c> if it should always be expanded (renders as static text).
    /// Default is <c>false</c>.
    /// </value>
    /// <remarks>
    /// When set to true, the header text becomes a clickable tree node that can expand/collapse the group box content.
    /// This only applies when a header ID is provided to the Begin method.
    /// </remarks>
    public bool Collapsible { get; init; } = false;

    /// <summary>
    /// Gets or initializes the color of the header text.
    /// </summary>
    /// <value>
    /// A 32-bit RGBA color value for the header text. Default is the current ImGui text color.
    /// </value>
    /// <remarks>
    /// This color is applied to both static header text and collapsible tree node headers.
    /// </remarks>
    public uint HeaderTextColor { get; init; } = ImGui.GetColorU32(ImGuiCol.Text);

    /// <summary>
    /// Gets or initializes an optional action to execute after rendering the header text.
    /// </summary>
    /// <value>
    /// An action delegate that will be invoked immediately after the header is rendered, or <c>null</c> if no action is needed.
    /// Default is <c>null</c>.
    /// </value>
    /// <remarks>
    /// This can be used to add additional UI elements (like buttons or icons) next to the header text.
    /// The action is called within the same horizontal layout context as the header.
    /// </remarks>
    public Action? HeaderTextAction { get; init; } = null;

    /// <summary>
    /// Gets or initializes the color of the group box border.
    /// </summary>
    /// <value>
    /// A 32-bit RGBA color value for the border. Default is the current ImGui border color.
    /// </value>
    /// <remarks>
    /// This color is used for the rectangular border drawn around the entire group box content area.
    /// </remarks>
    public uint BorderColor { get; init; } = ImGui.GetColorU32(ImGuiCol.Border);

    /// <summary>
    /// Gets or initializes the padding inside the group box border.
    /// </summary>
    /// <value>
    /// A Vector2 specifying the horizontal (X) and vertical (Y) padding in pixels. Default is the current ImGui window padding.
    /// </value>
    /// <remarks>
    /// This padding creates space between the border and the content inside the group box.
    /// The X component affects both left and right padding, while Y affects top and bottom.
    /// </remarks>
    public Vector2 BorderPadding { get; init; } = ImGui.GetStyle().WindowPadding;

    /// <summary>
    /// Gets or initializes the rounding radius for the group box border corners.
    /// </summary>
    /// <value>
    /// The radius in pixels for rounding the border corners. Default is the current ImGui frame rounding value.
    /// </value>
    /// <remarks>
    /// A value of 0 creates sharp rectangular corners, while positive values create rounded corners.
    /// </remarks>
    public float BorderRounding { get; init; } = ImGui.GetStyle().FrameRounding;

    /// <summary>
    /// Gets or initializes the drawing flags for the border rectangle.
    /// </summary>
    /// <value>
    /// ImDrawFlags that control how the border is drawn. Default is ImDrawFlags.None.
    /// </value>
    /// <remarks>
    /// These flags can be used to control which corners are rounded when BorderRounding is greater than 0,
    /// or to apply other drawing modifications supported by ImGui's draw list.
    /// </remarks>
    public ImDrawFlags DrawFlags { get; init; } = ImDrawFlags.None;

    /// <summary>
    /// Gets or initializes the thickness of the group box border.
    /// </summary>
    /// <value>
    /// The border thickness in pixels. Default is 2.0f.
    /// </value>
    /// <remarks>
    /// This determines how thick the border line appears around the group box.
    /// </remarks>
    public float BorderThickness { get; init; } = 2f;

    /// <summary>
    /// Gets or sets the calculated width of the group box.
    /// </summary>
    /// <value>
    /// The actual width in pixels that the group box will occupy, calculated internally by the GroupBox class.
    /// </value>
    /// <remarks>
    /// This property is set internally by the GroupBox.Begin method and should not be modified by user code.
    /// It represents the final calculated width after considering parent containers and percentage settings.
    /// </remarks>
    public float Width { get; set; }

    /// <summary>
    /// Gets or sets the maximum X coordinate of the group box.
    /// </summary>
    /// <value>
    /// The maximum X coordinate in screen space that the group box extends to, set internally by the GroupBox class.
    /// </value>
    /// <remarks>
    /// This property is used internally for clipping and cursor positioning. It should not be modified by user code.
    /// </remarks>
    public float MaxX { get; set; }
}
