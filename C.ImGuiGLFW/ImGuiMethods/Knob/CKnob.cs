using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.ImGuiMethods.Knob;

/// <summary>
/// Provides static methods for creating interactive knob controls in ImGui applications.
/// </summary>
/// <remarks>
/// The CKnob class offers a comprehensive set of knob controls with various visual styles and interaction modes.
/// It supports both float and integer value types, with features including logarithmic scaling, multiple visual
/// variants (tick, dot, wiper, stepped, space), customizable angles, and optional tooltips and input fields.
/// The knobs are designed to integrate seamlessly with ImGui's styling system and provide smooth mouse-based
/// interaction for parameter adjustment in audio applications, games, and other interactive software.
/// All methods are static and thread-safe for use in ImGui rendering contexts.
/// </remarks>
public static class CKnob
{
    private static void DrawArc(Vector2 center, float radius, float startAngle, float endAngle, float thickness, uint color)
    {
        var drawList = ImGui.GetWindowDrawList();
        drawList.PathArcTo(center, radius, startAngle, endAngle);
        drawList.PathStroke(color, thickness, ImDrawFlags.None);
    }

    private static KnobState CreateKnobState(string label, ref float value, float vMin, float vMax, float speed,
        float radius, ImGuiKnobFlags flags, float angleMin, float angleMax)
    {
        var state = new KnobState
        {
            Radius = radius,
            ValueChanged = false
        };

        // Calculate normalized value (t)
        if (flags.HasFlag(ImGuiKnobFlags.Logarithmic))
        {
            float v = Math.Max(Math.Min(value, vMax), vMin);
            state.T = (MathF.Log(MathF.Abs(v)) - MathF.Log(MathF.Abs(vMin))) / (MathF.Log(MathF.Abs(vMax)) - MathF.Log(MathF.Abs(vMin)));
        }
        else
        {
            state.T = (value - vMin) / (vMax - vMin);
        }

        var screenPos = ImGui.GetCursorScreenPos();

        // Create invisible button for interaction
        ImGui.InvisibleButton(label, new Vector2(radius * 2.0f, radius * 2.0f));

        // Handle manual dragging
        var io = ImGui.GetIO();
        state.IsActive = ImGui.IsItemActive();
        state.IsHovered = ImGui.IsItemHovered();

        if (state.IsActive && ImGui.IsMouseDragging(ImGuiMouseButton.Left))
        {
            bool dragVertical = !flags.HasFlag(ImGuiKnobFlags.DragHorizontal) &&
                               (flags.HasFlag(ImGuiKnobFlags.DragVertical) ||
                                MathF.Abs(io.MouseDelta.Y) > MathF.Abs(io.MouseDelta.X));

            float delta = dragVertical ? -io.MouseDelta.Y : io.MouseDelta.X;
            float valueDelta = delta * speed;

            if (flags.HasFlag(ImGuiKnobFlags.Logarithmic))
            {
                // For logarithmic scale
                float logValue = MathF.Log(MathF.Abs(value));
                logValue += valueDelta * 0.01f;
                value = MathF.Sign(value) * MathF.Exp(logValue);
            }
            else
            {
                value += valueDelta;
            }

            // Clamp value
            if (flags.HasFlag(ImGuiKnobFlags.AlwaysClamp) || !flags.HasFlag(ImGuiKnobFlags.Logarithmic))
            {
                value = Math.Max(Math.Min(value, vMax), vMin);
            }

            state.ValueChanged = true;

            // Recalculate T after value change
            if (flags.HasFlag(ImGuiKnobFlags.Logarithmic))
            {
                float v = Math.Max(Math.Min(value, vMax), vMin);
                state.T = (MathF.Log(MathF.Abs(v)) - MathF.Log(MathF.Abs(vMin))) / (MathF.Log(MathF.Abs(vMax)) - MathF.Log(MathF.Abs(vMin)));
            }
            else
            {
                state.T = (value - vMin) / (vMax - vMin);
            }
        }

        // Set angles
        state.AngleMin = angleMin < 0 ? MathF.PI * 0.75f : angleMin;
        state.AngleMax = angleMax < 0 ? MathF.PI * 2.25f : angleMax;

        // Calculate positions and states
        state.Center = new Vector2(screenPos.X + radius, screenPos.Y + radius);
        state.Angle = state.AngleMin + (state.AngleMax - state.AngleMin) * state.T;
        state.AngleCos = MathF.Cos(state.Angle);
        state.AngleSin = MathF.Sin(state.Angle);

        return state;
    }

    private static void DrawDot(in KnobState knob, float size, float radius, float angle, in ColorSet colorSet, bool filled = true, int segments = 12)
    {
        var dotSize = size * knob.Radius;
        var dotRadius = radius * knob.Radius;

        var color = knob.IsActive ? colorSet.Active : (knob.IsHovered ? colorSet.Hovered : colorSet.Base);
        var drawList = ImGui.GetWindowDrawList();

        if (filled)
        {
            drawList.AddCircleFilled(
                new Vector2(knob.Center.X + MathF.Cos(angle) * dotRadius,
                knob.Center.Y + MathF.Sin(angle) * dotRadius),
                dotSize,
                ImGui.ColorConvertFloat4ToU32(color),
                segments);
        }
        else
        {
            drawList.AddCircle(
                new Vector2(knob.Center.X + MathF.Cos(angle) * dotRadius,
                knob.Center.Y + MathF.Sin(angle) * dotRadius),
                dotSize,
                ImGui.ColorConvertFloat4ToU32(color),
                segments);
        }
    }

    private static void DrawTick(in KnobState knob, float start, float end, float width, float angle, in ColorSet colorSet)
    {
        var tickStart = start * knob.Radius;
        var tickEnd = end * knob.Radius;
        var angleCos = MathF.Cos(angle);
        var angleSin = MathF.Sin(angle);

        var color = knob.IsActive ? colorSet.Active : (knob.IsHovered ? colorSet.Hovered : colorSet.Base);
        var drawList = ImGui.GetWindowDrawList();

        drawList.AddLine(
            new Vector2(knob.Center.X + angleCos * tickEnd, knob.Center.Y + angleSin * tickEnd),
            new Vector2(knob.Center.X + angleCos * tickStart, knob.Center.Y + angleSin * tickStart),
            ImGui.ColorConvertFloat4ToU32(color),
            width * knob.Radius);
    }

    private static void DrawCircle(in KnobState knob, float size, in ColorSet colorSet, bool filled = true, int segments = 32)
    {
        var circleRadius = size * knob.Radius;
        var color = knob.IsActive ? colorSet.Active : (knob.IsHovered ? colorSet.Hovered : colorSet.Base);
        var drawList = ImGui.GetWindowDrawList();

        if (filled)
        {
            drawList.AddCircleFilled(
                knob.Center,
                circleRadius,
                ImGui.ColorConvertFloat4ToU32(color),
                segments);
        }
        else
        {
            drawList.AddCircle(
                knob.Center,
                circleRadius,
                ImGui.ColorConvertFloat4ToU32(color),
                segments);
        }
    }

    private static void DrawKnobArc(in KnobState knob, float radius, float size, float startAngle, float endAngle, in ColorSet colorSet)
    {
        var trackRadius = radius * knob.Radius;
        var trackSize = size * knob.Radius * 0.5f + 0.0001f;
        var color = knob.IsActive ? colorSet.Active : (knob.IsHovered ? colorSet.Hovered : colorSet.Base);

        DrawArc(knob.Center, trackRadius, startAngle, endAngle, trackSize, ImGui.ColorConvertFloat4ToU32(color));
    }

    private static ColorSet GetPrimaryColorSet()
    {
        var style = ImGui.GetStyle();
        return new ColorSet(
            style.Colors[(int)ImGuiCol.ButtonActive],
            style.Colors[(int)ImGuiCol.ButtonHovered],
            style.Colors[(int)ImGuiCol.ButtonHovered]);
    }

    private static ColorSet GetSecondaryColorSet()
    {
        var style = ImGui.GetStyle();
        var active = style.Colors[(int)ImGuiCol.ButtonActive];
        var hovered = style.Colors[(int)ImGuiCol.ButtonHovered];

        return new ColorSet(
            new Vector4(active.X * 0.5f, active.Y * 0.5f, active.Z * 0.5f, active.W),
            new Vector4(hovered.X * 0.5f, hovered.Y * 0.5f, hovered.Z * 0.5f, hovered.W),
            new Vector4(hovered.X * 0.5f, hovered.Y * 0.5f, hovered.Z * 0.5f, hovered.W));
    }

    private static ColorSet GetTrackColorSet()
    {
        var style = ImGui.GetStyle();
        var color = style.Colors[(int)ImGuiCol.Button];
        return new ColorSet(color, color, color);
    }

    /// <summary>
    /// Creates a knob control for float values with various visual styles and interaction modes.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated as (vMax - vMin) / 250.</param>
    /// <param name="format">Format string for displaying the value (e.g., "%.3f" for 3 decimal places).</param>
    /// <param name="variant">Visual style variant of the knob (Tick, Dot, Wiper, etc.).</param>
    /// <param name="size">Size of the knob in pixels. If 0, defaults to 4 times the text line height.</param>
    /// <param name="flags">Flags controlling knob behavior (logarithmic scaling, clamping, etc.).</param>
    /// <param name="steps">Number of steps for the Stepped variant.</param>
    /// <param name="angleMin">Minimum angle in radians. If negative, defaults to PI * 0.75.</param>
    /// <param name="angleMax">Maximum angle in radians. If negative, defaults to PI * 2.25.</param>
    /// <returns>True if the value was changed during this frame, false otherwise.</returns>
    /// <remarks>
    /// This method creates an interactive knob control that can be manipulated by mouse dragging.
    /// The knob supports multiple visual variants including tick marks, dots, wiper-style arcs, and stepped displays.
    /// It automatically handles logarithmic scaling when the Logarithmic flag is set, adjusting minimum values
    /// to avoid mathematical errors with log(0). The control includes an optional title, tooltip, and input field
    /// based on the provided flags.
    /// </remarks>
    public static bool Knob(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
        string format = "%.3f", KnobVariant variant = KnobVariant.Tick, float size = 0.0f,
        ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp, int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f)
    {
        // Handle logarithmic range containing zero
        if (flags.HasFlag(ImGuiKnobFlags.Logarithmic) && vMin <= 0.0f && vMax >= 0.0f)
        {
            vMin = 0.001f; // Small positive value to avoid log(0)
            vMax = Math.Max(vMin, vMax);
            value = Math.Max(Math.Min(value, vMax), vMin);
        }

        if (speed == 0.0f)
            speed = (vMax - vMin) / 250.0f;

        ImGui.PushID(label);

        var fontScale = ImGui.GetStyle().MainScale;
        var width = size == 0.0f ? ImGui.GetTextLineHeight() * 4.0f : size * fontScale;
        ImGui.PushItemWidth(width);

        ImGui.BeginGroup();

        // Draw title
        if (!flags.HasFlag(ImGuiKnobFlags.NoTitle))
        {
            var titleSize = ImGui.CalcTextSize(label);
            // Center title
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + (width - titleSize.X) * 0.5f);
            ImGui.Text(label);
        }

        // Create knob state
        var knob = CreateKnobState(label, ref value, vMin, vMax, speed, width * 0.5f, flags, angleMin, angleMax);

        // Draw knob based on variant
        var primaryColors = GetPrimaryColorSet();
        var secondaryColors = GetSecondaryColorSet();
        var trackColors = GetTrackColorSet();

        switch (variant)
        {
            case KnobVariant.Tick:
                DrawCircle(knob, 0.85f, secondaryColors, true, 32);
                DrawTick(knob, 0.5f, 0.85f, 0.08f, knob.Angle, primaryColors);
                break;

            case KnobVariant.Dot:
                DrawCircle(knob, 0.85f, secondaryColors, true, 32);
                DrawDot(knob, 0.12f, 0.6f, knob.Angle, primaryColors, true, 12);
                break;

            case KnobVariant.Wiper:
                DrawCircle(knob, 0.7f, secondaryColors, true, 32);
                DrawKnobArc(knob, 0.8f, 0.41f, knob.AngleMin, knob.AngleMax, trackColors);
                if (knob.T > 0.01f)
                {
                    DrawKnobArc(knob, 0.8f, 0.43f, knob.AngleMin, knob.Angle, primaryColors);
                }
                break;

            case KnobVariant.WiperOnly:
                DrawKnobArc(knob, 0.8f, 0.41f, knob.AngleMin, knob.AngleMax, trackColors);
                if (knob.T > 0.01f)
                {
                    DrawKnobArc(knob, 0.8f, 0.43f, knob.AngleMin, knob.Angle, primaryColors);
                }
                break;

            case KnobVariant.WiperDot:
                DrawCircle(knob, 0.6f, secondaryColors, true, 32);
                DrawKnobArc(knob, 0.85f, 0.41f, knob.AngleMin, knob.AngleMax, trackColors);
                DrawDot(knob, 0.1f, 0.85f, knob.Angle, primaryColors, true, 12);
                break;

            case KnobVariant.Stepped:
                for (int n = 0; n < steps; n++)
                {
                    var a = (float)n / (steps - 1);
                    var angle = knob.AngleMin + (knob.AngleMax - knob.AngleMin) * a;
                    DrawTick(knob, 0.7f, 0.9f, 0.04f, angle, primaryColors);
                }
                DrawCircle(knob, 0.6f, secondaryColors, true, 32);
                DrawDot(knob, 0.12f, 0.4f, knob.Angle, primaryColors, true, 12);
                break;

            case KnobVariant.Space:
                DrawCircle(knob, 0.3f - knob.T * 0.1f, secondaryColors, true, 16);
                if (knob.T > 0.01f)
                {
                    DrawKnobArc(knob, 0.4f, 0.15f, knob.AngleMin - 1.0f, knob.Angle - 1.0f, primaryColors);
                    DrawKnobArc(knob, 0.6f, 0.15f, knob.AngleMin + 1.0f, knob.Angle + 1.0f, primaryColors);
                    DrawKnobArc(knob, 0.8f, 0.15f, knob.AngleMin + 3.0f, knob.Angle + 3.0f, primaryColors);
                }
                break;
        }

        // Draw tooltip
        if (flags.HasFlag(ImGuiKnobFlags.ValueTooltip) &&
            (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenDisabled) || ImGui.IsItemActive()))
        {
            ImGui.BeginTooltip();
            ImGui.Text(string.Format(format.Replace("%.3f", "{0:F3}").Replace("%i", "{0}"), value));
            ImGui.EndTooltip();
        }

        // Draw input field
        if (!flags.HasFlag(ImGuiKnobFlags.NoInput))
        {
            var sliderFlags = ImGuiSliderFlags.None;
            if (flags.HasFlag(ImGuiKnobFlags.AlwaysClamp)) sliderFlags |= ImGuiSliderFlags.AlwaysClamp;
            if (flags.HasFlag(ImGuiKnobFlags.Logarithmic)) sliderFlags |= ImGuiSliderFlags.Logarithmic;

            var inputChanged = ImGui.DragFloat($"##{label}_input", ref value, speed, vMin, vMax, format, sliderFlags);
            if (inputChanged)
            {
                knob.ValueChanged = true;
            }
        }

        ImGui.EndGroup();
        ImGui.PopItemWidth();
        ImGui.PopID();

        return knob.ValueChanged;
    }

    /// <summary>
    /// Creates a knob control with a tick mark indicator for float values.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated.</param>
    /// <param name="format">Format string for displaying the value.</param>
    /// <param name="size">Size of the knob in pixels. If 0, uses default sizing.</param>
    /// <param name="flags">Flags controlling knob behavior.</param>
    /// <param name="steps">Number of steps (unused for this variant).</param>
    /// <param name="angleMin">Minimum angle in radians.</param>
    /// <param name="angleMax">Maximum angle in radians.</param>
    /// <returns>True if the value was changed during this frame.</returns>
    /// <remarks>
    /// This is a convenience method that creates a knob with the Tick variant, displaying a line
    /// from the center to the edge indicating the current value position. The tick rotates around
    /// the knob as the value changes.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool KnobTick(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
        string format = "%.3f", float size = 0.0f, ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp,
        int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f) => Knob(label, ref value, vMin, vMax, speed, format, KnobVariant.Tick, size, flags, steps, angleMin, angleMax);

    /// <summary>
    /// Creates a knob control with a dot indicator for float values.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated.</param>
    /// <param name="format">Format string for displaying the value.</param>
    /// <param name="size">Size of the knob in pixels. If 0, uses default sizing.</param>
    /// <param name="flags">Flags controlling knob behavior.</param>
    /// <param name="steps">Number of steps (unused for this variant).</param>
    /// <param name="angleMin">Minimum angle in radians.</param>
    /// <param name="angleMax">Maximum angle in radians.</param>
    /// <returns>True if the value was changed during this frame.</returns>
    /// <remarks>
    /// This is a convenience method that creates a knob with the Dot variant, displaying a small
    /// circular dot on the perimeter of the knob to indicate the current value position.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool KnobDot(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
        string format = "%.3f", float size = 0.0f, ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp,
        int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f) => Knob(label, ref value, vMin, vMax, speed, format, KnobVariant.Dot, size, flags, steps, angleMin, angleMax);

    /// <summary>
    /// Creates a knob control with a wiper-style arc indicator for float values.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated.</param>
    /// <param name="format">Format string for displaying the value.</param>
    /// <param name="size">Size of the knob in pixels. If 0, uses default sizing.</param>
    /// <param name="flags">Flags controlling knob behavior.</param>
    /// <param name="steps">Number of steps (unused for this variant).</param>
    /// <param name="angleMin">Minimum angle in radians.</param>
    /// <param name="angleMax">Maximum angle in radians.</param>
    /// <returns>True if the value was changed during this frame.</returns>
    /// <remarks>
    /// This is a convenience method that creates a knob with the Wiper variant, displaying both
    /// a filled circular base and an arc that extends from the minimum angle to the current value
    /// position, resembling a windshield wiper motion.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool KnobWiper(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
    string format = "%.3f", float size = 0.0f, ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp,
    int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f) => Knob(label, ref value, vMin, vMax, speed, format, KnobVariant.Wiper, size, flags, steps, angleMin, angleMax);

    /// <summary>
    /// Creates a knob control with only a wiper-style arc indicator (no base circle) for float values.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated.</param>
    /// <param name="format">Format string for displaying the value.</param>
    /// <param name="size">Size of the knob in pixels. If 0, uses default sizing.</param>
    /// <param name="flags">Flags controlling knob behavior.</param>
    /// <param name="steps">Number of steps (unused for this variant).</param>
    /// <param name="angleMin">Minimum angle in radians.</param>
    /// <param name="angleMax">Maximum angle in radians.</param>
    /// <returns>True if the value was changed during this frame.</returns>
    /// <remarks>
    /// This is a convenience method that creates a knob with the WiperOnly variant, displaying
    /// only the arc indicator without a base circle, creating a minimalist appearance.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool KnobWiperOnly(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
    string format = "%.3f", float size = 0.0f, ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp,
    int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f) => Knob(label, ref value, vMin, vMax, speed, format, KnobVariant.WiperOnly, size, flags, steps, angleMin, angleMax);

    /// <summary>
    /// Creates a knob control combining a wiper-style arc with a dot indicator for float values.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated.</param>
    /// <param name="format">Format string for displaying the value.</param>
    /// <param name="size">Size of the knob in pixels. If 0, uses default sizing.</param>
    /// <param name="flags">Flags controlling knob behavior.</param>
    /// <param name="steps">Number of steps (unused for this variant).</param>
    /// <param name="angleMin">Minimum angle in radians.</param>
    /// <param name="angleMax">Maximum angle in radians.</param>
    /// <returns>True if the value was changed during this frame.</returns>
    /// <remarks>
    /// This is a convenience method that creates a knob with the WiperDot variant, combining
    /// both an arc track and a dot indicator for enhanced visual feedback of the current position.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool KnobWiperDot(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
    string format = "%.3f", float size = 0.0f, ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp,
    int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f) => Knob(label, ref value, vMin, vMax, speed, format, KnobVariant.WiperDot, size, flags, steps, angleMin, angleMax);

    /// <summary>
    /// Creates a knob control with discrete step indicators for float values.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated.</param>
    /// <param name="format">Format string for displaying the value.</param>
    /// <param name="size">Size of the knob in pixels. If 0, uses default sizing.</param>
    /// <param name="flags">Flags controlling knob behavior.</param>
    /// <param name="steps">Number of step tick marks to display around the knob.</param>
    /// <param name="angleMin">Minimum angle in radians.</param>
    /// <param name="angleMax">Maximum angle in radians.</param>
    /// <returns>True if the value was changed during this frame.</returns>
    /// <remarks>
    /// This is a convenience method that creates a knob with the Stepped variant, displaying
    /// multiple tick marks around the perimeter to indicate discrete steps, with a dot showing
    /// the current position. The steps parameter determines how many tick marks are drawn.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool KnobStepped(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
    string format = "%.3f", float size = 0.0f, ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp,
    int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f) => Knob(label, ref value, vMin, vMax, speed, format, KnobVariant.Stepped, size, flags, steps, angleMin, angleMax);

    /// <summary>
    /// Creates a knob control with a space-themed visual design for float values.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the float value to be modified by the knob.</param>
    /// <param name="vMin">Minimum value that the knob can represent.</param>
    /// <param name="vMax">Maximum value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated.</param>
    /// <param name="format">Format string for displaying the value.</param>
    /// <param name="size">Size of the knob in pixels. If 0, uses default sizing.</param>
    /// <param name="flags">Flags controlling knob behavior.</param>
    /// <param name="steps">Number of steps (unused for this variant).</param>
    /// <param name="angleMin">Minimum angle in radians.</param>
    /// <param name="angleMax">Maximum angle in radians.</param>
    /// <returns>True if the value was changed during this frame.</returns>
    /// <remarks>
    /// This is a convenience method that creates a knob with the Space variant, featuring
    /// a unique visual design with a central circle that changes size based on the value,
    /// and multiple concentric arcs that create a futuristic, space-themed appearance.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool KnobSpace(string label, ref float value, float vMin, float vMax, float speed = 0.0f,
    string format = "%.3f", float size = 0.0f, ImGuiKnobFlags flags = ImGuiKnobFlags.AlwaysClamp,
    int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f) => Knob(label, ref value, vMin, vMax, speed, format, KnobVariant.Space, size, flags, steps, angleMin, angleMax);

    /// <summary>
    /// Creates a knob control for integer values with various visual styles and interaction modes.
    /// </summary>
    /// <param name="label">The label/identifier for the knob control.</param>
    /// <param name="value">Reference to the integer value to be modified by the knob.</param>
    /// <param name="vMin">Minimum integer value that the knob can represent.</param>
    /// <param name="vMax">Maximum integer value that the knob can represent.</param>
    /// <param name="speed">The sensitivity of mouse dragging. If 0, automatically calculated based on range.</param>
    /// <param name="format">Format string for displaying the value (e.g., "%i" for integer display).</param>
    /// <param name="variant">Visual style variant of the knob (Tick, Dot, Wiper, etc.).</param>
    /// <param name="size">Size of the knob in pixels. If 0, defaults to 4 times the text line height.</param>
    /// <param name="flags">Flags controlling knob behavior (clamping, interaction modes, etc.).</param>
    /// <param name="steps">Number of steps for the Stepped variant.</param>
    /// <param name="angleMin">Minimum angle in radians. If negative, defaults to PI * 0.75.</param>
    /// <param name="angleMax">Maximum angle in radians. If negative, defaults to PI * 2.25.</param>
    /// <returns>True if the value was changed during this frame, false otherwise.</returns>
    /// <remarks>
    /// This is an integer-specific wrapper around the main Knob method. It internally converts the integer
    /// value to float for processing and converts back to integer for the result. This ensures consistent
    /// behavior with the float version while providing a convenient interface for integer values.
    /// Note that logarithmic scaling is generally not recommended for integer knobs due to precision issues.
    /// </remarks>
    public static bool KnobInt(string label, ref int value, int vMin, int vMax, float speed = 0.0f,
        string format = "%i", KnobVariant variant = KnobVariant.Tick, float size = 0.0f,
        ImGuiKnobFlags flags = 0, int steps = 10, float angleMin = -1.0f, float angleMax = -1.0f)
    {
        float floatValue = value;
        bool changed = Knob(label, ref floatValue, vMin, vMax, speed, format, variant, size, flags, steps, angleMin, angleMax);
        value = (int)floatValue;
        return changed;
    }
}
