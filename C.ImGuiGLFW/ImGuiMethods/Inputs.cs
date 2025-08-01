namespace C.ImGuiGLFW.ImGuiMethods;
public static partial class ImGuiC
{
    /// <summary>
    /// Displays an input text box for a <see cref="uint"/> value, allowing user input and parsing the result.
    /// </summary>
    /// <param name="label">The label displayed next to the input box.</param>
    /// <param name="v">Reference to the <see cref="uint"/> value to edit.</param>
    /// <returns>True if the value was changed and parsed successfully; otherwise, false.</returns>
    /// <remarks>
    /// Uses ImGui's InputText to allow editing the value as text with a buffer size of 16 characters.
    /// The input is parsed back to <see cref="uint"/> on success.
    /// </remarks>
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

    /// <summary>
    /// Displays an input text box for a <see cref="ushort"/> value, allowing user input and parsing the result.
    /// </summary>
    /// <param name="label">The label displayed next to the input box.</param>
    /// <param name="v">Reference to the <see cref="ushort"/> value to edit.</param>
    /// <returns>True if the value was changed and parsed successfully; otherwise, false.</returns>
    /// <remarks>
    /// Uses ImGui's InputText to allow editing the value as text with a buffer size of 8 characters.
    /// The input is parsed back to <see cref="ushort"/> on success.
    /// </remarks>
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

    /// <summary>
    /// Displays an input text box for a <see cref="short"/> value, allowing user input and parsing the result.
    /// </summary>
    /// <param name="label">The label displayed next to the input box.</param>
    /// <param name="v">Reference to the <see cref="short"/> value to edit.</param>
    /// <returns>True if the value was changed and parsed successfully; otherwise, false.</returns>
    /// <remarks>
    /// Uses ImGui's InputText to allow editing the value as text with a buffer size of 8 characters.
    /// The input is parsed back to <see cref="short"/> on success.
    /// </remarks>
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

    /// <summary>
    /// Displays an input text box for a <see cref="byte"/> value, allowing user input and parsing the result.
    /// </summary>
    /// <param name="label">The label displayed next to the input box.</param>
    /// <param name="v">Reference to the <see cref="byte"/> value to edit.</param>
    /// <returns>True if the value was changed and parsed successfully; otherwise, false.</returns>
    /// <remarks>
    /// Uses ImGui's InputText to allow editing the value as text with a buffer size of 4 characters.
    /// The input is parsed back to <see cref="byte"/> on success.
    /// </remarks>
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

    /// <summary>
    /// Displays an input text box for an <see cref="sbyte"/> value, allowing user input and parsing the result.
    /// </summary>
    /// <param name="label">The label displayed next to the input box.</param>
    /// <param name="v">Reference to the <see cref="sbyte"/> value to edit.</param>
    /// <returns>True if the value was changed and parsed successfully; otherwise, false.</returns>
    /// <remarks>
    /// Uses ImGui's InputText to allow editing the value as text with a buffer size of 4 characters.
    /// The input is parsed back to <see cref="sbyte"/> on success.
    /// </remarks>
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
