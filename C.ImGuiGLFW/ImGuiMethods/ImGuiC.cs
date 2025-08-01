using C.ImGuiGLFW.Color;
using C.ImGuiGLFW.Text.FontAwesome;
using C.ImGuiGLFW.Text.NotoEmojis;
using C.ImGuiGLFW.Text.SeIcon;
using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// Provides extension methods and utility functions for ImGui to simplify common UI operations.
/// </summary>
/// <remarks>
/// This static class contains helper methods for ImGui operations including indentation management,
/// mouse cursor handling, clipboard operations, tooltips, and layout utilities. All methods are designed to reduce
/// boilerplate code and provide more convenient APIs for common ImGui patterns.
/// </remarks>
public static partial class ImGuiC
{
    private static readonly Stack<float> indentStack = new();

    /// <summary>
    /// Pushes an indentation level and tracks it on an internal stack for proper cleanup.
    /// </summary>
    /// <param name="indent">The amount to indent. If 0, uses the default indentation.</param>
    /// <remarks>
    /// This method automatically tracks indentation levels using an internal stack to ensure
    /// proper cleanup with PopIndent(). Always pair with PopIndent().
    /// </remarks>
    public static void PushIndent(float indent = 0f)
    {
        ImGui.Indent(indent);
        indentStack.Push(indent);
    }

    /// <summary>
    /// Pops the most recent indentation level from the stack.
    /// </summary>
    /// <remarks>
    /// This method must be called to match every PushIndent() call to maintain proper
    /// indentation stack management.
    /// </remarks>
    public static void PopIndent() => ImGui.Unindent(indentStack.Pop());

    /// <summary>
    /// Sets the mouse cursor type if the last item is currently being hovered.
    /// </summary>
    /// <param name="cursorType">The cursor type to set when hovering.</param>
    /// <remarks>
    /// This is a convenience method that combines ImGui.IsItemHovered() and ImGui.SetMouseCursor()
    /// in a single call for cleaner code.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetMouseCursorIfHovered(ImGuiMouseCursor cursorType)
    {
        if (ImGui.IsItemHovered()) ImGui.SetMouseCursor(cursorType);
    }

    /// <summary>
    /// Copies the specified text to the clipboard if the last item was clicked.
    /// </summary>
    /// <param name="text">The text to copy to the clipboard.</param>
    /// <remarks>
    /// Uses the left mouse button by default. This is useful for making clickable text elements
    /// that copy content to the clipboard.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetClipboardTextIfClicked(string text)
    {
        if (ImGui.IsItemClicked()) ImGui.SetClipboardText(text);
    }

    /// <summary>
    /// Copies the specified text to the clipboard if the last item was clicked with the specified mouse button.
    /// </summary>
    /// <param name="text">The text to copy to the clipboard.</param>
    /// <param name="mouseButton">The mouse button that must be clicked.</param>
    /// <remarks>
    /// Provides more control over which mouse button triggers the clipboard operation.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetClipboardTextIfClicked(string text, ImGuiMouseButton mouseButton)
    {
        if (ImGui.IsItemClicked(mouseButton)) ImGui.SetClipboardText(text);
    }

    /// <summary>
    /// Displays a tooltip with the specified text if the last item is being hovered.
    /// </summary>
    /// <param name="text">The text to display in the tooltip.</param>
    /// <remarks>
    /// This is a convenience method that automatically handles the hover detection and
    /// calls SetTooltip() when appropriate. The tooltip will be word-wrapped automatically.
    /// </remarks>
    public static void Tooltip(string text)
    {
        if (ImGui.IsItemHovered())
            SetTooltip(text);
    }

    /// <summary>
    /// Displays a tooltip with the specified text immediately.
    /// </summary>
    /// <param name="text">The text to display in the tooltip.</param>
    /// <remarks>
    /// This method creates a tooltip with automatic text wrapping at 35 times the current font size.
    /// Use this when you want to show a tooltip without hover detection.
    /// </remarks>
    public static void SetTooltip(string text)
    {
        ImGui.BeginTooltip();
        ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35f);
        ImGui.TextUnformatted(text);
        ImGui.PopTextWrapPos();
        ImGui.EndTooltip();
    }

    /// <summary>
    /// Sets the next item's width to fill the entire available content region.
    /// </summary>
    /// <param name="mod">Optional modifier to adjust the width by a fixed amount.</param>
    /// <remarks>
    /// This is useful for creating full-width input fields or other UI elements.
    /// The modifier can be negative to reduce the width or positive to extend it.
    /// </remarks>
    public static void SetNextItemFullWidth(int mod = 0) => ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X + mod);

    /// <summary>
    /// Sets the next item's width to a percentage of the available content region.
    /// </summary>
    /// <param name="percent">The percentage of available width to use (0.0 to 1.0).</param>
    /// <param name="mod">Optional modifier to adjust the width by a fixed amount.</param>
    /// <remarks>
    /// Allows for responsive layouts by setting item widths as percentages rather than
    /// fixed pixel values.
    /// </remarks>
    public static void SetNextItemWidth(float percent, int mod = 0) => ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X * percent + mod);

    /// <summary>
    /// Creates a tab item configuration for use with TabBar methods.
    /// </summary>
    /// <param name="id">The identifier and display name for the tab.</param>
    /// <param name="function">The action to execute when the tab is active.</param>
    /// <param name="color">Optional text color for the tab.</param>
    /// <param name="child">Whether to wrap the tab content in a child window.</param>
    /// <returns>A tuple containing the tab configuration.</returns>
    /// <remarks>
    /// This is a helper method for creating tab configurations that can be passed to TabBar methods.
    /// </remarks>
    public static (string, Action, Vector4?, bool) TabItem(string id, Action function, Vector4? color = null, bool child = false) => (id, function, color, child);

    /// <summary>
    /// Creates a tab bar with the specified tabs.
    /// </summary>
    /// <param name="id">The unique identifier for the tab bar.</param>
    /// <param name="tabs">The tab configurations to display.</param>
    /// <remarks>
    /// This overload uses default flags and no initially selected tab.
    /// </remarks>
    public static void TabBar(string id, params (string? name, Action function, Vector4? color, bool child)[] tabs) => TabBar(id, null, tabs);

    /// <summary>
    /// Creates a tab bar with the specified tabs and an initially selected tab.
    /// </summary>
    /// <param name="id">The unique identifier for the tab bar.</param>
    /// <param name="openTabName">The name of the tab that should be initially selected.</param>
    /// <param name="tabs">The tab configurations to display.</param>
    /// <remarks>
    /// This overload allows specifying which tab should be selected when the tab bar is first displayed.
    /// </remarks>
    public static void TabBar(string id, string? openTabName, params (string? name, Action function, Vector4? color, bool child)[] tabs) => TabBar(id, openTabName, ImGuiTabBarFlags.None, tabs);

    /// <summary>
    /// Creates a tab bar with full customization options.
    /// </summary>
    /// <param name="id">The unique identifier for the tab bar.</param>
    /// <param name="openTabName">The name of the tab that should be initially selected.</param>
    /// <param name="flags">ImGui tab bar flags for customization.</param>
    /// <param name="tabs">The tab configurations to display.</param>
    /// <remarks>
    /// This is the most flexible TabBar method, allowing full control over tab bar behavior
    /// through ImGui flags. Each tab's content is executed within a try-catch block for error handling.
    /// </remarks>
    public static void TabBar(string id, string? openTabName, ImGuiTabBarFlags flags, params (string? name, Action function, Vector4? color, bool child)[] tabs)
    {
        if (ImGui.BeginTabBar(id, flags))
        {
            foreach (var (name, function, color, child) in tabs)
            {
                if (string.IsNullOrEmpty(name)) continue;
                if (color != null) ImGui.PushStyleColor(ImGuiCol.Text, color.Value);
                if (ImGui.BeginTabItem(name, !string.IsNullOrEmpty(openTabName) && openTabName == name ? ImGuiTabItemFlags.SetSelected : ImGuiTabItemFlags.None))
                {
                    if (color != null) ImGui.PopStyleColor();
                    if (child) ImGui.BeginChild(name + "child");
                    try
                    {
                        function();
                    }
                    catch (Exception ex)
                    {
                        ImGui.TextColored(EzColor.Red, ex.Message);
                    }
                    if (child) ImGui.EndChild();
                    ImGui.EndTabItem();
                }
                else
                {
                    if (color != null) ImGui.PopStyleColor();
                }
            }
            ImGui.EndTabBar();
        }
    }

    /// <summary>
    /// Displays a help marker with a FontAwesome icon that shows a tooltip when hovered.
    /// </summary>
    /// <param name="text">The help text to display in the tooltip.</param>
    /// <param name="icon">The FontAwesome icon to display.</param>
    /// <param name="color">Optional color for the icon.</param>
    /// <remarks>
    /// The help marker appears on the same line as the previous item and displays as a
    /// disabled text icon that shows the help text when hovered.
    /// </remarks>
    public static void HelpMarker(string text, FontAwesomeIcon icon, Vector4? color = null)
    {
        int popCount = 0;
        if (color.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.TextDisabled, color.Value);
            popCount++;
        }
        ImGui.SameLine();
        ImGui.TextDisabled(icon.ToIconString());
        Tooltip(text);
        if (popCount > 0) ImGui.PopStyleColor(popCount);
    }

    /// <summary>
    /// Displays a help marker with a SeIcon character that shows a tooltip when hovered.
    /// </summary>
    /// <param name="text">The help text to display in the tooltip.</param>
    /// <param name="icon">The SeIcon character to display.</param>
    /// <param name="color">Optional color for the icon.</param>
    /// <remarks>
    /// Similar to the FontAwesome version but uses SeIcon characters for the marker icon.
    /// </remarks>
    public static void HelpMarker(string text, SeIconChar icon, Vector4? color = null)
    {
        int popCount = 0;
        if (color.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.TextDisabled, color.Value);
            popCount++;
        }
        ImGui.SameLine();
        ImGui.TextDisabled(icon.ToIconString());
        Tooltip(text);
        if (popCount > 0) ImGui.PopStyleColor(popCount);
    }

    /// <summary>
    /// Displays a help marker with a Noto emoji that shows a tooltip when hovered.
    /// </summary>
    /// <param name="text">The help text to display in the tooltip.</param>
    /// <param name="icon">The Noto emoji to display.</param>
    /// <param name="color">Optional color for the icon.</param>
    /// <remarks>
    /// Similar to other HelpMarker methods but uses Noto emoji characters for the marker icon.
    /// </remarks>
    public static void HelpMarker(string text, NotoEmoji icon, Vector4? color = null)
    {
        int popCount = 0;
        if (color.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.TextDisabled, color.Value);
            popCount++;
        }
        ImGui.SameLine();
        ImGui.TextDisabled(icon.ToIconString());
        Tooltip(text);
        if (popCount > 0) ImGui.PopStyleColor(popCount);
    }

    /// <summary>
    /// Centers an ImGui item within the available content region.
    /// </summary>
    /// <param name="itemWidth">The width of the item to be centered</param>
    public static void CenterItem(float itemWidth)
    {
        float availableWidth = ImGui.GetContentRegionAvail().X;
        float centerX = (availableWidth - itemWidth) * 0.5f;
        if (centerX > 0.0f)
        {
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + centerX);
        }
    }

    /// <summary>
    /// Centers an ImGui item vertically within the available content region.
    /// </summary>
    /// <param name="itemHeight">The height of the item to be centered</param>
    public static void CenterItemVertically(float itemHeight)
    {
        float availableHeight = ImGui.GetContentRegionAvail().Y;
        float centerY = (availableHeight - itemHeight) * 0.5f;
        if (centerY > 0.0f)
        {
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + centerY);
        }
    }

    /// <summary>
    /// Centers an ImGui item both horizontally and vertically within the available content region.
    /// </summary>
    /// <param name="itemSize">The size of the item to be centered</param>
    public static void CenterItem(Vector2 itemSize)
    {
        Vector2 availableSize = ImGui.GetContentRegionAvail();
        Vector2 center = (availableSize - itemSize) * 0.5f;
        if (center.X > 0.0f)
        {
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + center.X);
        }
        if (center.Y > 0.0f)
        {
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + center.Y);
        }
    }

    /// <summary>
    /// Aligns a menu to the right side of the current window.
    /// </summary>
    /// <param name="label">The label text for the menu.</param>
    /// <param name="drawAction">Optional action to execute for drawing menu contents.</param>
    /// <param name="enabled">Whether the menu is enabled and clickable.</param>
    /// <param name="additionalPadding">Additional padding to apply to the positioning calculation.</param>
    /// <remarks>
    /// This method calculates the required width and positions the menu at the right edge
    /// of the window, accounting for padding and the menu label size.
    /// </remarks>
    public static void AlignMenuToRight(string label, Action? drawAction = null, bool enabled = true, float additionalPadding = 0f)
    {
        float totalWidth = ImGui.CalcTextSize(label).X + ImGui.GetStyle().FramePadding.X * 3f + additionalPadding;
        float rightPosition = ImGui.GetWindowWidth() - totalWidth;

        ImGui.SetCursorPosX(rightPosition);
        if (ImGui.BeginMenu(label, enabled))
        {
            drawAction?.Invoke();
            ImGui.EndMenu();
        }
    }

    /// <summary>
    /// Draws a prefix symbol before the next UI element.
    /// </summary>
    /// <param name="prefix">The prefix string to display. Defaults to "◇".</param>
    /// <remarks>
    /// Creates a visual prefix marker that appears before subsequent UI elements.
    /// The prefix is centered within a dummy area the size of the current frame height.
    /// </remarks>
    public static void Prefix(string prefix = "◇")
    {
        var dummySize = new Vector2(ImGui.GetFrameHeight());
        ImGui.Dummy(dummySize);
        AddTextCentered(ImGui.GetItemRectMin() + dummySize / 2, prefix, ImGui.GetColorU32(ImGuiCol.Text));
        ImGui.SameLine();
    }

    /// <summary>
    /// Draws a tree-style prefix symbol indicating whether this is the last item in a branch.
    /// </summary>
    /// <param name="isLast">True if this is the last item in the current branch level.</param>
    /// <remarks>
    /// Uses "└" for the last item and "├" for non-last items to create tree-like visual hierarchies.
    /// </remarks>
    public static void Prefix(bool isLast) => Prefix(isLast ? "└" : "├");

    private static void AddTextCentered(Vector2 pos, string text, uint color)
    {
        var textSize = ImGui.CalcTextSize(text);
        ImGui.GetWindowDrawList().AddText(pos - textSize / 2, color, text);
    }
}