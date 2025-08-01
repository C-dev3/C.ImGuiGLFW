using System.Reflection;

namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// Provides helper methods to load fonts for ImGui from files, embedded resources, or memory,
/// supporting various configurations including font size, glyph ranges, and font configuration settings.
/// </summary>
/// <remarks>
/// This class handles loading TrueType fonts (TTF) into ImGui, including support for custom glyph ranges and
/// font configuration pointers. It abstracts the details of reading font data from disk, embedded resources,
/// or raw memory, and offers multiple overloads for convenience.
/// </remarks>
public static unsafe class FontHelper
{
    /// <summary>
    /// Loads a font from a TTF file with specified size and glyph ranges.
    /// </summary>
    /// <param name="path">The file path to the TTF font file.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">The glyph ranges to include in the font.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the font file is not found.</exception>
    public static ImFontPtr GetFontFromFileTTF(string path, float size, GlyphRanges glyphRanges) => GetFontFromFileTTF(path, size, glyphRanges.GetRanges());

    /// <summary>
    /// Loads a font from a TTF file with specified size and glyph ranges.
    /// </summary>
    /// <param name="path">The file path to the TTF font file.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">Pointer to an array of glyph ranges to include in the font.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the font file is not found.</exception>
    public static ImFontPtr GetFontFromFileTTF(string path, float size, uint* glyphRanges)
    {
        string fullPath = Path.GetFullPath(path);
        if (!File.Exists(fullPath)) throw new FileNotFoundException($"Font file not found: {fullPath}");
        FontBlob item = new(File.ReadAllBytes(fullPath));
        return GetFontFromMemoryTTF(item.Data, item.Length, size, glyphRanges);
    }

    /// <summary>
    /// Loads a font from a TTF file with specified size using default glyph ranges.
    /// </summary>
    /// <param name="path">The file path to the TTF font file.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the font file is not found.</exception>
    public static ImFontPtr GetFontFromFileTTF(string path, float size)
    {
        string fullPath = Path.GetFullPath(path);
        if (!File.Exists(fullPath)) throw new FileNotFoundException($"Font file not found: {fullPath}");
        FontBlob item = new(File.ReadAllBytes(fullPath));
        return GetFontFromMemoryTTF(item.Data, item.Length, size);
    }

    /// <summary>
    /// Loads a font from a TTF file with specified size using default glyph ranges.
    /// </summary>
    /// <param name="path">The file path to the TTF font file.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">Glyph ranged in the font.</param>
    /// <param name="config">Font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the font file is not found.</exception>
    public static ImFontPtr GetFontFromFileTTF(string path, float size, GlyphRanges glyphRanges, ImFontConfig* config) => GetFontFromFileTTF(path, size, glyphRanges.GetRanges(), config);

    /// <summary>
    /// Loads a font from a TTF file with specified size, glyph ranges, and font configuration.
    /// </summary>
    /// <param name="path">The file path to the TTF font file.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">Pointer to an array of glyph ranges to include in the font.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the font file is not found.</exception>
    public static ImFontPtr GetFontFromFileTTF(string path, float size, uint* glyphRanges, ImFontConfig* config)
    {
        string fullPath = Path.GetFullPath(path);
        if (!File.Exists(fullPath)) throw new FileNotFoundException($"Font file not found: {fullPath}");
        FontBlob item = new(File.ReadAllBytes(fullPath));
        return GetFontFromMemoryTTF(item.Data, item.Length, size, config, glyphRanges);
    }

    /// <summary>
    /// Loads a font from a TTF file with specified size and font configuration using default glyph ranges.
    /// </summary>
    /// <param name="path">The file path to the TTF font file.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the font file is not found.</exception>
    public static ImFontPtr GetFontFromFileTTF(string path, float size, ImFontConfig* config)
    {
        string fullPath = Path.GetFullPath(path);
        if (!File.Exists(fullPath)) throw new FileNotFoundException($"Font file not found: {fullPath}");
        FontBlob item = new(File.ReadAllBytes(fullPath));
        return GetFontFromMemoryTTF(item.Data, item.Length, size, config);
    }

    /// <summary>
    /// Loads a font from an embedded resource with specified size using default glyph ranges.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size)
    {
        using Stream? stream = assembly.GetManifestResourceStream(path) ?? throw new FileNotFoundException($"Embedded resource not found: {path}");
        byte[] array = new byte[stream.Length];
        stream.ReadExactly(array);
        FontBlob item = new(array);
        return GetFontFromMemoryTTF(item.Data, item.Length, size);
    }

    /// <summary>
    /// Loads a font from an embedded resource with specified size and glyph ranges.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">The glyph ranges to include in the font as a ReadOnlySpan.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size, ReadOnlySpan<uint> glyphRanges) => GetFontFromEmbeddedResource(assembly, path, size, new GlyphRanges(glyphRanges));

    /// <summary>
    /// Loads a font from an embedded resource with specified size and glyph ranges.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">The glyph ranges to include in the font.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size, GlyphRanges glyphRanges) => GetFontFromEmbeddedResource(assembly, path, size, glyphRanges.GetRanges());

    /// <summary>
    /// Loads a font from an embedded resource with specified size and glyph ranges.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">Pointer to an array of glyph ranges to include in the font.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size, uint* glyphRanges)
    {
        Stream? obj = assembly.GetManifestResourceStream(path) ?? throw new FileNotFoundException($"Embedded resource not found: {path}");
        byte[] array = new byte[obj.Length];
        obj.ReadExactly(array);
        FontBlob item = new(array);
        return GetFontFromMemoryTTF(item.Data, item.Length, size, glyphRanges);
    }

    /// <summary>
    /// Loads a font from an embedded resource with specified size and font configuration using default glyph ranges.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size, ImFontConfig* config)
    {
        using Stream? stream = assembly.GetManifestResourceStream(path) ?? throw new FileNotFoundException($"Embedded resource not found: {path}");
        byte[] array = new byte[stream.Length];
        stream.ReadExactly(array);
        FontBlob item = new(array);
        return GetFontFromMemoryTTF(item.Data, item.Length, size, config);
    }

    /// <summary>
    /// Loads a font from an embedded resource with specified size, glyph ranges, and font configuration.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">The glyph ranges to include in the font as a ReadOnlySpan.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size, ReadOnlySpan<uint> glyphRanges, ImFontConfig* config) => GetFontFromEmbeddedResource(assembly, path, size, new GlyphRanges(glyphRanges), config);

    /// <summary>
    /// Loads a font from an embedded resource with specified size, glyph ranges, and font configuration.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">The glyph ranges to include in the font.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size, GlyphRanges glyphRanges, ImFontConfig* config) => GetFontFromEmbeddedResource(assembly, path, size, glyphRanges.GetRanges(), config);

    /// <summary>
    /// Loads a font from an embedded resource with specified size, glyph ranges, and font configuration.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The resource path to the embedded TTF font.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">Pointer to an array of glyph ranges to include in the font.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the embedded resource is not found.</exception>
    public static ImFontPtr GetFontFromEmbeddedResource(Assembly assembly, string path, float size, uint* glyphRanges, ImFontConfig* config)
    {
        Stream? obj = assembly.GetManifestResourceStream(path) ?? throw new FileNotFoundException($"Embedded resource not found: {path}");
        byte[] array = new byte[obj.Length];
        obj.ReadExactly(array);
        FontBlob item = new(array);
        return GetFontFromMemoryTTF(item.Data, item.Length, size, config, glyphRanges);
    }

    /// <summary>
    /// Loads a font from memory data with specified size and glyph ranges.
    /// </summary>
    /// <param name="fontData">The font data as a ReadOnlySpan of bytes.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">The glyph ranges to include in the font as a ReadOnlySpan.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    public static ImFontPtr GetFontFromMemoryTTF(ReadOnlySpan<byte> fontData, float size, ReadOnlySpan<uint> glyphRanges) => GetFontFromMemoryTTF(fontData, size, new GlyphRanges(glyphRanges));

    private static ImFontPtr GetFontFromMemoryTTF(ReadOnlySpan<byte> fontData, float size, GlyphRanges glyphRanges)
    {
        FontBlob item = new(fontData);
        return GetFontFromMemoryTTF(item.Data, item.Length, size, glyphRanges.GetRanges());
    }

    /// <summary>
    /// Loads a font from memory data with specified size using default glyph ranges.
    /// </summary>
    /// <param name="fontData">Pointer to the font data in memory.</param>
    /// <param name="fontDataSize">The size of the font data in bytes.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    public static ImFontPtr GetFontFromMemoryTTF(void* fontData, int fontDataSize, float size) => ImGui.GetIO().Fonts.AddFontFromMemoryTTF(fontData, fontDataSize, size);

    private static ImFontPtr GetFontFromMemoryTTF(void* data, int length, float size, uint* v) => ImGui.GetIO().Fonts.AddFontFromMemoryTTF(data, length, size, v);

    /// <summary>
    /// Loads a font from memory data with specified size, glyph ranges, and font configuration.
    /// </summary>
    /// <param name="fontData">The font data as a ReadOnlySpan of bytes.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="glyphRanges">The glyph ranges to include in the font as a ReadOnlySpan.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    public static ImFontPtr GetFontFromMemoryTTF(ReadOnlySpan<byte> fontData, float size, ReadOnlySpan<uint> glyphRanges, ImFontConfig* config) => GetFontFromMemoryTTF(fontData, size, new GlyphRanges(glyphRanges), config);

    private static ImFontPtr GetFontFromMemoryTTF(ReadOnlySpan<byte> fontData, float size, GlyphRanges glyphRanges, ImFontConfig* config)
    {
        FontBlob item = new(fontData);
        return GetFontFromMemoryTTF(item.Data, item.Length, size, config, glyphRanges.GetRanges());
    }

    /// <summary>
    /// Loads a font from memory data with specified size and font configuration using default glyph ranges.
    /// </summary>
    /// <param name="fontData">Pointer to the font data in memory.</param>
    /// <param name="fontDataSize">The size of the font data in bytes.</param>
    /// <param name="size">The font size in pixels.</param>
    /// <param name="config">Pointer to the font configuration settings.</param>
    /// <returns>A pointer to the loaded ImGui font.</returns>
    public static ImFontPtr GetFontFromMemoryTTF(void* fontData, int fontDataSize, float size, ImFontConfig* config) => ImGui.GetIO().Fonts.AddFontFromMemoryTTF(fontData, fontDataSize, size, config);

    private static ImFontPtr GetFontFromMemoryTTF(void* data, int length, float size, ImFontConfig* config, uint* v) => ImGui.GetIO().Fonts.AddFontFromMemoryTTF(data, length, size, config, v);
}