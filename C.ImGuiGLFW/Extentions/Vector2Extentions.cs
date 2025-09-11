using Hexa.NET.Mathematics;

namespace C.ImGuiGLFW.Extentions;

/// <summary>
/// Provides extension methods for the <see cref="Vector2"/> class to extend its functionality with additional conversion operations.
/// </summary>
public static class Vector2Extentions
{
    /// <summary>
    /// Converts a <see cref="Vector2"/> to a <see cref="Point2"/> by casting the X and Y components to integers.
    /// </summary>
    /// <param name="vector">The <see cref="Vector2"/> to convert.</param>
    /// <returns>A <see cref="Point2"/> with X and Y values cast from the corresponding <see cref="Vector2"/> components.</returns>
    /// <remarks>
    /// This method performs a truncating conversion, where decimal portions are discarded.
    /// For example, a Vector2(3.7f, -2.9f) will result in Point2(3, -2).
    /// </remarks>
    public static Point2 ToPoint2(this Vector2 vector) => (Point2)vector;

    /// <summary>
    /// Converts a <see cref="Vector2"/> to a <see cref="Point2"/> by rounding the X and Y components to the nearest integers.
    /// </summary>
    /// <param name="vector">The <see cref="Vector2"/> to convert.</param>
    /// <returns>A <see cref="Point2"/> with X and Y values rounded from the corresponding <see cref="Vector2"/> components.</returns>
    /// <remarks>
    /// This method uses banker's rounding (round half to even) as implemented by <see cref="Math.Round(double)"/>.
    /// For example, a Vector2(3.7f, -2.5f) will result in Point2(4, -2).
    /// </remarks>
    public static Point2 ToPoint2Rounded(this Vector2 vector) => new((int)Math.Round(vector.X), (int)Math.Round(vector.Y));

    /// <summary>
    /// Converts a <see cref="Vector2"/> to a <see cref="Point2"/> by applying ceiling function to the X and Y components.
    /// </summary>
    /// <param name="vector">The <see cref="Vector2"/> to convert.</param>
    /// <returns>A <see cref="Point2"/> with X and Y values rounded up from the corresponding <see cref="Vector2"/> components.</returns>
    /// <remarks>
    /// This method always rounds towards positive infinity.
    /// For example, a Vector2(3.1f, -2.9f) will result in Point2(4, -2).
    /// </remarks>
    public static Point2 ToPoint2Ceiling(this Vector2 vector) => new((int)Math.Ceiling(vector.X), (int)Math.Ceiling(vector.Y));

    /// <summary>
    /// Converts a <see cref="Vector2"/> to a <see cref="Point2"/> by applying floor function to the X and Y components.
    /// </summary>
    /// <param name="vector">The <see cref="Vector2"/> to convert.</param>
    /// <returns>A <see cref="Point2"/> with X and Y values rounded down from the corresponding <see cref="Vector2"/> components.</returns>
    /// <remarks>
    /// This method always rounds towards negative infinity.
    /// For example, a Vector2(3.9f, -2.1f) will result in Point2(3, -3).
    /// </remarks>
    public static Point2 ToPoint2Floor(this Vector2 vector) => new((int)Math.Floor(vector.X), (int)Math.Floor(vector.Y));
}
