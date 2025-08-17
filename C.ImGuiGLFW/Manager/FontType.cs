namespace C.ImGuiGLFW.Manager;

/// <summary>
/// Specifies the type of font loading method to be used when configuring fonts.
/// </summary>
/// <remarks>
/// This enumeration defines the different sources from which fonts can be loaded in the application. Each value corresponds to a specific loading mechanism with different requirements and use cases.
/// </remarks>
public enum FontType
{
    /// <summary>
    /// Indicates that no font type has been specified or the font type is undefined.
    /// </summary>
    /// <remarks>
    /// This value should not be used for actual font loading operations and will result in an exception if used.
    /// </remarks>
    None = 0,

    /// <summary>
    /// Indicates that the font should be loaded from a file on the file system.
    /// </summary>
    /// <remarks>
    /// When using this type, the font file must be accessible at the specified file path and should be in TTF (TrueType Font) format.
    /// </remarks>
    File,

    /// <summary>
    /// Indicates that the font should be loaded from an embedded resource within an assembly.
    /// </summary>
    /// <remarks>
    /// When using this type, the font must be embedded as a resource in the specified assembly. This method allows fonts to be bundled with the application executable for distribution.
    /// </remarks>
    EmbeddedResource,

    /// <summary>
    /// Indicates that the font should be loaded from memory using byte array data.
    /// </summary>
    /// <remarks>
    /// When using this type, the font data must be provided as a byte array containing valid TTF font data. This method allows loading fonts without requiring file system access.
    /// </remarks>
    Memory,
}
