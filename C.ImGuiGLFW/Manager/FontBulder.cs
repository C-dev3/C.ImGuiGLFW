using C.ImGuiGLFW.Text;
using C.ImGuiGLFW.Text.FontAwesome;
using C.ImGuiGLFW.Text.NotoEmojis;
using Serilog;
using System.Reflection;

namespace C.ImGuiGLFW.Manager;

/// <summary>
/// Represents configuration settings for font loading, including font type, file path, size, and glyph ranges.
/// </summary>
/// <remarks>
/// This class provides multiple constructors to support different font loading scenarios including file-based fonts, embedded resources, and in-memory font data. The font size is automatically clamped to ensure valid values.
/// </remarks>
/// <remarks>
/// Initializes a new instance of the <see cref="FontConfig"/> class with the specified font type.
/// </remarks>
/// <param name="fontType">The type of font to be loaded.</param>
internal class FontConfig(FontType fontType)
{

    /// <summary>
    /// Initializes a new instance of the <see cref="FontConfig"/> class for embedded resource fonts.
    /// </summary>
    /// <param name="fontType">The type of font to be loaded.</param>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="filePath">The path to the font file within the assembly.</param>
    /// <param name="fontSize">The size of the font.</param>
    public FontConfig(FontType fontType, Assembly assembly, string filePath, float fontSize) : this(fontType)
    {
        this.assembly = assembly;
        this.filePath = filePath;
        this.fontSize = fontSize;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FontConfig"/> class for embedded resource fonts with custom glyph ranges.
    /// </summary>
    /// <param name="fontType">The type of font to be loaded.</param>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="filePath">The path to the font file within the assembly.</param>
    /// <param name="fontSize">The size of the font.</param>
    /// <param name="glyphRanges">The Unicode ranges of glyphs to include in the font.</param>
    public FontConfig(FontType fontType, Assembly assembly, string filePath, float fontSize, uint[] glyphRanges) : this(fontType, assembly, filePath, fontSize) => this.glyphRanges = glyphRanges;

    /// <summary>
    /// Initializes a new instance of the <see cref="FontConfig"/> class for in-memory font data.
    /// </summary>
    /// <param name="fontType">The type of font to be loaded.</param>
    /// <param name="fontData">The byte array containing the font data.</param>
    /// <param name="fontSize">The size of the font.</param>
    public FontConfig(FontType fontType, byte[] fontData, float fontSize) : this(fontType)
    {
        this.fontData = fontData;
        this.fontSize = fontSize;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FontConfig"/> class for file-based fonts.
    /// </summary>
    /// <param name="fontType">The type of font to be loaded.</param>
    /// <param name="filePath">The path to the font file.</param>
    /// <param name="fontSize">The size of the font.</param>
    public FontConfig(FontType fontType, string filePath, float fontSize) : this(fontType)
    {
        this.filePath = filePath;
        this.fontSize = fontSize;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FontConfig"/> class for file-based fonts with custom glyph ranges.
    /// </summary>
    /// <param name="fontType">The type of font to be loaded.</param>
    /// <param name="filePath">The path to the font file.</param>
    /// <param name="fontSize">The size of the font.</param>
    /// <param name="glyphRanges">The Unicode ranges of glyphs to include in the font.</param>
    public FontConfig(FontType fontType, string filePath, float fontSize, uint[] glyphRanges) : this(fontType, filePath, fontSize) => this.glyphRanges = glyphRanges;

    /// <summary>
    /// The assembly containing the embedded font resource. Used when FontType is EmbeddedResource.
    /// </summary>
    public Assembly assembly = null!;

    /// <summary>
    /// The path to the font file, either on disk or within an embedded resource.
    /// </summary>
    public string filePath = string.Empty;

    /// <summary>
    /// The Unicode ranges of glyphs to include when loading the font. If null, all available glyphs are loaded.
    /// </summary>
    public uint[] glyphRanges = [];

    /// <summary>
    /// The byte array containing font data for in-memory font loading.
    /// </summary>
    public byte[] fontData = [];

    /// <summary>
    /// The font size in pixels. Default value is 24.0f.
    /// </summary>
    public float fontSize = 24f;

    /// <summary>
    /// The type of font loading method to use.
    /// </summary>
    public FontType FontType = fontType;

    /// <summary>
    /// Gets or sets the font size, automatically clamped between 1 and the maximum float value.
    /// </summary>
    /// <value>The font size in pixels, with a minimum value of 1.</value>
    /// <remarks>
    /// Setting this property will automatically clamp the value to ensure it falls within valid bounds for font rendering.
    /// </remarks>
    public float FontSize
    {
        get => Math.Clamp(fontSize, 1, float.MaxValue);
        set => fontSize = Math.Clamp(value, 1, float.MaxValue);
    }

    /// <summary>
    /// Gets a read-only span of the glyph ranges for this font configuration.
    /// </summary>
    /// <value>A read-only span containing the Unicode ranges of glyphs to include in the font.</value>
    /// <remarks>
    /// This property provides efficient access to the glyph ranges without copying the underlying array data.
    /// </remarks>
    public ReadOnlySpan<uint> GlyphRanges
    {
        get
        {
            glyphRanges ??= [];
            return glyphRanges.AsSpan();
        }
    }
}

/// <summary>
/// Provides functionality to build and configure fonts for ImGui applications, supporting multiple font types and automatic fallback fonts.
/// </summary>
/// <remarks>
/// This class manages the loading of various font types including custom fonts, Noto Sans Japanese fonts, Font Awesome icons, and emoji fonts. It automatically handles font merging and provides fallback to default fonts if loading fails. The class implements IDisposable to properly clean up resources.
/// </remarks>
public unsafe class FontBuilder
{
#pragma warning disable CS0618
    private ImGuiFontBuilder? builder = null!;
#pragma warning restore CS0618
    private readonly List<FontConfig> fontConfigs = [];

    private FontBuilder() { }

    internal static FontBuilder Create() => new();

    /// <summary>
    /// Gets or sets a value indicating whether to add the Noto Sans Japanese font.
    /// </summary>
    /// <value>true to add Noto Sans font; otherwise, false. Default is true.</value>
    /// <remarks>
    /// The Noto Sans font provides comprehensive Japanese character support including default and Japanese-specific glyph ranges.
    /// </remarks>
    public bool AddNotoSansFont { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to add the Font Awesome icon font.
    /// </summary>
    /// <value>true to add Font Awesome font; otherwise, false. Default is true.</value>
    /// <remarks>
    /// Font Awesome provides a comprehensive set of scalable vector icons that can be used in ImGui applications.
    /// </remarks>
    public bool AddFontAwesomeFont { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to add the Noto Emoji font for emoji support.
    /// </summary>
    /// <value>true to add emoji font; otherwise, false. Default is true.</value>
    /// <remarks>
    /// The Noto Emoji font enables color emoji rendering in ImGui applications.
    /// </remarks>
    public bool AddEmojiFont { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to add ImGui's default font as a fallback.
    /// </summary>
    /// <value>true to add default font; otherwise, false. Default is true.</value>
    /// <remarks>
    /// The default font serves as a fallback to ensure text rendering works even if custom fonts fail to load.
    /// </remarks>
    public bool AddDefaultFont { get; set; } = true;

    internal void SetupFonts()
    {
        builder = new();

        int addCount = 0;

        try
        {
            foreach (var fontConfig in fontConfigs)
            {
                try
                {
                    switch (fontConfig.FontType)
                    {
                        case FontType.None:
                            throw new InvalidOperationException("FontType must need specified.");
                        case FontType.File:
                            if (fontConfig.GlyphRanges.IsEmpty)
                            {
                                builder.AddFontFromFileTTF(fontConfig.filePath, fontConfig.FontSize);
                            }
                            else
                            {
                                builder.AddFontFromFileTTF(fontConfig.filePath, fontConfig.FontSize, fontConfig.GlyphRanges);
                            }
                            break;
                        case FontType.EmbeddedResource:
                            if (fontConfig.GlyphRanges.IsEmpty)
                            {
                                builder.AddFontFromEmbeddedResource(fontConfig.assembly, fontConfig.filePath, fontConfig.FontSize);
                            }
                            else
                            {
                                builder.AddFontFromEmbeddedResource(fontConfig.assembly, fontConfig.filePath, fontConfig.FontSize, fontConfig.GlyphRanges);
                            }
                            break;
                        case FontType.Memory:
                            builder.AddFontFromMemoryTTF(fontConfig.fontData, fontConfig.FontSize, fontConfig.GlyphRanges);
                            break;
                    }

                    addCount++;
                    SetOption(addCount);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "");
                }
            }

            var assembly = Assembly.GetCallingAssembly();
            var assemblyName = assembly.GetName().Name + ".assets.";

            if (AddNotoSansFont)
            {
                var io = ImGui.GetIO();
                builder.AddFontFromEmbeddedResource(assembly, $"{assemblyName}NotoSansJP-Medium.ttf", 16.0f, io.Fonts.GetGlyphRangesDefault());
                addCount++;
                SetOption(addCount);
                builder.AddFontFromEmbeddedResource(assembly, $"{assemblyName}NotoSansJP-Medium.ttf", 16.0f, FontGlyph.GlyphRangesJapanese);
            }

            if (AddFontAwesomeFont)
            {
                builder.AddFontFromEmbeddedResource(assembly, $"{assemblyName}FontAwesomeFreeSolid.otf", 14.0f, FontAwesomeExtensions.GlyphRange);
                addCount++;
                SetOption(addCount);
            }

            if (AddEmojiFont)
            {
                builder.AddFontFromEmbeddedResource(assembly, $"{assemblyName}NotoEmoji-Regular.ttf", 18.0f, NotoEmojiExtentions.GlyphRange);
                addCount++;
                SetOption(addCount);
            }

            if (AddDefaultFont)
            {
                builder.AddDefaultFont();
                addCount++;
            }

            builder.Build();
            Log.Information($"Setup font completed successfully. {addCount} font added.");
        }
        catch (Exception ex)
        {
            builder
                .AddDefaultFont()
                .Build();
            Log.Error(ex, "Failed to configure fonts");
        }
    }

    private void SetOption(int addCount)
    {
        if (addCount != 1) return;

        builder?.SetOption((option) =>
        {
            option.FontLoaderFlags |= (uint)ImGuiFreeTypeLoaderFlags.LoadColor;
            option.MergeMode = true;
        });
    }

    /// <summary>
    /// Adds a font from memory using TTF font data.
    /// </summary>
    /// <param name="fontData">A read-only span containing the TTF font data.</param>
    /// <param name="size">The size of the font in pixels.</param>
    /// <remarks>
    /// This method allows loading fonts directly from memory without requiring file system access.
    /// </remarks>
    public void AddFontFromMemoryTTF(ReadOnlySpan<byte> fontData, float size) => fontConfigs.Add(new FontConfig(FontType.Memory, fontData.ToArray(), size));

    /// <summary>
    /// Adds a font from a TTF file on disk.
    /// </summary>
    /// <param name="filePath">The path to the TTF font file.</param>
    /// <param name="fontSize">The size of the font in pixels.</param>
    /// <remarks>
    /// The font file must be accessible at the specified path and in TTF format.
    /// </remarks>
    public void AddFontFromFileTTF(string filePath, float fontSize) => fontConfigs.Add(new FontConfig(FontType.File, filePath, fontSize));

    /// <summary>
    /// Adds a font from a TTF file on disk with custom glyph ranges.
    /// </summary>
    /// <param name="filePath">The path to the TTF font file.</param>
    /// <param name="fontSize">The size of the font in pixels.</param>
    /// <param name="glyphRanges">A read-only span containing the Unicode ranges of glyphs to include.</param>
    /// <remarks>
    /// Specifying custom glyph ranges can reduce memory usage by loading only the required characters.
    /// </remarks>
    public void AddFontFromFileTTF(string filePath, float fontSize, ReadOnlySpan<uint> glyphRanges) => fontConfigs.Add(new FontConfig(FontType.File, filePath, fontSize, glyphRanges.ToArray()));

    /// <summary>
    /// Adds a font from an embedded resource within an assembly.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The path to the font resource within the assembly.</param>
    /// <param name="size">The size of the font in pixels.</param>
    /// <remarks>
    /// This method allows bundling fonts with the application executable for distribution.
    /// </remarks>
    public void AddFontFromEmbeddedResource(Assembly assembly, string path, float size) => fontConfigs.Add(new FontConfig(FontType.EmbeddedResource, assembly, path, size));

    /// <summary>
    /// Adds a font from an embedded resource within an assembly with custom glyph ranges.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded font resource.</param>
    /// <param name="path">The path to the font resource within the assembly.</param>
    /// <param name="size">The size of the font in pixels.</param>
    /// <param name="glyphRanges">A read-only span containing the Unicode ranges of glyphs to include.</param>
    /// <remarks>
    /// This method combines embedded resource loading with selective glyph range loading for optimal memory usage.
    /// </remarks>
    public void AddFontFromEmbeddedResource(Assembly assembly, string path, float size, ReadOnlySpan<uint> glyphRanges) => fontConfigs.Add(new FontConfig(FontType.EmbeddedResource, assembly, path, size, glyphRanges.ToArray()));

    /// <summary>
    /// Releases all resources used by the FontBuilder instance.
    /// </summary>
    /// <remarks>
    /// This method should be called when the FontBuilder is no longer needed to ensure proper cleanup of unmanaged resources.
    /// </remarks>
    internal void Dispose()
    {
        builder?.Dispose();
        fontConfigs.Clear();
    }
}