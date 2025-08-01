namespace C.ImGuiGLFW.ImGuiMethods;
public static partial class ImGuiC
{
    /// <summary>
    /// Creates a draggable slider for a uint value.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the uint value to modify.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value to a minimum of 0 and maximum of int.MaxValue.</remarks>
    public static bool DragUInt(string label, ref uint v)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin: 0))
        {
            v = (uint)Math.Clamp(temp, uint.MinValue, int.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a uint value with a display format and flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the uint value to modify.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value to a minimum of 0 and maximum of int.MaxValue.</remarks>
    public static bool DragUInt(string label, ref uint v, string format, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin: 0, format, flags))
        {
            v = (uint)Math.Clamp(temp, uint.MinValue, int.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a uint value with a speed and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the uint value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value to a minimum of 0 and maximum of int.MaxValue.</remarks>
    public static bool DragUInt(string label, ref uint v, float vSpeed, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin: 0, flags))
        {
            v = (uint)Math.Clamp(temp, uint.MinValue, int.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a uint value with minimum and maximum limits and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the uint value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUInt(string label, ref uint v, int vMax, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vMin, vMax, flags))
        {
            v = (uint)Math.Clamp(temp, uint.MinValue, int.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a uint value with specified format, minimum and maximum limits, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the uint value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUInt(string label, ref uint v, int vMax, string format, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vMin, vMax, format, flags))
        {
            v = (uint)Math.Clamp(temp, uint.MinValue, int.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a uint value with speed, minimum and maximum limits, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the uint value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUInt(string label, ref uint v, float vSpeed, int vMax, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, flags))
        {
            v = (uint)Math.Clamp(temp, uint.MinValue, int.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a uint value with speed, minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the uint value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUInt(string label, ref uint v, float vSpeed, int vMax, string format, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, format, flags))
        {
            v = (uint)Math.Clamp(temp, uint.MinValue, int.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a ushort value.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the ushort value to modify.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between ushort.MinValue and ushort.MaxValue.</remarks>
    public static bool DragUShort(string label, ref ushort v)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin: 0))
        {
            v = (ushort)Math.Clamp(temp, ushort.MinValue, ushort.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a ushort value with display format and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the ushort value to modify.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between ushort.MinValue and ushort.MaxValue.</remarks>
    public static bool DragUShort(string label, ref ushort v, string format, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin: 0, format, flags))
        {
            v = (ushort)Math.Clamp(temp, ushort.MinValue, ushort.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a ushort value with speed and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the ushort value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between ushort.MinValue and ushort.MaxValue.</remarks>
    public static bool DragUShort(string label, ref ushort v, float vSpeed, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin: 0, flags))
        {
            v = (ushort)Math.Clamp(temp, ushort.MinValue, ushort.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a ushort value with minimum and maximum limits and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the ushort value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUShort(string label, ref ushort v, int vMax, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vMin, vMax, flags))
        {
            v = (ushort)Math.Clamp(temp, ushort.MinValue, ushort.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a ushort value with minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the ushort value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUShort(string label, ref ushort v, int vMax, string format, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vMin, vMax, format, flags))
        {
            v = (ushort)Math.Clamp(temp, ushort.MinValue, ushort.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a ushort value with speed, minimum and maximum limits, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the ushort value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUShort(string label, ref ushort v, float vSpeed, int vMax, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, flags))
        {
            v = (ushort)Math.Clamp(temp, uint.MinValue, ushort.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a ushort value with speed, minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the ushort value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragUShort(string label, ref ushort v, float vSpeed, int vMax, string format, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, format, flags))
        {
            v = (ushort)Math.Clamp(temp, uint.MinValue, ushort.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a short value.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the short value to modify.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between short.MinValue and short.MaxValue.</remarks>
    public static bool DragShort(string label, ref short v)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp))
        {
            v = (short)Math.Clamp(temp, short.MinValue, short.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a short value with display format and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the short value to modify.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between short.MinValue and short.MaxValue.</remarks>
    public static bool DragShort(string label, ref short v, string format, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, format: format, flags: flags))
        {
            v = (short)Math.Clamp(temp, short.MinValue, short.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a short value with speed and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the short value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between short.MinValue and short.MaxValue.</remarks>
    public static bool DragShort(string label, ref short v, float vSpeed, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, flags: flags))
        {
            v = (short)Math.Clamp(temp, short.MinValue, short.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a short value with minimum and maximum limits and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the short value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is short.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between short.MinValue and short.MaxValue.</remarks>
    public static bool DragShort(string label, ref short v, int vMax, int vMin = short.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin, vMax, flags))
        {
            v = (short)Math.Clamp(temp, short.MinValue, short.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a short value with minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the short value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is short.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between short.MinValue and short.MaxValue.</remarks>
    public static bool DragShort(string label, ref short v, int vMax, string format, int vMin = short.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin, vMax, format, flags))
        {
            v = (short)Math.Clamp(temp, short.MinValue, short.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a short value with speed, minimum and maximum limits, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the short value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is short.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between short.MinValue and short.MaxValue.</remarks>
    public static bool DragShort(string label, ref short v, float vSpeed, int vMax, int vMin = short.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, flags))
        {
            v = (short)Math.Clamp(temp, short.MinValue, short.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a short value with speed, minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the short value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is short.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between short.MinValue and short.MaxValue.</remarks>
    public static bool DragShort(string label, ref short v, float vSpeed, int vMax, string format, int vMin = short.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, format, flags))
        {
            v = (short)Math.Clamp(temp, short.MinValue, short.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a byte value.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the byte value to modify.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between byte.MinValue and byte.MaxValue.</remarks>
    public static bool DragByte(string label, ref byte v)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin: 0))
        {
            v = (byte)Math.Clamp(temp, byte.MinValue, byte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a byte value with display format and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the byte value to modify.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between byte.MinValue and byte.MaxValue.</remarks>
    public static bool DragByte(string label, ref byte v, string format, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin: 0, format, flags))
        {
            v = (byte)Math.Clamp(temp, byte.MinValue, byte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a byte value with speed and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the byte value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between byte.MinValue and byte.MaxValue.</remarks>
    public static bool DragByte(string label, ref byte v, float vSpeed, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin: 0, flags))
        {
            v = (byte)Math.Clamp(temp, byte.MinValue, byte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a byte value with minimum and maximum limits and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the byte value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragByte(string label, ref byte v, int vMax, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vMin, vMax, flags))
        {
            v = (byte)Math.Clamp(temp, byte.MinValue, byte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a byte value with minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the byte value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragByte(string label, ref byte v, int vMax, string format, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vMin, vMax, format, flags))
        {
            v = (byte)Math.Clamp(temp, byte.MinValue, byte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a byte value with speed, minimum and maximum limits, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the byte value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragByte(string label, ref byte v, float vSpeed, int vMax, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, flags))
        {
            v = (byte)Math.Clamp(temp, byte.MinValue, byte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for a byte value with speed, minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the byte value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is 0).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Minimum value is clamped to 0.</remarks>
    public static bool DragByte(string label, ref byte v, float vSpeed, int vMax, string format, int vMin = 0, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        vMin = Math.Max(0, vMin);
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, format, flags))
        {
            v = (byte)Math.Clamp(temp, byte.MinValue, byte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for an sbyte value.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the sbyte value to modify.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between sbyte.MinValue and sbyte.MaxValue.</remarks>
    public static bool DragSByte(string label, ref sbyte v)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp))
        {
            v = (sbyte)Math.Clamp(temp, sbyte.MinValue, sbyte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for an sbyte value with display format and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the sbyte value to modify.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between sbyte.MinValue and sbyte.MaxValue.</remarks>
    public static bool DragSByte(string label, ref sbyte v, string format, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, format: format, flags: flags))
        {
            v = (sbyte)Math.Clamp(temp, sbyte.MinValue, sbyte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for an sbyte value with speed and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the sbyte value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between sbyte.MinValue and sbyte.MaxValue.</remarks>
    public static bool DragSByte(string label, ref sbyte v, float vSpeed, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, flags: flags))
        {
            v = (sbyte)Math.Clamp(temp, sbyte.MinValue, sbyte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for an sbyte value with minimum and maximum limits and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the sbyte value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is sbyte.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between sbyte.MinValue and sbyte.MaxValue.</remarks>
    public static bool DragSByte(string label, ref sbyte v, int vMax, int vMin = sbyte.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin, vMax, flags))
        {
            v = (sbyte)Math.Clamp(temp, sbyte.MinValue, sbyte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for an sbyte value with minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the sbyte value to modify.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is sbyte.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between sbyte.MinValue and sbyte.MaxValue.</remarks>
    public static bool DragSByte(string label, ref sbyte v, int vMax, string format, int vMin = sbyte.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vMin, vMax, format, flags))
        {
            v = (sbyte)Math.Clamp(temp, sbyte.MinValue, sbyte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for an sbyte value with speed, minimum and maximum limits, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the sbyte value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="vMin">The minimum allowed value (default is sbyte.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between sbyte.MinValue and sbyte.MaxValue.</remarks>
    public static bool DragSByte(string label, ref sbyte v, float vSpeed, int vMax, int vMin = sbyte.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, flags))
        {
            v = (sbyte)Math.Clamp(temp, sbyte.MinValue, sbyte.MaxValue);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a draggable slider for an sbyte value with speed, minimum and maximum limits, display format, and optional flags.
    /// </summary>
    /// <param name="label">The label of the slider.</param>
    /// <param name="v">Reference to the sbyte value to modify.</param>
    /// <param name="vSpeed">The speed of the drag operation.</param>
    /// <param name="vMax">The maximum allowed value.</param>
    /// <param name="format">The display format string.</param>
    /// <param name="vMin">The minimum allowed value (default is sbyte.MinValue).</param>
    /// <param name="flags">Slider behavior flags.</param>
    /// <returns>True if the value was changed; otherwise false.</returns>
    /// <remarks>Clamps the value between sbyte.MinValue and sbyte.MaxValue.</remarks>
    public static bool DragSByte(string label, ref sbyte v, float vSpeed, int vMax, string format, int vMin = sbyte.MinValue, ImGuiSliderFlags flags = ImGuiSliderFlags.None)
    {
        var temp = (int)v;
        if (ImGui.DragInt(label, ref temp, vSpeed, vMin, vMax, format, flags))
        {
            v = (sbyte)Math.Clamp(temp, sbyte.MinValue, sbyte.MaxValue);
            return true;
        }
        return false;
    }
}
