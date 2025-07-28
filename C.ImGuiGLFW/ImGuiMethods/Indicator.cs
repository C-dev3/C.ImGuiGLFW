namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    private const float ProgressBarRatio = 0.7f;

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
}
