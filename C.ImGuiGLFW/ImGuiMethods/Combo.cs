namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    /// <summary>
    /// Stores the current search filter text for enum combo selectors by label.
    /// </summary>
    /// <remarks>
    /// Used internally to persist filter text per combo label to support filtering in large enum lists.
    /// </remarks>
    public static readonly Dictionary<string, Box<string>> EnumComboSearch = [];

    /// <summary>
    /// Draws an easy combo selector for an enum with a search field for long lists.
    /// </summary>
    /// <typeparam name="T">Enum</typeparam>
    /// <param name="name">ImGui ID</param>
    /// <param name="refConfigField">Value</param>
    /// <param name="names">Optional Name overrides</param>
    public static bool EnumCombo<T>(string name, ref T refConfigField, IDictionary<T, string> names) where T : Enum, IConvertible => EnumCombo(name, ref refConfigField, null, names);

    /// <summary>
    /// Draws an easy combo selector for an enum with a search field for long lists.
    /// </summary>
    /// <typeparam name="T">Enum</typeparam>
    /// <param name="label">ImGui ID</param>
    /// <param name="refConfigField">Value</param>
    /// <param name="filter">Optional filter</param>
    /// <param name="names">Optional Name overrides</param>
    /// <returns>True if the selection was changed, false otherwise</returns>
    public static bool EnumCombo<T>(string label, ref T refConfigField, Func<T, bool>? filter = null, IDictionary<T, string>? names = null) where T : Enum, IConvertible
    {
        var ret = false;
        if (ImGui.BeginCombo(label, (names != null && names.TryGetValue(refConfigField, out var n)) ? n : refConfigField.ToString().Replace("_", " ")))
        {
            var values = Enum.GetValues(typeof(T));
            Box<string>? fltr = null;
            if (values.Length > 10)
            {
                if (!EnumComboSearch.ContainsKey(label)) EnumComboSearch.Add(label, new(""));
                fltr = EnumComboSearch[label];
                SetNextItemFullWidth();
                ImGui.InputTextWithHint($"##{label.Replace("#", "_")}", "Filter...", ref fltr.Value, 50);
            }
            foreach (var x in values)
            {
                if (x is null) continue;
                var equals = EqualityComparer<T>.Default.Equals((T)x, refConfigField);
                var element = (names != null && names.TryGetValue((T)x, out n)) ? n : x.ToString()?.Replace("_", " ") ?? "";
                if ((filter == null || filter((T)x))
                    && (fltr == null || element.Contains(fltr.Value, StringComparison.OrdinalIgnoreCase))
                    && ImGui.Selectable(element, equals)
                    )
                {
                    ret = true;
                    refConfigField = (T)x;
                }
                if (ImGui.IsWindowAppearing() && equals) ImGui.SetScrollHereY();
            }
            ImGui.EndCombo();
        }
        return ret;
    }

    /// <summary>
    /// Stores the current search filter text for general combo selectors by label.
    /// </summary>
    /// <remarks>
    /// Used internally to persist filter text per combo label to support filtering in large collections.
    /// </remarks>
    public static readonly Dictionary<string, Box<string>> ComboSearch = [];

    /// <summary>
    /// Draws a combo selector with optional search functionality for collections.
    /// Automatically adds a search filter when the collection has more than 10 items.
    /// </summary>
    /// <typeparam name="T">Type of the items in the collection</typeparam>
    /// <param name="label">ImGui label and ID for the combo</param>
    /// <param name="refConfigField">Reference to the currently selected value</param>
    /// <param name="values">Collection of items to display in the combo</param>
    /// <param name="filter">Optional filter function to hide certain items</param>
    /// <param name="names">Optional dictionary to override display names for items</param>
    /// <returns>True if the selection was changed, false otherwise</returns>
    public static bool Combo<T>(string label, ref T refConfigField, IEnumerable<T> values, Func<T, bool>? filter = null, IDictionary<T, string>? names = null)
    {
        var ret = false;
        if (ImGui.BeginCombo(label, (names != null && names.TryGetValue(refConfigField, out var n)) ? n : refConfigField?.ToString() ?? "", ImGuiComboFlags.HeightLarge))
        {
            Box<string>? fltr = null;
            if (values.Count() > 10)
            {
                if (!ComboSearch.ContainsKey(label)) ComboSearch.Add(label, new(""));
                fltr = ComboSearch[label];
                SetNextItemFullWidth();
                ImGui.InputTextWithHint($"##{label}fltr", "Filter...", ref fltr.Value, 50);
            }
            foreach (var x in values)
            {
                if (x is null) continue;
                var equals = EqualityComparer<T>.Default.Equals(x, refConfigField);
                var element = (names != null && names.TryGetValue(x, out n)) ? n : x.ToString()?.Replace("_", " ") ?? "";
                if ((filter == null || filter(x))
                    && (fltr == null || element.Contains(fltr.Value, StringComparison.OrdinalIgnoreCase))
                    && ImGui.Selectable(element, equals)
                    )
                {
                    ret = true;
                    refConfigField = x;
                }
                if (ImGui.IsWindowAppearing() && equals) ImGui.SetScrollHereY();
            }
            ImGui.EndCombo();
        }
        return ret;
    }

    /// <summary>
    /// Draws radio buttons for all values of an enum type.
    /// Allows selection of a single enum value from multiple radio button options.
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="refConfigField">Reference to the currently selected enum value</param>
    /// <param name="sameLine">If true, renders all radio buttons on the same line</param>
    /// <param name="filter">Optional filter function to hide certain enum values</param>
    /// <param name="names">Optional dictionary to override display names for enum values</param>
    /// <returns>True if the selection was changed, false otherwise</returns>
    public static bool EnumRadio<T>(ref T refConfigField, bool sameLine = false, Func<T, bool>? filter = null, IDictionary<T, string>? names = null) where T : Enum, IConvertible
    {
        var ret = false;
        var values = Enum.GetValues(typeof(T));
        var first = true;
        foreach (var x in values)
        {
            if (x is null) continue;
            if (!first && sameLine) ImGui.SameLine();
            first = false;
            var equals = EqualityComparer<T>.Default.Equals((T)x, refConfigField);
            var element = (names != null && names.TryGetValue((T)x, out var n)) ? n : x.ToString()?.Replace("_", " ") ?? "";
            if ((filter == null || filter((T)x)) && ImGui.RadioButton(element, equals))
            {
                ret = true;
                refConfigField = (T)x;
            }
        }
        return ret;
    }
}
