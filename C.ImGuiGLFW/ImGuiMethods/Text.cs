using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    /// <summary>
    /// Displays text using ImGui's default text rendering.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This is a simple wrapper around ImGui.Text() with aggressive inlining for performance.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Text(string text) => ImGui.Text(text);

    /// <summary>
    /// Displays colored text using ImGui's text rendering.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This is a wrapper around ImGui.TextColored() with aggressive inlining for performance.
    /// The color parameter should be in RGBA format where each component ranges from 0.0 to 1.0.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Text(Vector4 color, string text) => ImGui.TextColored(color, text);

    /// <summary>
    /// Displays text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// The mouse cursor changes to a hand when hovering over the text, indicating it's clickable.
    /// Clicking the text will copy it to the system clipboard.
    /// </remarks>
    public static void TextCopy(string text)
    {
        ImGui.Text(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays colored text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// Combines colored text rendering with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextCopy(Vector4 color, string text)
    {
        Text(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays text with automatic word wrapping.
    /// </summary>
    /// <param name="text">The text to display with wrapping.</param>
    /// <remarks>
    /// Uses ImGui's text wrapping functionality by pushing a wrap position of 0,
    /// which enables wrapping at the current content region width.
    /// </remarks>
    public static void TextWrapped(string text)
    {
        ImGui.PushTextWrapPos(0);
        Text(text);
        ImGui.PopTextWrapPos();
    }

    /// <summary>
    /// Displays colored text with automatic word wrapping.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display with wrapping.</param>
    /// <remarks>
    /// Combines colored text rendering with automatic word wrapping functionality.
    /// Wrapping occurs at the current content region boundaries.
    /// </remarks>
    public static void TextWrapped(Vector4 color, string text)
    {
        ImGui.PushTextWrapPos(0);
        Text(color, text);
        ImGui.PopTextWrapPos();
    }

    /// <summary>
    /// Displays wrapped text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display with wrapping and copy functionality.</param>
    /// <remarks>
    /// Combines text wrapping with clipboard copy functionality.
    /// The mouse cursor indicates clickability, and clicking copies the text.
    /// </remarks>
    public static void TextWrappedCopy(string text)
    {
        TextWrapped(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays colored wrapped text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display with wrapping and copy functionality.</param>
    /// <remarks>
    /// Combines colored text rendering, word wrapping, and clipboard copy functionality.
    /// Provides full text display and interaction capabilities in one method.
    /// </remarks>
    public static void TextWrappedCopy(Vector4 color, string text)
    {
        TextWrapped(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays colored wrapped text that can be copied to clipboard when clicked with a specific mouse button.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display with wrapping and copy functionality.</param>
    /// <param name="mouseButton">The specific mouse button that triggers the copy action.</param>
    /// <remarks>
    /// Allows customization of which mouse button triggers the clipboard copy action.
    /// Useful when you want to reserve left-click for other actions or prefer right-click copying.
    /// </remarks>
    public static void TextWrappedCopy(Vector4 color, string text, ImGuiMouseButton mouseButton)
    {
        TextWrapped(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text, mouseButton);
    }

    /// <summary>
    /// Displays unformatted text for better performance with large text blocks.
    /// </summary>
    /// <param name="text">The text to display without formatting.</param>
    /// <remarks>
    /// This is a wrapper around ImGui.TextUnformatted() with aggressive inlining.
    /// More efficient than regular Text() for large amounts of text as it skips formatting parsing.
    /// </remarks>
    public static void TextUnformatted(string text) => ImGui.TextUnformatted(text);

    /// <summary>
    /// Displays colored unformatted text for better performance with large text blocks.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display without formatting.</param>
    /// <remarks>
    /// Uses style color pushing to apply color to unformatted text.
    /// More efficient than formatted text methods for large text blocks.
    /// </remarks>
    public static void TextUnformatted(Vector4 color, string text)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color);
        ImGui.TextUnformatted(text);
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// Displays unformatted text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The unformatted text to display and copy.</param>
    /// <remarks>
    /// Combines the performance benefits of unformatted text with clipboard copy functionality.
    /// Ideal for displaying large amounts of copyable text efficiently.
    /// </remarks>
    public static void TextUnformattedCopy(string text)
    {
        ImGui.TextUnformatted(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays colored unformatted text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The unformatted text to display and copy.</param>
    /// <remarks>
    /// Provides colored, unformatted text with clipboard functionality for optimal performance
    /// when dealing with large text blocks that need to be copyable.
    /// </remarks>
    public static void TextUnformattedCopy(Vector4 color, string text)
    {
        TextUnformatted(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays unformatted text with automatic word wrapping.
    /// </summary>
    /// <param name="text">The unformatted text to display with wrapping.</param>
    /// <remarks>
    /// Combines the performance benefits of unformatted text with word wrapping.
    /// Useful for large text blocks that need to fit within the current content region.
    /// </remarks>
    public static void TextUnformattedWrapped(string text)
    {
        ImGui.PushTextWrapPos(0);
        TextUnformatted(text);
        ImGui.PopTextWrapPos();
    }

    /// <summary>
    /// Displays colored unformatted text with automatic word wrapping.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The unformatted text to display with wrapping.</param>
    /// <remarks>
    /// Provides colored, wrapped, unformatted text rendering for maximum flexibility
    /// while maintaining performance benefits for large text content.
    /// </remarks>
    public static void TextUnformattedWrapped(Vector4 color, string text)
    {
        ImGui.PushTextWrapPos(0);
        TextUnformatted(color, text);
        ImGui.PopTextWrapPos();
    }

    /// <summary>
    /// Displays wrapped unformatted text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The unformatted text to display with wrapping and copy functionality.</param>
    /// <remarks>
    /// Combines unformatted text performance, word wrapping, and clipboard copy functionality.
    /// Perfect for large text blocks that need to be both readable and copyable.
    /// </remarks>
    public static void TextUnformattedWrappedCopy(string text)
    {
        TextUnformattedWrapped(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays colored wrapped unformatted text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The unformatted text to display with wrapping and copy functionality.</param>
    /// <remarks>
    /// Provides the complete feature set: colored text, word wrapping, unformatted performance,
    /// and clipboard copy functionality in a single method call.
    /// </remarks>
    public static void TextUnformattedWrappedCopy(Vector4 color, string text)
    {
        TextUnformattedWrapped(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays text with a bullet point prefix.
    /// </summary>
    /// <param name="text">The text to display with a bullet point.</param>
    /// <remarks>
    /// This is a wrapper around ImGui.BulletText() with aggressive inlining for performance.
    /// Automatically adds a bullet point and proper indentation before the text.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void BulletText(string text) => ImGui.BulletText(text);

    /// <summary>
    /// Displays colored text with a bullet point prefix.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display with a bullet point.</param>
    /// <remarks>
    /// Combines bullet point formatting with custom text coloring.
    /// The color affects the text portion while maintaining standard bullet point appearance.
    /// </remarks>
    public static void BulletText(Vector4 color, string text)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color);
        ImGui.BulletText(text);
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// Displays bullet text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display with bullet point and copy functionality.</param>
    /// <remarks>
    /// Adds clipboard copy functionality to bullet text.
    /// Clicking on the text will copy it to clipboard, and the cursor indicates interactivity.
    /// </remarks>
    public static void BulletTextCopy(string text)
    {
        ImGui.BulletText(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays colored bullet text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color to apply to the text as a Vector4 (RGBA).</param>
    /// <param name="text">The text to display with bullet point and copy functionality.</param>
    /// <remarks>
    /// Combines colored bullet text with clipboard copy functionality.
    /// Provides a complete interactive bullet list item with custom styling.
    /// </remarks>
    public static void BulletTextCopy(Vector4 color, string text)
    {
        BulletText(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }
}
