using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Text(string text) => ImGui.Text(text);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Text(Vector4 color, string text) => ImGui.TextColored(color, text);

    public static void TextCopy(string text)
    {
        ImGui.Text(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void TextCopy(Vector4 color, string text)
    {
        Text(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void TextWrapped(string text)
    {
        ImGui.PushTextWrapPos(0);
        Text(text);
        ImGui.PopTextWrapPos();
    }

    public static void TextWrapped(Vector4 color, string text)
    {
        ImGui.PushTextWrapPos(0);
        Text(color, text);
        ImGui.PopTextWrapPos();
    }

    public static void TextWrappedCopy(string text)
    {
        TextWrapped(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void TextWrappedCopy(Vector4 color, string text)
    {
        TextWrapped(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void TextWrappedCopy(Vector4 color, string text, ImGuiMouseButton mouseButton)
    {
        TextWrapped(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text, mouseButton);
    }

    public static void TextUnformatted(string text) => ImGui.TextUnformatted(text);

    public static void TextUnformatted(Vector4 color, string text)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color);
        ImGui.TextUnformatted(text);
        ImGui.PopStyleColor();
    }

    public static void TextUnformattedCopy(string text)
    {
        ImGui.TextUnformatted(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void TextUnformattedCopy(Vector4 color, string text)
    {
        TextUnformatted(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void TextUnformattedWrapped(string text)
    {
        ImGui.PushTextWrapPos(0);
        TextUnformatted(text);
        ImGui.PopTextWrapPos();
    }

    public static void TextUnformattedWrapped(Vector4 color, string text)
    {
        ImGui.PushTextWrapPos(0);
        TextUnformatted(color, text);
        ImGui.PopTextWrapPos();
    }

    public static void TextUnformattedWrappedCopy(string text)
    {
        TextUnformattedWrapped(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void TextUnformattedWrappedCopy(Vector4 color, string text)
    {
        TextUnformattedWrapped(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void BulletText(string text) => ImGui.BulletText(text);

    public static void BulletText(Vector4 color, string text)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color);
        ImGui.BulletText(text);
        ImGui.PopStyleColor();
    }

    public static void BulletTextCopy(string text)
    {
        ImGui.BulletText(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    public static void BulletTextCopy(Vector4 color, string text)
    {
        BulletText(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }
}
