namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    private const float ProgressBarRatio = 0.7f;

    /// <summary>
    /// Displays a buffering-style progress bar with animated dots and returns true when clicked.
    /// </summary>
    /// <param name="label">Unique label ID.</param>
    /// <param name="value">Progress value from 0.0 to 1.0.</param>
    /// <param name="sizeArg">Total size of the progress bar.</param>
    /// <param name="bgCol">Optional background color (defaults to Button color).</param>
    /// <param name="fgCol">Optional foreground (progress) color (defaults to ButtonHovered color).</param>
    /// <returns>True if the invisible button is clicked.</returns>
    /// <remarks>
    /// Displays a progress bar with a fixed-width region for animated circles indicating activity.
    /// Use this for tasks with visible buffering state.
    /// </remarks>
    public static bool BufferingBar(string label, float value, Vector2 sizeArg, uint? bgCol = null, uint? fgCol = null)
    {
        var style = ImGui.GetStyle();
        var size = new Vector2(sizeArg.X - style.FramePadding.X * 2, sizeArg.Y);

        bool ret = ImGui.InvisibleButton(label, size);

        var pos = ImGui.GetItemRectMin();
        var drawList = ImGui.GetWindowDrawList();
        var bgColor = bgCol ?? ImGui.GetColorU32(ImGuiCol.Button);
        var fgColor = fgCol ?? ImGui.GetColorU32(ImGuiCol.ButtonHovered);
        var progressBarWidth = size.X * ProgressBarRatio;
        var progressBarEnd = new Vector2(pos.X + progressBarWidth, pos.Y + size.Y);
        var progressFilledEnd = new Vector2(pos.X + progressBarWidth * value, pos.Y + size.Y);
        drawList.AddRectFilled(pos, progressBarEnd, bgColor);
        drawList.AddRectFilled(pos, progressFilledEnd, fgColor);
        DrawAnimatedCircles(drawList, pos, size, progressBarWidth, bgColor);

        return ret;
    }

    /// <summary>
    /// Displays a rounded buffering-style progress bar with animated dots and returns true when clicked.
    /// </summary>
    /// <param name="label">Unique label ID.</param>
    /// <param name="value">Progress value from 0.0 to 1.0.</param>
    /// <param name="sizeArg">Total size of the progress bar.</param>
    /// <param name="bgCol">Optional background color.</param>
    /// <param name="fgCol">Optional foreground (progress) color.</param>
    /// <param name="rounding">Corner rounding radius.</param>
    /// <returns>True if the invisible button is clicked.</returns>
    /// <remarks>
    /// Similar to <c>BufferingBar</c> but with rounded corners. Rounding is adjusted dynamically when progress is small.
    /// </remarks>
    public static bool BufferingBarRounded(string label, float value, Vector2 sizeArg, uint? bgCol = null, uint? fgCol = null, float rounding = 4.0f)
    {
        var style = ImGui.GetStyle();
        var size = new Vector2(sizeArg.X - style.FramePadding.X * 2, sizeArg.Y);
        bool ret = ImGui.InvisibleButton(label, size);
        var pos = ImGui.GetItemRectMin();
        var drawList = ImGui.GetWindowDrawList();
        var bgColor = bgCol ?? ImGui.GetColorU32(ImGuiCol.Button);
        var fgColor = fgCol ?? ImGui.GetColorU32(ImGuiCol.ButtonHovered);
        var progressBarWidth = size.X * ProgressBarRatio;
        var progressBarEnd = new Vector2(pos.X + progressBarWidth, pos.Y + size.Y);
        var progressFilledEnd = new Vector2(pos.X + progressBarWidth * value, pos.Y + size.Y);
        drawList.AddRectFilled(pos, progressBarEnd, bgColor, rounding);
        float progressRounding = rounding;
        if (value < 1.0f && progressFilledEnd.X < pos.X + rounding * 2)
        {
            progressRounding = Math.Min(rounding, (progressFilledEnd.X - pos.X) / 2.0f);
        }

        drawList.AddRectFilled(pos, progressFilledEnd, fgColor, progressRounding);

        DrawAnimatedCircles(drawList, pos, size, progressBarWidth, bgColor);
        return ret;
    }

    /// <summary>
    /// Displays a linear progress bar and returns true when clicked.
    /// </summary>
    /// <param name="label">Unique label ID.</param>
    /// <param name="value">Progress value from 0.0 to 1.0.</param>
    /// <param name="size">Size of the progress bar.</param>
    /// <param name="bgCol">Optional background color.</param>
    /// <param name="fgCol">Optional foreground (progress) color.</param>
    /// <returns>True if the invisible button is clicked.</returns>
    /// <remarks>
    /// Basic determinate progress bar without animation or rounded edges.
    /// </remarks>
    public static bool ProgressBar(string label, float value, Vector2 size, uint? bgCol = null, uint? fgCol = null)
    {
        bool ret = ImGui.InvisibleButton(label, size);

        var pos = ImGui.GetItemRectMin();
        var drawList = ImGui.GetWindowDrawList();
        var bgColor = bgCol ?? ImGui.GetColorU32(ImGuiCol.Button);
        var fgColor = fgCol ?? ImGui.GetColorU32(ImGuiCol.ButtonHovered);
        var progressBarEnd = new Vector2(pos.X + size.X, pos.Y + size.Y);
        var progressFilledEnd = new Vector2(pos.X + size.X * value, pos.Y + size.Y);
        drawList.AddRectFilled(pos, progressBarEnd, bgColor);
        drawList.AddRectFilled(pos, progressFilledEnd, fgColor);
        return ret;
    }

    /// <summary>
    /// Displays a rounded linear progress bar and returns true when clicked.
    /// </summary>
    /// <param name="label">Unique label ID.</param>
    /// <param name="value">Progress value from 0.0 to 1.0.</param>
    /// <param name="size">Size of the progress bar.</param>
    /// <param name="bgCol">Optional background color.</param>
    /// <param name="fgCol">Optional foreground (progress) color.</param>
    /// <param name="rounding">Corner rounding radius.</param>
    /// <returns>True if the invisible button is clicked.</returns>
    /// <remarks>
    /// Visually enhanced version of <c>ProgressBar</c> with smooth rounded corners.
    /// </remarks>
    public static bool ProgressBarRounded(string label, float value, Vector2 size, uint? bgCol = null, uint? fgCol = null, float rounding = 4.0f)
    {
        bool ret = ImGui.InvisibleButton(label, size);
        var pos = ImGui.GetItemRectMin();
        var drawList = ImGui.GetWindowDrawList();
        var bgColor = bgCol ?? ImGui.GetColorU32(ImGuiCol.Button);
        var fgColor = fgCol ?? ImGui.GetColorU32(ImGuiCol.ButtonHovered);
        var progressBarEnd = new Vector2(pos.X + size.X, pos.Y + size.Y);
        var progressFilledEnd = new Vector2(pos.X + size.X * value, pos.Y + size.Y);
        drawList.AddRectFilled(pos, progressBarEnd, bgColor, rounding);
        float progressRounding = rounding;
        if (value < 1.0f && progressFilledEnd.X < pos.X + rounding * 2)
        {
            progressRounding = Math.Min(rounding, (progressFilledEnd.X - pos.X) / 2.0f);
        }

        drawList.AddRectFilled(pos, progressFilledEnd, fgColor, progressRounding);

        return ret;
    }

    private static void DrawAnimatedCircles(ImDrawListPtr drawList, Vector2 pos, Vector2 size, float progressBarWidth, uint bgColor)
    {
        var circleWidth = size.X - progressBarWidth;
        var circleRadius = size.Y * 0.5f;
        var circleY = pos.Y + circleRadius;
        var circleEndX = pos.X + size.X;

        var time = (float)ImGui.GetTime();
        const float Speed = 1.5f;
        var offsets = new float[3];
        for (int i = 0; i < 3; i++)
        {
            var phase = Speed * i / 3.0f;
            var normalizedTime = (time + phase) % Speed / Speed;
            offsets[i] = (circleWidth + circleRadius) * normalizedTime;
        }

        for (int i = 0; i < 3; i++)
        {
            var circleX = circleEndX - offsets[i];
            drawList.AddCircleFilled(new Vector2(circleX, circleY), circleRadius, bgColor);
        }
    }

    /// <summary>
    /// Displays a rotating spinner animation and returns true when clicked.
    /// </summary>
    /// <param name="label">Unique label ID.</param>
    /// <param name="radius">Spinner radius.</param>
    /// <param name="thickness">Optional line thickness.</param>
    /// <param name="color">Optional color.</param>
    /// <returns>True if the invisible button is clicked.</returns>
    /// <remarks>
    /// Useful for indicating indeterminate background operations.
    /// </remarks>
    public static bool Spinner(string label, float radius, float? thickness = null, uint? color = null)
    {
        var style = ImGui.GetStyle();
        Vector2 size = new(radius * 2, (radius + style.FramePadding.Y) * 2);
        bool ret = ImGui.InvisibleButton(label, size);
        Vector2 pos = ImGui.GetItemRectMin();
        var drawList = ImGui.GetWindowDrawList();

        const int numSegments = 30;
        float time = (float)ImGui.GetTime();
        float start = MathF.Abs(MathF.Sin(time * 1.8f) * (numSegments - 5));

        float aMin = (float)(MathF.PI * 2.0f * start / numSegments);
        float aMax = (float)(MathF.PI * 2.0f * (numSegments - 3) / numSegments);

        Vector2 center = new(pos.X + radius, pos.Y + radius + style.FramePadding.Y);
        Vector2[] points = new Vector2[numSegments];
        for (int i = 0; i < numSegments; i++)
        {
            float a = aMin + ((float)i / numSegments) * (aMax - aMin);
            points[i] = new Vector2(
                center.X + MathF.Cos(a + time * 8f) * radius,
                center.Y + MathF.Sin(a + time * 8f) * radius
            );
        }
        drawList.AddPolyline(ref points[0], numSegments, color ?? ImGui.GetColorU32(ImGuiCol.ButtonHovered), ImDrawFlags.None, thickness ?? 6f);
        return ret;
    }

    /// <summary>
    /// Displays a loading indicator composed of animated circles and returns true when clicked.
    /// </summary>
    /// <param name="indicatorRadius">Overall radius of the circular loading indicator.</param>
    /// <param name="mainColor">Color of the most prominent circle.</param>
    /// <param name="backdropColor">Color of the background circles.</param>
    /// <param name="circleCount">Total number of animated circles.</param>
    /// <param name="speed">Animation speed multiplier.</param>
    /// <returns>True if the item is clicked.</returns>
    /// <remarks>
    /// This indicator provides a dynamic animation effect suitable for async or loading states.
    /// </remarks>
    public static bool LoadingCircle(float indicatorRadius, Vector4? mainColor = null, Vector4? backdropColor = null, int circleCount = 12, float speed = 5f)
    {
        var drawList = ImGui.GetWindowDrawList();
        var cursorPos = ImGui.GetCursorScreenPos();
        const float circleRadiusRatio = 1f / 15f;
        float circleRadius = indicatorRadius * circleRadiusRatio;
        float updatedIndicatorRadius = indicatorRadius - 4f * circleRadius;
        float degreeOffset = 2f * MathF.PI / circleCount;
        float currentTime = (float)ImGui.GetTime() * speed;
        var resolvedMainColor = mainColor ?? ImGui.ColorConvertU32ToFloat4(ImGui.GetColorU32(ImGuiCol.ButtonHovered));
        var resolvedBackdropColor = backdropColor ?? ImGui.ColorConvertU32ToFloat4(ImGui.GetColorU32(ImGuiCol.ButtonHovered));
        var colorDiff = new Vector4(
            resolvedMainColor.X - resolvedBackdropColor.X,
            resolvedMainColor.Y - resolvedBackdropColor.Y,
            resolvedMainColor.Z - resolvedBackdropColor.Z,
            0f
        );
        var baseCenter = new Vector2(
            cursorPos.X + indicatorRadius,
            cursorPos.Y + indicatorRadius
        );

        ImGui.Dummy(new Vector2(indicatorRadius * 2f, indicatorRadius * 2f));
        for (int i = 0; i < circleCount; i++)
        {
            float angle = degreeOffset * i;
            float x = updatedIndicatorRadius * MathF.Sin(angle);
            float y = updatedIndicatorRadius * MathF.Cos(angle);

            float growth = MathF.Max(0f, MathF.Sin(currentTime - angle));
            var color = new Vector4(
                resolvedBackdropColor.X + colorDiff.X * growth,
                resolvedBackdropColor.Y + colorDiff.Y * growth,
                resolvedBackdropColor.Z + colorDiff.Z * growth,
                1f
            );

            var center = new Vector2(baseCenter.X + x, baseCenter.Y - y);
            float radius = circleRadius * (1f + growth);

            drawList.AddCircleFilled(center, radius, ImGui.ColorConvertFloat4ToU32(color));
        }

        return ImGui.IsItemClicked();
    }

    /// <summary>
    /// Draws a simple, centered linear progress bar.
    /// </summary>
    /// <param name="progress">Progress value from 0.0 to 1.0.</param>
    /// <param name="size">Optional size (defaults to 200x4).</param>
    /// <param name="bgCol">Optional background color.</param>
    /// <param name="fgCol">Optional foreground (progress) color.</param>
    /// <remarks>
    /// Use this method to display a minimal and stylized horizontal progress bar.
    /// </remarks>
    public static void LinearProgressBar(float progress, Vector2 size = default, uint? bgCol = null, uint? fgCol = null)
    {
        if (size == default) size = new Vector2(200, 4);

        var pos = ImGui.GetCursorScreenPos();
        var drawList = ImGui.GetWindowDrawList();

        // Background
        var bgColor = bgCol ?? ImGui.GetColorU32(ImGuiCol.Button);
        drawList.AddRectFilled(pos, pos + size, bgColor, size.Y * 0.5f);

        // Progress
        var progressWidth = size.X * Math.Clamp(progress, 0f, 1f);
        var progressColor = fgCol ?? ImGui.GetColorU32(ImGuiCol.ButtonHovered);
        drawList.AddRectFilled(pos, pos + new Vector2(progressWidth, size.Y), progressColor, size.Y * 0.5f);

        ImGui.Dummy(size);
    }

    /// <summary>
    /// Draws a circular progress indicator with optional determinate or indeterminate mode.
    /// </summary>
    /// <param name="progress">Progress value (0.0 to 1.0). Pass -1 for indeterminate mode.</param>
    /// <param name="radius">Radius of the circular progress indicator.</param>
    /// <param name="bgCol">Optional background circle color.</param>
    /// <param name="fgCol">Optional foreground (progress arc) color.</param>
    /// <remarks>
    /// Provides a visual representation of progress in a circular form.
    /// </remarks>
    public static void CircularProgress(float progress = -1f, float radius = 20f, uint? bgCol = null, uint? fgCol = null)
    {
        var pos = ImGui.GetCursorScreenPos();
        var center = pos + new Vector2(radius);
        var drawList = ImGui.GetWindowDrawList();

        // Background circle
        var bgColor = bgCol ?? ImGui.GetColorU32(ImGuiCol.Button);
        drawList.AddCircle(center, radius, bgColor, 0, 3.0f);

        // Progress arc
        var progressColor = fgCol ?? ImGui.GetColorU32(ImGuiCol.ButtonHovered);
        if (progress >= 0)
        {
            // Determinate
            var angle = progress * 2 * MathF.PI;
            drawList.PathArcTo(center, radius, -MathF.PI / 2, -MathF.PI / 2 + angle, 32);
            drawList.PathStroke(progressColor, ImDrawFlags.None, 3.0f);
        }
        else
        {
            // Indeterminate - would need time-based animation
            var time = (float)ImGui.GetTime();
            var startAngle = time * 2;
            var endAngle = startAngle + MathF.PI;
            drawList.PathArcTo(center, radius, startAngle, endAngle, 32);
            drawList.PathStroke(progressColor, ImDrawFlags.None, 3.0f);
        }

        ImGui.Dummy(new Vector2(radius * 2, radius * 2));
    }

    /// <summary>
    /// Renders a customizable progress bar with gradient colors and optional overcap display.
    /// </summary>
    /// <param name="label">The text label displayed above the progress bar.</param>
    /// <param name="fraction">The progress value. Values 0-1 show normal progress. Values above 1 display overcap color overlay.</param>
    /// <param name="size">The size of the progress bar. If default, uses available content region width with 10px height.</param>
    /// <param name="bgColor">The background color in ABGR format. Default is dark gray (0xFF262626).</param>
    /// <param name="color1">The starting gradient color in ABGR format. Default is blue (0xFFFF9933).</param>
    /// <param name="color2">The ending gradient color in ABGR format. Default is green (0xFFCCFF99).</param>
    /// <param name="overcapColor">The color used for progress beyond 100% in ABGR format. Default is gold (0xFF00D6FF).</param>
    /// <remarks>
    /// The progress bar uses a horizontal gradient from color1 to color2 for the filled portion.
    /// When fraction exceeds 1.0, the bar fills completely with the gradient, then overlays
    /// the overcap portion (from 0% to the excess amount) with the overcapColor.
    /// All color values use ABGR (Alpha-Blue-Green-Red) format as required by ImGui.
    /// </remarks>
    public static void GradientProgressBar(string label, float fraction, Vector2 size = default, uint bgColor = 0xFF262626, uint color1 = 0xFFFF9933, uint color2 = 0xFFCCFF99, uint overcapColor = 0xFF00D6FF)
    {
        if (size == default)
        {
            size = new Vector2(GetContentRegionWidthAvail(), 10f);
        }

        ImGui.Text(label);

        var pos = ImGui.GetCursorScreenPos();
        var drawList = ImGui.GetWindowDrawList();

        var barStart = pos;
        var barEnd = new Vector2(pos.X + size.X, pos.Y + size.Y);

        drawList.AddRectFilled(barStart, barEnd, bgColor);

        if (fraction <= 1)
        {
            float fr = Math.Clamp(fraction, 0, 1);
            float filledWidth = size.X * fr;

            if (filledWidth > 0f)
            {
                var filledEnd = new Vector2(pos.X + filledWidth, pos.Y + size.Y);

                drawList.AddRectFilledMultiColor(
                    barStart,
                    filledEnd,
                    color1,
                    color2,
                    color2,
                    color1);
            }
        }
        else // overcapped
        {
            var filledEnd = new Vector2(pos.X + size.X, pos.Y + size.Y);

            drawList.AddRectFilledMultiColor(
                    barStart,
                    filledEnd,
                    color1,
                    color2,
                    color2,
                    color1);

            float overcapFraction = Math.Clamp(fraction - 1, 0, 1);
            float overcapWidth = size.X * overcapFraction;

            if(overcapWidth > 0)
            {
                var overcapEnd = new Vector2(pos.X + overcapWidth, pos.Y + size.Y);
                drawList.AddRectFilled(
                    barStart,
                    overcapEnd,
                    overcapColor
                );
            }
        }

        ImGui.Dummy(new Vector2(size.X, size.Y + 5));
    }
}
