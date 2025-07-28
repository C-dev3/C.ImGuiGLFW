using System.Collections;

namespace C.ImGuiGLFW.ImGuiMethods;

public class ListClipper : IEnumerable<(int, int)>, IDisposable
{
    private ImGuiListClipper clipper = new();
    private readonly int rows;
    private readonly int columns;
    private readonly bool twoDimensional;
    private readonly int itemRemainder;

    public int FirstRow { get; private set; } = -1;

    public int LastRow => CurrentRow;

    public int CurrentRow { get; private set; }

    public bool IsStepped => CurrentRow == DisplayStart;

    public int DisplayStart => clipper.DisplayStart;

    public int DisplayEnd => clipper.DisplayEnd;

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

    public IEnumerable<int> Columns
    {
        get
        {
            var cols = itemRemainder == 0 || rows != DisplayEnd || CurrentRow != DisplayEnd - 1 ? columns : itemRemainder;
            for (int j = 0; j < cols; ++j)
                yield return j;
        }
    }

    public ListClipper(int itemsCount, int columns = 1, bool twoDimensional = false, float itemsHeight = 0)
    {
        this.twoDimensional = twoDimensional;
        this.columns = columns;
        rows = this.twoDimensional ? itemsCount : (int)MathF.Ceiling((float)itemsCount / this.columns);
        itemRemainder = !this.twoDimensional ? itemsCount % this.columns : 0;
        clipper.Begin(itemsCount, itemsHeight);
    }

    public IEnumerator<(int, int)> GetEnumerator() => (from i in Rows from j in Columns select (i, j)).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Dispose()
    {
        clipper.End();
        GC.SuppressFinalize(this);
    }
}
