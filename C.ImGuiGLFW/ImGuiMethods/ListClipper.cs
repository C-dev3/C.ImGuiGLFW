using System.Collections;

namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// A wrapper around ImGuiListClipper that provides enumerable functionality for efficiently rendering large lists
/// with support for both one-dimensional and two-dimensional layouts.
/// </summary>
/// <remarks>
/// This class is designed to work with ImGui's list clipping functionality to optimize rendering performance
/// when dealing with large datasets. It supports both linear (one-dimensional) and grid (two-dimensional) layouts.
/// The clipper only renders visible items, significantly improving performance for large collections.
/// 
/// When used in one-dimensional mode, items are arranged in a grid with the specified number of columns.
/// In two-dimensional mode, the itemsCount parameter represents the total number of rows.
/// 
/// The class implements IDisposable and should be used within a using statement or manually disposed
/// to ensure proper cleanup of ImGui resources.
/// </remarks>
public class ListClipper : IEnumerable<(int, int)>, IDisposable
{
    private ImGuiListClipper clipper = new();
    private readonly int rows;
    private readonly int columns;
    private readonly bool twoDimensional;
    private readonly int itemRemainder;

    /// <summary>
    /// Gets the first visible row index, or -1 if not yet determined.
    /// </summary>
    /// <remarks>
    /// This value is calculated based on the current scroll position and item height.
    /// It remains -1 until the first Step() call with a valid ItemsHeight.
    /// </remarks>
    public int FirstRow { get; private set; } = -1;

    /// <summary>
    /// Gets the last row index that was processed during enumeration.
    /// </summary>
    /// <remarks>
    /// This property returns the same value as CurrentRow and represents the most recently
    /// processed row during the enumeration of visible items.
    /// </remarks>
    public int LastRow => CurrentRow;

    /// <summary>
    /// Gets the current row index being processed during enumeration.
    /// </summary>
    /// <remarks>
    /// This value is updated during enumeration of the Rows property and represents
    /// the row currently being processed. It's useful for tracking progress during iteration.
    /// </remarks>
    public int CurrentRow { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the clipper has stepped and is ready for rendering.
    /// </summary>
    /// <remarks>
    /// This property returns true when the current row matches the display start position,
    /// indicating that the clipper has successfully stepped and calculated the visible range.
    /// </remarks>
    public bool IsStepped => CurrentRow == DisplayStart;

    /// <summary>
    /// Gets the first visible item index as determined by the ImGui clipper.
    /// </summary>
    /// <remarks>
    /// This value is provided directly by the underlying ImGuiListClipper and represents
    /// the index of the first item that should be rendered in the current frame.
    /// </remarks>
    public int DisplayStart => clipper.DisplayStart;

    /// <summary>
    /// Gets the last visible item index (exclusive) as determined by the ImGui clipper.
    /// </summary>
    /// <remarks>
    /// This value is provided directly by the underlying ImGuiListClipper and represents
    /// the index after the last item that should be rendered in the current frame.
    /// The range is [DisplayStart, DisplayEnd).
    /// </remarks>
    public int DisplayEnd => clipper.DisplayEnd;

    /// <summary>
    /// Gets an enumerable sequence of visible row indices.
    /// </summary>
    /// <remarks>
    /// This property performs the actual clipping logic by calling Step() on the underlying
    /// ImGuiListClipper and yielding only the visible row indices. In one-dimensional mode,
    /// the returned values are multiplied by the column count to get the starting item index
    /// for each row. In two-dimensional mode, the row indices are returned directly.
    /// 
    /// The FirstRow property is calculated during the first iteration if ItemsHeight is available.
    /// </remarks>
    public IEnumerable<int> Rows
    {
        get
        {
            while (clipper.Step())
            {
                if (clipper.ItemsHeight > 0 && FirstRow < 0)
                    FirstRow = (int)(ImGui.GetScrollY() / clipper.ItemsHeight);
                for (int i = clipper.DisplayStart; i < clipper.DisplayEnd; ++i)
                {
                    CurrentRow = i;
                    yield return twoDimensional ? i : i * columns;
                }
            }
        }
    }

    /// <summary>
    /// Gets an enumerable sequence of column indices for the current row.
    /// </summary>
    /// <remarks>
    /// The number of columns returned depends on whether this is the last row and whether
    /// there are remaining items. For all rows except potentially the last one, this returns
    /// indices from 0 to columns-1. For the last row in one-dimensional mode, it may return
    /// fewer columns if the total item count doesn't evenly divide by the column count.
    /// </remarks>
    public IEnumerable<int> Columns
    {
        get
        {
            var cols = itemRemainder == 0 || rows != DisplayEnd || CurrentRow != DisplayEnd - 1 ? columns : itemRemainder;
            for (int j = 0; j < cols; ++j)
                yield return j;
        }
    }

    /// <summary>
    /// Initializes a new instance of the ListClipper class.
    /// </summary>
    /// <param name="itemsCount">The total number of items to be displayed. In two-dimensional mode, this represents the number of rows.</param>
    /// <param name="columns">The number of columns in the layout. Default is 1 for a simple list.</param>
    /// <param name="twoDimensional">If true, treats itemsCount as the number of rows; if false, treats it as total items to be arranged in a grid.</param>
    /// <param name="itemsHeight">The height of each item in pixels. If 0, ImGui will auto-calculate based on the first rendered item.</param>
    /// <remarks>
    /// In one-dimensional mode (twoDimensional = false), the clipper calculates the number of rows needed
    /// by dividing itemsCount by columns and rounding up. The itemRemainder is calculated to handle
    /// cases where itemsCount doesn't evenly divide by columns.
    /// 
    /// In two-dimensional mode (twoDimensional = true), itemsCount directly represents the number of rows,
    /// and itemRemainder is always 0.
    /// 
    /// The itemsHeight parameter can be left as 0 to let ImGui automatically determine the height
    /// based on the first rendered item, but providing an explicit height can improve performance.
    /// </remarks>
    public ListClipper(int itemsCount, int columns = 1, bool twoDimensional = false, float itemsHeight = 0)
    {
        this.twoDimensional = twoDimensional;
        this.columns = columns;
        rows = this.twoDimensional ? itemsCount : (int)MathF.Ceiling((float)itemsCount / this.columns);
        itemRemainder = !this.twoDimensional ? itemsCount % this.columns : 0;
        clipper.Begin(itemsCount, itemsHeight);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the visible items as (row, column) tuples.
    /// </summary>
    /// <returns>An enumerator for (row, column) tuples representing visible items.</returns>
    /// <remarks>
    /// This method combines the Rows and Columns enumerables to produce tuples representing
    /// each visible item's position. The row values depend on the dimensional mode:
    /// in one-dimensional mode, they represent the starting item index for each row;
    /// in two-dimensional mode, they represent the actual row index.
    /// </remarks>
    public IEnumerator<(int, int)> GetEnumerator() => (from i in Rows from j in Columns select (i, j)).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Releases the resources used by the ListClipper and finalizes the ImGui clipper.
    /// </summary>
    /// <remarks>
    /// This method calls End() on the underlying ImGuiListClipper to properly clean up ImGui resources.
    /// It also suppresses finalization to improve garbage collection performance.
    /// This method should be called when the ListClipper is no longer needed, preferably using
    /// a using statement for automatic disposal.
    /// </remarks>
    public void Dispose()
    {
        clipper.End();
        GC.SuppressFinalize(this);
    }
}
