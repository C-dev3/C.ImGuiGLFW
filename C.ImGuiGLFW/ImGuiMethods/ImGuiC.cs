using C.ImGuiGLFW.Color;
using C.ImGuiGLFW.Text.FontAwesome;
using C.ImGuiGLFW.Text.NotoEmojis;
using C.ImGuiGLFW.Text.SeIcon;
using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    private static readonly Stack<float> indentStack = new();
    public static void PushIndent(float indent = 0f)
    {
        ImGui.Indent(indent);
        indentStack.Push(indent);
    }

    public static void PopIndent() => ImGui.Unindent(indentStack.Pop());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetMouseCursorIfHovered(ImGuiMouseCursor cursorType)
    {
        if (ImGui.IsItemHovered()) ImGui.SetMouseCursor(cursorType);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetClipboardTextIfClicked(string text)
    {
        if (ImGui.IsItemClicked()) ImGui.SetClipboardText(text);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetClipboardTextIfClicked(string text, ImGuiMouseButton mouseButton)
    {
        if (ImGui.IsItemClicked(mouseButton)) ImGui.SetClipboardText(text);
    }

    public static void Tooltip(string text)
    {
        if (ImGui.IsItemHovered())
            SetTooltip(text);
    }

    public static void SetTooltip(string text)
    {
        ImGui.BeginTooltip();
        ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35f);
        ImGui.TextUnformatted(text);
        ImGui.PopTextWrapPos();
        ImGui.EndTooltip();
    }

    public static void SetNextItemFullWidth(int mod = 0) => ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X + mod);

    public static void SetNextItemWidth(float percent, int mod = 0) => ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X * percent + mod);

    public static (string, Action, Vector4?, bool) TabItem(string id, Action function, Vector4? color = null, bool child = false) => (id, function, color, child);

    public static void TabBar(string id, params (string? name, Action function, Vector4? color, bool child)[] tabs) => TabBar(id, null, tabs);

    public static void TabBar(string id, string? openTabName, params (string? name, Action function, Vector4? color, bool child)[] tabs) => TabBar(id, openTabName, ImGuiTabBarFlags.None, tabs);

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

    public static void Prefix(string prefix = "◇")
    {
        var dummySize = new Vector2(ImGui.GetFrameHeight());
        ImGui.Dummy(dummySize);
        AddTextCentered(ImGui.GetItemRectMin() + dummySize / 2, prefix, ImGui.GetColorU32(ImGuiCol.Text));
        ImGui.SameLine();
    }

    public static void Prefix(bool isLast) => Prefix(isLast ? "└" : "├");

    private static void AddTextCentered(Vector2 pos, string text, uint color)
    {
        var textSize = ImGui.CalcTextSize(text);
        ImGui.GetWindowDrawList().AddText(pos - textSize / 2, color, text);
    }
}