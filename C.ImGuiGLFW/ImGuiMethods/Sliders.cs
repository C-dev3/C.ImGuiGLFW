namespace C.ImGuiGLFW.ImGuiMethods;
public static partial class ImGuiC
{
    public static bool SliderUInt(string label, ref uint v, int vMax, int vMin, string format, ImGuiSliderFlags flags)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format, flags);
        if (ret) v = (uint)temp;
        return ret;
    }

    public static bool SliderUInt(string label, ref uint v, int vMax, int vMin, string format)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format);
        if (ret) v = (uint)temp;
        return ret;
    }

    public static bool SliderUInt(string label, ref uint v, int vMax, int vMin = 0)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax);
        if (ret) v = (uint)temp;
        return ret;
    }

    public static bool SliderUShort(string label, ref ushort v, int vMax, int vMin, string format, ImGuiSliderFlags flags)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        if (vMax > 65535) vMax = 65535;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format, flags);
        if (ret) v = (ushort)temp;
        return ret;
    }

    public static bool SliderUShort(string label, ref ushort v, int vMax, int vMin, string format)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        if (vMax > 65535) vMax = 65535;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format);
        if (ret) v = (ushort)temp;
        return ret;
    }

    public static bool SliderUShort(string label, ref ushort v, int vMax, int vMin = 0)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        if (vMax > 65535) vMax = 65535;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax);
        if (ret) v = (ushort)temp;
        return ret;
    }
    public static bool SliderShort(string label, ref short v, int vMax, int vMin, string format, ImGuiSliderFlags flags)
    {
        var temp = (int)v;
        if (vMin < -32768) vMin = -32768;
        if (vMax > 32767) vMax = 32767;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format, flags);
        if (ret) v = (short)temp;
        return ret;
    }

    public static bool SliderShort(string label, ref short v, int vMax, int vMin, string format)
    {
        var temp = (int)v;
        if (vMin < -32768) vMin = -32768;
        if (vMax > 32767) vMax = 32767;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format);
        if (ret) v = (short)temp;
        return ret;
    }

    public static bool SliderShort(string label, ref short v, int vMax, int vMin = -32768)
    {
        var temp = (int)v;
        if (vMin < -32768) vMin = -32768;
        if (vMax > 32767) vMax = 32767;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax);
        if (ret) v = (short)temp;
        return ret;
    }

    public static bool SliderByte(string label, ref byte v, int vMax, int vMin, string format, ImGuiSliderFlags flags)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        if (vMax > 255) vMax = 255;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format, flags);
        if (ret) v = (byte)temp;
        return ret;
    }

    public static bool SliderByte(string label, ref byte v, int vMax, int vMin, string format)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        if (vMax > 255) vMax = 255;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format);
        if (ret) v = (byte)temp;
        return ret;
    }

    public static bool SliderByte(string label, ref byte v, int vMax, int vMin = 0)
    {
        var temp = (int)v;
        if (vMin < 0) vMin = 0;
        if (vMax > 255) vMax = 255;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax);
        if (ret) v = (byte)temp;
        return ret;
    }

    public static bool SliderSByte(string label, ref sbyte v, int vMax, int vMin, string format, ImGuiSliderFlags flags)
    {
        var temp = (int)v;
        if (vMin < -128) vMin = -128;
        if (vMax > 127) vMax = 127;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format, flags);
        if (ret) v = (sbyte)temp;
        return ret;
    }

    public static bool SliderSByte(string label, ref sbyte v, int vMax, int vMin, string format)
    {
        var temp = (int)v;
        if (vMin < -128) vMin = -128;
        if (vMax > 127) vMax = 127;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax, format);
        if (ret) v = (sbyte)temp;
        return ret;
    }

    public static bool SliderSByte(string label, ref sbyte v, int vMax, int vMin = -128)
    {
        var temp = (int)v;
        if (vMin < -128) vMin = -128;
        if (vMax > 127) vMax = 127;
        bool ret = ImGui.SliderInt(label, ref temp, vMin, vMax);
        if (ret) v = (sbyte)temp;
        return ret;
    }
}
