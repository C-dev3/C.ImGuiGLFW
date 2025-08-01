namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// A scoped block that automatically pushes and pops an ImGui ID.
/// </summary>
/// <remarks>
/// Use this block to scope ImGui IDs safely using <c>using</c> statements.
/// </remarks>
public sealed class IDBlock : IDisposable
{
    private static readonly IDBlock instance = new();
    private IDBlock() { }

    /// <summary>
    /// Begins a scoped ID block using an integer ID.
    /// </summary>
    /// <param name="intId">The integer ID to push.</param>
    /// <returns>An instance that pops the ID when disposed.</returns>
    /// <remarks>Use with a <c>using</c> statement to ensure the ID is properly popped.</remarks>
    public static IDBlock Begin(int intId)
    {
        ImGui.PushID(intId);
        return instance;
    }

    /// <summary>
    /// Begins a scoped ID block using an unsigned integer ID.
    /// </summary>
    /// <param name="uintId">The unsigned integer ID to push.</param>
    /// <returns>An instance that pops the ID when disposed.</returns>
    /// <remarks>Use with a <c>using</c> statement to ensure the ID is properly popped.</remarks>
    public static IDBlock Begin(uint uintId) => Begin((int)uintId);

    /// <summary>
    /// Begins a scoped ID block using a string ID.
    /// </summary>
    /// <param name="strId">The string ID to push.</param>
    /// <returns>An instance that pops the ID when disposed.</returns>
    /// <remarks>Use with a <c>using</c> block to ensure the ID is popped.</remarks>
    public static IDBlock Begin(string strId)
    {
        ImGui.PushID(strId);
        return instance;
    }

    /// <summary>
    /// Begins a scoped ID block using a pointer ID.
    /// </summary>
    /// <param name="ptrId">The pointer ID to push.</param>
    /// <returns>An instance that pops the ID when disposed.</returns>
    /// <remarks>Use with a <c>using</c> block to ensure the ID is popped.</remarks>
    public static unsafe IDBlock Begin(void* ptrId)
    {
        ImGui.PushID(ptrId);
        return instance;
    }

    /// <summary>
    /// Pops the last ID from the stack.
    /// </summary>
    /// <remarks>This is automatically called when the instance is disposed.</remarks>
    public void Dispose() => ImGui.PopID();
}

/// <summary>
/// A scoped block that sets and restores an ImGui style variable.
/// </summary>
/// <remarks>
/// Use this block with <c>using</c> statements to temporarily override ImGui style variables.
/// </remarks>
public sealed class StyleVarBlock : IDisposable
{
    private static readonly StyleVarBlock instance = new();
    private StyleVarBlock() { }

    /// <summary>
    /// Begins a scoped style variable block with a float value.
    /// </summary>
    /// <param name="idx">The style variable to set.</param>
    /// <param name="val">The float value to apply.</param>
    /// <param name="conditional">If false, the block will not be applied.</param>
    /// <returns>An instance that pops the style variable when disposed.</returns>
    /// <remarks>Useful for temporary style changes.</remarks>
    public static StyleVarBlock Begin(ImGuiStyleVar idx, float val, bool conditional = true)
    {
        if (!conditional) return null!;
        ImGui.PushStyleVar(idx, val);
        return instance;
    }

    /// <summary>
    /// Begins a scoped style variable block with a Vector2 value.
    /// </summary>
    /// <param name="idx">The style variable to set.</param>
    /// <param name="val">The Vector2 value to apply.</param>
    /// <param name="conditional">If false, the block will not be applied.</param>
    /// <returns>An instance that pops the style variable when disposed.</returns>
    /// <remarks>Useful for temporary style changes.</remarks>
    public static StyleVarBlock Begin(ImGuiStyleVar idx, Vector2 val, bool conditional = true)
    {
        if (!conditional) return null!;
        ImGui.PushStyleVar(idx, val);
        return instance;
    }

    /// <summary>
    /// Pops the last style variable from the stack.
    /// </summary>
    /// <remarks>Always called automatically when disposed.</remarks>
    public void Dispose() => ImGui.PopStyleVar();
}

/// <summary>
/// A scoped block that sets and restores an ImGui style color.
/// </summary>
/// <remarks>
/// Use to temporarily change style colors within a scoped context.
/// </remarks>
public sealed class StyleColorBlock : IDisposable
{
    private static readonly StyleColorBlock instance = new();
    private StyleColorBlock() { }

    /// <summary>
    /// Begins a scoped style color using a packed RGBA uint.
    /// </summary>
    /// <param name="idx">The color index to set.</param>
    /// <param name="val">The color value as a 32-bit unsigned integer.</param>
    /// <param name="conditional">Whether to apply the color conditionally.</param>
    /// <returns>An instance that will pop the color on dispose.</returns>
    /// <remarks>Use for temporary color changes.</remarks>
    public static StyleColorBlock Begin(ImGuiCol idx, uint val, bool conditional = true)
    {
        if (!conditional) return null!;
        ImGui.PushStyleColor(idx, val);
        return instance;
    }

    /// <summary>
    /// Begins a scoped style color using a Vector4 RGBA color.
    /// </summary>
    /// <param name="idx">The color index to set.</param>
    /// <param name="val">The color value as a Vector4.</param>
    /// <param name="conditional">Whether to apply the color conditionally.</param>
    /// <returns>An instance that will pop the color on dispose.</returns>
    /// <remarks>Use for temporary color changes with floating point values.</remarks>
    public static StyleColorBlock Begin(ImGuiCol idx, Vector4 val, bool conditional = true)
    {
        if (!conditional) return null!;
        ImGui.PushStyleColor(idx, val);
        return instance;
    }

    /// <summary>
    /// Pops the last style color from the stack.
    /// </summary>
    /// <remarks>Always called automatically when disposed.</remarks>
    public void Dispose() => ImGui.PopStyleColor();
}

/// <summary>
/// A scoped block that increases and restores the ImGui indentation.
/// </summary>
/// <remarks>
/// Use this to indent widgets temporarily within a <c>using</c> block.
/// </remarks>
public sealed class IndentBlock : IDisposable
{
    private static readonly IndentBlock instance = new();
    private IndentBlock() { }

    /// <summary>
    /// Begins an indent block using the default indent size.
    /// </summary>
    /// <returns>An indent block instance that restores indentation on dispose.</returns>
    /// <remarks>Use to visually group widgets with standard indentation.</remarks>
    public static IndentBlock Begin()
    {
        ImGuiC.PushIndent();
        return instance;
    }

    /// <summary>
    /// Begins an indent block using a custom indent size.
    /// </summary>
    /// <param name="indent">The amount to indent.</param>
    /// <returns>An indent block instance that restores indentation on dispose.</returns>
    /// <remarks>Use to customize visual grouping with specific offset.</remarks>
    public static IndentBlock Begin(float indent)
    {
        ImGuiC.PushIndent(indent);
        return instance;
    }

    /// <summary>
    /// Pops the indentation from the ImGui stack.
    /// </summary>
    /// <remarks>Automatically called when disposed.</remarks>
    public void Dispose() => ImGuiC.PopIndent();
}

/// <summary>
/// A scoped block that temporarily overrides ImGui's indent spacing style.
/// </summary>
/// <remarks>
/// Automatically restores the original indent spacing after scope ends.
/// </remarks>
public sealed class IndentSpacingBlock : IDisposable
{
    private static readonly IndentSpacingBlock instance = new();
    private readonly float defaultIndent;

    private IndentSpacingBlock() => defaultIndent = ImGui.GetStyle().IndentSpacing;

    /// <summary>
    /// Begins a block that sets indent spacing to 30.
    /// </summary>
    /// <returns>A block instance that restores the original spacing on dispose.</returns>
    /// <remarks>Useful for standardizing indentation in complex layouts.</remarks>
    public static IndentSpacingBlock Begin()
    {
        ImGui.GetStyle().IndentSpacing = 30;
        return instance;
    }

    /// <summary>
    /// Begins a block with a specified indent spacing value.
    /// </summary>
    /// <param name="indentSpacing">The spacing to apply.</param>
    /// <returns>A block instance that restores the original spacing on dispose.</returns>
    /// <remarks>Use for advanced layout customization.</remarks>
    public static IndentSpacingBlock Begin(float indentSpacing)
    {
        ImGui.GetStyle().IndentSpacing = indentSpacing;
        return instance;
    }

    /// <summary>
    /// Restores the original indent spacing.
    /// </summary>
    /// <remarks>Called automatically when disposed.</remarks>
    public void Dispose() => ImGui.GetStyle().IndentSpacing = defaultIndent;
}

/// <summary>
/// A scoped block that sets and restores the current ImGui font.
/// </summary>
/// <remarks>
/// Useful for rendering text in different fonts temporarily.
/// </remarks>
public sealed class FontBlock : IDisposable
{
    private static readonly FontBlock instance = new();
    private FontBlock() { }

    /// <summary>
    /// Begins a font block with a specified base font size.
    /// </summary>
    /// <param name="font">The font to push.</param>
    /// <param name="fontSizeBaseUnscaled">The font size to use.</param>
    /// <returns>A block instance that restores the font on dispose.</returns>
    /// <remarks>Use to customize text appearance in UI.</remarks>
    public static FontBlock Begin(ImFontPtr font, float fontSizeBaseUnscaled)
    {
        ImGui.PushFont(font, fontSizeBaseUnscaled);
        return instance;
    }

    /// <summary>
    /// Begins a font block using the font's legacy size.
    /// </summary>
    /// <param name="font">The font to push.</param>
    /// <returns>A block instance that restores the font on dispose.</returns>
    /// <remarks>Simple overload for standard font use cases.</remarks>
    public static FontBlock Begin(ImFontPtr font)
    {
        ImGui.PushFont(font, font.LegacySize);
        return instance;
    }

    /// <summary>
    /// Pops the current font from the ImGui stack.
    /// </summary>
    /// <remarks>Restores the previously active font.</remarks>
    public void Dispose() => ImGui.PopFont();
}

/// <summary>
/// A scoped block that begins and ends an ImGui group.
/// </summary>
/// <remarks>
/// Groups widgets together for layout or interaction.
/// </remarks>
public sealed class GroupBlock : IDisposable
{
    private static readonly GroupBlock instance = new();
    private GroupBlock() { }

    /// <summary>
    /// Begins a new group block.
    /// </summary>
    /// <returns>A block instance that ends the group on dispose.</returns>
    /// <remarks>Use to treat a set of widgets as one unit.</remarks>
    public static GroupBlock Begin()
    {
        ImGui.BeginGroup();
        return instance;
    }

    /// <summary>
    /// Ends the group block.
    /// </summary>
    /// <remarks>Called automatically at the end of the <c>using</c> scope.</remarks>
    public void Dispose() => ImGui.EndGroup();
}

/// <summary>
/// A scoped block that defines a clipping rectangle in ImGui.
/// </summary>
/// <remarks>
/// Useful to restrict rendering to a specific region.
/// </remarks>
public sealed class ClipRectBlock : IDisposable
{
    private static readonly ClipRectBlock instance = new();
    private ClipRectBlock() { }

    /// <summary>
    /// Begins a clipping region.
    /// </summary>
    /// <param name="clipRectMin">Top-left corner of the clipping area.</param>
    /// <param name="clipRectMax">Bottom-right corner of the clipping area.</param>
    /// <param name="intersectWithCurrentClipRect">Whether to intersect with existing clip rect.</param>
    /// <returns>A block instance that pops the clip rect on dispose.</returns>
    /// <remarks>Clipping is restored automatically when disposed.</remarks>
    public static ClipRectBlock Begin(Vector2 clipRectMin, Vector2 clipRectMax, bool intersectWithCurrentClipRect = true)
    {
        ImGui.PushClipRect(clipRectMin, clipRectMax, intersectWithCurrentClipRect);
        return instance;
    }

    /// <summary>
    /// Pops the clipping rectangle from the stack.
    /// </summary>
    /// <remarks>Restores the previous clip region automatically.</remarks>
    public void Dispose() => ImGui.PopClipRect();
}

/// <summary>
/// A scoped block that handles the lifetime of an ImGui tooltip.
/// </summary>
/// <remarks>
/// Begins and ends an ImGui tooltip automatically when used in a <c>using</c> block.
/// </remarks>
public sealed class TooltipBlock : IDisposable
{
    private static readonly TooltipBlock instance = new();
    private bool shouldEndTooltip;
    private TooltipBlock() { }

    /// <summary>
    /// Begins a tooltip block.
    /// </summary>
    /// <returns>A block instance that ends the tooltip on dispose.</returns>
    /// <remarks>Internally tracks whether the tooltip was successfully opened.</remarks>
    public static TooltipBlock Begin()
    {
        instance.shouldEndTooltip = ImGui.BeginTooltip();
        return instance;
    }

    /// <summary>
    /// Ends the tooltip if it was started.
    /// </summary>
    /// <remarks>Tooltip closing is conditional based on whether it was opened successfully.</remarks>
    public void Dispose()
    {
        if (shouldEndTooltip) ImGui.EndTooltip();
    }
}

/// <summary>
/// A scoped block that disables ImGui widgets temporarily.
/// </summary>
/// <remarks>
/// Automatically restores widget enable state at the end of the scope.
/// </remarks>
public sealed class DisabledBlock : IDisposable
{
    private static readonly DisabledBlock instance = new();
    private DisabledBlock() { }

    /// <summary>
    /// Begins a disabled block with widgets disabled.
    /// </summary>
    /// <returns>A block instance that re-enables widgets on dispose.</returns>
    /// <remarks>Equivalent to passing <c>true</c> to the conditional overload.</remarks>
    public static DisabledBlock Begin()
    {
        ImGui.BeginDisabled();
        return instance;
    }

    /// <summary>
    /// Begins a disabled block conditionally.
    /// </summary>
    /// <param name="disabled">If true, disables widgets; otherwise, no effect.</param>
    /// <returns>A block instance that restores the previous enabled state.</returns>
    /// <remarks>Use for conditional disabling of UI sections.</remarks>
    public static DisabledBlock Begin(bool disabled = true)
    {
        ImGui.BeginDisabled(disabled);
        return instance;
    }

    /// <summary>
    /// Ends the disabled state block.
    /// </summary>
    /// <remarks>Automatically restores the widget state after the block ends.</remarks>
    public void Dispose() => ImGui.EndDisabled();
}

/// <summary>
/// A scoped block that sets and restores the item width for widgets.
/// </summary>
/// <remarks>
/// Useful for aligning input fields and sliders uniformly.
/// </remarks>
public sealed class ItemWidthBlock : IDisposable
{
    private static readonly ItemWidthBlock instance = new();
    private ItemWidthBlock() { }

    /// <summary>
    /// Begins an item width block.
    /// </summary>
    /// <param name="itemWidth">The width to set for subsequent widgets.</param>
    /// <returns>A block instance that restores the width on dispose.</returns>
    /// <remarks>Use for consistent layout and alignment.</remarks>
    public static ItemWidthBlock Begin(float itemWidth)
    {
        ImGui.PushItemWidth(itemWidth);
        return instance;
    }

    /// <summary>
    /// Pops the item width from the stack.
    /// </summary>
    /// <remarks>Restores the previous width value after scope ends.</remarks>
    public void Dispose() => ImGui.PopItemWidth();
}

/// <summary>
/// A scoped block that sets the text wrap position in ImGui.
/// </summary>
/// <remarks>
/// Automatically restores the previous wrap position when disposed.
/// </remarks>
public sealed class TextWrapPosBlock : IDisposable
{
    private static readonly TextWrapPosBlock instance = new();
    private TextWrapPosBlock() { }

    /// <summary>
    /// Begins a text wrap position block using the default value.
    /// </summary>
    /// <returns>A block instance that restores wrap position on dispose.</returns>
    /// <remarks>Useful for wrapping long texts at the container edge.</remarks>
    public static TextWrapPosBlock Begin()
    {
        ImGui.PushTextWrapPos();
        return instance;
    }

    /// <summary>
    /// Begins a text wrap position block with a specific wrap position.
    /// </summary>
    /// <param name="wrapLocalPosX">The local X position to wrap text at.</param>
    /// <returns>A block instance that restores wrap position on dispose.</returns>
    /// <remarks>Use to align text wrapping with other UI elements.</remarks>
    public static TextWrapPosBlock Begin(float wrapLocalPosX)
    {
        ImGui.PushTextWrapPos(wrapLocalPosX);
        return instance;
    }

    /// <summary>
    /// Pops the text wrap position from the stack.
    /// </summary>
    /// <remarks>Automatically restores the previous setting.</remarks>
    public void Dispose() => ImGui.PopTextWrapPos();
}

/// <summary>
/// A scoped block for beginning and ending an ImGui drag-drop source.
/// </summary>
/// <remarks>
/// Automatically ends the drag-drop source when the block is disposed.
/// </remarks>
public sealed class DragDropSourceBlock : IDisposable
{
    private static readonly DragDropSourceBlock instance = new();
    private bool shouldEndSource;

    private DragDropSourceBlock() { }

    /// <summary>
    /// Begins a drag-drop source block.
    /// </summary>
    /// <returns>A block instance that ends the drag-drop source on dispose.</returns>
    /// <remarks>Use to wrap <c>ImGui.BeginDragDropSource()</c> within a <c>using</c> block.</remarks>
    public static DragDropSourceBlock Begin()
    {
        instance.shouldEndSource = ImGui.BeginDragDropSource();
        return instance;
    }

    /// <summary>
    /// Ends the drag-drop source if it was successfully begun.
    /// </summary>
    /// <remarks>Conditional end is performed based on whether Begin returned true.</remarks>
    public void Dispose()
    {
        if (shouldEndSource) ImGui.EndDragDropSource();
    }
}

/// <summary>
/// A scoped block for handling an ImGui drag-drop target.
/// </summary>
/// <remarks>
/// Automatically ends the target block when disposed.
/// </remarks>
public sealed class DragDropTargetBlock : IDisposable
{
    private static readonly DragDropTargetBlock instance = new();
    private bool shouldEndTarget;
    private DragDropTargetBlock() { }

    /// <summary>
    /// Begins a drag-drop target block.
    /// </summary>
    /// <returns>A block instance that ends the drag-drop target on dispose.</returns>
    /// <remarks>Use in conjunction with <c>ImGui.AcceptDragDropPayload()</c>.</remarks>
    public static DragDropTargetBlock Begin()
    {
        instance.shouldEndTarget = ImGui.BeginDragDropTarget();
        return instance;
    }

    /// <summary>
    /// Ends the drag-drop target if it was successfully begun.
    /// </summary>
    /// <remarks>Disposes the drag-drop target only if it was valid.</remarks>
    public void Dispose()
    {
        if (shouldEndTarget) ImGui.EndDragDropTarget();
    }
}

/// <summary>
/// A scoped block that begins and ends an ImGui child window.
/// </summary>
/// <remarks>
/// Automatically calls <c>ImGui.EndChild()</c> when disposed.
/// </remarks>
public sealed class ChildBlock : IDisposable
{
    private static readonly ChildBlock instance = new();
    private bool shouldEndChild;
    private ChildBlock() { }

    /// <summary>
    /// Begins a child window block using a string ID.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content in a separate scrollable region.</remarks>
    public static ChildBlock Begin(string strId)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content in a separate scrollable region.</remarks>
    public static ChildBlock Begin(uint id)
    {
        instance.shouldEndChild = ImGui.BeginChild(id);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a string ID and specific size.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content in a separate scrollable region with a defined size.</remarks>
    public static ChildBlock Begin(string strId, Vector2 size)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a string ID and child window flags.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with specific child window behavior.</remarks>
    public static ChildBlock Begin(string strId, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, childFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a string ID and window flags.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with specific window behavior.</remarks>
    public static ChildBlock Begin(string strId, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, windowFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID and specific size.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content in a separate scrollable region with a defined size.</remarks>
    public static ChildBlock Begin(uint id, Vector2 size)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID and child window flags.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with specific child window behavior.</remarks>
    public static ChildBlock Begin(uint id, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, childFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID and window flags.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with specific window behavior.</remarks>
    public static ChildBlock Begin(uint id, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, windowFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a string ID, specific size, and child window flags.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with a defined size and specific child window behavior.</remarks>
    public static ChildBlock Begin(string strId, Vector2 size, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size, childFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a string ID, specific size, and window flags.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with a defined size and specific window behavior.</remarks>
    public static ChildBlock Begin(string strId, Vector2 size, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size, windowFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID, specific size, and child window flags.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with a defined size and specific child window behavior.</remarks>
    public static ChildBlock Begin(uint id, Vector2 size, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size, childFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a string ID, child window flags, and window flags.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with specific child and window behaviors.</remarks>
    public static ChildBlock Begin(string strId, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, childFlags, windowFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID, specific size, and window flags.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with a defined size and specific window behavior.</remarks>
    public static ChildBlock Begin(uint id, Vector2 size, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size, windowFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID, child window flags, and window flags.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with specific child and window behaviors.</remarks>
    public static ChildBlock Begin(uint id, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, childFlags, windowFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a string ID, specific size, child window flags, and window flags.
    /// </summary>
    /// <param name="strId">The string ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with a defined size and specific child and window behaviors.</remarks>
    public static ChildBlock Begin(string strId, Vector2 size, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size, childFlags, windowFlags);
        return instance;
    }

    /// <summary>
    /// Begins a child window block using a numeric ID, specific size, child window flags, and window flags.
    /// </summary>
    /// <param name="id">The numeric ID of the child.</param>
    /// <param name="size">The size of the child window.</param>
    /// <param name="childFlags">Flags to customize the child window behavior.</param>
    /// <param name="windowFlags">Flags to customize the window behavior.</param>
    /// <returns>A block instance that ends the child window on dispose.</returns>
    /// <remarks>Use when you need to group content with a defined size and specific child and window behaviors.</remarks>
    public static ChildBlock Begin(uint id, Vector2 size, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size, childFlags, windowFlags);
        return instance;
    }

    /// <summary>
    /// Ends the child window block if it was successfully begun.
    /// </summary>
    /// <remarks>Ensures that <c>ImGui.EndChild()</c> is only called if the child was active.</remarks>
    public void Dispose()
    {
        if (shouldEndChild) ImGui.EndChild();
    }
}

/// <summary>
/// A scoped block that begins and ends an ImGui list box.
/// </summary>
/// <remarks>
/// Useful for wrapping <c>ImGui.BeginListBox()</c> and <c>ImGui.EndListBox()</c> with automatic cleanup.
/// </remarks>
public sealed class ListBoxBlock : IDisposable
{
    private static readonly ListBoxBlock instance = new();
    private bool shouldEndListBox;
    private ListBoxBlock() { }

    /// <summary>
    /// Begins a list box block using a label.
    /// </summary>
    /// <param name="label">The label for the list box.</param>
    /// <returns>A block instance that ends the list box on dispose.</returns>
    /// <remarks>Call <c>ImGui.Selectable()</c> within the block.</remarks>
    public static ListBoxBlock Begin(string label)
    {
        instance.shouldEndListBox = ImGui.BeginListBox(label);
        return instance;
    }

    /// <summary>
    /// Begins a list box block with a label and custom size.
    /// </summary>
    /// <param name="label">The label for the list box.</param>
    /// <param name="size">The size of the list box.</param>
    /// <returns>A block instance that ends the list box on dispose.</returns>
    /// <remarks>Use to control the dimensions of the list box explicitly.</remarks>
    public static ListBoxBlock Begin(string label, Vector2 size)
    {
        instance.shouldEndListBox = ImGui.BeginListBox(label, size);
        return instance;
    }

    /// <summary>
    /// Ends the list box if it was successfully begun.
    /// </summary>
    /// <remarks>Ensures proper rendering behavior and state cleanup.</remarks>
    public void Dispose()
    {
        if (shouldEndListBox) ImGui.EndListBox();
    }
}

/// <summary>
/// A scoped block that begins and ends an ImGui multi-select session.
/// </summary>
/// <remarks>
/// Use this block to enable multiple item selections within a unified scope.
/// </remarks>
public sealed class MultiSelectBlock : IDisposable
{
    private static readonly MultiSelectBlock instance = new();
    private MultiSelectBlock() { }

    /// <summary>
    /// Begins a multi-select block with specific flags.
    /// </summary>
    /// <param name="flags">Flags that define multi-select behavior.</param>
    /// <returns>A block instance that ends the multi-select session on dispose.</returns>
    /// <remarks>Use to enable extended selection features in ImGui.</remarks>
    public static MultiSelectBlock Begin(ImGuiMultiSelectFlags flags)
    {
        ImGui.BeginMultiSelect(flags);
        return instance;
    }

    /// <summary>
    /// Begins a multi-select block with flags and a selection size.
    /// </summary>
    /// <param name="flags">Multi-select configuration flags.</param>
    /// <param name="selectionSize">Number of items to select.</param>
    /// <returns>A block instance that ends the multi-select session on dispose.</returns>
    /// <remarks>Provides more control over how selections are handled.</remarks>
    public static MultiSelectBlock Begin(ImGuiMultiSelectFlags flags, int selectionSize)
    {
        ImGui.BeginMultiSelect(flags, selectionSize);
        return instance;
    }

    /// <summary>
    /// Begins a multi-select block with flags, selection size, and total item count.
    /// </summary>
    /// <param name="flags">Multi-select configuration flags.</param>
    /// <param name="selectionSize">Number of selected items.</param>
    /// <param name="itemsCount">Total number of selectable items.</param>
    /// <returns>A block instance that ends the multi-select session on dispose.</returns>
    /// <remarks>Use for large datasets or custom selection logic.</remarks>
    public static MultiSelectBlock Begin(ImGuiMultiSelectFlags flags, int selectionSize, int itemsCount)
    {
        ImGui.BeginMultiSelect(flags, selectionSize, itemsCount);
        return instance;
    }

    /// <summary>
    /// Ends the multi-select block.
    /// </summary>
    /// <remarks>Restores the previous multi-select state automatically.</remarks>
    public void Dispose() => ImGui.EndMultiSelect();
}

/// <summary>
/// A scoped block that manages an ImGui menu's open/close lifecycle.
/// </summary>
/// <remarks>
/// Automatically ends the menu if it was successfully opened.
/// </remarks>
public sealed class MenuBlock : IDisposable
{
    private static readonly MenuBlock instance = new();
    private bool shouldEndMenu;
    private MenuBlock() { }

    /// <summary>
    /// Begins a menu block with a label.
    /// </summary>
    /// <param name="label">The label of the menu.</param>
    /// <returns>A block instance that ends the menu on dispose.</returns>
    /// <remarks>Use for hierarchical or dropdown menus.</remarks>
    public static MenuBlock Begin(string label)
    {
        instance.shouldEndMenu = ImGui.BeginMenu(label);
        return instance;
    }

    /// <summary>
    /// Begins a menu block with a label and enabled state.
    /// </summary>
    /// <param name="label">The label of the menu.</param>
    /// <param name="enabled">Whether the menu is interactable.</param>
    /// <returns>A block instance that ends the menu on dispose.</returns>
    /// <remarks>Disables interaction without hiding the menu entry.</remarks>
    public static MenuBlock Begin(string label, bool enabled)
    {
        instance.shouldEndMenu = ImGui.BeginMenu(label, enabled);
        return instance;
    }

    /// <summary>
    /// Ends the menu block if it was successfully opened.
    /// </summary>
    /// <remarks>Closes the menu automatically if it was opened.</remarks>
    public void Dispose()
    {
        if (shouldEndMenu) ImGui.EndMenu();
    }
}

/// <summary>
/// A scoped block that manages the lifetime of an ImGui menu bar.
/// </summary>
/// <remarks>
/// Automatically closes the menu bar when disposed.
/// </remarks>
public sealed class MenuBarBlock : IDisposable
{
    private static readonly MenuBarBlock instance = new();
    private bool shouldEndMenuBar;
    private MenuBarBlock() { }

    /// <summary>
    /// Begins a menu bar block.
    /// </summary>
    /// <returns>A block instance that ends the menu bar on dispose.</returns>
    /// <remarks>Call this within a window or dockspace to render a menu bar.</remarks>
    public static MenuBarBlock Begin()
    {
        instance.shouldEndMenuBar = ImGui.BeginMenuBar();
        return instance;
    }

    /// <summary>
    /// Ends the menu block if it was successfully opened.
    /// </summary>
    /// <remarks>Closes the menu automatically if it was opened.</remarks>
    public void Dispose()
    {
        if (shouldEndMenuBar) ImGui.EndMenuBar();
    }
}