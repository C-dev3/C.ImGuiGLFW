namespace C.ImGuiGLFW.Imaging;

public enum PixelFormat
{
    // 8bit formats
    L8,           // 8-bit grayscale
    La16,         // 8-bit grayscale + 8-bit alpha
    Rgb24,        // 8-bit RGB (24-bit)
    Rgba32,       // 8-bit RGBA (32-bit)
    Argb32,       // 8-bit ARGB (32-bit)
    Bgr24,        // 8-bit BGR (24-bit)
    Bgra32,       // 8-bit BGRA (32-bit)
    Abgr32,       // 8-bit ABGR (32-bit)
    Alpha8,       // 8-bit alpha only

    // 16bit formats
    L16,          // 16-bit grayscale
    La32,         // 16-bit grayscale + 16-bit alpha
    Rgb48,        // 16-bit RGB (48-bit)
    Rgba64,       // 16-bit RGBA (64-bit)
    Bgr565,       // 5-6-5 BGR (16-bit)
    Bgra4444,     // 4-4-4-4 BGRA (16-bit)
    Bgra5551,     // 5-5-5-1 BGRA (16-bit)
    Rg32,         // 16-bit × 2-channel RG

    // Float formats
    RgbaVector,   // RGBA using Vector4
    HalfSingle,   // 16-bit float grayscale
    HalfVector2,  // 16-bit float × 2 components
    HalfVector4,  // 16-bit float × 4 components

    // Packed formats
    Byte4,              // Packed 4 byte values
    Short2,             // Packed 2 short values
    Short4,             // Packed 4 short values
    NormalizedByte2,    // Normalized 2 byte values
    NormalizedByte4,    // Normalized 4 byte values
    NormalizedShort2,   // Normalized 2 short values
    NormalizedShort4,   // Normalized 4 short values

    // Raw pixel data formats (requires width and height)
    RawArgb32,          // Raw A8R8G8B8 data (requires width and height)
    RawRgba32,          // Raw R8G8B8A8 data (requires width and height)
    RawRgb24,           // Raw R8G8B8 data (requires width and height)
    RawBgra32,          // Raw B8G8R8A8 data (requires width and height)
    RawBgr24            // Raw B8G8R8 data (requires width and height)
}
