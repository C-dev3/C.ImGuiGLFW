namespace C.ImGuiGLFW.ImGuiMethods;
public static partial class ImGuiC
{
    public static bool InputUInt(string label, ref uint v)
    {
        var text = v.ToString();
        if (ImGui.InputText(label, ref text, 16) && uint.TryParse(text, out var num))
        {
            v = num;
            return true;
        }
        return false;
    }

    public static bool InputUShort(string label, ref ushort v)
    {
        var text = v.ToString();
        if (ImGui.InputText(label, ref text, 8) && ushort.TryParse(text, out var num))
        {
            v = num;
            return true;
        }
        return false;
    }

    public static bool InputShort(string label, ref short v)
    {
        var text = v.ToString();
        if (ImGui.InputText(label, ref text, 8) && short.TryParse(text, out var num))
        {
            v = num;
            return true;
        }
        return false;
    }

    public static bool InputByte(string label, ref byte v)
    {
        var text = v.ToString();
        if (ImGui.InputText(label, ref text, 4) && byte.TryParse(text, out var num))
        {
            v = num;
            return true;
        }
        return false;
    }

    public static bool InputSByte(string label, ref sbyte v)
    {
        var text = v.ToString();
        if (ImGui.InputText(label, ref text, 4) && sbyte.TryParse(text, out var num))
        {
            v = num;
            return true;
        }
        return false;
    }
}
