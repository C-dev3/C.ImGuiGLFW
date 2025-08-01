using C.ImGuiGLFW.Text.FontAwesome;

namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// Represents a single node in a hierarchical structure with support for visibility toggles, children, and associated data.
/// </summary>
/// <remarks>
/// This class is designed to represent tree-like data structures commonly used in UI hierarchies such as scene graphs,
/// file systems, or organizational charts. Each node can contain arbitrary data, have visibility controls, and maintain
/// a collection of child nodes. The class supports multiple constructor overloads for convenient initialization.
/// </remarks>
public class HierarchyNode(string name)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HierarchyNode"/> class with the specified name and visibility toggle setting.
    /// </summary>
    /// <param name="name">The display name of the node.</param>
    /// <param name="hasVisibilityToggle">Indicates whether this node should display a visibility toggle control.</param>
    public HierarchyNode(string name, bool hasVisibilityToggle) : this(name) => HasVisibilityToggle = hasVisibilityToggle;

    /// <summary>
    /// Initializes a new instance of the <see cref="HierarchyNode"/> class with the specified name, visibility toggle setting, and initial visibility state.
    /// </summary>
    /// <param name="name">The display name of the node.</param>
    /// <param name="hasVisibilityToggle">Indicates whether this node should display a visibility toggle control.</param>
    /// <param name="isVisible">The initial visibility state of the node.</param>
    public HierarchyNode(string name, bool hasVisibilityToggle, bool isVisible) : this(name, hasVisibilityToggle) => IsVisible = isVisible;

    /// <summary>
    /// Initializes a new instance of the <see cref="HierarchyNode"/> class with the specified name, visibility settings, and child nodes.
    /// </summary>
    /// <param name="name">The display name of the node.</param>
    /// <param name="isVisible">The initial visibility state of the node.</param>
    /// <param name="hasVisibilityToggle">Indicates whether this node should display a visibility toggle control.</param>
    /// <param name="children">The collection of child nodes to assign to this node.</param>
    public HierarchyNode(string name, bool isVisible, bool hasVisibilityToggle, List<HierarchyNode> children) : this(name, hasVisibilityToggle, isVisible) => Children = children;

    /// <summary>
    /// Gets or sets the display name of the node.
    /// </summary>
    /// <value>A string representing the name that will be displayed in the hierarchy viewer.</value>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets a value indicating whether the node is currently visible.
    /// </summary>
    /// <value><c>true</c> if the node is visible; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    /// <remarks>
    /// When a node's visibility is changed, it may affect the visual representation of the node in the hierarchy viewer.
    /// This property is used in conjunction with <see cref="HasVisibilityToggle"/> to control visibility behavior.
    /// </remarks>
    public bool IsVisible { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the node should display a visibility toggle control.
    /// </summary>
    /// <value><c>true</c> if a visibility toggle should be displayed; otherwise, <c>false</c>. The default is <c>true</c>.</value>
    /// <remarks>
    /// When set to <c>true</c>, the hierarchy viewer will display an eye icon that allows users to toggle
    /// the node's visibility. This is useful for scene graphs or other hierarchies where individual items
    /// can be shown or hidden.
    /// </remarks>
    public bool HasVisibilityToggle { get; set; } = true;

    /// <summary>
    /// Gets or sets arbitrary data associated with this node.
    /// </summary>
    /// <value>An object containing custom data, or <c>null</c> if no data is associated.</value>
    /// <remarks>
    /// This property allows you to attach any custom data to a hierarchy node, such as references to
    /// game objects, file system entries, or business objects. The hierarchy viewer does not interpret
    /// this data but preserves it for application use.
    /// </remarks>
    public object? Data { get; set; } = null;

    /// <summary>
    /// Gets or sets the collection of child nodes.
    /// </summary>
    /// <value>A list of <see cref="HierarchyNode"/> objects representing the children of this node.</value>
    /// <remarks>
    /// Child nodes are displayed as nested items in the hierarchy viewer. The collection is initialized
    /// as an empty list and can be modified to build tree structures dynamically.
    /// </remarks>
    public List<HierarchyNode> Children { get; set; } = [];
}

/// <summary>
/// Represents data passed during drag and drop operations within the hierarchy viewer.
/// </summary>
/// <remarks>
/// This structure is used internally by the hierarchy viewer to track which node is being dragged
/// and to facilitate proper drag and drop operations between different locations in the hierarchy.
/// </remarks>
public struct HierarchyDragDropData
{
    /// <summary>
    /// Gets or sets the unique identifier of the node being dragged.
    /// </summary>
    /// <value>An integer representing the internal node ID assigned by the hierarchy viewer.</value>
    public int NodeId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the node being dragged.
    /// </summary>
    /// <value>A string containing the name of the node, used for visual feedback during drag operations.</value>
    public string NodeName { get; set; }
}

/// <summary>
/// Provides a complete ImGui-based hierarchy viewer control with support for drag-and-drop, context menus, 
/// search functionality, and visibility toggles.
/// </summary>
/// <remarks>
/// The HierarchyViewer class is designed to display tree-structured data using ImGui controls. It supports
/// common hierarchy operations such as selecting nodes, toggling visibility, drag-and-drop reordering,
/// context menu actions, and text-based filtering. The viewer can operate either as a standalone window
/// or as content within an existing ImGui window.
/// 
/// Key features include:
/// - Drag and drop reordering of nodes
/// - Context menu with customizable actions
/// - Search/filter functionality
/// - Visibility toggles with eye icons
/// - Event-driven architecture for responding to user interactions
/// - Support for both windowed and child window rendering modes
/// </remarks>
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

    /// <summary>
    /// Gets or sets a value indicating whether the hierarchy content should be rendered within a child window.
    /// </summary>
    /// <value><c>true</c> to render content in a child window; <c>false</c> to render directly. The default is <c>false</c>.</value>
    /// <remarks>
    /// When set to <c>true</c>, the hierarchy content will be rendered inside an ImGui child window, which provides
    /// automatic scrolling and better layout control. This is useful when embedding the hierarchy viewer within
    /// other UI elements or when you need precise control over the content area.
    /// </remarks>
    public bool UseChildWindow { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether context menus should be displayed when right-clicking nodes.
    /// </summary>
    /// <value><c>true</c> to enable context menus; <c>false</c> to disable them. The default is <c>true</c>.</value>
    /// <remarks>
    /// When enabled, right-clicking on any node will display a context menu with available actions such as
    /// duplicate, delete, and visibility toggle options, along with any custom menu items that have been added.
    /// </remarks>
    public bool HasContextMenu { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the "Duplicate" option should appear in context menus.
    /// </summary>
    /// <value><c>true</c> to show the duplicate option; <c>false</c> to hide it. The default is <c>true</c>.</value>
    /// <remarks>
    /// When enabled and context menus are active, users can duplicate nodes by right-clicking and selecting
    /// the "Duplicate" option. This creates a copy of the node with "(Copy)" appended to its name.
    /// </remarks>
    public bool HasDuplicateContextMenu { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the "Delete" option should appear in context menus.
    /// </summary>
    /// <value><c>true</c> to show the delete option; <c>false</c> to hide it. The default is <c>true</c>.</value>
    /// <remarks>
    /// When enabled and context menus are active, users can delete nodes by right-clicking and selecting
    /// the "Delete" option. This permanently removes the node and all its children from the hierarchy.
    /// </remarks>
    public bool HasDeleteContextMenu { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether visibility toggle options should appear in context menus.
    /// </summary>
    /// <value><c>true</c> to show visibility toggle options; <c>false</c> to hide them. The default is <c>true</c>.</value>
    /// <remarks>
    /// When enabled and context menus are active, users can toggle node visibility through the context menu
    /// in addition to using the eye icon buttons. This provides an alternative method for visibility control.
    /// </remarks>
    public bool HasVisibilityToggleContextMenu { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="HierarchyViewer"/> class with default settings.
    /// </summary>
    public HierarchyViewer() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="HierarchyViewer"/> class with the specified child window setting.
    /// </summary>
    /// <param name="useChildWindow">Indicates whether to render content within a child window.</param>
    public HierarchyViewer(bool useChildWindow) => UseChildWindow = useChildWindow;

    /// <summary>
    /// Gets or sets the collection of root-level nodes in the hierarchy.
    /// </summary>
    /// <value>A list of <see cref="HierarchyNode"/> objects representing the top-level nodes.</value>
    /// <remarks>
    /// Setting this property triggers a rebuild of internal node mapping structures. Root nodes are displayed
    /// at the top level of the hierarchy and can contain child nodes to form tree structures.
    /// </remarks>
    public List<HierarchyNode> RootNodes
    {
        get => rootNodes;
        set
        {
            rootNodes = value ?? [];
            nodeIdMapNeedsRebuild = true;
        }
    }

    /// <summary>
    /// Occurs when a node is selected by the user.
    /// </summary>
    /// <remarks>
    /// This event is raised when a user clicks on a node in the hierarchy. Subscribers can use this event
    /// to respond to node selection, such as updating property panels or highlighting objects in a scene.
    /// </remarks>
    public event Action<HierarchyNode> OnNodeSelected = null!;

    /// <summary>
    /// Occurs when a node's visibility state is changed.
    /// </summary>
    /// <remarks>
    /// This event is raised when a user toggles a node's visibility either through the eye icon or context menu.
    /// The event provides both the affected node and the previous visibility state for comprehensive handling.
    /// </remarks>
    public event Action<HierarchyNode, bool> OnNodeVisibilityChanged = null!;

    /// <summary>
    /// Occurs when a node is moved to a new location in the hierarchy through drag and drop.
    /// </summary>
    /// <remarks>
    /// This event is raised when a user successfully completes a drag and drop operation to move a node.
    /// The event provides the moved node, its new parent (or null for root level), and the new index position
    /// within the parent's children collection.
    /// </remarks>
    public event Action<HierarchyNode, HierarchyNode?, int> OnNodeMoved = null!; // (moved node, new parent, new index)

    /// <summary>
    /// Adds a new root node to the hierarchy.
    /// </summary>
    /// <param name="node">The <see cref="HierarchyNode"/> to add as a root node.</param>
    /// <remarks>
    /// The added node will appear at the top level of the hierarchy. This method triggers a rebuild
    /// of internal mapping structures to ensure proper drag and drop functionality.
    /// </remarks>
    public void AddRootNode(HierarchyNode node)
    {
        rootNodes.Add(node);
        nodeIdMapNeedsRebuild = true;
    }

    /// <summary>
    /// Adds multiple root nodes to the hierarchy.
    /// </summary>
    /// <param name="nodes">A collection of <see cref="HierarchyNode"/> objects to add as root nodes.</param>
    /// <remarks>
    /// All nodes in the collection will be added at the top level of the hierarchy. This method is more
    /// efficient than calling <see cref="AddRootNode"/> multiple times as it only triggers one rebuild
    /// of internal mapping structures.
    /// </remarks>
    public void AddRootNodes(IEnumerable<HierarchyNode> nodes)
    {
        rootNodes.AddRange(nodes);
        nodeIdMapNeedsRebuild = true;
    }

    /// <summary>
    /// Removes a root node from the hierarchy.
    /// </summary>
    /// <param name="node">The <see cref="HierarchyNode"/> to remove from the root level.</param>
    /// <remarks>
    /// This method removes the specified node from the root level only. If the node is not found at the
    /// root level, no action is taken. The node and all its children will be removed from the hierarchy display.
    /// </remarks>
    public void RemoveRootNode(HierarchyNode node)
    {
        rootNodes.Remove(node);
        nodeIdMapNeedsRebuild = true;
    }

    /// <summary>
    /// Removes all root nodes from the hierarchy.
    /// </summary>
    /// <remarks>
    /// This method clears the entire hierarchy by removing all root nodes and their children.
    /// The hierarchy viewer will display as empty after this operation.
    /// </remarks>
    public void ClearRootNodes()
    {
        rootNodes.Clear();
        nodeIdMapNeedsRebuild = true;
    }

    /// <summary>
    /// Toggles the open/closed state of the hierarchy window.
    /// </summary>
    /// <remarks>
    /// This method switches the window visibility state. If the window is currently open, it will be closed,
    /// and vice versa. Only affects the window when using windowed rendering mode.
    /// </remarks>
    public void Toggle() => isWindowOpen ^= true;

    /// <summary>
    /// Shows the hierarchy window.
    /// </summary>
    /// <remarks>
    /// This method ensures the hierarchy window is visible when using windowed rendering mode.
    /// If the window is already open, this method has no effect.
    /// </remarks>
    public void Show() => isWindowOpen = true;

    /// <summary>
    /// Closes the hierarchy window.
    /// </summary>
    /// <remarks>
    /// This method hides the hierarchy window when using windowed rendering mode.
    /// If the window is already closed, this method has no effect.
    /// </remarks>
    public void Close() => isWindowOpen = false;

    /// <summary>
    /// Adds a custom menu item to the context menu.
    /// </summary>
    /// <param name="label">The display text for the menu item.</param>
    /// <param name="action">The action to execute when the menu item is selected. The action receives the clicked node as a parameter.</param>
    /// <remarks>
    /// Custom menu items appear in the context menu after the standard options (duplicate, delete, visibility).
    /// The action delegate receives the node that was right-clicked, allowing for context-specific operations.
    /// </remarks>
    public void AddContextMenuItem(string label, Action<HierarchyNode> action) => customContextMenuItems.Add(new ContextMenuItem { Label = label, Action = action });

    /// <summary>
    /// Removes all custom context menu items.
    /// </summary>
    /// <remarks>
    /// This method clears all previously added custom menu items, leaving only the standard context menu options.
    /// Standard options include duplicate, delete, and visibility toggle (depending on their respective settings).
    /// </remarks>
    public void ClearContextMenuItems() => customContextMenuItems.Clear();

    /// <summary>
    /// Renders the hierarchy viewer with the specified root nodes in a window.
    /// </summary>
    /// <param name="rootNodes">The collection of root nodes to display.</param>
    /// <param name="windowTitle">The title to display in the window header. Defaults to "Hierarchy".</param>
    /// <remarks>
    /// This method updates the internal root nodes collection and renders the hierarchy within an ImGui window.
    /// The window includes standard ImGui window controls (close button, resize handles, etc.) and the full
    /// hierarchy interface including search, drag-and-drop, and context menus.
    /// </remarks>
    public void Render(List<HierarchyNode> rootNodes, string windowTitle = "Hierarchy")
    {
        this.rootNodes = rootNodes;
        nodeIdMapNeedsRebuild = true;
        RenderWindow(windowTitle);
    }

    /// <summary>
    /// Renders the hierarchy viewer window with the current root nodes.
    /// </summary>
    /// <param name="windowTitle">The title to display in the window header. Defaults to "Hierarchy".</param>
    /// <remarks>
    /// This method renders the hierarchy viewer as a complete ImGui window using the currently configured
    /// root nodes. The window will only be drawn if <see cref="IsWindowOpen"/> is true. The window includes
    /// all hierarchy features such as search, drag-and-drop, context menus, and visibility controls.
    /// </remarks>
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

    /// <summary>
    /// Renders the hierarchy viewer content without a window wrapper.
    /// </summary>
    /// <remarks>
    /// This method renders only the hierarchy content (search box, node tree, context menus) without
    /// creating an ImGui window. This is useful when embedding the hierarchy viewer within existing
    /// windows or UI layouts. The content includes all interactive features such as drag-and-drop,
    /// selection, and context menus.
    /// </remarks>
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

    /// <summary>
    /// Gets or sets a value indicating whether the hierarchy window is currently open.
    /// </summary>
    /// <value><c>true</c> if the window is open; <c>false</c> if it is closed.</value>
    /// <remarks>
    /// This property controls the visibility of the hierarchy window when using windowed rendering mode.
    /// When set to <c>false</c>, the <see cref="RenderWindow"/> method will not display the window.
    /// This property has no effect when using the <see cref="Render()"/> method without windowing.
    /// </remarks>
    public bool IsWindowOpen
    {
        get => isWindowOpen;
        set => isWindowOpen = value;
    }
}

/// <summary>
/// Represents a custom menu item that can be added to the hierarchy viewer's context menu.
/// </summary>
/// <remarks>
/// This class is used internally by the hierarchy viewer to store custom context menu items
/// added through the <see cref="HierarchyViewer.AddContextMenuItem"/> method. Each menu item
/// consists of a display label and an action to execute when selected.
/// </remarks>
public class ContextMenuItem
{
    /// <summary>
    /// Gets or sets the display text for the menu item.
    /// </summary>
    /// <value>A string containing the text that will appear in the context menu.</value>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the action to execute when the menu item is selected.
    /// </summary>
    /// <value>An action delegate that receives the clicked <see cref="HierarchyNode"/> as a parameter, or <c>null</c> if no action is assigned.</value>
    /// <remarks>
    /// The action is invoked when a user selects this menu item from the context menu. The action
    /// receives the node that was right-clicked, allowing for context-specific operations.
    /// </remarks>
    public Action<HierarchyNode>? Action { get; set; }
}