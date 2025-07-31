using C.ImGuiGLFW.Color;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    public static void TreeNodeCollapsingHeader(string name, Action action, ImGuiTreeNodeFlags extraFlags = ImGuiTreeNodeFlags.None) => TreeNodeCollapsingHeader(name, true, action, extraFlags);

    public static void TreeNodeCollapsingHeader(string name, bool usePadding, Action action, ImGuiTreeNodeFlags extraFlags = ImGuiTreeNodeFlags.None)
    {
        ImGui.PushID("CollapsingHeaderHelperTable");
        ImGui.PushStyleVar(ImGuiStyleVar.CellPadding, Vector2.Zero);
        if (ImGui.BeginTable($"{name}", 1, ImGuiTableFlags.Borders | ImGuiTableFlags.NoSavedSettings))
        {
            ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch);
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

    public static bool TreeNode(string name, ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanFullWidth) => TreeNode(null, name, flags);

    public static bool TreeNode(Vector4? color, string name, ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanFullWidth)
    {
        flags |= ImGuiTreeNodeFlags.SpanFullWidth;
        if (color != null) ImGui.PushStyleColor(ImGuiCol.Text, color.Value);
        var ret = ImGui.TreeNodeEx(name, flags);
        if (color != null) ImGui.PopStyleColor();
        return ret;
    }
}
