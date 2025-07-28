namespace C.ImGuiGLFW.Common;

public class Texture : IDisposable
{
    private double _lastUsed;
    private nint? _handle;
    private Vector2 _size;
    private ImTextureRef? _cachedTextureRef;
    private bool _disposed;

    private float? _maxSize;

    /// <summary>
    /// Initializes a new instance of the Texture class with default size.
    /// </summary>
    public Texture()
    {
        _lastUsed = ImGui.GetTime();
        _size = Vector2.One;
    }

    /// <summary>
    /// Initializes a new instance of the Texture class with the specified handle and size.
    /// </summary>
    /// <param name="handle">The native texture handle.</param>
    /// <param name="size">The size of the texture.</param>
    public Texture(nint handle, Vector2 size)
    {
        _handle = handle;
        _size = size;
        _lastUsed = ImGui.GetTime();
    }

    /// <summary>
    /// Initializes a new instance of the Texture class with the specified handle, size, and maximum size constraint.
    /// </summary>
    /// <param name="handle">The native texture handle.</param>
    /// <param name="size">The size of the texture.</param>
    /// <param name="maxSize">The maximum size constraint for automatic scaling.</param>
    public Texture(nint handle, Vector2 size, float maxSize) : this(handle, size) => _maxSize = maxSize;

    /// <summary>
    /// Gets the timestamp when this texture was last used for rendering.
    /// </summary>
    public double LastUsed
    {
        get
        {
            ThrowIfDisposed();
            return _lastUsed;
        }
        private set => _lastUsed = value;
    }

    /// <summary>
    /// Gets or sets the native texture handle. Setting this value invalidates the texture cache.
    /// </summary>
    public nint? Handle
    {
        get
        {
            ThrowIfDisposed();
            return _handle;
        }
        set
        {
            ThrowIfDisposed();
            if (_handle != value)
            {
                _handle = value;
                InvalidateCache();
            }
        }
    }

    /// <summary>
    /// Gets or sets the size of the texture.
    /// </summary>
    public Vector2 Size
    {
        get
        {
            ThrowIfDisposed();
            return _size;
        }
        set
        {
            ThrowIfDisposed();
            if (_size != value)
            {
                _size = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the maximum size constraint for automatic scaling. 
    /// When set, the texture will be automatically scaled down if it exceeds this size.
    /// </summary>
    public float? MaxSize
    {
        get
        {
            ThrowIfDisposed();
            return _maxSize;
        }
        set
        {
            ThrowIfDisposed();
            _maxSize = value;
        }
    }

    /// <summary>
    /// Gets a value indicating whether this texture is valid (not disposed, has a valid handle).
    /// </summary>
    public bool IsValid => !_disposed && _handle.HasValue && _handle.Value != nint.Zero;

    /// <summary>
    /// Gets a value indicating whether this texture has been disposed.
    /// </summary>
    public bool IsDisposed => _disposed;

    private Vector2 GetScaledSize(Vector2 originalSize)
    {
        if (!_maxSize.HasValue || _maxSize.Value <= 0) return originalSize;

        float maxDimension = Math.Max(originalSize.X, originalSize.Y);
        if (maxDimension <= _maxSize.Value) return originalSize;

        float scale = _maxSize.Value / maxDimension;
        return new Vector2(originalSize.X * scale, originalSize.Y * scale);
    }

    private static Vector2 GetScaledSize(Vector2 originalSize, float _maxSize)
    {
        if (_maxSize <= 0) return originalSize;

        float maxDimension = Math.Max(originalSize.X, originalSize.Y);
        if (maxDimension <= _maxSize) return originalSize;

        float scale = _maxSize / maxDimension;
        return new Vector2(originalSize.X * scale, originalSize.Y * scale);
    }

    /// <summary>
    /// Draws the texture as an image in ImGui with optional size constraints and disabled state.
    /// If the texture is invalid, draws a dummy placeholder with error indicators.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    /// <param name="maxSize">Optional maximum size constraint that overrides the instance MaxSize property.</param>
    public void Draw(Vector2? drawSize = null, bool disabled = false, float? maxSize = null)
    {
        ThrowIfDisposed();

        var requestSize = drawSize ?? _size;
        var actualSize = maxSize.HasValue ? GetScaledSize(requestSize, maxSize.Value) : GetScaledSize(requestSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {actualSize}. Size must be positive.");
        }

        UpdateLastUsed();
        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture centered horizontally within the available content region width.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    /// <param name="maxSize">Optional maximum size constraint that overrides the instance MaxSize property.</param>
    public void DrawCenteredHorizontally(Vector2? drawSize = null, bool disabled = false, float? maxSize = null)
    {
        ThrowIfDisposed();
        var requestSize = drawSize ?? _size;
        var actualSize = maxSize.HasValue ? GetScaledSize(requestSize, maxSize.Value) : GetScaledSize(requestSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {actualSize}. Size must be positive.");
        }

        // Calculate horizontal centering offset
        var availableWidth = ImGui.GetContentRegionAvail().X;
        var offsetX = Math.Max(0, (availableWidth - actualSize.X) * 0.5f);

        UpdateLastUsed();

        // Set cursor position for horizontal centering
        var currentPos = ImGui.GetCursorPos();
        ImGui.SetCursorPosX(currentPos.X + offsetX);

        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture centered horizontally with automatic width fitting to the available content region.
    /// The texture is scaled to fit within the available width while maintaining aspect ratio.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    public void DrawCenteredHorizontallyFitted(Vector2? drawSize = null, bool disabled = false)
    {
        ThrowIfDisposed();
        var requestSize = drawSize ?? _size;
        var availableRegion = ImGui.GetContentRegionAvail();
        var maxSize = availableRegion.X;

        var actualSize = GetScaledSize(requestSize, maxSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {actualSize}. Size must be positive.");
        }

        // Calculate horizontal centering offset
        var offsetX = Math.Max(0, (availableRegion.X - actualSize.X) * 0.5f);

        UpdateLastUsed();

        // Set cursor position for horizontal centering
        var currentPos = ImGui.GetCursorPos();
        ImGui.SetCursorPosX(currentPos.X + offsetX);

        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture centered vertically with automatic height fitting to the available content region.
    /// The texture is scaled to fit within the available height while maintaining aspect ratio.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    public void DrawCenteredVerticallyFitted(Vector2? drawSize = null, bool disabled = false)
    {
        ThrowIfDisposed();
        var requestSize = drawSize ?? _size;
        var availableRegion = ImGui.GetContentRegionAvail();
        var maxSize = availableRegion.Y;

        var actualSize = GetScaledSize(requestSize, maxSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {actualSize}. Size must be positive.");
        }

        // Calculate vertical centering offset
        var offsetY = Math.Max(0, (availableRegion.Y - actualSize.Y) * 0.5f);

        UpdateLastUsed();

        // Set cursor position for vertical centering
        var currentPos = ImGui.GetCursorPos();
        ImGui.SetCursorPosY(currentPos.Y + offsetY);

        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture centered both horizontally and vertically with automatic size fitting to the available content region.
    /// The texture is scaled to fit within the smaller dimension (width or height) of the available region while maintaining aspect ratio.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    public void DrawCenteredFitted(Vector2? drawSize = null, bool disabled = false)
    {
        ThrowIfDisposed();
        var requestSize = drawSize ?? _size;
        var availableRegion = ImGui.GetContentRegionAvail();
        var maxSize = Math.Min(availableRegion.X, availableRegion.Y);

        var actualSize = GetScaledSize(requestSize, maxSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {actualSize}. Size must be positive.");
        }

        // Calculate centering offsets for both axes
        var offsetX = Math.Max(0, (availableRegion.X - actualSize.X) * 0.5f);
        var offsetY = Math.Max(0, (availableRegion.Y - actualSize.Y) * 0.5f);

        UpdateLastUsed();

        // Set cursor position for full centering
        var currentPos = ImGui.GetCursorPos();
        ImGui.SetCursorPos(new Vector2(currentPos.X + offsetX, currentPos.Y + offsetY));

        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture centered vertically within the available content region height.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    /// <param name="maxSize">Optional maximum size constraint that overrides the instance MaxSize property.</param>
    public void DrawCenteredVertically(Vector2? drawSize = null, bool disabled = false, float? maxSize = null)
    {
        ThrowIfDisposed();
        var requestSize = drawSize ?? _size;
        var actualSize = maxSize.HasValue ? GetScaledSize(requestSize, maxSize.Value) : GetScaledSize(requestSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {actualSize}. Size must be positive.");
        }

        // Calculate vertical centering offset
        var availableHeight = ImGui.GetContentRegionAvail().Y;
        var offsetY = Math.Max(0, (availableHeight - actualSize.Y) * 0.5f);

        UpdateLastUsed();

        // Set cursor position for vertical centering
        var currentPos = ImGui.GetCursorPos();
        ImGui.SetCursorPosY(currentPos.Y + offsetY);

        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture centered both horizontally and vertically within the available content region.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    /// <param name="maxSize">Optional maximum size constraint that overrides the instance MaxSize property.</param>
    public void DrawCentered(Vector2? drawSize = null, bool disabled = false, float? maxSize = null)
    {
        ThrowIfDisposed();
        var requestSize = drawSize ?? _size;
        var actualSize = maxSize.HasValue ? GetScaledSize(requestSize, maxSize.Value) : GetScaledSize(requestSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {actualSize}. Size must be positive.");
        }

        // Calculate centering offsets for both axes
        var availableRegion = ImGui.GetContentRegionAvail();
        var offsetX = Math.Max(0, (availableRegion.X - actualSize.X) * 0.5f);
        var offsetY = Math.Max(0, (availableRegion.Y - actualSize.Y) * 0.5f);

        UpdateLastUsed();

        // Set cursor position for full centering
        var currentPos = ImGui.GetCursorPos();
        ImGui.SetCursorPos(new Vector2(currentPos.X + offsetX, currentPos.Y + offsetY));

        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture as an image with custom UV coordinates for texture sampling.
    /// Allows rendering only a portion of the texture by specifying UV coordinates.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="uv0">The UV coordinate for the top-left corner (typically 0,0).</param>
    /// <param name="uv1">The UV coordinate for the bottom-right corner (typically 1,1).</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    /// <param name="maxSize">Optional maximum size constraint that overrides the instance MaxSize property.</param>
    public void DrawWithUV(Vector2? drawSize, Vector2 uv0, Vector2 uv1, bool disabled = false, float? maxSize = null)
    {
        ThrowIfDisposed();

        var requestSize = drawSize ?? _size;
        var actualSize = maxSize.HasValue ? GetScaledSize(requestSize, maxSize.Value) : GetScaledSize(requestSize);

        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid draw size: {drawSize}. Size must be positive.");
        }

        UpdateLastUsed();
        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            ImGui.EndDisabled();
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize, uv0, uv1);
            }
            catch (Exception ex)
            {
                DrawDummy(actualSize);
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture as an ImGui image button with customizable appearance.
    /// Returns true if the button was clicked.
    /// </summary>
    /// <param name="drawSize">The size to draw the button. If null, uses the texture's original size.</param>
    /// <param name="backgroundTint">The background tint color. If null, uses transparent.</param>
    /// <param name="tintColor">The tint color applied to the texture. If null, uses white (no tinting).</param>
    /// <param name="disbled">Whether to draw the button in a disabled state.</param>
    /// <param name="maxSize">Optional maximum size constraint that overrides the instance MaxSize property.</param>
    /// <returns>True if the button was clicked, otherwise false.</returns>
    public bool DrawImageButton(Vector2? drawSize = null, Vector4? backgroundTint = null, Vector4? tintColor = null, bool disbled = false, float? maxSize = null)
    {
        ThrowIfDisposed();

        var requestSize = drawSize ?? _size;
        var actualSize = maxSize.HasValue ? GetScaledSize(requestSize, maxSize.Value) : GetScaledSize(requestSize);

        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid button size: {actualSize}. Size must be positive.");
        }

        UpdateLastUsed();
        ImGui.BeginDisabled(disbled);
        if (!IsValid)
        {
            bool ret = ImGui.Button($"[ERROR]", actualSize);
            ImGui.EndDisabled();
            return ret;
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                var bgTint = backgroundTint ?? Vector4.Zero;
                var tint = tintColor ?? Vector4.One;
                return ImGui.ImageButton($"texture_button_{Handle}", textureRef, actualSize,
                                       Vector2.Zero, Vector2.One, bgTint, tint);
            }
            catch (Exception ex)
            {
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
                return ImGui.Button($"[Error: {ex.Message}]", actualSize);
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Draws the texture as a clickable image that behaves like a button.
    /// Changes the mouse cursor to a hand when hovered and returns true when clicked.
    /// </summary>
    /// <param name="drawSize">The size to draw the texture. If null, uses the texture's original size.</param>
    /// <param name="disabled">Whether to draw the texture in a disabled state.</param>
    /// <param name="maxSize">Optional maximum size constraint that overrides the instance MaxSize property.</param>
    /// <returns>True if the texture was clicked with the left mouse button, otherwise false.</returns>
    public bool DrawAsButton(Vector2? drawSize = null, bool disabled = false, float? maxSize = null)
    {
        var requestSize = drawSize ?? _size;
        var actualSize = maxSize.HasValue ? GetScaledSize(requestSize, maxSize.Value) : GetScaledSize(requestSize);
        if (actualSize.X <= 0 || actualSize.Y <= 0)
        {
            throw new InvalidOperationException($"Invalid button size: {actualSize}. Size must be positive.");
        }

        UpdateLastUsed();
        ImGui.BeginDisabled(disabled);
        if (!IsValid)
        {
            DrawDummy(actualSize);
            if (ImGui.IsItemHovered()) ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
            bool ret = ImGui.IsItemClicked(ImGuiMouseButton.Left);
            ImGui.EndDisabled();
            return ret;
        }
        else
        {
            try
            {
                var textureRef = GetCachedTextureRef();
                ImGui.Image(textureRef, actualSize, Vector2.Zero, Vector2.One);
                if (ImGui.IsItemHovered()) ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
                return ImGui.IsItemClicked(ImGuiMouseButton.Left);
            }
            catch (Exception ex)
            {
                OnDrawError?.Invoke(this, new TextureDrawErrorEventArgs(ex));
                DrawDummy(actualSize);
                return false;
            }
            finally
            {
                ImGui.EndDisabled();
            }
        }
    }

    /// <summary>
    /// Updates the LastUsed timestamp to the current ImGui time.
    /// Used internally to track texture usage for potential caching or cleanup scenarios.
    /// </summary>
    public void UpdateLastUsed()
    {
        ThrowIfDisposed();
        _lastUsed = ImGui.GetTime();
    }

    private ImTextureRef GetCachedTextureRef()
    {
        if (!_handle.HasValue)
        {
            throw new InvalidOperationException("Texture handle is null.");
        }

        _cachedTextureRef ??= new ImTextureRef()
        {
            TexID = (ImTextureID)_handle.Value
        };

        return _cachedTextureRef.Value;
    }

    private static readonly Vector4 BorderColor = new(1, 0, 0, 0.5f);
    private static readonly Vector4 CrossColor = new(1, 0, 0, 0.8f);

    private static void DrawDummy(Vector2 size)
    {
        ImGui.Dummy(size);

        if (ImGui.IsItemVisible())
        {
            var drawList = ImGui.GetWindowDrawList();
            var min = ImGui.GetItemRectMin();
            var max = ImGui.GetItemRectMax();

            drawList.AddRect(min, max, ImGui.GetColorU32(BorderColor));

            var center = (min + max) * 0.5f;
            var halfSize = Math.Min(size.X, size.Y) * 0.1f;
            drawList.AddLine(new Vector2(center.X - halfSize, center.Y - halfSize),
                           new Vector2(center.X + halfSize, center.Y + halfSize),
                           ImGui.GetColorU32(CrossColor), 2.0f);
            drawList.AddLine(new Vector2(center.X + halfSize, center.Y - halfSize),
                           new Vector2(center.X - halfSize, center.Y + halfSize),
                           ImGui.GetColorU32(CrossColor), 2.0f);
        }
    }

    private void InvalidateCache() => _cachedTextureRef = null;

    private void ThrowIfDisposed() => ObjectDisposedException.ThrowIf(_disposed, this);

    /// <summary>
    /// Occurs when an error happens during texture drawing operations.
    /// Provides access to the exception details for error handling and logging.
    /// </summary>
    public event EventHandler<TextureDrawErrorEventArgs>? OnDrawError;

    /// <summary>
    /// Releases all resources used by the Texture instance.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the Texture and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _cachedTextureRef = null;
            }
            _disposed = true;
        }
    }

    ~Texture() => Dispose(false);
}

/// <summary>
/// Provides data for the OnDrawError event, containing exception information when texture drawing fails.
/// </summary>
/// <param name="exception">The exception that occurred during texture drawing.</param>
public class TextureDrawErrorEventArgs(Exception exception) : EventArgs
{
    /// <summary>
    /// Gets the exception that occurred during the texture drawing operation.
    /// </summary>
    public Exception Exception { get; } = exception ?? throw new ArgumentNullException(nameof(exception));
}
