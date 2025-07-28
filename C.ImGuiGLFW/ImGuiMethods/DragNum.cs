namespace C.ImGuiGLFW.ImGuiMethods;
public static partial class ImGuiC
{
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
