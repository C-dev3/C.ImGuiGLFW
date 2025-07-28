using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace C.ImGuiGLFW.Imaging;

public static class ImageConverter
{
    public static byte[] ConvertImageToRgba(string filePath, out int width, out int height)
    {
        if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path cannot be null or empty");
        if (!File.Exists(filePath)) throw new FileNotFoundException($"Image file not found: {filePath}");
        return ConvertImageToRgba(File.ReadAllBytes(filePath), out width, out height);
    }

    public static byte[] ConvertImageToRgba(string filePath, PixelFormat format, out int width, out int height)
    {
        if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path cannot be null or empty");
        if (!File.Exists(filePath)) throw new FileNotFoundException($"Image file not found: {filePath}");
        return ConvertImageToRgba(File.ReadAllBytes(filePath), format, out width, out height);
    }

    public static byte[] ConvertImageToRgba(byte[] imageData, PixelFormat pixelFormat, out int width, out int height) => ConvertImageToRgba(imageData.AsSpan(), pixelFormat, out width, out height);

    public static byte[] ConvertImageToRgba(byte[] imageData, out int width, out int height) => ConvertImageToRgba(imageData.AsSpan(), out width, out height);

    public static byte[] ConvertImageToRgba(ReadOnlySpan<byte> imageData, PixelFormat pixelFormat, out int width, out int height, int? pixelWidth = null, int? pixelHeight = null) => pixelFormat switch
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

    public static byte[] ConvertRawImageToRgba(byte[] rawData, int pixelWidth, int pixelHeight, out int width, out int height) => ConvertRawImageToRgba(rawData, PixelFormat.RawArgb32, pixelWidth, pixelHeight, out width, out height);

    public static byte[] ConvertRawImageToRgba(byte[] rawData, PixelFormat format, int pixelWidth, int pixelHeight, out int width, out int height) => ConvertRawImageToRgba(rawData.AsSpan(), format, pixelWidth, pixelHeight, out width, out height);

    public static byte[] ConvertRawImageToRgba(ReadOnlySpan<byte> imageData, PixelFormat pixelFormat, int pixelWidth, int pixelHeight, out int width, out int height) => pixelFormat switch
    {
        PixelFormat.RawArgb32 => ConvertRawToRgba<Argb32>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawRgba32 => ConvertRawToRgba<Rgba32>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawRgb24 => ConvertRawToRgba<Rgb24>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawBgra32 => ConvertRawToRgba<Bgra32>(imageData, pixelWidth, pixelHeight, out width, out height),
        PixelFormat.RawBgr24 => ConvertRawToRgba<Bgr24>(imageData, pixelWidth, pixelHeight, out width, out height),
        _ => throw new ArgumentException($"Not a raw pixel format: {pixelFormat}")
    };

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

    public static byte[] ConvertA8R8G8B8ToRgba(byte[] argbData, int width, int height) => ConvertA8R8G8B8ToRgba(argbData.AsSpan(), width, height);

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
