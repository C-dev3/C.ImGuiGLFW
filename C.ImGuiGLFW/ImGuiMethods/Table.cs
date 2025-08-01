namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    private static readonly Dictionary<string, int> tablePages = [];

    /// <summary>
    /// Creates a paginated table
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    /// <param name="id">Table ID</param>
    /// <param name="data">Data list</param>
    /// <param name="columns">Column names</param>
    /// <param name="itemsPerPage">Items per page</param>
    /// <param name="flags">Table flags</param>
    /// <param name="size">Table size</param>
    /// <param name="drawRowCallback">Row drawing callback</param>
    public static void PaginatedTable<T>(string id, List<T> data, string[] columns,
        Action<T, int> drawRowCallback,
        int itemsPerPage = 10,
        ImGuiTableFlags flags = ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.SizingFixedFit,
        Vector2? size = null)
    {
        if (!tablePages.TryGetValue(id, out int currentPage))
        {
            currentPage = 0;
            tablePages[id] = currentPage;
        }

        int totalPages = (int)Math.Ceiling((double)data.Count / itemsPerPage);
        currentPage = Math.Max(0, Math.Min(currentPage, totalPages - 1));
        tablePages[id] = currentPage;

        int startIndex = currentPage * itemsPerPage;
        int endIndex = Math.Min(startIndex + itemsPerPage, data.Count);
        if (ImGui.BeginTable(id, columns.Length, flags, size ?? new(0)))
        {
            foreach (var column in columns)
            {
                ImGui.TableSetupColumn(column, ImGuiTableColumnFlags.WidthFixed);
            }
            ImGui.TableHeadersRow();

            for (int i = startIndex; i < endIndex; i++)
            {
                ImGui.TableNextRow();
                drawRowCallback(data[i], i);
            }
            ImGui.EndTable();
        }

        bool pageChanged = false;

        if (ImGui.Button($"<<##{id}") && currentPage > 0)
        {
            currentPage = 0;
            pageChanged = true;
        }
        ImGui.SameLine();

        if (ImGui.Button($"<##{id}") && currentPage > 0)
        {
            currentPage--;
            pageChanged = true;
        }
        ImGui.SameLine();

        int maxPages = Math.Max(1, totalPages);
        int digits = maxPages.ToString().Length;
        ImGui.Text($"{(currentPage + 1).ToString($"d{digits}")} / {maxPages}");
        ImGui.SameLine();

        if (ImGui.Button($">##{id}") && currentPage < totalPages - 1)
        {
            currentPage++;
            pageChanged = true;
        }
        ImGui.SameLine();

        if (ImGui.Button($">>##{id}") && currentPage < totalPages - 1)
        {
            currentPage = totalPages - 1;
            pageChanged = true;
        }
        if (pageChanged) tablePages[id] = currentPage;
    }
}