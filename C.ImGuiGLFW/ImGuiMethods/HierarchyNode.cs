using C.ImGuiGLFW.Text.FontAwesome;

namespace C.ImGuiGLFW.ImGuiMethods;

public class HierarchyNode(string name)
{
    public HierarchyNode(string name, bool hasVisibilityToggle) : this(name) => HasVisibilityToggle = hasVisibilityToggle;
    public HierarchyNode(string name, bool hasVisibilityToggle, bool isVisible) : this(name, hasVisibilityToggle) => IsVisible = isVisible;
    public HierarchyNode(string name, bool isVisible, bool hasVisibilityToggle, List<HierarchyNode> children) : this(name, hasVisibilityToggle, isVisible) => Children = children;

    public string Name { get; set; } = name;
    public bool IsVisible { get; set; } = true;
    public bool HasVisibilityToggle { get; set; } = true;
    public object? Data { get; set; } = null;
    public List<HierarchyNode> Children { get; set; } = [];
}

public struct HierarchyDragDropData
{
    public int NodeId { get; set; }
    public string NodeName { get; set; }
}

public class HierarchyViewer
{
    private string searchText = string.Empty;
    private bool isWindowOpen = true;
    private int nextNodeId = 1;
    private readonly Dictionary<int, HierarchyNode> nodeIdMap = [];
    private bool showContextMenu = false;
    private HierarchyNode? contextMenuNode = null;
    private readonly List<ContextMenuItem> customContextMenuItems = [];

    private List<HierarchyNode> rootNodes = [];

    private bool nodeIdMapNeedsRebuild = true;

    public event Action<HierarchyNode> OnNodeSelected = null!;
    public event Action<HierarchyNode, bool> OnNodeVisibilityChanged = null!;
    public event Action<HierarchyNode, HierarchyNode?, int> OnNodeMoved = null!; // (moved node, new parent, new index)

    public bool UseChildWindow { get; set; } = false;

    public bool HasContextMenu { get; set; } = true;

    public bool HasDuplicateContextMenu { get; set; } = true;

    public bool HasDeleteContextMenu { get; set; } = true;

    public bool HasVisibilityToggleContextMenu { get; set; } = true;

    public HierarchyViewer() { }

    public HierarchyViewer(bool useChildWindow) => UseChildWindow = useChildWindow;

    public List<HierarchyNode> RootNodes
    {
        get => rootNodes;
        set
        {
            rootNodes = value ?? [];
            nodeIdMapNeedsRebuild = true;
        }
    }

    public void AddRootNode(HierarchyNode node)
    {
        rootNodes.Add(node);
        nodeIdMapNeedsRebuild = true;
    }

    public void AddRootNodes(IEnumerable<HierarchyNode> nodes)
    {
        rootNodes.AddRange(nodes);
        nodeIdMapNeedsRebuild = true;
    }

    public void RemoveRootNode(HierarchyNode node)
    {
        rootNodes.Remove(node);
        nodeIdMapNeedsRebuild = true;
    }

    public void ClearRootNodes()
    {
        rootNodes.Clear();
        nodeIdMapNeedsRebuild = true;
    }

    public void Toggle() => isWindowOpen ^= true;

    public void Show() => isWindowOpen = true;

    public void Close() => isWindowOpen = false;

    public void AddContextMenuItem(string label, Action<HierarchyNode> action) => customContextMenuItems.Add(new ContextMenuItem { Label = label, Action = action });

    public void ClearContextMenuItems() => customContextMenuItems.Clear();

    public void Render(List<HierarchyNode> rootNodes, string windowTitle = "Hierarchy")
    {
        this.rootNodes = rootNodes;
        nodeIdMapNeedsRebuild = true;
        RenderWindow(windowTitle);
    }

    public void RenderWindow(string windowTitle = "Hierarchy")
    {
        if (!isWindowOpen) return;
        if (nodeIdMapNeedsRebuild)
        {
            RebuildNodeIdMap(rootNodes);
            nodeIdMapNeedsRebuild = false;
        }

        ImGui.SetNextWindowSize(new Vector2(300, 500), ImGuiCond.FirstUseEver);

        if (ImGui.Begin(windowTitle, ref isWindowOpen))
        {
            RenderContent(rootNodes);
        }
        ImGui.End();
    }

    public void Render()
    {
        if (nodeIdMapNeedsRebuild)
        {
            RebuildNodeIdMap(rootNodes);
            nodeIdMapNeedsRebuild = false;
        }
        RenderContent(rootNodes);
    }

    private void RebuildNodeIdMap(List<HierarchyNode> nodes)
    {
        nodeIdMap.Clear();
        nextNodeId = 1;
        RebuildNodeIdMapRecursive(nodes);
    }

    private void RebuildNodeIdMapRecursive(List<HierarchyNode> nodes)
    {
        foreach (var node in nodes)
        {
            nodeIdMap[nextNodeId] = node;
            nextNodeId++;
            RebuildNodeIdMapRecursive(node.Children);
        }
    }

    private const float ButtonMod = 60;
    private int dropTargetIdCounter = 0;

    private void RenderContent(List<HierarchyNode> rootNodes)
    {
        dropTargetIdCounter = 0;

        ImGui.SetNextItemWidth(-1);
        ImGui.InputTextWithHint("##search", "Search...", ref searchText, 256);
        ImGui.Separator();
        ImGui.Columns(2, "HierarchyColumns", false);
        ImGui.SetColumnWidth(0, ImGui.GetWindowWidth() - ButtonMod);
        ImGui.Text("Name");
        ImGui.NextColumn();
        ImGui.NextColumn();
        ImGui.Separator();
        ImGui.Columns(1);

        if (UseChildWindow)
        {
            var childSize = ImGui.GetContentRegionAvail();
            if (ImGui.BeginChild("HierarchyContent", childSize))
            {
                ImGui.Columns(2, "HierarchyColumnsChild", false);
                ImGui.SetColumnWidth(0, ImGui.GetWindowWidth() - ButtonMod);
                RenderHierarchyNodesWithDragDrop(rootNodes);
                ImGui.Columns(1);
            }
            ImGui.EndChild();
        }
        else
        {
            ImGui.Columns(2, "HierarchyColumns", false);
            ImGui.SetColumnWidth(0, ImGui.GetWindowWidth() - ButtonMod);
            RenderHierarchyNodesWithDragDrop(rootNodes);
            ImGui.Columns(1);
        }

        RenderContextMenu();
    }

    private void RenderHierarchyNodesWithDragDrop(List<HierarchyNode> rootNodes)
    {
        RenderDropTarget(rootNodes, 0);

        for (int i = 0; i < rootNodes.Count; i++)
        {
            var node = rootNodes[i];
            if (ShouldShowNode(node, searchText))
            {
                RenderNode(node, 0);

                RenderDropTarget(rootNodes, i + 1);
            }
        }
    }

    private const float IndentW = 0.5f;

    private void RenderNode(HierarchyNode node, int depth)
    {
        var hasChildren = node.Children.Count > 0;
        var filteredChildren = GetFilteredChildren(node, searchText);
        var shouldShowChildren = filteredChildren.Count > 0;

        var nodeId = GetNodeId(node);
        ImGui.PushID(nodeId);

        for (int i = 0; i < depth; i++)
        {
            ImGui.Indent(IndentW);
        }

        bool nodeOpen = false;

        if (!node.IsVisible) ImGui.PushStyleColor(ImGuiCol.Text, ImGui.GetColorU32(ImGuiCol.TextDisabled));

        if (hasChildren && shouldShowChildren)
        {
            nodeOpen = ImGui.TreeNodeEx(node.Name,
                ImGuiTreeNodeFlags.OpenOnArrow |
                ImGuiTreeNodeFlags.OpenOnDoubleClick |
                ImGuiTreeNodeFlags.SpanFullWidth);
        }
        else
        {
            ImGui.TreeNodeEx(node.Name,
                ImGuiTreeNodeFlags.Leaf |
                ImGuiTreeNodeFlags.NoTreePushOnOpen |
                ImGuiTreeNodeFlags.SpanFullWidth);
        }

        if (!node.IsVisible) ImGui.PopStyleColor();

        if (ImGui.BeginDragDropSource(ImGuiDragDropFlags.None))
        {
            var dragData = new HierarchyDragDropData
            {
                NodeId = nodeId,
                NodeName = node.Name
            };
            ImDragDrop.SetDragDropPayloadJson("HIERARCHY_NODE", dragData);
            ImGui.Text($"Moving: {node.Name}");

            ImGui.EndDragDropSource();
        }

        if (ImGui.BeginDragDropTarget())
        {
            if (ImDragDrop.AcceptDragDropPayloadJson<HierarchyDragDropData?>("HIERARCHY_NODE", out var payload) && payload.HasValue)
            {
                HandleNodeDrop(payload.Value, node.Children, node.Children.Count, node);
            }
            ImGui.EndDragDropTarget();
        }

        if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
        {
            OnNodeSelected?.Invoke(node);
        }

        if (HasContextMenu && ImGui.IsItemClicked(ImGuiMouseButton.Right))
        {
            contextMenuNode = node;
            showContextMenu = true;
        }

        if (node.HasVisibilityToggle)
        {
            ImGui.NextColumn();

            bool isVisible = node.IsVisible;
            var visibleIcon = isVisible ? FontAwesomeIcon.Eye : FontAwesomeIcon.EyeSlash;
            if (ImGuiC.IconButtonTransparent(visibleIcon, "Hierarchy-visibility"))
            {
                node.IsVisible ^= true;
                ToggleNodeVisibility(node.Children, node.IsVisible);
                OnNodeVisibilityChanged?.Invoke(node, isVisible);
            }

            ImGui.NextColumn();
        }
        else
        {
            ImGui.NextColumn();
            ImGui.NextColumn();
        }

        if (nodeOpen && shouldShowChildren)
        {
            RenderDropTargetBetweenNodes(node.Children, 0);

            for (int i = 0; i < filteredChildren.Count; i++)
            {
                var child = filteredChildren[i];
                var originalIndex = GetOriginalIndex(node.Children, child);
                RenderNode(child, depth + 1);
                RenderDropTargetBetweenNodes(node.Children, originalIndex + 1);
            }

            ImGui.TreePop();
        }

        for (int i = 0; i < depth; i++)
        {
            ImGui.Unindent(IndentW);
        }

        ImGui.PopID();
    }

    private const float BetweenNodeButtonHeight = 3f;

    private void RenderDropTarget(List<HierarchyNode> targetList, int insertIndex)
    {
        var buttonId = $"drop_target_{dropTargetIdCounter++}";
        var buttonSize = new Vector2(ImGui.GetContentRegionAvail().X, BetweenNodeButtonHeight);

        ImGui.PushID(buttonId);

        _ = ImGui.InvisibleButton("drop_zone", buttonSize);

        if (ImGui.BeginDragDropTarget())
        {
            if (ImDragDrop.AcceptDragDropPayloadJson<HierarchyDragDropData?>("HIERARCHY_NODE", out var payload) && payload.HasValue)
            {
                HandleNodeDrop(payload.Value, targetList, insertIndex, null);
            }
            ImGui.EndDragDropTarget();
        }

        ImGui.PopID();
    }

    private void RenderDropTargetBetweenNodes(List<HierarchyNode> targetList, int insertIndex)
    {
        var buttonId = $"drop_between_{dropTargetIdCounter++}";
        var buttonSize = new Vector2(ImGui.GetContentRegionAvail().X, BetweenNodeButtonHeight);

        ImGui.PushID(buttonId);

        _ = ImGui.InvisibleButton("drop_between", buttonSize);

        if (ImGui.BeginDragDropTarget())
        {
            if (ImDragDrop.AcceptDragDropPayloadJson<HierarchyDragDropData?>("HIERARCHY_NODE", out var payload) && payload.HasValue)
            {
                HandleNodeDrop(payload.Value, targetList, insertIndex, null);
            }
            ImGui.EndDragDropTarget();
        }

        ImGui.PopID();
    }

    private void HandleNodeDrop(HierarchyDragDropData payload, List<HierarchyNode> targetList, int insertIndex, HierarchyNode? newParent)
    {
        if (nodeIdMap.TryGetValue(payload.NodeId, out var draggedNode))
        {
            if (newParent != null && IsNodeDescendant(newParent, draggedNode))
            {
                return;
            }

            var originalParent = FindNodeParent(draggedNode);
            var originalIndex = -1;

            if (originalParent != null)
            {
                originalIndex = originalParent.Children.IndexOf(draggedNode);
                originalParent.Children.Remove(draggedNode);
            }
            else
            {
                if (rootNodes.Contains(draggedNode))
                {
                    originalIndex = rootNodes.IndexOf(draggedNode);
                    rootNodes.Remove(draggedNode);
                }
            }

            var adjustedInsertIndex = insertIndex;
            if (originalParent == newParent || originalParent == null && newParent == null)
            {
                if (originalIndex >= 0 && originalIndex < insertIndex)
                {
                    adjustedInsertIndex = insertIndex - 1;
                }
            }

            if (adjustedInsertIndex >= targetList.Count)
            {
                targetList.Add(draggedNode);
            }
            else
            {
                targetList.Insert(adjustedInsertIndex, draggedNode);
            }

            nodeIdMapNeedsRebuild = true;

            OnNodeMoved?.Invoke(draggedNode, newParent, adjustedInsertIndex);
        }
    }

    private static bool IsNodeDescendant(HierarchyNode ancestor, HierarchyNode potentialDescendant)
    {
        if (ancestor == potentialDescendant) return true;

        foreach (var child in ancestor.Children)
        {
            if (IsNodeDescendant(child, potentialDescendant)) return true;
        }
        return false;
    }

    private HierarchyNode? FindNodeParent(HierarchyNode target)
    {
        foreach (var kvp in nodeIdMap)
        {
            var node = kvp.Value;
            if (node.Children.Contains(target))
                return node;
        }
        return null;
    }

    private int GetNodeId(HierarchyNode node)
    {
        foreach (var kvp in nodeIdMap)
        {
            if (kvp.Value == node)
                return kvp.Key;
        }
        return -1;
    }

    private static int GetOriginalIndex(List<HierarchyNode> list, HierarchyNode node) => list.IndexOf(node);

    private void RenderContextMenu()
    {
        if (!HasContextMenu) return;
        if (showContextMenu && contextMenuNode != null)
        {
            ImGui.OpenPopup("HierarchyContextMenu");
            showContextMenu = false;
        }

        if (ImGui.BeginPopup("HierarchyContextMenu"))
        {
            if (contextMenuNode != null)
            {
                ImGui.Text($"Node: {contextMenuNode.Name}");
                ImGui.Separator();
                if (HasDuplicateContextMenu)
                {
                    if (ImGui.MenuItem("Duplicate"))
                    {
                        DuplicateNode(contextMenuNode);
                    }
                }
                if (HasDeleteContextMenu)
                {
                    if (ImGui.MenuItem("Delete"))
                    {
                        DeleteNode(contextMenuNode);
                    }
                }

                if (HasVisibilityToggleContextMenu)
                {
                    if (contextMenuNode.HasVisibilityToggle)
                    {
                        string visibilityText = contextMenuNode.IsVisible ? "Hide" : "Show";
                        if (ImGui.MenuItem(visibilityText))
                        {
                            contextMenuNode.IsVisible = !contextMenuNode.IsVisible;
                            ToggleNodeVisibility(contextMenuNode.Children, contextMenuNode.IsVisible);
                            OnNodeVisibilityChanged?.Invoke(contextMenuNode, !contextMenuNode.IsVisible);
                        }
                    }
                }

                if (customContextMenuItems.Count > 0)
                {
                    ImGui.Separator();
                    foreach (var item in customContextMenuItems)
                    {
                        if (ImGui.MenuItem(item.Label))
                        {
                            item.Action?.Invoke(contextMenuNode);
                        }
                    }
                }
            }
            ImGui.EndPopup();
        }
    }

    private void DuplicateNode(HierarchyNode node)
    {
        var parent = FindNodeParent(node);
        var newNode = new HierarchyNode($"{node.Name} (Copy)", node.HasVisibilityToggle, node.IsVisible)
        {
            Data = node.Data
        };

        foreach (var child in node.Children)
        {
            newNode.Children.Add(DuplicateNodeRecursive(child));
        }

        if (parent != null)
        {
            var index = parent.Children.IndexOf(node);
            parent.Children.Insert(index + 1, newNode);
        }
        else
        {
            var index = rootNodes.IndexOf(node);
            if (index >= 0)
            {
                rootNodes.Insert(index + 1, newNode);
            }
        }

        nodeIdMapNeedsRebuild = true;
    }

    private static HierarchyNode DuplicateNodeRecursive(HierarchyNode node)
    {
        var newNode = new HierarchyNode($"{node.Name} (Copy)", node.HasVisibilityToggle, node.IsVisible)
        {
            Data = node.Data
        };

        foreach (var child in node.Children)
        {
            newNode.Children.Add(DuplicateNodeRecursive(child));
        }

        return newNode;
    }

    private void DeleteNode(HierarchyNode node)
    {
        var parent = FindNodeParent(node);
        if (parent != null)
        {
            parent.Children.Remove(node);
        }
        else
        {
            rootNodes.Remove(node);
        }
        nodeIdMapNeedsRebuild = true;
    }

    private static void ToggleNodeVisibility(List<HierarchyNode> node, bool visibility)
    {
        if (node.Count == 0) return;
        foreach (var child in node)
        {
            child.IsVisible = visibility;
            ToggleNodeVisibility(child.Children, visibility);
        }
    }

    private static bool ShouldShowNode(HierarchyNode node, string filter)
    {
        if (string.IsNullOrEmpty(filter))
            return true;

        if (node.Name.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
            return true;

        foreach (var child in node.Children)
        {
            if (ShouldShowNode(child, filter))
                return true;
        }

        return false;
    }

    private static List<HierarchyNode> GetFilteredChildren(HierarchyNode node, string filter)
    {
        var result = new List<HierarchyNode>();

        foreach (var child in node.Children)
        {
            if (ShouldShowNode(child, filter))
            {
                result.Add(child);
            }
        }

        return result;
    }

    public bool IsWindowOpen
    {
        get => isWindowOpen;
        set => isWindowOpen = value;
    }
}

public class ContextMenuItem
{
    public string Label { get; set; } = string.Empty;
    public Action<HierarchyNode>? Action { get; set; }
}