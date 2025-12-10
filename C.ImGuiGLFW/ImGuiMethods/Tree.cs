using C.ImGuiGLFW.Color;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    /// <summary>
    /// Creates a collapsing header with a tree node layout using default padding settings.
    /// </summary>
    /// <param name="name">The display name for the collapsing header.</param>
    /// <param name="action">The action to execute when the header is expanded.</param>
    /// <param name="extraFlags">Additional tree node flags to apply.</param>
    /// <remarks>
    /// This is a convenience overload that calls the main TreeNodeCollapsingHeader method
    /// with padding enabled by default. The header is rendered using a table layout with
    /// borders for visual separation.
    /// </remarks>
    public static void TreeNodeCollapsingHeader(string name, Action action, ImGuiTreeNodeFlags extraFlags = ImGuiTreeNodeFlags.None) => TreeNodeCollapsingHeader(name, true, action, extraFlags);

    /// <summary>
    /// Creates a collapsing header with a tree node layout and configurable padding.
    /// </summary>
    /// <param name="name">The display name for the collapsing header.</param>
    /// <param name="usePadding">Whether to apply outer padding to the content area.</param>
    /// <param name="action">The action to execute when the header is expanded.</param>
    /// <param name="extraFlags">Additional tree node flags to apply.</param>
    /// <remarks>
    /// This method creates a collapsing header using ImGui tables for layout. The header
    /// appears as a selected tree node with borders. When expanded, the content is rendered
    /// in a nested table with optional padding. Any exceptions thrown by the action are
    /// caught and displayed as red text. The method automatically manages ImGui IDs and
    /// style variables to ensure proper rendering and cleanup.
    /// </remarks>
    public static void TreeNodeCollapsingHeader(string name, bool usePadding, Action action, ImGuiTreeNodeFlags extraFlags = ImGuiTreeNodeFlags.None)
    {
        ImGui.PushID("CollapsingHeaderHelperTable");
        ImGui.PushStyleVar(ImGuiStyleVar.CellPadding, Vector2.Zero);
        if (ImGui.BeginTable(name, 1, ImGuiTableFlags.Borders | ImGuiTableFlags.NoSavedSettings))
        {
            ImGui.TableSetupColumn(string.Empty, ImGuiTableColumnFlags.WidthStretch);
            ImGui.TableNextRow();
            ImGui.TableNextColumn();
            var ret = TreeNode(name, ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.Selected | extraFlags);
            ImGui.PopStyleVar();
            if (ret)
            {
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                if (ImGui.BeginTable($"2{name}", 1, ImGuiTableFlags.NoSavedSettings | (usePadding ? ImGuiTableFlags.PadOuterX : ImGuiTableFlags.None)))
                {
                    ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    try
                    {
                        action();
                    }
                    catch (Exception ex)
                    {
                        ImGui.TextColored(EzColor.RedBright, ex.ToString());
                    }
                    ImGui.EndTable();
                }
            }
            ImGui.EndTable();
        }
        else
        {
            ImGui.PopStyleVar();
        }
        ImGui.PopID();
    }

    /// <summary>
    /// Creates a tree node with default styling and full-width spanning.
    /// </summary>
    /// <param name="name">The display name for the tree node.</param>
    /// <param name="flags">Tree node flags to control appearance and behavior.</param>
    /// <returns>true if the tree node is open; otherwise, false.</returns>
    /// <remarks>
    /// This is a convenience overload that creates a tree node with SpanFullWidth flag
    /// enabled by default. The method automatically applies full-width spanning to ensure
    /// consistent layout across the available space.
    /// </remarks>
    public static bool TreeNode(string name, ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanFullWidth) => TreeNode(null, name, flags);

    /// <summary>
    /// Creates a tree node with optional text color customization and full-width spanning.
    /// </summary>
    /// <param name="color">The text color to apply to the tree node, or null for default color.</param>
    /// <param name="name">The display name for the tree node.</param>
    /// <param name="flags">Tree node flags to control appearance and behavior.</param>
    /// <returns>true if the tree node is open; otherwise, false.</returns>
    /// <remarks>
    /// This method creates a tree node using ImGui.TreeNodeEx with customizable text color.
    /// The SpanFullWidth flag is automatically added to ensure consistent layout. If a color
    /// is specified, it temporarily overrides the default text color using ImGui's style
    /// color stack, which is automatically restored after rendering. The method handles
    /// the color stack management to prevent style leaks.
    /// </remarks>
    public static bool TreeNode(Vector4? color, string name, ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanFullWidth)
    {
        flags |= ImGuiTreeNodeFlags.SpanFullWidth;
        if (color != null) ImGui.PushStyleColor(ImGuiCol.Text, color.Value);
        var ret = ImGui.TreeNodeEx(name, flags);
        if (color != null) ImGui.PopStyleColor();
        return ret;
    }
}
