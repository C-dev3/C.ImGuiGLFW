namespace C.ImGuiGLFW.Imaging;

/// <summary>
/// Defines the pixel format used for image data representation, specifying how color and alpha channel information is stored and organized in memory.
/// </summary>
/// <remarks>
/// This enumeration covers various pixel formats including:
/// - 8-bit and 16-bit color depths
/// - Grayscale, RGB, BGR, and their alpha variants
/// - Floating-point and normalized formats
/// - Packed data formats for specialized use cases
/// - Raw pixel data formats that require explicit width and height parameters
/// 
/// The format names follow a consistent pattern where the component order (R, G, B, A or L for luminance) 
/// indicates the memory layout, and the numbers indicate the bit depth per component or total bits.
/// </remarks>
public enum PixelFormat
{
    // 8bit formats
    /// <summary>
    /// 8-bit grayscale
    /// </summary>
    L8,

    /// <summary>
    /// 8-bit grayscale + 8-bit alpha
    /// </summary>
    La16,

    /// <summary>
    /// 8-bit RGB (24-bit)
    /// </summary>
    Rgb24,

    /// <summary>
    /// 8-bit RGBA (32-bit)
    /// </summary>
    Rgba32,

    /// <summary>
    /// 8-bit ARGB (32-bit)
    /// </summary>
    Argb32,

    /// <summary>
    /// 8-bit BGR (24-bit)
    /// </summary>
    Bgr24,

    /// <summary>
    /// 8-bit BGRA (32-bit)
    /// </summary>
    Bgra32,

    /// <summary>
    /// 8-bit ABGR (32-bit)
    /// </summary>
    Abgr32,

    /// <summary>
    /// 8-bit alpha only
    /// </summary>
    Alpha8,

    // 16bit formats
    /// <summary>
    /// 16-bit grayscale
    /// </summary>
    L16,

    /// <summary>
    /// 16-bit grayscale + 16-bit alpha
    /// </summary>
    La32,

    /// <summary>
    /// 16-bit RGB (48-bit)
    /// </summary>
    Rgb48,

    /// <summary>
    /// 16-bit RGBA (64-bit)
    /// </summary>
    Rgba64,

    /// <summary>
    /// 5-6-5 BGR (16-bit)
    /// </summary>
    Bgr565,

    /// <summary>
    /// 4-4-4-4 BGRA (16-bit)
    /// </summary>
    Bgra4444,

    /// <summary>
    /// 5-5-5-1 BGRA (16-bit)
    /// </summary>
    Bgra5551,

    /// <summary>
    /// 16-bit × 2-channel RG
    /// </summary>
    Rg32,

    // Float formats
    /// <summary>
    /// RGBA using Vector4
    /// </summary>
    RgbaVector,

    /// <summary>
    /// 16-bit float grayscale
    /// </summary>
    HalfSingle,

    /// <summary>
    /// 16-bit float × 2 components
    /// </summary>
    HalfVector2,

    /// <summary>
    /// 16-bit float × 4 components
    /// </summary>
    HalfVector4,

    // Packed formats
    /// <summary>
    /// Packed 4 byte values
    /// </summary>
    Byte4,

    /// <summary>
    /// Packed 2 short values
    /// </summary>
    Short2,

    /// <summary>
    /// Packed 4 short values
    /// </summary>
    Short4,

    /// <summary>
    /// Normalized 2 byte values
    /// </summary>
    NormalizedByte2,

    /// <summary>
    /// Normalized 4 byte values
    /// </summary>
    NormalizedByte4,

    /// <summary>
    /// Normalized 2 short values
    /// </summary>
    NormalizedShort2,

    /// <summary>
    /// Normalized 4 short values
    /// </summary>
    NormalizedShort4,

    // Raw pixel data formats (requires width and height)
    /// <summary>
    /// Raw A8R8G8B8 data (requires width and height)
    /// </summary>
    RawArgb32,

    /// <summary>
    /// Raw R8G8B8A8 data (requires width and height)
    /// </summary>
    RawRgba32,

    /// <summary>
    /// Raw R8G8B8 data (requires width and height)
    /// </summary>
    RawRgb24,

    /// <summary>
    /// Raw B8G8R8A8 data (requires width and height)
    /// </summary>
    RawBgra32,

    /// <summary>
    /// Raw B8G8R8 data (requires width and height)
    /// </summary>
    RawBgr24
}
