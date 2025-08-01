namespace C.ImGuiGLFW.Common;

/// <summary>
/// Initializes a new instance of the <see cref="WindowSizeLimits"/> struct with the specified minimum and maximum dimensions.
/// </summary>
/// <param name="minWidth">The minimum allowed width of the window.</param>
/// <param name="minHeight">The minimum allowed height of the window.</param>
/// <param name="maxWidth">The maximum allowed width of the window.</param>
/// <param name="maxHeight">The maximum allowed height of the window.</param>
/// <remarks>
/// This constructor provides explicit bounds for both minimum and maximum window dimensions. 
/// It is the caller’s responsibility to ensure that <paramref name="minWidth"/> is less than or equal to <paramref name="maxWidth"/>, 
/// and likewise for height values, to maintain a valid configuration.
/// </remarks>
public struct WindowSizeLimits(int minWidth, int minHeight, int maxWidth, int maxHeight)
{
    /// <summary>
    /// Gets or sets the minimum allowed width of the window.
    /// </summary>
    /// <remarks>
    /// If the window's width is smaller than this value, it may be clamped or resized depending on the window system's behavior.
    /// </remarks>
    public int MinWidth { readonly get; set; } = minWidth;

    /// <summary>
    /// Gets or sets the minimum allowed height of the window.
    /// </summary>
    /// <remarks>
    /// Used to enforce vertical sizing limits. Windows shorter than this height may be adjusted automatically.
    /// </remarks>
    public int MinHeight { readonly get; set; } = minHeight;

    /// <summary>
    /// Gets or sets the maximum allowed width of the window.
    /// </summary>
    /// <remarks>
    /// Prevents the window from being resized beyond the specified width.
    /// </remarks>
    public int MaxWidth { readonly get; set; } = maxWidth;

    /// <summary>
    /// Gets or sets the maximum allowed height of the window.
    /// </summary>
    /// <remarks>
    /// This value defines the upper vertical bound for the window's size.
    /// </remarks>
    public int MaxHeight { readonly get; set; } = maxHeight;

    /// <summary>
    /// Determines whether the specified <see cref="WindowSizeLimits"/> instance has the same size constraints as the current instance.
    /// </summary>
    /// <param name="source">The <see cref="WindowSizeLimits"/> instance to compare with.</param>
    /// <returns><c>true</c> if all size limits match; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This comparison checks for equality of all four dimension fields: minimum and maximum width and height.
    /// </remarks>
    public readonly bool Equals(WindowSizeLimits source) => MinWidth == source.MinWidth && MinHeight == source.MinHeight &&
               MaxWidth == source.MaxWidth && MaxHeight == source.MaxHeight;
}
