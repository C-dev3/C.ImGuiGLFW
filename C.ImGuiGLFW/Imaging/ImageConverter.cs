using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace C.ImGuiGLFW.Imaging;

/// <summary>
/// Provides static methods for converting images and raw pixel data to RGBA format using SixLabors.ImageSharp.
/// </summary>
/// <remarks>
/// This class supports various pixel formats including standard color formats (RGB, BGR), 
/// alpha variants (RGBA, ARGB, etc.), grayscale formats, floating-point formats, and raw pixel data.
/// All conversion methods output 8-bit RGBA data suitable for graphics rendering.
/// </remarks>
public static class ImageConverter
{
    /// <summary>
    /// Converts an image file to RGBA format.
    /// </summary>
    /// <param name="filePath">The path to the image file to convert.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    /// <exception cref="ArgumentException">Thrown when the file path is null or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified image file does not exist.</exception>
    public static byte[] ConvertImageToRgba(string filePath, out int width, out int height)
    {
        if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path cannot be null or empty");
        if (!File.Exists(filePath)) throw new FileNotFoundException($"Image file not found: {filePath}");
        return ConvertImageToRgba(File.ReadAllBytes(filePath), out width, out height);
    }

    /// <summary>
    /// Converts an image file to RGBA format using the specified pixel format.
    /// </summary>
    /// <param name="filePath">The path to the image file to convert.</param>
    /// <param name="format">The pixel format to use for conversion.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    /// <exception cref="ArgumentException">Thrown when the file path is null or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the specified image file does not exist.</exception>
    public static byte[] ConvertImageToRgba(string filePath, PixelFormat format, out int width, out int height)
    {
        if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path cannot be null or empty");
        if (!File.Exists(filePath)) throw new FileNotFoundException($"Image file not found: {filePath}");
        return ConvertImageToRgba(File.ReadAllBytes(filePath), format, out width, out height);
    }

    /// <summary>
    /// Converts image data from a byte array to RGBA format using the specified pixel format.
    /// </summary>
    /// <param name="imageData">The byte array containing the image data.</param>
    /// <param name="pixelFormat">The pixel format of the input image data.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertImageToRgba(byte[] imageData, PixelFormat pixelFormat, out int width, out int height) => ConvertImageToRgba(imageData.AsSpan(), pixelFormat, out width, out height);

    /// <summary>
    /// Converts image data from a byte array to RGBA format using automatic format detection.
    /// </summary>
    /// <param name="imageData">The byte array containing the image data.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertImageToRgba(byte[] imageData, out int width, out int height) => ConvertImageToRgba(imageData.AsSpan(), out width, out height);

    /// <summary>
    /// Converts image data from a ReadOnlySpan to RGBA format using the specified pixel format.
    /// </summary>
    /// <param name="imageData">The ReadOnlySpan containing the image data.</param>
    /// <param name="pixelFormat">The pixel format of the input image data.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    /// <exception cref="ArgumentException">Thrown when the specified pixel format is not supported.</exception>
    public static byte[] ConvertImageToRgba(ReadOnlySpan<byte> imageData, PixelFormat pixelFormat, out int width, out int height) => pixelFormat switch
    {
        PixelFormat.L8 => ConvertToRgba<L8>(imageData, out width, out height),
        PixelFormat.La16 => ConvertToRgba<La16>(imageData, out width, out height),
        PixelFormat.Rgb24 => ConvertToRgba<Rgb24>(imageData, out width, out height),
        PixelFormat.Rgba32 => ConvertToRgba<Rgba32>(imageData, out width, out height),
        PixelFormat.Argb32 => ConvertToRgba<Argb32>(imageData, out width, out height),
        PixelFormat.Bgr24 => ConvertToRgba<Bgr24>(imageData, out width, out height),
        PixelFormat.Bgra32 => ConvertToRgba<Bgra32>(imageData, out width, out height),
        PixelFormat.Abgr32 => ConvertToRgba<Abgr32>(imageData, out width, out height),
        PixelFormat.Alpha8 => ConvertToRgba<A8>(imageData, out width, out height),
        PixelFormat.L16 => ConvertToRgba<L16>(imageData, out width, out height),
        PixelFormat.La32 => ConvertToRgba<La32>(imageData, out width, out height),
        PixelFormat.Rgb48 => ConvertToRgba<Rgb48>(imageData, out width, out height),
        PixelFormat.Rgba64 => ConvertToRgba<Rgba64>(imageData, out width, out height),
        PixelFormat.Bgr565 => ConvertToRgba<Bgr565>(imageData, out width, out height),
        PixelFormat.Bgra4444 => ConvertToRgba<Bgra4444>(imageData, out width, out height),
        PixelFormat.Bgra5551 => ConvertToRgba<Bgra5551>(imageData, out width, out height),
        PixelFormat.Rg32 => ConvertToRgba<Rg32>(imageData, out width, out height),
        PixelFormat.RgbaVector => ConvertToRgba<RgbaVector>(imageData, out width, out height),
        PixelFormat.HalfSingle => ConvertToRgba<HalfSingle>(imageData, out width, out height),
        PixelFormat.HalfVector2 => ConvertToRgba<HalfVector2>(imageData, out width, out height),
        PixelFormat.HalfVector4 => ConvertToRgba<HalfVector4>(imageData, out width, out height),
        PixelFormat.Byte4 => ConvertToRgba<Byte4>(imageData, out width, out height),
        PixelFormat.Short2 => ConvertToRgba<Short2>(imageData, out width, out height),
        PixelFormat.Short4 => ConvertToRgba<Short4>(imageData, out width, out height),
        PixelFormat.NormalizedByte2 => ConvertToRgba<NormalizedByte2>(imageData, out width, out height),
        PixelFormat.NormalizedByte4 => ConvertToRgba<NormalizedByte4>(imageData, out width, out height),
        PixelFormat.NormalizedShort2 => ConvertToRgba<NormalizedShort2>(imageData, out width, out height),
        PixelFormat.NormalizedShort4 => ConvertToRgba<NormalizedShort4>(imageData, out width, out height),
        _ => throw new ArgumentException($"Un pixel format: {pixelFormat}")
    };

    /// <summary>
    /// Converts raw pixel data to RGBA format using the default RawArgb32 format.
    /// </summary>
    /// <param name="rawData">The byte array containing the raw pixel data.</param>
    /// <param name="pixelWidth">The width of the image in pixels.</param>
    /// <param name="pixelHeight">The height of the image in pixels.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertRawImageToRgba(byte[] rawData, int pixelWidth, int pixelHeight, out int width, out int height) => ConvertRawImageToRgba(rawData, PixelFormat.RawArgb32, pixelWidth, pixelHeight, out width, out height);

    /// <summary>
    /// Converts raw pixel data to RGBA format using the specified raw pixel format.
    /// </summary>
    /// <param name="rawData">The byte array containing the raw pixel data.</param>
    /// <param name="format">The raw pixel format of the input data.</param>
    /// <param name="pixelWidth">The width of the image in pixels.</param>
    /// <param name="pixelHeight">The height of the image in pixels.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertRawImageToRgba(byte[] rawData, PixelFormat format, int pixelWidth, int pixelHeight, out int width, out int height) => ConvertRawImageToRgba(rawData.AsSpan(), format, pixelWidth, pixelHeight, out width, out height);

    /// <summary>
    /// Converts raw pixel data from a ReadOnlySpan to RGBA format using the specified raw pixel format.
    /// </summary>
    /// <param name="imageData">The ReadOnlySpan containing the raw pixel data.</param>
    /// <param name="pixelFormat">The raw pixel format of the input data.</param>
    /// <param name="pixelWidth">The width of the image in pixels.</param>
    /// <param name="pixelHeight">The height of the image in pixels.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    /// <exception cref="ArgumentException">Thrown when the specified format is not a raw pixel format.</exception>
    public static byte[] ConvertRawImageToRgba(ReadOnlySpan<byte> imageData, PixelFormat pixelFormat, int pixelWidth, int pixelHeight, out int width, out int height) => pixelFormat switch
    {
        PixelFormat.RawArgb32 => ConvertRawToRgba<Argb32>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawRgba32 => ConvertRawToRgba<Rgba32>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawRgb24 => ConvertRawToRgba<Rgb24>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawBgra32 => ConvertRawToRgba<Bgra32>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawBgr24 => ConvertRawToRgba<Bgr24>(imageData, pixelWidth, pixelHeight, out width, out height),
        _ => throw new ArgumentException($"Not a raw pixel format: {pixelFormat}")
    };

    /// <summary>
    /// Converts image data from a ReadOnlySpan to RGBA format using automatic format detection.
    /// </summary>
    /// <param name="imageData">The ReadOnlySpan containing the image data.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertImageToRgba(ReadOnlySpan<byte> imageData, out int width, out int height)
    {
        using var image = Image.Load(imageData);
        using var rgba32Image = image.CloneAs<Rgba32>();

        width = rgba32Image.Width;
        height = rgba32Image.Height;

        byte[] rgbaPixels = new byte[width * height * 4];

        rgba32Image.ProcessPixelRows(accessor =>
        {
            for (int y = 0; y < rgba32Image.Height; y++)
            {
                Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                for (int x = 0; x < rgba32Image.Width; x++)
                {
                    int destPos = (y * rgba32Image.Width + x) * 4;
                    Rgba32 pixel = pixelRow[x];
                    rgbaPixels[destPos] = pixel.R;
                    rgbaPixels[destPos + 1] = pixel.G;
                    rgbaPixels[destPos + 2] = pixel.B;
                    rgbaPixels[destPos + 3] = pixel.A;
                }
            }
        });

        return rgbaPixels;
    }

    /// <summary>
    /// Converts image data of a specific pixel type to RGBA format.
    /// </summary>
    /// <typeparam name="TPixel">The pixel type that implements IPixel interface.</typeparam>
    /// <param name="imageData">The ReadOnlySpan containing the image data.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    private static byte[] ConvertToRgba<TPixel>(ReadOnlySpan<byte> imageData, out int width, out int height) where TPixel : unmanaged, IPixel<TPixel>
    {
        using var image = Image.Load<TPixel>(imageData);

        using var rgba32Image = image.CloneAs<Rgba32>();

        width = rgba32Image.Width;
        height = rgba32Image.Height;

        byte[] rgbaPixels = new byte[width * height * 4];

        rgba32Image.ProcessPixelRows(accessor =>
        {
            for (int y = 0; y < rgba32Image.Height; y++)
            {
                Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                for (int x = 0; x < rgba32Image.Width; x++)
                {
                    int destPos = (y * rgba32Image.Width + x) * 4;
                    Rgba32 pixel = pixelRow[x];
                    rgbaPixels[destPos] = pixel.R;
                    rgbaPixels[destPos + 1] = pixel.G;
                    rgbaPixels[destPos + 2] = pixel.B;
                    rgbaPixels[destPos + 3] = pixel.A;
                }
            }
        });

        return rgbaPixels;
    }

    /// <summary>
    /// Converts raw pixel data of a specific pixel type to RGBA format.
    /// </summary>
    /// <typeparam name="TPixel">The pixel type that implements IPixel interface.</typeparam>
    /// <param name="rawData">The ReadOnlySpan containing the raw pixel data.</param>
    /// <param name="pixelWidth">The width of the image in pixels.</param>
    /// <param name="pixelHeight">The height of the image in pixels.</param>
    /// <param name="width">When this method returns, contains the width of the converted image.</param>
    /// <param name="height">When this method returns, contains the height of the converted image.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertRawToRgba<TPixel>(ReadOnlySpan<byte> rawData, int pixelWidth, int pixelHeight, out int width, out int height) where TPixel : unmanaged, IPixel<TPixel>
    {
        using var image = Image.LoadPixelData<TPixel>(rawData, pixelWidth, pixelHeight);
        using var rgba32Image = image.CloneAs<Rgba32>();

        width = rgba32Image.Width;
        height = rgba32Image.Height;

        byte[] rgbaPixels = new byte[pixelWidth * pixelHeight * 4];

        rgba32Image.ProcessPixelRows(accessor =>
        {
            for (int y = 0; y < pixelHeight; y++)
            {
                Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                for (int x = 0; x < pixelWidth; x++)
                {
                    int destPos = (y * pixelWidth + x) * 4;
                    Rgba32 pixel = pixelRow[x];
                    rgbaPixels[destPos] = pixel.R;
                    rgbaPixels[destPos + 1] = pixel.G;
                    rgbaPixels[destPos + 2] = pixel.B;
                    rgbaPixels[destPos + 3] = pixel.A;
                }
            }
        });
        return rgbaPixels;
    }

    /// <summary>
    /// Converts A8R8G8B8 (ARGB32) pixel data to RGBA format.
    /// </summary>
    /// <param name="argbData">The byte array containing ARGB32 pixel data.</param>
    /// <param name="width">The width of the image in pixels.</param>
    /// <param name="height">The height of the image in pixels.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertA8R8G8B8ToRgba(byte[] argbData, int width, int height) => ConvertA8R8G8B8ToRgba(argbData.AsSpan(), width, height);

    /// <summary>
    /// Converts A8R8G8B8 (ARGB32) pixel data from a ReadOnlySpan to RGBA format.
    /// </summary>
    /// <param name="data">The ReadOnlySpan containing ARGB32 pixel data.</param>
    /// <param name="width">The width of the image in pixels.</param>
    /// <param name="height">The height of the image in pixels.</param>
    /// <returns>A byte array containing the RGBA pixel data.</returns>
    public static byte[] ConvertA8R8G8B8ToRgba(ReadOnlySpan<byte> data, int width, int height)
    {
        using var image = Image.LoadPixelData<Argb32>(data, width, height);
        using var rgba32Image = image.CloneAs<Rgba32>();

        byte[] rgbaPixels = new byte[width * height * 4];

        rgba32Image.ProcessPixelRows(accessor =>
        {
            for (int y = 0; y < height; y++)
            {
                Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                for (int x = 0; x < width; x++)
                {
                    int destPos = (y * width + x) * 4;
                    Rgba32 pixel = pixelRow[x];
                    rgbaPixels[destPos] = pixel.R;
                    rgbaPixels[destPos + 1] = pixel.G;
                    rgbaPixels[destPos + 2] = pixel.B;
                    rgbaPixels[destPos + 3] = pixel.A;
                }
            }
        });

        return rgbaPixels;
    }

    /// <summary>
    /// Converts a pixel format name string to the corresponding PixelFormat enum value.
    /// </summary>
    /// <param name="formatName">The name of the pixel format (case-insensitive).</param>
    /// <returns>The corresponding PixelFormat enum value.</returns>
    /// <exception cref="ArgumentException">Thrown when the format name is not recognized.</exception>
    /// <remarks>
    /// Supported format names include standard formats (RGB24, RGBA32, etc.), 
    /// alternative names (A8 for Alpha8), and raw formats (RAWARGB32, etc.).
    /// The comparison is case-insensitive.
    /// </remarks>
    public static PixelFormat GetPixelFormatFromName(string formatName) => formatName.ToUpperInvariant() switch
    {
        "L8" => PixelFormat.L8,
        "LA16" => PixelFormat.La16,
        "RGB24" => PixelFormat.Rgb24,
        "RGBA32" => PixelFormat.Rgba32,
        "ARGB32" => PixelFormat.Argb32,
        "BGR24" => PixelFormat.Bgr24,
        "BGRA32" => PixelFormat.Bgra32,
        "ABGR32" => PixelFormat.Abgr32,
        "ALPHA8" => PixelFormat.Alpha8,
        "A8" => PixelFormat.Alpha8,
        "L16" => PixelFormat.L16,
        "LA32" => PixelFormat.La32,
        "RGB48" => PixelFormat.Rgb48,
        "RGBA64" => PixelFormat.Rgba64,
        "BGR565" => PixelFormat.Bgr565,
        "BGRA4444" => PixelFormat.Bgra4444,
        "BGRA5551" => PixelFormat.Bgra5551,
        "RG32" => PixelFormat.Rg32,
        "RGBAVECTOR" => PixelFormat.RgbaVector,
        "HALFSINGLE" => PixelFormat.HalfSingle,
        "HALFVECTOR2" => PixelFormat.HalfVector2,
        "HALFVECTOR4" => PixelFormat.HalfVector4,
        "BYTE4" => PixelFormat.Byte4,
        "SHORT2" => PixelFormat.Short2,
        "SHORT4" => PixelFormat.Short4,
        "NORMALIZEDBYTE2" => PixelFormat.NormalizedByte2,
        "NORMALIZEDBYTE4" => PixelFormat.NormalizedByte4,
        "NORMALIZEDSHORT2" => PixelFormat.NormalizedShort2,
        "NORMALIZEDSHORT4" => PixelFormat.NormalizedShort4,

        // Raw formats
        "RAWARGB32" => PixelFormat.RawArgb32,
        "RAWRGBA32" => PixelFormat.RawRgba32,
        "RAWRGB24" => PixelFormat.RawRgb24,
        "RAWBGRA32" => PixelFormat.RawBgra32,
        "RAWBGR24" => PixelFormat.RawBgr24,
        _ => throw new ArgumentException($"Unknown pixel format: {formatName}")
    };
}
