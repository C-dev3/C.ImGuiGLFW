namespace C.ImGuiGLFW.Text.FontAwesome;

/// <summary>
/// Set categories associated with a font awesome icon.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="FontAwesomeCategoriesAttribute"/> class.
/// </remarks>
/// <param name="categories">categories for enum member.</param>
[AttributeUsage(AttributeTargets.Field)]
public class FontAwesomeCategoriesAttribute(string[] categories) : Attribute
{
    /// <summary>
    /// Gets or sets categories.
    /// </summary>
    public string[] Categories { get; set; } = categories;
}
