namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// A drag and drop enabled list component for ImGui that supports single and multi-selection
/// with Windows-like selection behavior (Ctrl/Shift modifiers for multi-selection).
/// </summary>
/// <typeparam name="T">The type of items in the list</typeparam>
/// <remarks>
/// Initializes a new instance of the ImGuiDragDropList.
/// </remarks>
/// <param name="items">The initial items for the list</param>
/// <param name="dragDropType">Unique identifier for drag-drop operations (default: "LISTITEM")</param>
/// <param name="multiSelectEnabled">Whether multi-selection is enabled initially</param>
public class DragDropList<T>(IEnumerable<T>? items = null, string dragDropType = "LISTITEM", bool multiSelectEnabled = false)
{
    private static readonly Vector2 ButtonSize = new(-1, 3f);
    private readonly List<T> _items = items?.ToList() ?? [];
    private readonly HashSet<int> _selectedIndices = [];
    private readonly string _dragDropType = dragDropType;
    private int _lastSelectedIndex = -1;
    private bool _multiSelectEnabled = multiSelectEnabled;

    /// <summary>
    /// Gets or sets whether multi-selection is enabled for this list.
    /// When enabled, users can select multiple items using Ctrl+Click or Shift+Click.
    /// </summary>
    public bool MultiSelectEnabled
    {
        get => _multiSelectEnabled;
        set
        {
            if (_multiSelectEnabled == value) return;

            _multiSelectEnabled = value;
            if (!value)
            {
                ConstrainToSingleSelection();
            }
        }
    }

    /// <summary>
    /// Gets the currently selected indices as a read-only collection.
    /// </summary>
    public IReadOnlySet<int> SelectedIndices => _selectedIndices;

    /// <summary>
    /// Gets the currently selected items as an enumerable.
    /// </summary>
    public IEnumerable<T> SelectedItems => _selectedIndices.Where(IsValidIndex).Select(i => _items[i]);

    /// <summary>
    /// Gets or sets the single selected index. When setting, clears other selections.
    /// Returns -1 if no item is selected or multiple items are selected.
    /// </summary>
    public int SelectedIndex
    {
        get => _selectedIndices.Count == 1 ? _selectedIndices.First() : -1;
        set => SetSingleSelection(value);
    }

    /// <summary>
    /// Gets the items in the list as a read-only collection.
    /// </summary>
    public IReadOnlyList<T> Items => _items;

    /// <summary>
    /// Event raised when the selection changes.
    /// </summary>
    public event Action<IReadOnlySet<int>>? SelectionChanged;

    /// <summary>
    /// Event raised when items are reordered via drag and drop.
    /// Parameters: (sourceIndices, targetIndex)
    /// </summary>
    public event Action<int[], int>? ItemsReordered;

    /// <summary>
    /// Renders the drag-drop enabled list using ImGui.
    /// </summary>
    /// <param name="itemRenderer">Function to render each item. Should return the display text.</param>
    /// <param name="listHeight">Height of the list box (0 for auto-size)</param>
    public void Render(Func<T, int, string> itemRenderer, float listWidth = -1, float listHeight = 0f)
    {
        if (!ImGui.BeginListBox("##DragDropList", new Vector2(listWidth, listHeight)))
            return;

        try
        {
            var io = ImGui.GetIO();
            bool ctrlPressed = io.KeyCtrl;
            bool shiftPressed = io.KeyShift;

            RenderItems(itemRenderer, ctrlPressed, shiftPressed);
        }
        finally
        {
            ImGui.EndListBox();
        }
    }

    private void RenderItems(Func<T, int, string> itemRenderer, bool ctrlPressed, bool shiftPressed)
    {
        for (int i = 0; i <= _items.Count; i++)
        {
            RenderDropZone(i);

            if (i >= _items.Count) break;

            RenderItem(i, itemRenderer, ctrlPressed, shiftPressed);
        }
    }

    private void RenderDropZone(int index)
    {
        ImGui.InvisibleButton($"##DropZone{index}", ButtonSize);

        if (!ImGui.BeginDragDropTarget()) return;

        try
        {
            if (ImDragDrop.AcceptDragDropPayload(_dragDropType, out int[] sourceIndices))
            {
                HandleItemReorder(sourceIndices, index);
            }
        }
        finally
        {
            ImGui.EndDragDropTarget();
        }
    }

    private void RenderItem(int index, Func<T, int, string> itemRenderer, bool ctrlPressed, bool shiftPressed)
    {
        bool isSelected = _selectedIndices.Contains(index);
        string itemText = itemRenderer(_items[index], index);

        if (ImGui.Selectable($"{itemText}##{index}", isSelected))
        {
            HandleItemSelection(index, ctrlPressed, shiftPressed);
        }

        RenderDragSource(index, itemRenderer);
    }

    private void RenderDragSource(int index, Func<T, int, string> itemRenderer)
    {
        if (!ImGui.BeginDragDropSource()) return;

        try
        {
            EnsureItemSelectedForDrag(index);

            var dragIndices = _selectedIndices.OrderBy(x => x).ToArray();
            ImDragDrop.SetDragDropPayload(_dragDropType, dragIndices);

            RenderDragPreview(dragIndices, itemRenderer);
        }
        finally
        {
            ImGui.EndDragDropSource();
        }
    }

    private void EnsureItemSelectedForDrag(int index)
    {
        if (_selectedIndices.Contains(index)) return;

        var oldSelection = new HashSet<int>(_selectedIndices);
        _selectedIndices.Clear();
        _selectedIndices.Add(index);
        _lastSelectedIndex = index;

        if (!oldSelection.SetEquals(_selectedIndices))
        {
            SelectionChanged?.Invoke(_selectedIndices);
        }
    }

    private void RenderDragPreview(int[] dragIndices, Func<T, int, string> itemRenderer)
    {
        if (dragIndices.Length == 1)
        {
            ImGui.Text($"Moving: {itemRenderer(_items[dragIndices[0]], dragIndices[0])}");
        }
        else
        {
            ImGui.Text($"Moving {dragIndices.Length} items");
        }
    }

    /// <summary>
    /// Handles item selection with Windows-like behavior.
    /// </summary>
    private void HandleItemSelection(int clickedIndex, bool ctrlPressed, bool shiftPressed)
    {
        var previousSelection = new HashSet<int>(_selectedIndices);

        if (_multiSelectEnabled && shiftPressed && IsValidIndex(_lastSelectedIndex))
        {
            HandleRangeSelection(clickedIndex);
        }
        else if (_multiSelectEnabled && ctrlPressed)
        {
            HandleToggleSelection(clickedIndex);
        }
        else
        {
            HandleSingleSelection(clickedIndex);
        }

        _lastSelectedIndex = clickedIndex;
        NotifySelectionChangedIfDifferent(previousSelection);
    }

    private void HandleRangeSelection(int clickedIndex)
    {
        _selectedIndices.Clear();
        int start = Math.Min(_lastSelectedIndex, clickedIndex);
        int end = Math.Max(_lastSelectedIndex, clickedIndex);

        for (int i = start; i <= end; i++)
        {
            _selectedIndices.Add(i);
        }
    }

    private void HandleToggleSelection(int clickedIndex)
    {
        if (!_selectedIndices.Remove(clickedIndex))
        {
            _selectedIndices.Add(clickedIndex);
        }
    }

    private void HandleSingleSelection(int clickedIndex)
    {
        bool shouldDeselect = _selectedIndices.Count == 1 && _selectedIndices.Contains(clickedIndex);
        _selectedIndices.Clear();

        if (!shouldDeselect)
        {
            _selectedIndices.Add(clickedIndex);
        }
    }

    /// <summary>
    /// Handles reordering items when drag-drop occurs.
    /// </summary>
    private void HandleItemReorder(int[] sourceIndices, int targetIndex)
    {
        if (sourceIndices.Length == 0) return;

        var itemsToMove = ExtractItemsToMove(sourceIndices);
        var adjustedTargetIndex = CalculateAdjustedTargetIndex(sourceIndices, targetIndex);

        InsertItemsAtTarget(itemsToMove, adjustedTargetIndex);
        UpdateSelectionAfterReorder(adjustedTargetIndex, itemsToMove.Length);

        ItemsReordered?.Invoke(sourceIndices, targetIndex);
        SelectionChanged?.Invoke(_selectedIndices);
    }

    private T[] ExtractItemsToMove(int[] sourceIndices)
    {
        var itemsToMove = sourceIndices.OrderBy(x => x).Select(i => _items[i]).ToArray();

        // Remove items in descending order to maintain indices
        foreach (int sourceIndex in sourceIndices.OrderByDescending(x => x))
        {
            _items.RemoveAt(sourceIndex);
        }

        return itemsToMove;
    }

    private int CalculateAdjustedTargetIndex(int[] sourceIndices, int targetIndex)
    {
        int adjustedTargetIndex = targetIndex;

        foreach (int sourceIndex in sourceIndices)
        {
            if (sourceIndex < targetIndex)
            {
                adjustedTargetIndex--;
            }
        }

        return Math.Clamp(adjustedTargetIndex, 0, _items.Count);
    }

    private void InsertItemsAtTarget(T[] itemsToMove, int targetIndex)
    {
        for (int i = 0; i < itemsToMove.Length; i++)
        {
            _items.Insert(targetIndex + i, itemsToMove[i]);
        }
    }

    private void UpdateSelectionAfterReorder(int targetIndex, int itemCount)
    {
        _selectedIndices.Clear();
        for (int i = 0; i < itemCount; i++)
        {
            _selectedIndices.Add(targetIndex + i);
        }

        _lastSelectedIndex = _selectedIndices.Count > 0 ? _selectedIndices.Max() : -1;
    }

    /// <summary>
    /// Adds an item to the list.
    /// </summary>
    public void AddItem(T item) => _items.Add(item);

    /// <summary>
    /// Adds items to the list.
    /// </summary>
    public void AddItems(IEnumerable<T> items) => _items.AddRange(items);

    /// <summary>
    /// Removes an item at the specified index.
    /// </summary>
    public bool RemoveAt(int index)
    {
        if (!IsValidIndex(index)) return false;

        _items.RemoveAt(index);
        UpdateSelectionAfterRemoval(index);
        return true;
    }

    /// <summary>
    /// Removes the selected items from the list.
    /// </summary>
    public void RemoveSelected()
    {
        if (_selectedIndices.Count == 0) return;

        var indicesToRemove = _selectedIndices.OrderByDescending(x => x).ToArray();
        foreach (int index in indicesToRemove)
        {
            if (IsValidIndex(index))
            {
                _items.RemoveAt(index);
            }
        }

        ClearSelectionInternal();
    }

    /// <summary>
    /// Clears all items from the list.
    /// </summary>
    public void Clear()
    {
        _items.Clear();
        ClearSelectionInternal();
    }

    /// <summary>
    /// Clears the current selection.
    /// </summary>
    public void ClearSelection() => ClearSelectionInternal();

    // Helper methods
    private bool IsValidIndex(int index) => index >= 0 && index < _items.Count;

    private void SetSingleSelection(int index)
    {
        var oldSelection = new HashSet<int>(_selectedIndices);
        _selectedIndices.Clear();

        if (IsValidIndex(index))
        {
            _selectedIndices.Add(index);
            _lastSelectedIndex = index;
        }
        else
        {
            _lastSelectedIndex = -1;
        }

        NotifySelectionChangedIfDifferent(oldSelection);
    }

    private void ConstrainToSingleSelection()
    {
        if (_selectedIndices.Count <= 1) return;

        var firstSelected = _selectedIndices.FirstOrDefault(-1);
        var oldSelection = new HashSet<int>(_selectedIndices);

        _selectedIndices.Clear();
        if (IsValidIndex(firstSelected))
        {
            _selectedIndices.Add(firstSelected);
        }

        NotifySelectionChangedIfDifferent(oldSelection);
    }

    private void UpdateSelectionAfterRemoval(int removedIndex)
    {
        var oldSelection = new HashSet<int>(_selectedIndices);
        var newSelection = new HashSet<int>();

        foreach (int selectedIndex in _selectedIndices)
        {
            if (selectedIndex < removedIndex)
            {
                newSelection.Add(selectedIndex);
            }
            else if (selectedIndex > removedIndex)
            {
                newSelection.Add(selectedIndex - 1);
            }
        }

        _selectedIndices.Clear();
        foreach (int index in newSelection)
        {
            _selectedIndices.Add(index);
        }

        UpdateLastSelectedIndexAfterRemoval(removedIndex);
        NotifySelectionChangedIfDifferent(oldSelection);
    }

    private void UpdateLastSelectedIndexAfterRemoval(int removedIndex)
    {
        if (_lastSelectedIndex == removedIndex)
        {
            _lastSelectedIndex = _selectedIndices.Count > 0 ? _selectedIndices.First() : -1;
        }
        else if (_lastSelectedIndex > removedIndex)
        {
            _lastSelectedIndex--;
        }
    }

    private void ClearSelectionInternal()
    {
        if (_selectedIndices.Count == 0) return;

        _selectedIndices.Clear();
        _lastSelectedIndex = -1;
        SelectionChanged?.Invoke(_selectedIndices);
    }

    private void NotifySelectionChangedIfDifferent(HashSet<int> previousSelection)
    {
        if (!_selectedIndices.SetEquals(previousSelection))
        {
            SelectionChanged?.Invoke(_selectedIndices);
        }
    }
}