using C.ImGuiGLFW.Imaging;
using System.Reflection;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
    private const int TextureCleanupThreshold = 5;
    private readonly Dictionary<string, Texture> textures = [];

    /// <summary>
    /// Creates an OpenGL texture from raw RGBA byte data with specified width and height.
    /// </summary>
    /// <param name="rgbaData">The raw RGBA byte data for the texture</param>
    /// <param name="width">The width of the texture in pixels</param>
    /// <param name="height">The height of the texture in pixels</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static unsafe nint CreateTextureFromRgbaData(byte[] rgbaData, int width, int height)
    {
        ArgumentNullException.ThrowIfNull(rgbaData);
        if (width <= 0 || height <= 0) throw new ArgumentException("Width and height must be positive");
        if (rgbaData.Length != width * height * 4)
            throw new ArgumentException("Data length doesn't match expected RGBA size");

        fixed (byte* dataPtr = rgbaData)
        {
            var texture = Instance.GL.GenTexture();
            Instance.GL.BindTexture(GLTextureTarget.Texture2D, texture);

            // Set texture parameters for better quality
            Instance.GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MinFilter, (int)GLTextureMinFilter.Linear);
            Instance.GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MagFilter, (int)GLTextureMagFilter.Linear);
            Instance.GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapS, (int)GLTextureWrapMode.ClampToEdge);
            Instance.GL.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapT, (int)GLTextureWrapMode.ClampToEdge);

            Instance.GL.PixelStorei(GLPixelStoreParameter.UnpackRowLength, 0);
            Instance.GL.TexImage2D(GLTextureTarget.Texture2D, 0, GLInternalFormat.Rgba, width, height, 0,
                         GLPixelFormat.Rgba, GLPixelType.UnsignedByte, (nint)dataPtr);

            return (nint)texture;
        }
    }

    /// <summary>
    /// Creates an OpenGL texture from encoded image data (PNG, JPEG, etc.) by converting it to RGBA format.
    /// </summary>
    /// <param name="imageData">The encoded image data (PNG, JPEG, etc.)</param>
    /// <returns></returns>
    public static nint CreateTextureFromImageData(byte[] imageData)
    {
        ArgumentNullException.ThrowIfNull(imageData);

        var rgbaData = ImageConverter.ConvertImageToRgba(imageData, out int width, out int height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture from encoded image data (PNG, JPEG, etc.) by converting it to RGBA format.
    /// </summary>
    /// <param name="imageData">The encoded image data (PNG, JPEG, etc.)</param>
    /// <returns></returns>
    public static nint CreateTextureFromImageData(byte[] imageData, out int width, out int height)
    {
        ArgumentNullException.ThrowIfNull(imageData);

        var rgbaData = ImageConverter.ConvertImageToRgba(imageData, out width, out height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture from raw image data with specified pixel dimensions.
    /// </summary>
    /// <param name="imageData">The raw image byte data</param>
    /// <param name="pixelWidth">The width of the image in pixels</param>
    /// <param name="pixelHeight">The height of the image in pixels</param>
    /// <returns></returns>
    public static nint CreateTextureFromRawImageData(byte[] imageData, int pixelWidth, int pixelHeight)
    {
        ArgumentNullException.ThrowIfNull(imageData);

        var rgbaData = ImageConverter.ConvertRawImageToRgba(imageData, pixelWidth, pixelHeight, out int width, out int height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture from raw image data with specified pixel dimensions.
    /// </summary>
    /// <param name="imageData">The raw image byte data</param>
    /// <param name="pixelWidth">The width of the image in pixels</param>
    /// <param name="pixelHeight">The height of the image in pixels</param>
    /// <returns></returns>
    public static nint CreateTextureFromRawImageData(byte[] imageData, int pixelWidth, int pixelHeight, out int width, out int height)
    {
        ArgumentNullException.ThrowIfNull(imageData);

        var rgbaData = ImageConverter.ConvertRawImageToRgba(imageData, pixelWidth, pixelHeight, out width, out height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture from raw image data with specified pixel format and dimensions.
    /// </summary>
    /// <param name="imageData">The raw image byte data</param>
    /// <param name="format">The pixel format of the raw image data</param>
    /// <param name="pixelWidth">The width of the image in pixels</param>
    /// <param name="pixelHeight">The height of the image in pixels</param>
    /// <returns></returns>
    public static nint CreateTextureFromRawImageData(byte[] imageData, PixelFormat format, int pixelWidth, int pixelHeight)
    {
        ArgumentNullException.ThrowIfNull(imageData);

        var rgbaData = ImageConverter.ConvertRawImageToRgba(imageData, format, pixelWidth, pixelHeight, out int width, out int height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture from raw image data with specified pixel format and dimensions.
    /// </summary>
    /// <param name="imageData">The raw image byte data</param>
    /// <param name="format">The pixel format of the raw image data</param>
    /// <param name="pixelWidth">The width of the image in pixels</param>
    /// <param name="pixelHeight">The height of the image in pixels</param>
    /// <returns></returns>
    public static nint CreateTextureFromRawImageData(byte[] imageData, PixelFormat format, int pixelWidth, int pixelHeight, out int width, out int height)
    {
        ArgumentNullException.ThrowIfNull(imageData);

        var rgbaData = ImageConverter.ConvertRawImageToRgba(imageData, format, pixelWidth, pixelHeight, out width, out height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture by loading an image file from the specified file path.
    /// </summary>
    /// <param name="filePath">The file path to the image file</param>
    /// <returns></returns>
    public static nint CreateTextureFromFile(string filePath)
    {
        var rgbaData = ImageConverter.ConvertImageToRgba(filePath, out int width, out int height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture by loading an image file from the specified file path.
    /// </summary>
    /// <param name="filePath">The file path to the image file</param>
    /// <returns></returns>
    public static nint CreateTextureFromFile(string filePath, out int width, out int height)
    {
        var rgbaData = ImageConverter.ConvertImageToRgba(filePath, out width, out height);
        return CreateTextureFromRgbaData(rgbaData, width, height);
    }

    /// <summary>
    /// Creates an OpenGL texture from an embedded resource in the specified assembly by loading the resource stream and converting it to texture data.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded resource</param>
    /// <param name="path">The path to the embedded resource</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static nint CreateTextureFromEmbeddedResource(Assembly assembly, string path)
    {
        using Stream? stream = assembly.GetManifestResourceStream(path) ?? throw new FileNotFoundException($"Embedded resource not found: {path}");
        byte[] array = new byte[stream.Length];
        stream.ReadExactly(array);
        return CreateTextureFromImageData(array);
    }

    /// <summary>
    /// Creates an OpenGL texture from an embedded resource in the specified assembly by loading the resource stream and converting it to texture data.
    /// </summary>
    /// <param name="assembly">The assembly containing the embedded resource</param>
    /// <param name="path">The path to the embedded resource</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static nint CreateTextureFromEmbeddedResource(Assembly assembly, string path, out int width, out int height)
    {
        using Stream? stream = assembly.GetManifestResourceStream(path) ?? throw new FileNotFoundException($"Embedded resource not found: {path}");
        byte[] array = new byte[stream.Length];
        stream.ReadExactly(array);
        return CreateTextureFromImageData(array, out width, out height);
    }

    /// <summary>
    /// Attempts to register a texture with the specified name, returning true if successful or false if the name already exists and overwrite is false.
    /// </summary>
    /// <param name="name">The name to register the texture under</param>
    /// <param name="tex">The texture to register</param>
    /// <param name="overwrite">Whether to overwrite an existing texture with the same name</param>
    /// <returns></returns>
    public static bool TryRegisterTexture(string name, Texture tex, bool overwrite = false)
    {
        if (Instance.textures.ContainsKey(name))
        {
            if (overwrite)
            {
                Instance.textures[name] = tex;
                return true;
            }
            else return false;
        }
        Instance.textures.Add(name, tex);
        return true;
    }

    /// <summary>
    /// Registers a texture with the specified name, optionally overwriting an existing texture with the same name.
    /// </summary>
    /// <param name="name">The name to register the texture under</param>
    /// <param name="tex">The texture to register</param>
    /// <param name="overwrite">Whether to overwrite an existing texture with the same name</param>
    public static void RegisterTexture(string name, Texture tex, bool overwrite = false)
    {
        if (Instance.textures.ContainsKey(name))
        {
            if (overwrite)
                Instance.textures[name] = tex;
            else return;
        }
        Instance.textures.Add(name, tex);
        return;
    }

    /// <summary>
    /// Removes a registered texture with the specified name from the texture cache.
    /// </summary>
    /// <param name="name">The name of the texture to unregister</param>
    public void UnregisterTexture(string name) => textures.Remove(name);

    /// <summary>
    /// Attempts to retrieve a registered texture by name, returning true if found and outputting the texture.
    /// </summary>
    /// <param name="name">The name of the texture to retrieve</param>
    /// <param name="texture">The retrieved texture if found</param>
    /// <returns></returns>
    public static bool TryGetTexture(string name, out Texture texture)
    {
        texture = new();
        if (Instance.textures.TryGetValue(name, out Texture? value))
        {
            texture = value;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one with specified dimensions and optional image data.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="width">The width of the texture</param>
    /// <param name="height">The height of the texture</param>
    /// <param name="imageData">Image data to create the texture from</param>
    /// <returns></returns>
    public static Texture GetTexture(string name, float width, float height, byte[]? imageData = null)
    {
        if (Instance.textures.TryGetValue(name, out var texture))
        {
            texture.UpdateLastUsed();
            return texture;
        }
        else
        {
            var size = new Vector2(width, height);
            if (imageData is not null)
            {
                var handle = CreateTextureFromImageData(imageData);
                return Instance.textures[name] = new Texture
                {
                    Handle = handle,
                    Size = size
                };
            }
            else return new Texture() { Size = size };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one with specified size vector and optional image data.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="size">The size of the texture as a Vector2</param>
    /// <param name="imageData">Image data to create the texture from</param>
    /// <returns></returns>
    public static Texture GetTexture(string name, Vector2 size, byte[]? imageData = null)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            if (imageData is not null)
            {
                var handle = CreateTextureFromImageData(imageData);
                return Instance.textures[name] = new Texture
                {
                    Handle = handle,
                    Size = size
                };
            }
            else return new Texture() { Size = size };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one with specified size vector and optional image data.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="size">The size of the texture as a Vector2</param>
    /// <param name="imageData">Image data to create the texture from</param>
    /// <returns></returns>
    public static Texture GetTexture(string name, byte[]? imageData = null)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            if (imageData is not null)
            {
                var handle = CreateTextureFromImageData(imageData, out int width, out int height);
                var size = new Vector2(width, height);
                return Instance.textures[name] = new Texture
                {
                    Handle = handle,
                    Size = size
                };
            }
            else return new Texture() { Size = Vector2.One };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one from raw image data with specified pixel dimensions.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="pixelWidth">The width of the image in pixels</param>
    /// <param name="pixelHeight">The height of the image in pixels</param>
    /// <param name="imageData">Raw image data to create the texture from</param>
    /// <returns></returns>
    public static Texture GetTextureFromRawImage(string name, int pixelWidth, int pixelHeight, byte[]? imageData = null)
    {
        if (Instance.textures.TryGetValue(name, out var texture))
        {
            texture.UpdateLastUsed();
            return texture;
        }
        else
        {
            var size = new Vector2(pixelWidth, pixelHeight);
            if (imageData is not null)
            {
                var handle = CreateTextureFromRawImageData(imageData, pixelWidth, pixelHeight);
                return Instance.textures[name] = new Texture
                {
                    Handle = handle,
                    Size = size
                };
            }
            else return new Texture() { Size = size };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one from raw image data with specified pixel size vector.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="pixelSize">The pixel size of the image as a Vector2</param>
    /// <param name="imageData">Raw image data to create the texture from</param>
    /// <returns></returns>
    public static Texture GetTextureFromRawImage(string name, Vector2 pixelSize, byte[]? imageData = null)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            if (imageData is not null)
            {
                var handle = CreateTextureFromRawImageData(imageData, (int)pixelSize.X, (int)pixelSize.Y);
                return Instance.textures[name] = new Texture
                {
                    Handle = handle,
                    Size = pixelSize
                };
            }
            else return new Texture() { Size = pixelSize };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one from raw image data with specified pixel dimensions.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="format">The pixel format of the raw image data</param>
    /// <param name="pixelWidth">The width of the image in pixels</param>
    /// <param name="pixelHeight">The height of the image in pixels</param>
    /// <param name="imageData">Raw image data to create the texture from</param>
    /// <returns></returns>
    public static Texture GetTextureFromRawImage(string name, PixelFormat format, int pixelWidth, int pixelHeight, byte[]? imageData = null)
    {
        if (Instance.textures.TryGetValue(name, out var texture))
        {
            texture.UpdateLastUsed();
            return texture;
        }
        else
        {
            var size = new Vector2(pixelWidth, pixelHeight);
            if (imageData is not null)
            {
                var handle = CreateTextureFromRawImageData(imageData, format, pixelWidth, pixelHeight);
                return Instance.textures[name] = new Texture
                {
                    Handle = handle,
                    Size = size
                };
            }
            else return new Texture() { Size = size };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one from raw image data with specified pixel format and size vector.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="format">The pixel format of the raw image data</param>
    /// <param name="pixelSize">The pixel size of the image as a Vector2</param>
    /// <param name="imageData">Raw image data to create the texture from</param>
    /// <returns></returns>
    public static Texture GetTextureFromRawImage(string name, PixelFormat format, Vector2 pixelSize, byte[]? imageData = null)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            if (imageData is not null)
            {
                var handle = CreateTextureFromRawImageData(imageData, format, (int)pixelSize.X, (int)pixelSize.Y);
                return Instance.textures[name] = new Texture
                {
                    Handle = handle,
                    Size = pixelSize
                };
            }
            else return new Texture() { Size = pixelSize };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one by loading from a file with specified dimensions.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="width">The width of the texture</param>
    /// <param name="height">The height of the texture</param>
    /// <param name="filePath">The file path to the image file</param>
    /// <returns></returns>
    public static Texture GetTextureFromFile(string name, float width, float height, string filePath)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            var handle = CreateTextureFromFile(filePath);
            return Instance.textures[name] = new Texture
            {
                Handle = handle,
                Size = new Vector2(width, height)
            };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one by loading from a file with specified dimensions.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="width">The width of the texture</param>
    /// <param name="height">The height of the texture</param>
    /// <param name="filePath">The file path to the image file</param>
    /// <returns></returns>
    public static Texture GetTextureFromFile(string name, string filePath)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            var handle = CreateTextureFromFile(filePath, out int width, out int height);
            return Instance.textures[name] = new Texture
            {
                Handle = handle,
                Size = new Vector2(width, height)
            };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one by loading from a file with specified size vector.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="size">The size of the texture as a Vector2</param>
    /// <param name="filePath">The file path to the image file</param>
    /// <returns></returns>
    public static Texture GetTextureFromFile(string name, Vector2 size, string filePath)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            var handle = CreateTextureFromFile(filePath);
            return Instance.textures[name] = new Texture
            {
                Handle = handle,
                Size = size
            };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one from an embedded resource with specified dimensions.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="width">The width of the texture</param>
    /// <param name="height">The height of the texture</param>
    /// <param name="assembly">The assembly containing the embedded resource</param>
    /// <param name="path">The path to the embedded resource</param>
    /// <returns></returns>
    public static Texture GetTextureFromEmbeddedResource(string name, float width, float height, Assembly assembly, string path)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            var handle = CreateTextureFromEmbeddedResource(assembly, path);
            return Instance.textures[name] = new Texture
            {
                Handle = handle,
                Size = new Vector2(width, height)
            };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one from an embedded resource with specified dimensions.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="width">The width of the texture</param>
    /// <param name="height">The height of the texture</param>
    /// <param name="assembly">The assembly containing the embedded resource</param>
    /// <param name="path">The path to the embedded resource</param>
    /// <returns></returns>
    public static Texture GetTextureFromEmbeddedResource(string name, Assembly assembly, string path)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            var handle = CreateTextureFromEmbeddedResource(assembly, path, out int width, out int height);
            return Instance.textures[name] = new Texture
            {
                Handle = handle,
                Size = new Vector2(width, height)
            };
        }
    }

    /// <summary>
    /// Gets a registered texture by name or creates a new one from an embedded resource with specified size vector.
    /// </summary>
    /// <param name="name">The name of the texture</param>
    /// <param name="size">The size of the texture as a Vector2</param>
    /// <param name="assembly">The assembly containing the embedded resource</param>
    /// <param name="path">The path to the embedded resource</param>
    /// <returns></returns>
    public static Texture GetTextureFromEmbeddedResource(string name, Vector2 size, Assembly assembly, string path)
    {
        if (Instance.textures.TryGetValue(name, out var tex))
        {
            tex.UpdateLastUsed();
            return tex;
        }
        else
        {
            var handle = CreateTextureFromEmbeddedResource(assembly, path);
            return Instance.textures[name] = new Texture
            {
                Handle = handle,
                Size = size
            };
        }
    }

    private void CleanOldTextures()
    {
        double currentTime = ImGui.GetTime();
        var cutfoff = currentTime < TextureCleanupThreshold ? 0 : currentTime - TextureCleanupThreshold;
        foreach (var (key, value) in textures)
        {
            if (value.LastUsed < cutfoff)
            {
                textures.Remove(key);
                if (value.Handle is not null)
                {
                    GL.DeleteTexture((uint)value.Handle.Value);
                    value.Handle = null;
                }
            }
        }
    }

    private void DisposeTextures()
    {
        foreach (var (_, value) in textures)
        {
            if (value.Handle is nint handle)
            {
                GL.DeleteTexture((uint)handle);
                value.Handle = null;
            }
        }
        textures.Clear();
    }
}
