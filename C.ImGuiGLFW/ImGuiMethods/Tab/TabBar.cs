namespace C.ImGuiGLFW.ImGuiMethods.Tab;

/// <summary>
/// Represents a tab bar control with customizable tabs and styling.
/// </summary>
/// <remarks>
/// This class provides a complete tab bar implementation with support for multiple tabs, custom sizing,
/// hover effects, and proper rendering with ImGui. It handles tab selection, drawing, and user interaction.
/// The tab bar supports both automatic width calculation and custom sizing.
/// </remarks>
internal class TabBar(string label, Vector2 tabBarSize)
{
    private static readonly uint BGColor = ImGui.ColorConvertFloat4ToU32(new Vector4(1.0f, 1.0f, 1.0f, 0.15f));
    private static readonly uint BorderColor = ImGui.ColorConvertFloat4ToU32(new Vector4(1.0f, 1.0f, 1.0f, 0.35f));

    /// <summary>
    /// Gets the list of tab titles displayed in the tab bar.
    /// </summary>
    /// <remarks>
    /// This collection is automatically populated when tabs are added and should not be modified directly.
    /// The order of titles corresponds to the visual order of tabs in the interface.
    /// </remarks>
    public List<string> TabTitles { get; private set; } = [];

    /// <summary>
    /// Gets the list of unique hash values for each tab.
    /// </summary>
    /// <remarks>
    /// These hash values are used internally for tab identification and should not be modified directly.
    /// Each hash is generated based on the tab title and index to ensure uniqueness.
    /// </remarks>
    public List<uint> TabHashes { get; private set; } = [];

    /// <summary>
    /// Gets or sets the total number of tabs in the tab bar.
    /// </summary>
    /// <remarks>
    /// This value is automatically managed by the tab bar and reflects the current number of active tabs.
    /// It should not be set directly unless you know what you're doing.
    /// </remarks>
    public int TabCount { get; set; } = 0;

    /// <summary>
    /// Gets or sets the index of the currently active (selected) tab.
    /// </summary>
    /// <remarks>
    /// The index is zero-based. Setting this value will change which tab appears as selected.
    /// If set to an invalid index, it will be automatically corrected during rendering.
    /// </remarks>
    public int ActiveTab { get; set; } = 0;

    /// <summary>
    /// Gets or sets the title text displayed above the tab bar.
    /// </summary>
    /// <remarks>
    /// This title is extracted from the label parameter and displayed above the tabs.
    /// If empty, no title will be shown.
    /// </remarks>
    public string BarTitle { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the size of the tab bar.
    /// </summary>
    /// <remarks>
    /// If X or Y components are set to 0 or negative values, automatic sizing will be used.
    /// Custom sizing allows for precise control over tab bar dimensions.
    /// </remarks>
    public Vector2 Size { get; set; } = tabBarSize;

    /// <summary>
    /// Gets or sets the unique hash identifier for this tab bar.
    /// </summary>
    /// <remarks>
    /// This hash is used to identify the tab bar instance and is automatically generated from the label.
    /// It enables proper state management across multiple tab bars.
    /// </remarks>
    public uint Hash { get; set; } = ImGuiP.ImHashStr(label);

    /// <summary>
    /// Gets or sets the internal counter used for tab indexing during construction.
    /// </summary>
    /// <remarks>
    /// This counter is used internally during the tab bar building process and should not be modified directly.
    /// It helps track the number of tabs being added in the current frame.
    /// </remarks>
    public int IndexCounter { get; set; } = 0;

    /// <summary>
    /// Gets or sets the upper-left position of the tab content area.
    /// </summary>
    /// <remarks>
    /// This position is calculated during rendering and represents where the tab content should begin.
    /// It accounts for padding and the tab header height.
    /// </remarks>
    public Vector2 UpperLeft { get; set; } = Vector2.Zero;

    /// <summary>
    /// Gets or sets whether the tab bar has completed its initialization.
    /// </summary>
    /// <remarks>
    /// This flag indicates whether the tab bar has been fully set up with all its tabs.
    /// During initialization, tabs are added and the layout is calculated.
    /// </remarks>
    public bool HasBeenInitialized { get; set; } = false;

    /// <summary>
    /// Gets or sets the corner rounding radius used for tab rendering.
    /// </summary>
    /// <remarks>
    /// This value controls how rounded the corners of tabs appear. A value of 0 results in sharp corners,
    /// while higher values create more rounded appearances.
    /// </remarks>
    public float CornerRounding { get; set; } = 0;

    /// <summary>
    /// Gets or sets the index of a newly selected tab, or -1 if no new selection occurred.
    /// </summary>
    /// <remarks>
    /// This value is set when a user clicks on a tab and is used to update the active tab.
    /// A value of -1 indicates no new selection has been made in the current frame.
    /// </remarks>
    public int NewSelected { get; set; } = -1;

    private Vector2 TabBarStartPos { get; set; } = Vector2.Zero;

    /// <summary>
    /// Sets the active tab to the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the tab to activate.</param>
    /// <remarks>
    /// This method provides a safe way to programmatically change the active tab.
    /// The index will be validated during the next rendering cycle.
    /// </remarks>
    public void SetActiveTab(uint index) => ActiveTab = (int)index;

    /// <summary>
    /// Gets the index of the currently active tab.
    /// </summary>
    /// <returns>The zero-based index of the active tab.</returns>
    /// <remarks>
    /// This method provides read-only access to the current active tab index.
    /// Use SetActiveTab to change the active tab programmatically.
    /// </remarks>
    public int GetActiveTab() => ActiveTab;

    /// <summary>
    /// Renders the top portion of the tab bar including the tab headers.
    /// </summary>
    /// <param name="label">The label identifier for the tab bar, optionally including a title before the # symbol.</param>
    /// <remarks>
    /// This method handles the rendering of tab headers, title text, hover effects, and click detection.
    /// It should be called before adding tab content and must be paired with DrawTabBarBottom.
    /// The label can include a title by using the format "Title#UniqueID".
    /// </remarks>
    public void DrawTabBarTop(string label)
    {
        if (!HasBeenInitialized)
            return;

        var style = ImGui.GetStyle();
        var padding = style.WindowPadding;
        var framePadding = style.FramePadding;

        var drawList = ImGui.GetWindowDrawList();

        TabBarStartPos = ImGui.GetCursorPos();

        // Extract title from label
        var hashIndex = label.IndexOf('#');
        BarTitle = hashIndex > 0 ? label[..hashIndex] : label;
        if (!string.IsNullOrEmpty(BarTitle))
        {
            ImGui.Text($"\t{BarTitle}");
        }

        var pos = ImGui.GetCursorPos();

        // Early return if no tabs, but after showing title
        if (TabCount == 0)
        {
            ImGui.SetCursorPos(pos + new Vector2(0, padding.Y));
            return;
        }

        var windowSize = ImGui.GetWindowSize();
        var windowPos = ImGui.GetWindowPos();

        float availableWidth;
        if (Size.X > 0)
        {
            availableWidth = Size.X; // Use custom width from size parameter
        }
        else
        {
            availableWidth = windowSize.X - 2 * padding.X; // Use default window-based calculation
        }
        var division = availableWidth / TabCount;

        const float rounding = 6.0f;
        const float shrink = 1.0f;

        var tabHeight = ImGui.CalcTextSize(TabTitles[0]).Y + framePadding.Y * 2;

        float selectedOffset = 0;
        Vector2 selectedExpands = Vector2.Zero;
        EdgeType selectedShadowEdges = EdgeType.None;
        int selectedIndex = 0;

        float maxX, minX;
        if (Size.X > 0)
        {
            // Use custom size for clipping boundaries
            minX = windowPos.X + pos.X;
            maxX = minX + Size.X;
        }
        else
        {
            // Use default window boundaries
            maxX = windowPos.X + windowSize.X - padding.X;
            minX = windowPos.X + padding.X;
        }

        if (ActiveTab > TabCount - 1)
            ActiveTab = TabCount - 1;

        NewSelected = -1;

        var tabNormalColorU32 = CTabBar.GetColorU32(ImGuiUserCol.TabNormal);
        var tabHoverColorU32 = CTabBar.GetColorU32(ImGuiUserCol.TabHover);
        var tabBorderShadowColorU32 = CTabBar.GetColorU32(ImGuiUserCol.TabBorderShadow);
        var tabTitleTextNormalColorU32 = CTabBar.GetColorU32(ImGuiUserCol.TabTitleTextNormal);

        // Draw non-selected tabs first
        for (int i = 0; i < TabCount; i++)
        {
            var offset = i * division;
            var selected = ActiveTab == i;
            Vector2 expands;

            if (!selected)
            {
                if (i == 0)
                    expands = new Vector2(0, 2);
                else if (i == TabCount - 1)
                    expands = new Vector2(1, 0);
                else
                    expands = new Vector2(1, 2);

                var xl = offset - expands.X + shrink;
                var xr = offset + division - shrink + expands.Y;
                var min = pos + new Vector2(xl, 0);
                var max = pos + new Vector2(xr, tabHeight);

                var hovered = ImGui.IsMouseHoveringRect(min, max);
                var clicked = hovered && ImGui.IsMouseClicked(ImGuiMouseButton.Left);

                if (clicked)
                    NewSelected = i;

                var color = hovered ?
                    tabHoverColorU32 :
                    tabNormalColorU32;

                // Draw background rect
                drawList.AddRectFilled(min, max, color, rounding, ImDrawFlags.RoundCornersTop);

                // Draw border
                DrawPartialRect(min, max, rounding, ImDrawFlags.RoundCornersTop, drawList,
                    EdgeType.Left | EdgeType.Right | EdgeType.Top,
                    tabBorderShadowColorU32);

                // Draw text
                var textSize = ImGui.CalcTextSize(TabTitles[i]);
                var textPos = pos + new Vector2(offset + (xr - xl - textSize.X) / 2.0f,
                    (textSize.Y - framePadding.Y * 2.0f) / 2.0f);
                drawList.AddText(textPos, tabTitleTextNormalColorU32, TabTitles[i]);
            }
            else
            {
                selectedOffset = offset;
                selectedIndex = i;
                if (i == 0)
                {
                    selectedExpands = new Vector2(0, rounding);
                    selectedShadowEdges = EdgeType.Right;
                }
                else if (i == TabCount - 1)
                {
                    selectedExpands = new Vector2(rounding, 0);
                    selectedShadowEdges = EdgeType.Left;
                }
                else
                {
                    selectedExpands = new Vector2(rounding, rounding);
                    selectedShadowEdges = EdgeType.Right | EdgeType.Left;
                }
            }
        }

        // Draw selected tab on top
        var selectedXl = selectedOffset - selectedExpands.X + shrink;
        var selectedXr = selectedOffset + division - shrink + selectedExpands.Y;
        var selectedMin = pos + new Vector2(selectedXl, 0);
        var selectedMax = pos + new Vector2(selectedXr, tabHeight);

        drawList.AddRectFilled(selectedMin, selectedMax,
            tabNormalColorU32, rounding, ImDrawFlags.RoundCornersTop);
        drawList.AddRectFilled(selectedMin, selectedMax,
            BorderColor, rounding, ImDrawFlags.RoundCornersTop);

        // Draw border with shadow
        DrawPartialRect(selectedMin, selectedMax, rounding, ImDrawFlags.RoundCornersTop,
            drawList,
            EdgeType.Left | EdgeType.Right | EdgeType.Top,
            tabBorderShadowColorU32,
            true, selectedShadowEdges);

        // Draw text with shadow
        var selectedTextSize = ImGui.CalcTextSize(TabTitles[selectedIndex]);
        var selectedTextPos = pos + new Vector2(
            selectedOffset + (selectedXr - selectedXl - selectedTextSize.X) / 2.0f - selectedExpands.X,
            (selectedTextSize.Y - framePadding.Y * 2.0f) / 2.0f);

        var tabTitleTextSelectedColorU32 = CTabBar.GetColorU32(ImGuiUserCol.TabTitleTextSelected);

        drawList.AddText(selectedTextPos + new Vector2(1, 1),
            tabTitleTextNormalColorU32, TabTitles[selectedIndex]); // Shadow
        drawList.AddText(selectedTextPos,
            tabTitleTextSelectedColorU32, TabTitles[selectedIndex]);

        ImGui.SetCursorPos(ImGui.GetCursorPos() + new Vector2(0, tabHeight + padding.Y));
        UpperLeft = ImGui.GetCursorPos() - new Vector2(0, padding.Y);
        ImGui.Indent(padding.X);
        CornerRounding = rounding;

        ImGui.PushClipRect(new Vector2(minX, selectedMax.Y),
            new Vector2(maxX, windowPos.Y + windowSize.Y), false);
    }

    /// <summary>
    /// Renders the bottom portion of the tab bar including the content background.
    /// </summary>
    /// <remarks>
    /// This method draws the background area where tab content is displayed and completes the tab bar rendering.
    /// It must be called after all tab content has been rendered and should be paired with DrawTabBarTop.
    /// The method also handles clipping restoration and cursor positioning.
    /// </remarks>
    public void DrawTabBarBottom()
    {
        var drawList = ImGui.GetWindowDrawList();
        var style = ImGui.GetStyle();
        var padding = style.WindowPadding;

        var currentPos = ImGui.GetCursorPos();
        var windowPos = ImGui.GetWindowPos();
        var windowSizeX = ImGui.GetWindowSize().X;

        Vector2 bottomRight;
        if (Size.X > 0 || Size.Y > 0)
        {
            // Use custom size when available
            float rightX = Size.X > 0 ?
                UpperLeft.X + Size.X :
                windowPos.X + windowSizeX - padding.X;

            float bottomY = Size.Y > 0 ?
                TabBarStartPos.Y + Size.Y :
                windowPos.Y + currentPos.Y + padding.Y;
            bottomRight = new Vector2(rightX, bottomY);
        }
        else
        {
            // Use default calculation when no custom size is specified
            bottomRight = new Vector2(
                windowPos.X + windowSizeX - padding.X,
                windowPos.Y + currentPos.Y + padding.Y
            );
        }

        drawList.AddRectFilled(UpperLeft, bottomRight,
            BGColor,
            CornerRounding, ImDrawFlags.RoundCornersBottom);

        drawList.AddRect(UpperLeft, bottomRight,
            BorderColor,
            CornerRounding, ImDrawFlags.RoundCornersBottom);
        ImGui.PopClipRect();
        ImGui.SetCursorPos(bottomRight);
    }

    /// <summary>
    /// Finalizes the tab count and processes any new tab selections.
    /// </summary>
    /// <remarks>
    /// This method should be called after all tabs have been added to the tab bar.
    /// It handles updating the active tab based on user interactions and validates the tab structure.
    /// If the tab structure has changed, it will reinitialize the tab bar.
    /// </remarks>
    public void SetTabCount()
    {
        if (NewSelected >= 0)
        {
            ActiveTab = NewSelected;
        }

        if (HasBeenInitialized && TabCount != IndexCounter)
        {
            HasBeenInitialized = false;
            TabTitles.Clear();
            TabHashes.Clear();
            return;
        }

        TabCount = IndexCounter;
        HasBeenInitialized = true;            
    }

    private static void DrawPartialRect(Vector2 a, Vector2 b, float rounding, ImDrawFlags roundingCorners,
    ImDrawListPtr drawList, EdgeType edges, uint color, bool shadow = false,
    EdgeType shadowEdges = EdgeType.None, float shadowOffset = 4.0f, float shadowAlpha = 0.075f)
    {
        float r = rounding;

        var absWidth = MathF.Abs(b.X - a.X);
        var absHeight = MathF.Abs(b.Y - a.Y);

        r = MathF.Min(r, absWidth *
            (roundingCorners.HasFlag(ImDrawFlags.RoundCornersTop) ||
            roundingCorners.HasFlag(ImDrawFlags.RoundCornersBottom) ? 0.5f : 1.0f) - 1.0f);

        r = MathF.Min(r, absHeight *
            (roundingCorners.HasFlag(ImDrawFlags.RoundCornersLeft) ||
            roundingCorners.HasFlag(ImDrawFlags.RoundCornersRight) ? 0.5f : 1.0f) - 1.0f);

        if (r <= float.NegativeZero || roundingCorners == ImDrawFlags.None)
        {
            var topRight = new Vector2(b.X, a.Y);
            var bottomLeft = new Vector2(a.X, b.Y);

            if (edges.HasFlag(EdgeType.Top))
            {
                drawList.PathLineTo(a);
                drawList.PathLineTo(topRight);
                drawList.PathStroke(color);
            }
            if (edges.HasFlag(EdgeType.Right))
            {
                drawList.PathLineTo(topRight);
                drawList.PathStroke(color);
                drawList.PathLineTo(b);
            }
            if (edges.HasFlag(EdgeType.Bottom))
            {
                drawList.PathLineTo(b);
                drawList.PathLineTo(bottomLeft);
                drawList.PathStroke(color);
            }
            if (edges.HasFlag(EdgeType.Left))
            {
                drawList.PathLineTo(bottomLeft);
                drawList.PathLineTo(a);
                drawList.PathStroke(color);
            }
        }
        else
        {
            float r0 = roundingCorners.HasFlag(ImDrawFlags.RoundCornersTopLeft) ? r : 0.0f;
            float r1 = roundingCorners.HasFlag(ImDrawFlags.RoundCornersTopRight) ? r : 0.0f;
            float r2 = roundingCorners.HasFlag(ImDrawFlags.RoundCornersBottomRight) ? r : 0.0f;
            float r3 = roundingCorners.HasFlag(ImDrawFlags.RoundCornersBottomLeft) ? r : 0.0f;

            var topLeftCenter = new Vector2(a.X + r0, a.Y + r0);
            var topRightCenter = new Vector2(b.X - r1, a.Y + r1);
            var bottomRightCenter = new Vector2(b.X - r2, b.Y - r2);
            var bottomLeftCenter = new Vector2(a.X + r3, b.Y - r3);

            if (edges.HasFlag(EdgeType.Top))
            {
                drawList.PathArcToFast(topLeftCenter, r0, 6, 9);
                drawList.PathArcToFast(topRightCenter, r1, 9, 12);
                drawList.PathStroke(color);
            }
            if (edges.HasFlag(EdgeType.Right))
            {
                drawList.PathArcToFast(topRightCenter, r1, 9, 12);
                drawList.PathArcToFast(bottomRightCenter, r2, 0, 3);
                drawList.PathStroke(color);
            }
            if (edges.HasFlag(EdgeType.Bottom))
            {
                drawList.PathArcToFast(bottomRightCenter, r2, 0, 3);
                drawList.PathArcToFast(bottomLeftCenter, r3, 3, 6);
                drawList.PathStroke(color);
            }
            if (edges.HasFlag(EdgeType.Left))
            {
                drawList.PathArcToFast(bottomLeftCenter, r3, 3, 6);
                drawList.PathArcToFast(topLeftCenter, r0, 6, 9);
                drawList.PathStroke(color);
            }
            if (shadow)
            {
                uint col = ImGui.ColorConvertFloat4ToU32(new Vector4(0, 0, 0, shadowAlpha));
                if (shadowEdges.HasFlag(EdgeType.Left))
                {
                    drawList.PathArcToFast(new Vector2(a.X + r3 - shadowOffset, b.Y - r3), r3, 3, 6);
                    drawList.PathArcToFast(new Vector2(a.X + r0 - shadowOffset, a.Y + r0), r0, 6, 9);
                    drawList.PathLineTo(new Vector2(a.X, b.Y));
                    drawList.PathFillConvex(col);
                }
                if (shadowEdges.HasFlag(EdgeType.Right))
                {
                    drawList.PathArcToFast(new Vector2(b.X - r1 + shadowOffset, a.Y + r1), r1, 9, 12);
                    drawList.PathArcToFast(new Vector2(b.X - r2 + shadowOffset, b.Y - r2), r2, 0, 3);
                    drawList.PathLineTo(b);
                    drawList.PathFillConvex(col);
                }
            }
        }
    }
}
