namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    private const int MaxPieMenuStack = 8;
    private const int MaxPieItemCount = 12;
    private const int RadiusEmpty = 30;
    private const int MinItemCount = 3;
    private const int MinItemCountPerLevel = 3;

    private struct PieMenuData
    {
        public int CurrentIndex;
        public float MaxItemSqrDiameter;
        public float LastMaxItemSqrDiameter;
        public int HoveredItem;
        public int LastHoveredItem;
        public int ClickedItem;
        public List<bool> ItemIsSubMenu;
        public List<string> ItemNames;
        public List<Vector2> ItemSizes;
        public List<bool> Enabled;

        public PieMenuData()
        {
            CurrentIndex = 0;
            MaxItemSqrDiameter = 0f;
            LastMaxItemSqrDiameter = 0f;
            HoveredItem = -1;
            LastHoveredItem = -1;
            ClickedItem = -1;
            ItemIsSubMenu = new List<bool>(MaxPieItemCount);
            ItemNames = new List<string>(MaxPieItemCount);
            ItemSizes = new List<Vector2>(MaxPieItemCount);
            Enabled = new List<bool>(MaxPieItemCount);
        }
    }

    private struct PieMenuContext
    {
        public PieMenuData[] PieMenuStack;
        public int CurrentIndex;
        public int MaxIndex;
        public int LastFrame;
        public Vector2 Center;
        public ImGuiMouseButton MouseButton;
        public bool Close;

        public PieMenuContext()
        {
            PieMenuStack = new PieMenuData[MaxPieMenuStack];
            for (int i = 0; i < MaxPieMenuStack; i++)
            {
                PieMenuStack[i] = new PieMenuData();
            }
            CurrentIndex = -1;
            MaxIndex = 0;
            LastFrame = 0;
            Center = Vector2.Zero;
            MouseButton = ImGuiMouseButton.Left;
            Close = false;
        }
    }

    private static PieMenuContext s_context = new();

    private static bool IsPopupOpen(string name)
    {
        uint id = ImGui.GetID(name);
        return ImGuiP.IsPopupOpen(id, ImGuiPopupFlags.None);
    }

    private static void BeginPieMenuEx()
    {
        if (s_context.CurrentIndex >= MaxPieMenuStack - 1)
            throw new InvalidOperationException("Pie menu stack overflow");

        s_context.CurrentIndex++;
        s_context.MaxIndex++;

        var pieMenu = s_context.PieMenuStack[s_context.CurrentIndex];
        pieMenu.CurrentIndex = 0;
        pieMenu.MaxItemSqrDiameter = 0f;

        if (!ImGui.IsMouseReleased(s_context.MouseButton))
            pieMenu.HoveredItem = -1;

        if (s_context.CurrentIndex > 0)
            pieMenu.MaxItemSqrDiameter = s_context.PieMenuStack[s_context.CurrentIndex - 1].MaxItemSqrDiameter;

        // Clear lists for new menu
        pieMenu.ItemIsSubMenu.Clear();
        pieMenu.ItemNames.Clear();
        pieMenu.ItemSizes.Clear();
        pieMenu.Enabled.Clear();

        // Update the struct in the array
        s_context.PieMenuStack[s_context.CurrentIndex] = pieMenu;
    }

    private static void EndPieMenuEx()
    {
        if (s_context.CurrentIndex < 0)
            throw new InvalidOperationException("Pie menu stack underflow");

        s_context.CurrentIndex--;
    }

    /// <summary>
    /// Begins a pie menu popup that opens when triggered by the specified mouse button.
    /// </summary>
    /// <param name="name">The unique identifier name for the popup.</param>
    /// <param name="mouseButton">The mouse button that triggers the popup. Defaults to right mouse button.</param>
    /// <returns>True if the popup is open and ready to accept menu items, false otherwise.</returns>
    /// <remarks>
    /// This method only works when ViewportEnable is false.
    /// Must be paired with <see cref="EndPiePopup"/> when the return value is true.
    /// The popup will be centered at the mouse position when first opened.
    /// </remarks>
    public static bool BeginPiePopup(string name, ImGuiMouseButton mouseButton = ImGuiMouseButton.Right)
    {
        if (IsPopupOpen(name))
        {
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0, 0, 0, 0));
            ImGui.PushStyleColor(ImGuiCol.Border, new Vector4(0, 0, 0, 0));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 1.0f);

            s_context.MouseButton = mouseButton;
            s_context.Close = false;

            ImGui.SetNextWindowPos(new Vector2(-100f, -100f), ImGuiCond.Appearing);
            bool opened = ImGui.BeginPopup(name, ImGuiWindowFlags.NoBackground);

            if (opened)
            {
                int currentFrame = ImGui.GetFrameCount();
                if (s_context.LastFrame < (currentFrame - 1))
                {
                    s_context.Center = ImGui.GetIO().MousePos;
                }
                s_context.LastFrame = currentFrame;

                s_context.MaxIndex = -1;
                BeginPieMenuEx();

                return true;
            }
            else
            {
                ImGui.PopStyleColor(2);
                ImGui.PopStyleVar(2);
            }
        }
        return false;
    }

    /// <summary>
    /// Ends the pie menu popup and handles rendering of all pie menu items and submenus.
    /// </summary>
    /// <remarks>
    /// This method only works when ViewportEnable is false.
    /// Must be called after <see cref="BeginPiePopup"/> returns true.
    /// Handles mouse interaction, rendering, and automatic popup closing when appropriate.
    /// The popup will automatically close when the mouse is released outside of any menu item.
    /// </remarks>
    public static void EndPiePopup()
    {
        EndPieMenuEx();

        var style = ImGui.GetStyle();
        var drawList = ImGui.GetWindowDrawList();
        drawList.PushClipRectFullScreen();

        var mousePos = ImGui.GetIO().MousePos;
        var dragDelta = mousePos - s_context.Center;
        float dragDistSqr = dragDelta.LengthSquared();

        float currentRadius = RadiusEmpty;
        var area = new Vector4(s_context.Center.X, s_context.Center.Y, s_context.Center.X, s_context.Center.Y);
        bool itemHovered = false;

        const float defaultRotate = -MathF.PI / 2f;
        float lastRotate = defaultRotate;

        for (int index = 0; index <= s_context.MaxIndex; index++)
        {
            var currentIndex = index;
            var pieMenu = s_context.PieMenuStack[currentIndex];
            float menuHeight = MathF.Sqrt(pieMenu.MaxItemSqrDiameter);

            float minRadius = currentRadius;
            float maxRadius = minRadius + (menuHeight * pieMenu.CurrentIndex) / 2f;

            int itemCount = Math.Max(MinItemCount + MinItemCountPerLevel * currentIndex, pieMenu.CurrentIndex);
            float itemArcSpan = 2 * MathF.PI / itemCount;
            float dragAngle = MathF.Atan2(dragDelta.Y, dragDelta.X);

            float rotate = lastRotate - itemArcSpan * (pieMenu.CurrentIndex - 1f) / 2f;
            int itemHoveredIndex = -1;

            for (int itemN = 0; itemN < pieMenu.CurrentIndex; itemN++)
            {
                if (itemN >= pieMenu.ItemNames.Count) break;

                bool itemEnabled = itemN >= pieMenu.Enabled.Count || pieMenu.Enabled[itemN];
                string itemLabel = pieMenu.ItemNames[itemN];
                float minInnerSpacing = style.ItemInnerSpacing.X / (minRadius * 2f);
                float maxInnerSpacing = style.ItemInnerSpacing.X / (maxRadius * 2f);

                float itemInnerAngMin = itemArcSpan * (itemN - 0.5f + minInnerSpacing) + rotate;
                float itemInnerAngMax = itemArcSpan * (itemN + 0.5f - minInnerSpacing) + rotate;
                float itemOuterAngMin = itemArcSpan * (itemN - 0.5f + maxInnerSpacing) + rotate;
                float itemOuterAngMax = itemArcSpan * (itemN + 0.5f - maxInnerSpacing) + rotate;

                bool hovered = false;
                if (itemEnabled && dragDistSqr >= minRadius * minRadius && dragDistSqr < maxRadius * maxRadius)
                {
                    // Normalize angle
                    while ((dragAngle - itemInnerAngMin) < 0f)
                        dragAngle += 2f * MathF.PI;
                    while ((dragAngle - itemInnerAngMin) > 2f * MathF.PI)
                        dragAngle -= 2f * MathF.PI;

                    if (dragAngle >= itemInnerAngMin && dragAngle < itemInnerAngMax)
                    {
                        hovered = true;
                        if (itemN < pieMenu.ItemIsSubMenu.Count)
                            itemHovered = !pieMenu.ItemIsSubMenu[itemN];
                    }
                }

                int arcSegments = Math.Max(1, (int)(32 * itemArcSpan / (2 * MathF.PI)) + 1);

                uint color = hovered && itemEnabled ?
                    ImGui.GetColorU32(ImGuiCol.ButtonHovered) :
                    ImGui.GetColorU32(ImGuiCol.Button);

                // Draw pie slice
                DrawPieSlice(drawList, s_context.Center, minRadius + style.ItemInnerSpacing.X,
                           maxRadius - style.ItemInnerSpacing.X, itemInnerAngMin, itemInnerAngMax,
                           itemOuterAngMin, itemOuterAngMax, color, arcSegments);

                float radCenter = itemArcSpan * itemN + rotate;
                var outerCenter = new Vector2(
                    s_context.Center.X + MathF.Cos(radCenter) * maxRadius,
                    s_context.Center.Y + MathF.Sin(radCenter) * maxRadius
                );

                // Update area bounds
                area.X = Math.Min(area.X, outerCenter.X);
                area.Y = Math.Min(area.Y, outerCenter.Y);
                area.Z = Math.Max(area.Z, outerCenter.X);
                area.W = Math.Max(area.W, outerCenter.Y);

                // Draw submenu indicator
                if (itemN < pieMenu.ItemIsSubMenu.Count && pieMenu.ItemIsSubMenu[itemN])
                {
                    DrawSubMenuIndicator(drawList, s_context.Center, radCenter, maxRadius);
                }

                // Draw text
                if (itemN < pieMenu.ItemSizes.Count)
                {
                    var textSize = pieMenu.ItemSizes[itemN];
                    var textPos = new Vector2(
                        s_context.Center.X + MathF.Cos((itemInnerAngMin + itemInnerAngMax) * 0.5f) * (minRadius + maxRadius) * 0.5f - textSize.X * 0.5f,
                        s_context.Center.Y + MathF.Sin((itemInnerAngMin + itemInnerAngMax) * 0.5f) * (minRadius + maxRadius) * 0.5f - textSize.Y * 0.5f
                    );
                    drawList.AddText(textPos, ImGui.GetColorU32(itemEnabled ? ImGuiCol.Text : ImGuiCol.TextDisabled), itemLabel);
                }

                if (hovered)
                    itemHoveredIndex = itemN;
            }

            currentRadius = maxRadius;
            pieMenu.LastMaxItemSqrDiameter = pieMenu.MaxItemSqrDiameter;
            pieMenu.HoveredItem = itemHoveredIndex;

            if (dragDistSqr >= maxRadius * maxRadius)
                itemHoveredIndex = pieMenu.LastHoveredItem;

            pieMenu.LastHoveredItem = itemHoveredIndex;

            // Update the struct in the array
            s_context.PieMenuStack[currentIndex] = pieMenu;

            if (itemHoveredIndex != -1)
                lastRotate = itemArcSpan * pieMenu.LastHoveredItem + rotate;

            if (itemHoveredIndex == -1 ||
                itemHoveredIndex >= pieMenu.ItemIsSubMenu.Count ||
                !pieMenu.ItemIsSubMenu[itemHoveredIndex])
                break;
        }

        drawList.PopClipRect();

        // Keep menu on screen
        var displaySize = ImGui.GetIO().DisplaySize;
        if (area.X < 0f)
            s_context.Center.X += -area.X;
        if (area.Y < 0f)
            s_context.Center.Y += -area.Y;
        if (area.Z > displaySize.X)
            s_context.Center.X += displaySize.X - area.Z;
        if (area.W > displaySize.Y)
            s_context.Center.Y += displaySize.Y - area.W;

        if (s_context.Close || (!itemHovered && ImGui.IsMouseReleased(s_context.MouseButton)))
        {
            ImGui.CloseCurrentPopup();
        }

        ImGui.EndPopup();
        ImGui.PopStyleColor(2);
        ImGui.PopStyleVar(2);
    }

    private static void DrawPieSlice(ImDrawListPtr drawList, Vector2 center, float innerRadius, float outerRadius,
                                   float innerAngMin, float innerAngMax, float outerAngMin, float outerAngMax,
                                   uint color, int segments)
    {
        if (segments <= 0) return;

        float angleStepInner = (innerAngMax - innerAngMin) / segments;
        float angleStepOuter = (outerAngMax - outerAngMin) / segments;

        for (int seg = 0; seg < segments; seg++)
        {
            float cosInner1 = MathF.Cos(innerAngMin + angleStepInner * seg);
            float sinInner1 = MathF.Sin(innerAngMin + angleStepInner * seg);
            float cosOuter1 = MathF.Cos(outerAngMin + angleStepOuter * seg);
            float sinOuter1 = MathF.Sin(outerAngMin + angleStepOuter * seg);

            float cosInner2 = MathF.Cos(innerAngMin + angleStepInner * (seg + 1));
            float sinInner2 = MathF.Sin(innerAngMin + angleStepInner * (seg + 1));
            float cosOuter2 = MathF.Cos(outerAngMin + angleStepOuter * (seg + 1));
            float sinOuter2 = MathF.Sin(outerAngMin + angleStepOuter * (seg + 1));

            var p1 = new Vector2(center.X + cosInner1 * innerRadius, center.Y + sinInner1 * innerRadius);
            var p2 = new Vector2(center.X + cosOuter1 * outerRadius, center.Y + sinOuter1 * outerRadius);
            var p3 = new Vector2(center.X + cosInner2 * innerRadius, center.Y + sinInner2 * innerRadius);
            var p4 = new Vector2(center.X + cosOuter2 * outerRadius, center.Y + sinOuter2 * outerRadius);

            drawList.AddQuadFilled(p1, p2, p4, p3, color);
        }
    }

    private static void DrawSubMenuIndicator(ImDrawListPtr drawList, Vector2 center, float radCenter, float maxRadius)
    {
        float radLeft = radCenter - 5f / maxRadius;
        float radRight = radCenter + 5f / maxRadius;

        var trianglePos1 = new Vector2(
            center.X + MathF.Cos(radCenter) * (maxRadius - 5f),
            center.Y + MathF.Sin(radCenter) * (maxRadius - 5f)
        );
        var trianglePos2 = new Vector2(
            center.X + MathF.Cos(radLeft) * (maxRadius - 10f),
            center.Y + MathF.Sin(radLeft) * (maxRadius - 10f)
        );
        var trianglePos3 = new Vector2(
            center.X + MathF.Cos(radRight) * (maxRadius - 10f),
            center.Y + MathF.Sin(radRight) * (maxRadius - 10f)
        );

        drawList.AddTriangleFilled(trianglePos1, trianglePos2, trianglePos3,
                                 ImGui.GetColorU32(ImGuiCol.Text));
    }

    /// <summary>
    /// Begins a submenu within a pie menu structure.
    /// </summary>
    /// <param name="name">The display name for the submenu item.</param>
    /// <param name="enabled">Whether the submenu is enabled and can be interacted with. Defaults to true.</param>
    /// <returns>True if the submenu should be rendered (when hovered), false otherwise.</returns>
    /// <remarks>
    /// This method only works when ViewportEnable is false.
    /// Must be called within a pie menu context (between BeginPiePopup/EndPiePopup or within another BeginPieMenu/EndPieMenu).
    /// Must be paired with <see cref="EndPieMenu"/> when the return value is true.
    /// The submenu will only open when the user hovers over this menu item.
    /// </remarks>
    public static bool BeginPieMenu(string name, bool enabled = true)
    {
        if (s_context.CurrentIndex < 0 || s_context.CurrentIndex >= MaxPieMenuStack)
            throw new InvalidOperationException("Invalid pie menu context");

        var pieMenu = s_context.PieMenuStack[s_context.CurrentIndex];

        var textSize = ImGui.CalcTextSize(name);

        // Ensure lists have enough capacity
        while (pieMenu.ItemSizes.Count <= pieMenu.CurrentIndex)
            pieMenu.ItemSizes.Add(Vector2.Zero);
        while (pieMenu.ItemNames.Count <= pieMenu.CurrentIndex)
            pieMenu.ItemNames.Add(string.Empty);
        while (pieMenu.ItemIsSubMenu.Count <= pieMenu.CurrentIndex)
            pieMenu.ItemIsSubMenu.Add(false);
        while (pieMenu.Enabled.Count <= pieMenu.CurrentIndex)
            pieMenu.Enabled.Add(true);

        pieMenu.ItemSizes[pieMenu.CurrentIndex] = textSize;

        float sqrDiameter = textSize.X * textSize.X + textSize.Y * textSize.Y;
        if (sqrDiameter > pieMenu.MaxItemSqrDiameter)
        {
            pieMenu.MaxItemSqrDiameter = sqrDiameter;
        }

        pieMenu.ItemIsSubMenu[pieMenu.CurrentIndex] = true;
        pieMenu.ItemNames[pieMenu.CurrentIndex] = name;
        pieMenu.Enabled[pieMenu.CurrentIndex] = enabled;

        bool shouldOpen = pieMenu.LastHoveredItem == pieMenu.CurrentIndex;
        pieMenu.CurrentIndex++;

        // Update the struct in the array
        s_context.PieMenuStack[s_context.CurrentIndex] = pieMenu;

        if (shouldOpen)
        {
            BeginPieMenuEx();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Ends the current pie submenu.
    /// </summary>
    /// <remarks>
    /// This method only works when ViewportEnable is false.
    /// Must be called after <see cref="BeginPieMenu"/> returns true.
    /// Properly closes the submenu context and returns to the parent menu level.
    /// </remarks>
    public static void EndPieMenu()
    {
        if (s_context.CurrentIndex < 0)
            throw new InvalidOperationException("Invalid pie menu context");

        s_context.CurrentIndex--;
    }

    /// <summary>
    /// Adds a selectable item to the current pie menu.
    /// </summary>
    /// <param name="name">The display name for the menu item.</param>
    /// <param name="enabled">Whether the menu item is enabled and can be selected. Defaults to true.</param>
    /// <returns>True if the menu item was clicked/selected, false otherwise.</returns>
    /// <remarks>
    /// This method only works when ViewportEnable is false.
    /// Must be called within a pie menu context (between BeginPiePopup/EndPiePopup or within BeginPieMenu/EndPieMenu).
    /// When this method returns true, the pie menu will automatically close.
    /// Disabled items will be visually distinct and cannot be selected.
    /// </remarks>
    public static bool PieMenuItem(string name, bool enabled = true)
    {
        if (s_context.CurrentIndex < 0 || s_context.CurrentIndex >= MaxPieMenuStack)
            throw new InvalidOperationException("Invalid pie menu context");

        var pieMenu = s_context.PieMenuStack[s_context.CurrentIndex];
        var textSize = ImGui.CalcTextSize(name);

        // Ensure lists have enough capacity
        while (pieMenu.ItemSizes.Count <= pieMenu.CurrentIndex)
            pieMenu.ItemSizes.Add(Vector2.Zero);
        while (pieMenu.ItemNames.Count <= pieMenu.CurrentIndex)
            pieMenu.ItemNames.Add(string.Empty);
        while (pieMenu.ItemIsSubMenu.Count <= pieMenu.CurrentIndex)
            pieMenu.ItemIsSubMenu.Add(false);
        while (pieMenu.Enabled.Count <= pieMenu.CurrentIndex)
            pieMenu.Enabled.Add(true);

        pieMenu.ItemSizes[pieMenu.CurrentIndex] = textSize;

        float sqrDiameter = textSize.X * textSize.X + textSize.Y * textSize.Y;
        if (sqrDiameter > pieMenu.MaxItemSqrDiameter)
        {
            pieMenu.MaxItemSqrDiameter = sqrDiameter;
        }

        pieMenu.ItemIsSubMenu[pieMenu.CurrentIndex] = false;
        pieMenu.ItemNames[pieMenu.CurrentIndex] = name;
        pieMenu.Enabled[pieMenu.CurrentIndex] = enabled;

        bool active = pieMenu.CurrentIndex == pieMenu.HoveredItem;
        pieMenu.CurrentIndex++;

        // Update the struct in the array
        s_context.PieMenuStack[s_context.CurrentIndex] = pieMenu;

        if (active)
            s_context.Close = true;
        if (!enabled) return false;
        return active;
    }
}
