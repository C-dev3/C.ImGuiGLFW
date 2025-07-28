namespace C.ImGuiGLFW.Text.FontAwesome;

/// <summary>
/// Set search terms associated with a font awesome icon.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="FontAwesomeSearchTermsAttribute"/> class.
/// </remarks>
/// <param name="searchTerms">search terms for enum member.</param>
[AttributeUsage(AttributeTargets.Field)]
public class FontAwesomeSearchTermsAttribute(string[] searchTerms) : Attribute
{

    /// <summary>
    /// Gets or sets search terms.
    /// </summary>
    public string[] SearchTerms { get; set; } = searchTerms;
}
