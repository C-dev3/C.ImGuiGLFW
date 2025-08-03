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

    /// <summary>
    /// Displays underlined text with a specified text color and underline color.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="textColor">The color of the text.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method temporarily changes the text color style, renders underlined text, then restores the original text color.
    /// The underline is drawn using ImGui's draw list functionality.
    /// </remarks>
    public static void TextUnderlined(string text, Vector4 textColor, uint underLineColor = 0xFFFFFFFFu)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, textColor);
        TextUnderlined(text, underLineColor);
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// Displays underlined text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method combines underlined text display with clipboard functionality. 
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextUnderlinedCopy(string text, uint underLineColor = 0xFFFFFFFFu)
    {
        TextUnderlined(text, underLineColor);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays underlined text with custom text color that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <param name="textColor">The color of the text.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method combines colored underlined text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextUnderlinedCopy(string text, Vector4 textColor, uint underLineColor = 0xFFFFFFFFu)
    {
        TextUnderlined(text, textColor, underLineColor);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays text with an underline drawn below it.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method calculates the text size and draws a line below the text using ImGui's draw list.
    /// The underline spans the full width of the text and is positioned directly below the text baseline.
    /// </remarks>
    public static void TextUnderlined(string text, uint underLineColor = 0xFFFFFFFFu)
    {
        var size = ImGui.CalcTextSize(text);
        var cursorPos = ImGui.GetCursorScreenPos();
        cursorPos.Y += size.Y;
        var drawList = ImGui.GetWindowDrawList();
        drawList.PathLineTo(cursorPos);
        cursorPos.X += size.X;
        drawList.PathLineTo(cursorPos);
        drawList.PathStroke(underLineColor);
        Text(text);
    }

    /// <summary>
    /// Displays unformatted underlined text with a specified text color and underline color.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="textColor">The color of the text.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method uses unformatted text rendering for better performance with large text blocks.
    /// It temporarily changes the text color style, renders underlined text, then restores the original text color.
    /// </remarks>
    public static void TextUnformattedUnderlined(string text, Vector4 textColor, uint underLineColor = 0xFFFFFFFFu)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, textColor);
        TextUnformattedUnderlined(text, underLineColor);
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// Displays unformatted underlined text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method combines unformatted underlined text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// Unformatted text rendering provides better performance for large text blocks.
    /// </remarks>
    public static void TextUnformattedUnderlinedCopy(string text, uint underLineColor = 0xFFFFFFFFu)
    {
        TextUnformattedUnderlined(text, underLineColor);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays unformatted underlined text with custom text color that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <param name="textColor">The color of the text.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method combines colored unformatted underlined text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// Unformatted text rendering provides better performance for large text blocks.
    /// </remarks>
    public static void TextUnformattedUnderlinedCopy(string text, Vector4 textColor, uint underLineColor = 0xFFFFFFFFu)
    {
        TextUnformattedUnderlined(text, textColor, underLineColor);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays unformatted text with an underline drawn below it.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="underLineColor">The color of the underline. Default is white (0xFFFFFFFF).</param>
    /// <remarks>
    /// This method uses unformatted text rendering for better performance with large text blocks.
    /// The underline is drawn using ImGui's draw list functionality and spans the full width of the text.
    /// </remarks>
    public static void TextUnformattedUnderlined(string text, uint underLineColor = 0xFFFFFFFFu)
    {
        var size = ImGui.CalcTextSize(text);
        var cursorPos = ImGui.GetCursorScreenPos();
        cursorPos.Y += size.Y;
        var drawList = ImGui.GetWindowDrawList();
        drawList.PathLineTo(cursorPos);
        cursorPos.X += size.X;
        drawList.PathLineTo(cursorPos);
        drawList.PathStroke(underLineColor);
        TextUnformatted(text);
    }

    /// <summary>
    /// Displays horizontally centered text with a specified color.
    /// </summary>
    /// <param name="color">The color of the text.</param>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This method temporarily changes the text color style, renders horizontally centered text, then restores the original text color.
    /// The text is centered within the available content region width.
    /// </remarks>
    public static void TextCenteredH(Vector4 color, string text)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color);
        TextCenteredH(text);
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// Displays horizontally centered text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// This method combines horizontally centered text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextCenteredHCopy(string text)
    {
        TextCenteredH(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays horizontally centered text with custom color that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color of the text.</param>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// This method combines colored horizontally centered text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextCenteredHCopy(Vector4 color, string text)
    {
        TextCenteredH(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays text centered horizontally within the available content region.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This method calculates the text width and positions the cursor to center the text horizontally.
    /// The centering is based on the available content region width minus the text width, divided by two.
    /// </remarks>
    public static void TextCenteredH(string text)
    {
        ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X / 2 - ImGui.CalcTextSize(text).X / 2);
        Text(text);
    }

    /// <summary>
    /// Displays vertically centered text with a specified color.
    /// </summary>
    /// <param name="color">The color of the text.</param>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This method temporarily changes the text color style, renders vertically centered text, then restores the original text color.
    /// The text is centered within the available content region height.
    /// </remarks>
    public static void TextCenteredV(Vector4 color, string text)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color);
        TextCenteredV(text);
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// Displays vertically centered text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// This method combines vertically centered text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextCenteredVCopy(string text)
    {
        TextCenteredV(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays vertically centered text with custom color that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color of the text.</param>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// This method combines colored vertically centered text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextCenteredVCopy(Vector4 color, string text)
    {
        TextCenteredV(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays text centered vertically within the available content region.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This method calculates the text height and positions the cursor to center the text vertically.
    /// The centering is based on the available content region height minus the text height, divided by two.
    /// </remarks>
    public static void TextCenteredV(string text)
    {
        ImGui.SetCursorPosY(ImGui.GetCursorPosY() + ImGui.GetContentRegionAvail().Y / 2 - ImGui.CalcTextSize(text).Y / 2);
        Text(text);
    }

    /// <summary>
    /// Displays text centered both horizontally and vertically with a specified color.
    /// </summary>
    /// <param name="color">The color of the text.</param>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This method temporarily changes the text color style, renders centered text, then restores the original text color.
    /// The text is centered within both the available content region width and height.
    /// </remarks>
    public static void TextCentered(Vector4 color, string text)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color);
        TextCentered(text);
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// Displays centered text that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// This method combines centered text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextCenteredCopy(string text)
    {
        TextCentered(text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays centered text with custom color that can be copied to clipboard when clicked.
    /// </summary>
    /// <param name="color">The color of the text.</param>
    /// <param name="text">The text to display and copy.</param>
    /// <remarks>
    /// This method combines colored centered text display with clipboard functionality.
    /// The mouse cursor changes to a hand when hovering over the text, and clicking copies the text to clipboard.
    /// </remarks>
    public static void TextCenteredCopy(Vector4 color, string text)
    {
        TextCentered(color, text);
        SetMouseCursorIfHovered(ImGuiMouseCursor.Hand);
        SetClipboardTextIfClicked(text);
    }

    /// <summary>
    /// Displays text centered both horizontally and vertically within the available content region.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <remarks>
    /// This method calculates the text size and available content region, then positions the cursor to center the text in both dimensions.
    /// The centering calculation uses half the text size subtracted from half the available region size.
    /// </remarks>
    public static void TextCentered(string text)
    {
        var currentPos = ImGui.GetCursorPos();
        var size = ImGui.CalcTextSize(text) / 2f;
        var region = ImGui.GetContentRegionAvail() / 2f;
        ImGui.SetCursorPos(currentPos + region - size);
        ImGui.Text(text);
    }
}
