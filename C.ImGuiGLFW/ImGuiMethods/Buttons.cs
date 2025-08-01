using C.ImGuiGLFW.Text.FontAwesome;
using C.ImGuiGLFW.Text.NotoEmojis;
using C.ImGuiGLFW.Text.SeIcon;
using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.ImGuiMethods;
public static partial class ImGuiC
{
    private const string DefaultIconId = "CButton";

    /// <summary>
    /// Renders an icon-only button using a FontAwesome icon.
    /// </summary>
    /// <param name="icon">The FontAwesome icon to display.</param>
    /// <param name="id">Optional ID to uniquely identify the button.</param>
    /// <param name="size">Optional button size.</param>
    /// <param name="enabled">Whether the button is enabled or disabled.</param>
    /// <returns>True if the button is clicked.</returns>
    /// <remarks>
    /// This method creates an ImGui button with an icon and no text.
    /// </remarks>
    public static bool IconButton(FontAwesomeIcon icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => IconButton(icon.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders an icon-only button using a SeIcon character.
    /// </summary>
    /// <param name="icon">The SeIcon character to display.</param>
    /// <param name="id">Optional ID to uniquely identify the button.</param>
    /// <param name="size">Optional button size.</param>
    /// <param name="enabled">Whether the button is enabled or disabled.</param>
    /// <returns>True if the button is clicked.</returns>
    /// <remarks>
    /// Use this to show SeIcon symbols as clickable buttons in the UI.
    /// </remarks>
    public static bool IconButton(SeIconChar icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => IconButton(icon.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders an icon-only button using a NotoEmoji character.
    /// </summary>
    /// <param name="icon">The NotoEmoji character to display.</param>
    /// <param name="id">Optional ID to uniquely identify the button.</param>
    /// <param name="size">Optional button size.</param>
    /// <param name="enabled">Whether the button is enabled or disabled.</param>
    /// <returns>True if the button is clicked.</returns>
    /// <remarks>
    /// Useful for using emoji characters as ImGui buttons.
    /// </remarks>
    public static bool IconButton(NotoEmoji icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => IconButton(icon.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders an icon-only button using the given string as the icon glyph.
    /// </summary>
    /// <param name="icon">The icon string to render (e.g., from FontAwesome or emoji).</param>
    /// <param name="id">Optional ID to uniquely identify the button.</param>
    /// <param name="size">Optional size of the button.</param>
    /// <param name="enabled">Whether the button is enabled.</param>
    /// <returns>True if the button is clicked and enabled.</returns>
    /// <remarks>
    /// This method creates a standard ImGui button that displays only an icon string, with styling and clickability.
    /// </remarks>
    public static bool IconButton(string icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true)
    {
        ImGui.BeginDisabled(!enabled);
        var ret = ImGui.Button($"{icon}##{icon}-{id}", size) && enabled;
        ImGui.EndDisabled();
        return ret;
    }

    /// <summary>
    /// Renders a transparent icon button using a FontAwesome icon.
    /// </summary>
    /// <param name="icon">The FontAwesome icon to display.</param>
    /// <param name="id">Optional unique ID.</param>
    /// <param name="size">Optional button size.</param>
    /// <param name="enabled">Whether the button is interactable.</param>
    /// <returns>True if clicked.</returns>
    /// <remarks>
    /// A transparent version of the icon button, useful for custom styling.
    /// </remarks>
    public static bool TransparentIconButton(FontAwesomeIcon icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => TransparentIconButton(icon.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders a transparent icon button using a SeIcon character.
    /// </summary>
    /// <param name="icon">The SeIcon character to display.</param>
    /// <param name="id">Optional unique ID.</param>
    /// <param name="size">Optional button size.</param>
    /// <param name="enabled">Whether the button is interactable.</param>
    /// <returns>True if clicked.</returns>
    /// <remarks>
    /// Displays the icon with transparent button background.
    /// </remarks>
    public static bool TransparentIconButton(SeIconChar icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => TransparentIconButton(icon.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders a transparent icon button using a NotoEmoji character.
    /// </summary>
    /// <param name="emoji">The NotoEmoji character to display.</param>
    /// <param name="id">Optional unique ID.</param>
    /// <param name="size">Optional button size.</param>
    /// <param name="enabled">Whether the button is interactable.</param>
    /// <returns>True if clicked.</returns>
    /// <remarks>
    /// Renders an emoji button without background fill.
    /// </remarks>
    public static bool TransparentIconButton(NotoEmoji emoji, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => TransparentIconButton(emoji.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders a transparent icon button using the given icon string.
    /// </summary>
    /// <param name="icon">The icon string to display.</param>
    /// <param name="id">Optional ID to uniquely identify the button.</param>
    /// <param name="size">Optional size of the button.</param>
    /// <param name="enabled">Whether the button is interactable.</param>
    /// <returns>True if the button is clicked and enabled.</returns>
    /// <remarks>
    /// This version of the icon button overrides the background color with transparency or custom color settings.
    /// </remarks>
    public static bool TransparentIconButton(string icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true)
    {
        ImGui.BeginDisabled(!enabled);
        ColorButton(0);
        var ret = ImGui.Button($"{icon}##{icon}-{id}", size);
        UncolorButton();
        ImGui.EndDisabled();
        return ret;
    }

    /// <summary>
    /// Renders a minimalist icon button using a FontAwesome icon with no background.
    /// </summary>
    /// <param name="icon">The icon to display.</param>
    /// <param name="id">Optional unique ID.</param>
    /// <param name="size">Optional size.</param>
    /// <param name="enabled">Whether the button is enabled.</param>
    /// <returns>True if clicked.</returns>
    /// <remarks>
    /// Draws only the icon as a button with no background styling.
    /// </remarks>
    public static bool IconButtonTransparent(FontAwesomeIcon icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => IconButtonTransparent(icon.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders a minimalist icon button using a SeIcon character with no background.
    /// </summary>
    /// <param name="icon">The icon to display.</param>
    /// <param name="id">Optional unique ID.</param>
    /// <param name="size">Optional size.</param>
    /// <param name="enabled">Whether the button is enabled.</param>
    /// <returns>True if clicked.</returns>
    /// <remarks>
    /// Use for subtle icon interactions without visible borders.
    /// </remarks>
    public static bool IconButtonTransparent(SeIconChar icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => IconButtonTransparent(icon.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders a minimalist icon button using a NotoEmoji character with no background.
    /// </summary>
    /// <param name="emoji">The icon to display.</param>
    /// <param name="id">Optional unique ID.</param>
    /// <param name="size">Optional size.</param>
    /// <param name="enabled">Whether the button is enabled.</param>
    /// <returns>True if clicked.</returns>
    /// <remarks>
    /// An emoji-style transparent button with click behavior.
    /// </remarks>
    public static bool IconButtonTransparent(NotoEmoji emoji, string id = DefaultIconId, Vector2 size = default, bool enabled = true) => IconButtonTransparent(emoji.ToIconString(), id, size, enabled);

    /// <summary>
    /// Renders a minimal, invisible icon button that only draws the icon string directly.
    /// </summary>
    /// <param name="icon">The icon string to display.</param>
    /// <param name="id">Optional ID to uniquely identify the button.</param>
    /// <param name="size">Optional size of the button. If unset, it uses text line height.</param>
    /// <param name="enabled">Whether the button is interactable.</param>
    /// <returns>True if the invisible button is clicked.</returns>
    /// <remarks>
    /// This function uses ImGui's InvisibleButton and directly draws the icon text with no frame or background.
    /// Ideal for subtle icon-only actions.
    /// </remarks>
    public static bool IconButtonTransparent(string icon, string id = DefaultIconId, Vector2 size = default, bool enabled = true)
    {
        ImGui.BeginDisabled(!enabled);
        if (size == default)
        {
            var height = ImGui.GetTextLineHeight();
            size = new Vector2(height);
        }
        var cursorPos = ImGui.GetCursorScreenPos();
        bool clicked = ImGui.InvisibleButton($"{id}-{icon}", size);
        var drawList = ImGui.GetWindowDrawList();
        var textSize = ImGui.CalcTextSize(icon);
        var textPos = new Vector2(
            cursorPos.X + (size.X - textSize.X) * 0.5f,
            cursorPos.Y + (size.Y - textSize.Y) * 0.5f
        );

        drawList.AddText(textPos, GetTextColor(enabled), icon);
        ImGui.EndDisabled();
        return clicked;
    }

    private static int StyleColors = 0;

    /// <summary>
    /// Applies a custom color to the button and its interactive states.
    /// </summary>
    /// <param name="color">The color to apply to button styles.</param>
    /// <remarks>
    /// Pushes three ImGui style colors (Button, Hovered, Active).
    /// Must be followed by <c>UncolorButton</c> to restore previous styles.
    /// </remarks>
    public static void ColorButton(uint color)
    {
        ImGui.PushStyleColor(ImGuiCol.Button, color);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, color);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, color);
        StyleColors += 3;
    }

    /// <summary>
    /// Applies a custom color to the button and its interactive states.
    /// </summary>
    /// <param name="color">The color as a Vector4 (RGBA float format).</param>
    /// <remarks>
    /// Converts the float color to U32 and applies it to the button appearance.
    /// </remarks>
    public static void ColorButton(Vector4 color)
    {
        var col = ImGui.ColorConvertFloat4ToU32(color);
        ImGui.PushStyleColor(ImGuiCol.Button, col);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, col);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, col);
        StyleColors += 3;
    }

    /// <summary>
    /// Pops all button style colors previously pushed by <c>ColorButton</c>.
    /// </summary>
    /// <remarks>
    /// Resets the button, hovered, and active colors to previous values.
    /// </remarks>
    public static void UncolorButton()
    {
        if (StyleColors == 0) return;
        ImGui.PopStyleColor(StyleColors);
        StyleColors = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint GetTextColor(bool enabled = true)
    {
        if (!enabled) return ImGui.GetColorU32(ImGuiCol.TextDisabled);
        return ImGui.IsItemHovered() ? ImGui.GetColorU32(ImGuiCol.Button) : ImGui.GetColorU32(ImGuiCol.Text);
    }

    /// <summary>
    /// IconButton component to use an icon as a button with color options.
    /// </summary>
    /// <param name="icon">Icon to show.</param>
    /// <param name="text">Text to show.</param>
    /// <param name="size">
    /// Sets the size of the button. If either dimension is set to 0,
    /// that dimension will conform to the size of the icon and text.
    /// </param>
    /// <returns>Indicator if button is clicked.</returns>
    public static bool IconButtonWithText(FontAwesomeIcon icon, string text, Vector2 size) => IconButtonWithText(icon, text, null, null, null, size);

    /// <summary>
    /// IconButton component to use an icon as a button with color options.
    /// </summary>
    /// <param name="icon">Icon to show.</param>
    /// <param name="text">Text to show.</param>
    /// <param name="buttonColor">The default color of the button.</param>
    /// <param name="buttonActiveColor">The color of the button when active.</param>
    /// <param name="buttonHoveredColor">The color of the button when hovered.</param>
    /// <param name="size">
    /// Sets the size of the button. If either dimension is set to 0,
    /// that dimension will conform to the size of the icon and text.
    /// </param>
    /// <returns>Indicator if button is clicked.</returns>
    public static bool IconButtonWithText(FontAwesomeIcon icon, string text, Vector4? buttonColor = null, Vector4? buttonActiveColor = null, Vector4? buttonHoveredColor = null, Vector2? size = null)
    {
        int popCount = 0;
        if (buttonColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.Button, buttonColor.Value);
            popCount++;
        }

        if (buttonActiveColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, buttonActiveColor.Value);
            popCount++;
        }

        if (buttonHoveredColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, buttonHoveredColor.Value);
            popCount++;
        }

        Vector2 iconSize = ImGui.CalcTextSize(icon.ToIconString());
        var textStr = text;
        if (textStr.Contains('#'))
        {
            textStr = textStr[..textStr.IndexOf('#', StringComparison.Ordinal)];
        }

        var framePadding = ImGui.GetStyle().FramePadding;
        const float iconPadding = 3f;

        var cursor = ImGui.GetCursorScreenPos();

        ImGui.PushID(text);
        var textSize = ImGui.CalcTextSize(textStr);

        var width = size is { X: not 0 } ? size.Value.X : iconSize.X + textSize.X + (framePadding.X * 2) + iconPadding;
        var height = size is { Y: not 0 } ? size.Value.Y : ImGui.GetFrameHeight();

        bool button = ImGui.Button(string.Empty, new Vector2(width, height));
        ImGui.PopID();

        var iconPos = cursor + framePadding;
        var textPos = new Vector2(iconPos.X + iconSize.X + iconPadding, cursor.Y + framePadding.Y);

        var dl = ImGui.GetWindowDrawList();
        dl.AddText(iconPos, ImGui.GetColorU32(ImGuiCol.Text), icon.ToIconString());
        dl.AddText(textPos, ImGui.GetColorU32(ImGuiCol.Text), textStr);
        if (popCount > 0) ImGui.PopStyleColor(popCount);
        return button;
    }

    /// <summary>
    /// Get width of IconButtonWithText component.
    /// </summary>
    /// <param name="icon">Icon to use.</param>
    /// <param name="text">Text to use.</param>
    /// <returns>Width.</returns>
    public static float GetIconButtonWithTextWidth(FontAwesomeIcon icon, string text)
    {
        Vector2 iconSize = ImGui.CalcTextSize(icon.ToIconString());
        var textSize = ImGui.CalcTextSize(text);
        return iconSize.X + textSize.X + (ImGui.GetStyle().FramePadding.X * 2) + 3f;
    }

    /// <summary>
    /// IconButton component to use an icon as a button with color options.
    /// </summary>
    /// <param name="icon">Icon to show.</param>
    /// <param name="text">Text to show.</param>
    /// <param name="size">
    /// Sets the size of the button. If either dimension is set to 0,
    /// that dimension will conform to the size of the icon and text.
    /// </param>
    /// <returns>Indicator if button is clicked.</returns>
    public static bool IconButtonWithText(NotoEmoji icon, string text, Vector2 size) => IconButtonWithText(icon, text, null, null, null, size);

    /// <summary>
    /// IconButton component to use an icon as a button with color options.
    /// </summary>
    /// <param name="icon">Icon to show.</param>
    /// <param name="text">Text to show.</param>
    /// <param name="buttonColor">The default color of the button.</param>
    /// <param name="buttonActiveColor">The color of the button when active.</param>
    /// <param name="buttonHoveredColor">The color of the button when hovered.</param>
    /// <param name="size">
    /// Sets the size of the button. If either dimension is set to 0,
    /// that dimension will conform to the size of the icon and text.
    /// </param>
    /// <returns>Indicator if button is clicked.</returns>
    public static bool IconButtonWithText(NotoEmoji icon, string text, Vector4? buttonColor = null, Vector4? buttonActiveColor = null, Vector4? buttonHoveredColor = null, Vector2? size = null)
    {
        int popCount = 0;
        if (buttonColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.Button, buttonColor.Value);
            popCount++;
        }

        if (buttonActiveColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, buttonActiveColor.Value);
            popCount++;
        }

        if (buttonHoveredColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, buttonHoveredColor.Value);
            popCount++;
        }

        Vector2 iconSize = ImGui.CalcTextSize(icon.ToIconString());
        var textStr = text;
        if (textStr.Contains('#'))
        {
            textStr = textStr[..textStr.IndexOf('#', StringComparison.Ordinal)];
        }

        var framePadding = ImGui.GetStyle().FramePadding;
        const float iconPadding = 3f;

        var cursor = ImGui.GetCursorScreenPos();

        ImGui.PushID(text);
        var textSize = ImGui.CalcTextSize(textStr);

        var width = size is { X: not 0 } ? size.Value.X : iconSize.X + textSize.X + (framePadding.X * 2) + iconPadding;
        var height = size is { Y: not 0 } ? size.Value.Y : ImGui.GetFrameHeight();

        bool button = ImGui.Button(string.Empty, new Vector2(width, height));
        ImGui.PopID();

        var iconPos = cursor + framePadding;
        var textPos = new Vector2(iconPos.X + iconSize.X + iconPadding, cursor.Y + framePadding.Y);

        var dl = ImGui.GetWindowDrawList();
        dl.AddText(iconPos, ImGui.GetColorU32(ImGuiCol.Text), icon.ToIconString());
        dl.AddText(textPos, ImGui.GetColorU32(ImGuiCol.Text), textStr);
        if (popCount > 0) ImGui.PopStyleColor(popCount);
        return button;
    }

    /// <summary>
    /// Get width of IconButtonWithText component.
    /// </summary>
    /// <param name="icon">Icon to use.</param>
    /// <param name="text">Text to use.</param>
    /// <returns>Width.</returns>
    public static float GetIconButtonWithTextWidth(NotoEmoji icon, string text)
    {
        Vector2 iconSize = ImGui.CalcTextSize(icon.ToIconString());
        var textSize = ImGui.CalcTextSize(text);
        return iconSize.X + textSize.X + (ImGui.GetStyle().FramePadding.X * 2) + 3f;
    }

    /// <summary>
    /// IconButton component to use an icon as a button with color options.
    /// </summary>
    /// <param name="icon">Icon to show.</param>
    /// <param name="text">Text to show.</param>
    /// <param name="size">
    /// Sets the size of the button. If either dimension is set to 0,
    /// that dimension will conform to the size of the icon and text.
    /// </param>
    /// <returns>Indicator if button is clicked.</returns>
    public static bool IconButtonWithText(SeIconChar icon, string text, Vector2 size) => IconButtonWithText(icon, text, null, null, null, size);

    /// <summary>
    /// IconButton component to use an icon as a button with color options.
    /// </summary>
    /// <param name="icon">Icon to show.</param>
    /// <param name="text">Text to show.</param>
    /// <param name="buttonColor">The default color of the button.</param>
    /// <param name="buttonActiveColor">The color of the button when active.</param>
    /// <param name="buttonHoveredColor">The color of the button when hovered.</param>
    /// <param name="size">
    /// Sets the size of the button. If either dimension is set to 0,
    /// that dimension will conform to the size of the icon and text.
    /// </param>
    /// <returns>Indicator if button is clicked.</returns>
    public static bool IconButtonWithText(SeIconChar icon, string text, Vector4? buttonColor = null, Vector4? buttonActiveColor = null, Vector4? buttonHoveredColor = null, Vector2? size = null)
    {
        int popCount = 0;
        if (buttonColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.Button, buttonColor.Value);
            popCount++;
        }

        if (buttonActiveColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, buttonActiveColor.Value);
            popCount++;
        }

        if (buttonHoveredColor.HasValue)
        {
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, buttonHoveredColor.Value);
            popCount++;
        }

        Vector2 iconSize = ImGui.CalcTextSize(icon.ToIconString());
        var textStr = text;
        if (textStr.Contains('#'))
        {
            textStr = textStr[..textStr.IndexOf('#', StringComparison.Ordinal)];
        }

        var framePadding = ImGui.GetStyle().FramePadding;
        const float iconPadding = 3f;

        var cursor = ImGui.GetCursorScreenPos();

        ImGui.PushID(text);
        var textSize = ImGui.CalcTextSize(textStr);

        var width = size is { X: not 0 } ? size.Value.X : iconSize.X + textSize.X + (framePadding.X * 2) + iconPadding;
        var height = size is { Y: not 0 } ? size.Value.Y : ImGui.GetFrameHeight();

        bool button = ImGui.Button(string.Empty, new Vector2(width, height));
        ImGui.PopID();

        var iconPos = cursor + framePadding;
        var textPos = new Vector2(iconPos.X + iconSize.X + iconPadding, cursor.Y + framePadding.Y);

        var dl = ImGui.GetWindowDrawList();
        dl.AddText(iconPos, ImGui.GetColorU32(ImGuiCol.Text), icon.ToIconString());
        dl.AddText(textPos, ImGui.GetColorU32(ImGuiCol.Text), textStr);
        if (popCount > 0) ImGui.PopStyleColor(popCount);
        return button;
    }

    /// <summary>
    /// Get width of IconButtonWithText component.
    /// </summary>
    /// <param name="icon">Icon to use.</param>
    /// <param name="text">Text to use.</param>
    /// <returns>Width.</returns>
    public static float GetIconButtonWithTextWidth(SeIconChar icon, string text)
    {
        Vector2 iconSize = ImGui.CalcTextSize(icon.ToIconString());
        var textSize = ImGui.CalcTextSize(text);
        return iconSize.X + textSize.X + (ImGui.GetStyle().FramePadding.X * 2) + 3f;
    }
}
