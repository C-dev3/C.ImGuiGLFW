using System.Text.Json.Serialization;

namespace C.ImGuiGLFW.Common;

public struct WindowSizeConstraints
{
    internal const float MaxLimitFloat = int.MaxValue - 10_000;
    internal const int MaxLimitInt = int.MaxValue - 10_000;
    private Vector2 _maxSize;
    private Vector2 _minSize;

    public WindowSizeConstraints()
    {
        _maxSize = new Vector2(MaxLimitInt);
        _minSize = new Vector2(0);
    }

    public WindowSizeConstraints(Vector2 minSize, Vector2 maxSize)
    {
        _minSize = ValidateAndClampMinSize(minSize);
        _maxSize = ValidateAndClampMaxSize(maxSize);
        if (_minSize.X > _maxSize.X || _minSize.Y > _maxSize.Y)
        {
            _minSize = new Vector2(Math.Min(_minSize.X, _maxSize.X), Math.Min(_minSize.Y, _maxSize.Y));
        }
    }

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

    public readonly Vector2 ClampSize(Vector2 size)
    {
        return new Vector2(
            Math.Max(_minSize.X, Math.Min(_maxSize.X, size.X)),
            Math.Max(_minSize.Y, Math.Min(_maxSize.Y, size.Y))
        );
    }

    public readonly bool IsValidSize(Vector2 size)
    {
        return size.X >= _minSize.X && size.X <= _maxSize.X &&
               size.Y >= _minSize.Y && size.Y <= _maxSize.Y;
    }

    [JsonIgnore]
    public readonly bool IsValid { get => _minSize.X <= _maxSize.X && _minSize.Y <= _maxSize.Y; }

    public static WindowSizeConstraints Default => new();
}