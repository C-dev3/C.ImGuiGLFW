namespace C.ImGuiGLFW.ImGuiMethods.Tab;

/// <summary>
/// Provides static methods for creating and managing custom tab bars with ImGui.
/// </summary>
/// <remarks>
/// This static class serves as the main API for tab bar functionality, providing methods to create,
/// manage, and render custom tab bars. It maintains global state for styling and tab bar management,
/// making it easy to use across different parts of an application.
/// </remarks>
public static class CTabBar
{
    private static readonly ImGuiUserStyle _userStyle = new();
    private static readonly TabBarStack _tabStack = new();

    /// <summary>
    /// Gets a color value converted to ImGui's 32-bit color format.
    /// </summary>
    /// <param name="index">The color index from the ImGuiUserCol enumeration.</param>
    /// <param name="alphaMul">Optional alpha multiplier to adjust transparency (default is 1.0f).</param>
    /// <returns>A 32-bit unsigned integer representing the color in ImGui format.</returns>
    /// <remarks>
    /// This method retrieves colors from the internal style and converts them to the format expected by ImGui.
    /// The alpha multiplier allows for temporary transparency adjustments without modifying the base color.
    /// </remarks>
    public static uint GetColorU32(ImGuiUserCol index, float alphaMul = 1.0f)
    {
        var color = _userStyle.Colors[(int)index];
        if (alphaMul != 1.0f)
        {
            color.W *= alphaMul;
        }
        return ImGui.ColorConvertFloat4ToU32(color);
    }

    /// <summary>
    /// Begins a new tab bar or activates an existing one with the specified identifier.
    /// </summary>
    /// <param name="label">The unique identifier for the tab bar, optionally including a display title.</param>
    /// <param name="size">Optional custom size for the tab bar. Uses automatic sizing if default Vector2 is provided.</param>
    /// <remarks>
    /// This method must be called before adding any tabs to a tab bar. If a tab bar with the given label
    /// already exists, it will be reused; otherwise, a new one will be created. The label can include
    /// a display title using the format "Title#UniqueID". This method handles the initialization and
    /// begins the rendering process for the tab bar headers.
    /// </remarks>
    public static void BeginTabBar(string label, Vector2 size = default)
    {
        if (!_tabStack.DoesTabBarExist(label, out uint index))
        {
            var bar = new TabBar(label, size);
            _tabStack.TabBars.Add(bar);
            _tabStack.CurrentTabBar = _tabStack.TabBarCount;
            _tabStack.TabBarCount++;
        }
        else
        {
            _tabStack.CurrentTabBar = index;
            _tabStack.ClearIndexCountCurrentTabBar();
        }

        _tabStack.GetCurrentTabBar().DrawTabBarTop(label);
    }

    /// <summary>
    /// Creates a complete tab bar with tabs and their associated content in a single method call.
    /// </summary>
    /// <param name="label">The unique identifier for the tab bar, optionally including a display title.</param>
    /// <param name="size">Optional custom size for the tab bar. Uses automatic sizing if default Vector2 is provided.</param>
    /// <param name="tabs">An array of tuples containing tab titles and their corresponding content rendering functions.</param>
    /// <remarks>
    /// This overload provides a convenient way to create a complete tab bar with all tabs and content
    /// in a single method call. It automatically handles the BeginTabBar, AddTab, and EndTabBar sequence,
    /// executing the provided function for each active tab. This is ideal for simple tab bars where
    /// each tab has a dedicated rendering function. The method ensures proper cleanup even if exceptions
    /// occur during tab content rendering.
    /// </remarks>
    public static void BeginTabBar(string label, Vector2 size = default, params (string? title, Action function)[] tabs)
    {
        BeginTabBar(label, size);

        foreach (var (title, function) in tabs)
        {
            if (string.IsNullOrEmpty(title)) continue;
            if (AddTab(title))
            {
                function();
            }
        }

        EndTabBar();
    }

    /// <summary>
    /// Adds a tab with the specified title to the current tab bar.
    /// </summary>
    /// <param name="title">The display title for the tab.</param>
    /// <returns>true if this tab is currently active and should render its content; otherwise, false.</returns>
    /// <remarks>
    /// This method should be called between BeginTabBar and EndTabBar for each tab you want to add.
    /// The return value indicates whether the tab content should be rendered - only render content
    /// when this method returns true. The method handles tab registration and determines visibility
    /// based on the current active tab selection.
    /// </remarks>
    public static bool AddTab(string title)
    {
        var bar = _tabStack.GetCurrentTabBar();
        bar.IndexCounter++;

        if (bar.IndexCounter > bar.TabCount)
            bar.HasBeenInitialized = false;

        if (!bar.HasBeenInitialized)
        {
            bar.TabTitles.Add(title);
            bar.TabHashes.Add(ImGuiP.ImHashStr($"{title}{bar.IndexCounter}"));
        }

        if (bar.ActiveTab != bar.IndexCounter - 1)
            return false;

        return bar.HasBeenInitialized;
    }

    /// <summary>
    /// Draws the background area for tab content.
    /// </summary>
    /// <remarks>
    /// This method renders the background area where tab content is displayed. It is called internally
    /// by EndTabBar and should not typically be called directly. The background provides visual
    /// consistency and proper clipping for the tab content area.
    /// </remarks>
    public static void DrawTabsBackground()
    {
        var bar = _tabStack.GetCurrentTabBar();
        if (bar.HasBeenInitialized && bar.TabCount > 0)
            bar.DrawTabBarBottom();
    }

    /// <summary>
    /// Completes the tab bar rendering and finalizes the tab structure.
    /// </summary>
    /// <remarks>
    /// This method must be called after all tabs have been added using AddTab. It finalizes the
    /// tab bar layout, processes any user interactions, and completes the rendering process.
    /// Always pair this method with a corresponding BeginTabBar call.
    /// </remarks>
    public static void EndTabBar()
    {
        DrawTabsBackground();
        var bar = _tabStack.GetCurrentTabBar();
        bar.SetTabCount();
        ImGui.Dummy(Vector2.Zero);
    }

    /// <summary>
    /// Sets the active tab of the currently active tab bar to the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the tab to activate.</param>
    /// <remarks>
    /// This method allows programmatic control over which tab is selected in the current tab bar.
    /// The index should be valid (less than the number of tabs) to avoid unexpected behavior.
    /// This is useful for implementing features like "go to next tab" or restoring a previously saved tab state.
    /// </remarks>
    public static void SetActiveTabOfCurrentTabBar(uint index) => _tabStack.GetCurrentTabBar().SetActiveTab(index);
}
