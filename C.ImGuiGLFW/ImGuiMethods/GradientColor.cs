namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// Provides functionality for creating animated gradient color transitions that smoothly interpolate between two colors over time.
/// </summary>
/// <remarks>
/// The GradientColor class generates time-based color animations that cycle continuously between a start and end color.
/// The animation follows a ping-pong pattern: starting from the start color, transitioning to the end color over the specified
/// duration, then transitioning back to the start color over the same duration, creating a seamless loop.
/// This is particularly useful for creating pulsing effects, attention-drawing animations, or dynamic UI color schemes
/// in Dear ImGui applications. The timing is based on Environment.TickCount64 to ensure consistent animation speed
/// regardless of frame rate variations.
/// </remarks>
public static class GradientColor
{
    /// <summary>
    /// Calculates the current color in a continuous gradient animation between two colors.
    /// </summary>
    /// <param name="start">The starting color as a Vector4 (RGBA values typically in the range 0.0 to 1.0).</param>
    /// <param name="end">The ending color as a Vector4 (RGBA values typically in the range 0.0 to 1.0).</param>
    /// <param name="Milliseconds">The duration in milliseconds for a single transition from start to end (or end to start). Default is 1000ms (1 second).</param>
    /// <returns>
    /// A Vector4 representing the current interpolated color at this moment in time. The color continuously animates
    /// in a ping-pong pattern between the start and end colors.
    /// </returns>
    /// <remarks>
    /// The animation creates a seamless loop with a total cycle time of (Milliseconds * 2). During the first half of the cycle,
    /// the color transitions from start to end. During the second half, it transitions from end back to start.
    /// The interpolation is linear, providing smooth color transitions. Each call to this method will return a slightly
    /// different color value (assuming sufficient time has passed) until the full cycle completes and repeats.
    /// This method is stateless and thread-safe, as it relies only on the current system tick count for timing.
    /// </remarks>
    public static Vector4 Get(Vector4 start, Vector4 end, int Milliseconds = 1000)
    {
        var delta = (end - start) / Milliseconds;
        var time = Environment.TickCount64 % (Milliseconds * 2);
        if (time < Milliseconds)
        {
            return start + delta * (time % Milliseconds);
        }
        else
        {
            return end - delta * (time % Milliseconds);
        }
    }
}
