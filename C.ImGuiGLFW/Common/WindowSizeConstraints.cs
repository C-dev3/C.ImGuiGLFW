using System.Text.Json.Serialization;

namespace C.ImGuiGLFW.Common;

/// <summary>
/// Represents constraints for the minimum and maximum size of a window,
/// providing validation and clamping to ensure safe resizing behavior.
/// </summary>
/// <remarks>
/// This struct helps enforce valid size ranges when creating or resizing windows.
/// It automatically adjusts inconsistent size pairs (e.g., when min size exceeds max size).
/// </remarks>
public struct WindowSizeConstraints
{
    // MaxLimitFloat: Used internally to cap float-based window dimensions to a practical maximum value.
    internal const float MaxLimitFloat = int.MaxValue - 10_000;
    // MaxLimitInt: Used internally to cap int-based window dimensions to prevent overflow or excessive sizing.
    internal const int MaxLimitInt = int.MaxValue - 10_000;
    private Vector2 _maxSize;
    private Vector2 _minSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowSizeConstraints"/> struct
    /// with no minimum size and a very large maximum size.
    /// </summary>
    /// <remarks>
    /// This constructor sets <see cref="MinSize"/> to (0, 0) and <see cref="MaxSize"/> to a large default value,
    /// effectively imposing no constraints on window size.
    /// </remarks>
    public WindowSizeConstraints()
    {
        _maxSize = new Vector2(MaxLimitInt);
        _minSize = new Vector2(0);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowSizeConstraints"/> struct
    /// with the specified minimum and maximum sizes.
    /// </summary>
    /// <param name="minSize">The minimum allowed window size.</param>
    /// <param name="maxSize">The maximum allowed window size.</param>
    /// <remarks>
    /// This constructor validates and clamps the provided size vectors to ensure they are within valid bounds.
    /// If <paramref name="minSize"/> exceeds <paramref name="maxSize"/> on any axis,
    /// it automatically adjusts the values to preserve consistency.
    /// </remarks>
    public WindowSizeConstraints(Vector2 minSize, Vector2 maxSize)
    {
        _minSize = ValidateAndClampMinSize(minSize);
        _maxSize = ValidateAndClampMaxSize(maxSize);
        if (_minSize.X > _maxSize.X || _minSize.Y > _maxSize.Y)
        {
            _minSize = new Vector2(Math.Min(_minSize.X, _maxSize.X), Math.Min(_minSize.Y, _maxSize.Y));
        }
    }

    /// <summary>
    /// Gets or sets the maximum allowed window size.
    /// </summary>
    /// <remarks>
    /// Values greater than the internal limit (<see cref="MaxLimitFloat"/>) are clamped,
    /// and invalid values (e.g., negative, NaN, or Infinity) are replaced with a safe default.
    /// If <c>MaxSize</c> becomes smaller than <c>MinSize</c>, <c>MinSize</c> will be clamped accordingly.
    /// </remarks>
    public Vector2 MaxSize
    {
        readonly get => _maxSize;
        set
        {
            _maxSize = ValidateAndClampMaxSize(value);
            if (_maxSize.X < _minSize.X || _maxSize.Y < _minSize.Y)
            {
                _minSize = new Vector2(
                    Math.Min(_minSize.X, _maxSize.X),
                    Math.Min(_minSize.Y, _maxSize.Y)
                );
            }
        }
    }

    /// <summary>
    /// Gets or sets the minimum allowed window size.
    /// </summary>
    /// <remarks>
    /// Negative, NaN, or Infinity values are clamped to 0.
    /// If <c>MinSize</c> becomes larger than <c>MaxSize</c>, <c>MaxSize</c> will be adjusted to maintain validity.
    /// </remarks>
    public Vector2 MinSize
    {
        readonly get => _minSize;
        set
        {
            _minSize = ValidateAndClampMinSize(value);
            if (_minSize.X > _maxSize.X || _minSize.Y > _maxSize.Y)
            {
                _maxSize = new Vector2(
                    Math.Max(_minSize.X, _maxSize.X),
                    Math.Max(_minSize.Y, _maxSize.Y)
                );
            }
        }
    }

    private static Vector2 ValidateAndClampMinSize(Vector2 size)
    {
        float x = float.IsNaN(size.X) || float.IsInfinity(size.X) || size.X < 0 ? 0 : size.X;
        float y = float.IsNaN(size.Y) || float.IsInfinity(size.Y) || size.Y < 0 ? 0 : size.Y;

        return new Vector2(x, y);
    }

    private static Vector2 ValidateAndClampMaxSize(Vector2 size)
    {
        float x = float.IsNaN(size.X) || size.X < 0 ? MaxLimitFloat : size.X;
        float y = float.IsNaN(size.Y) || size.Y < 0 ? MaxLimitFloat : size.Y;
        if (float.IsPositiveInfinity(size.X)) x = MaxLimitFloat;
        if (float.IsPositiveInfinity(size.Y)) y = MaxLimitFloat;

        return new Vector2(x, y);
    }

    /// <summary>
    /// Clamps a given size to ensure it lies within the <see cref="MinSize"/> and <see cref="MaxSize"/> constraints.
    /// </summary>
    /// <param name="size">The input size to clamp.</param>
    /// <returns>A new size vector that is constrained within valid limits.</returns>
    /// <remarks>
    /// This is useful to enforce valid dimensions during resizing or layout calculations.
    /// </remarks>
    public readonly Vector2 ClampSize(Vector2 size) => new(
            Math.Max(_minSize.X, Math.Min(_maxSize.X, size.X)),
            Math.Max(_minSize.Y, Math.Min(_maxSize.Y, size.Y))
        );

    /// <summary>
    /// Determines whether a given size lies within the defined minimum and maximum constraints.
    /// </summary>
    /// <param name="size">The size to validate.</param>
    /// <returns><c>true</c> if the size is within bounds; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This does not modify the input but checks whether it is valid within the current constraint range.
    /// </remarks>
    public readonly bool IsValidSize(Vector2 size) => size.X >= _minSize.X && size.X <= _maxSize.X &&
               size.Y >= _minSize.Y && size.Y <= _maxSize.Y;

    /// <summary>
    /// Gets a value indicating whether the current <see cref="MinSize"/> and <see cref="MaxSize"/> form a valid range.
    /// </summary>
    /// <remarks>
    /// Returns <c>true</c> if each component of <c>MinSize</c> is less than or equal to the corresponding component of <c>MaxSize</c>.
    /// </remarks>
    [JsonIgnore]
    public readonly bool IsValid { get => _minSize.X <= _maxSize.X && _minSize.Y <= _maxSize.Y; }

    /// <summary>
    /// Gets a default instance of <see cref="WindowSizeConstraints"/> with unbounded maximum size and zero minimum size.
    /// </summary>
    /// <remarks>
    /// This is typically used when no explicit size constraints are required for a window.
    /// </remarks>
    public static WindowSizeConstraints Default => new();
}