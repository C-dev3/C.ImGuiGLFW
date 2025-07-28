namespace C.ImGuiGLFW.ImGuiMethods;

public sealed class IDBlock : IDisposable
{
    private static readonly IDBlock instance = new();
    private IDBlock() { }

    public static IDBlock Begin(int intId)
    {
        ImGui.PushID(intId);
        return instance;
    }

    public static IDBlock Begin(uint uintId) => Begin((int)uintId);

    public static IDBlock Begin(string strId)
    {
        ImGui.PushID(strId);
        return instance;
    }

    public static unsafe IDBlock Begin(void* ptrId)
    {
        ImGui.PushID(ptrId);
        return instance;
    }

    public void Dispose() => ImGui.PopID();
}

public sealed class StyleVarBlock : IDisposable
{
    private static readonly StyleVarBlock instance = new();
    private StyleVarBlock() { }

    public static StyleVarBlock Begin(ImGuiStyleVar idx, float val, bool conditional = true)
    {
        if (!conditional) return instance;
        ImGui.PushStyleVar(idx, val);
        return instance;
    }

    public static StyleVarBlock Begin(ImGuiStyleVar idx, Vector2 val, bool conditional = true)
    {
        if (!conditional) return instance;
        ImGui.PushStyleVar(idx, val);
        return instance;
    }

    public void Dispose() => ImGui.PopStyleVar();
}

public sealed class StyleColorBlock : IDisposable
{
    private static readonly StyleColorBlock instance = new();
    private StyleColorBlock() { }

    public static StyleColorBlock Begin(ImGuiCol idx, uint val, bool conditional = true)
    {
        if (!conditional) return instance;
        ImGui.PushStyleColor(idx, val);
        return instance;
    }

    public static StyleColorBlock Begin(ImGuiCol idx, Vector4 val, bool conditional = true)
    {
        if (!conditional) return instance;
        ImGui.PushStyleColor(idx, val);
        return instance;
    }

    public void Dispose() => ImGui.PopStyleColor();
}

public sealed class IndentBlock : IDisposable
{
    private static readonly IndentBlock instance = new();
    private IndentBlock() { }

    public static IndentBlock Begin()
    {
        ImGuiC.PushIndent();
        return instance;
    }

    public static IndentBlock Begin(float indent)
    {
        ImGuiC.PushIndent(indent);
        return instance;
    }

    public void Dispose() => ImGuiC.PopIndent();
}

public sealed class IndentSpacingBlock : IDisposable
{
    private static readonly IndentSpacingBlock instance = new();
    private readonly float defaultIndent;
    private IndentSpacingBlock()
    {
        defaultIndent = ImGui.GetStyle().IndentSpacing;
    }
    public static IndentSpacingBlock Begin()
    {
        ImGui.GetStyle().IndentSpacing = 30;
        return instance;
    }

    public static IndentSpacingBlock Begin(float indentSpacing)
    {
        ImGui.GetStyle().IndentSpacing = indentSpacing;
        return instance;
    }

    public void Dispose() => ImGui.GetStyle().IndentSpacing = defaultIndent;
}

public sealed class FontBlock : IDisposable
{
    private static readonly FontBlock instance = new();
    private FontBlock() { }

    public static FontBlock Begin(ImFontPtr font, float fontSizeBaseUnscaled)
    {
        ImGui.PushFont(font, fontSizeBaseUnscaled);
        return instance;
    }

    public static FontBlock Begin(ImFontPtr font)
    {
        ImGui.PushFont(font, font.LegacySize);
        return instance;
    }

    public void Dispose() => ImGui.PopFont();
}

public sealed class GroupBlock : IDisposable
{
    private static readonly GroupBlock instance = new();
    private GroupBlock() { }

    public static GroupBlock Begin()
    {
        ImGui.BeginGroup();
        return instance;
    }

    public void Dispose() => ImGui.EndGroup();
}

public sealed class ClipRectBlock : IDisposable
{
    private static readonly ClipRectBlock instance = new();
    private ClipRectBlock() { }

    public static ClipRectBlock Begin(Vector2 clipRectMin, Vector2 clipRectMax, bool intersectWithCurrentClipRect = true)
    {
        ImGui.PushClipRect(clipRectMin, clipRectMax, intersectWithCurrentClipRect);
        return instance;
    }

    public void Dispose() => ImGui.PopClipRect();
}

public sealed class TooltipBlock : IDisposable
{
    private static readonly TooltipBlock instance = new();
    private bool shouldEndTooltip;
    private TooltipBlock() { }

    public static TooltipBlock Begin()
    {
        instance.shouldEndTooltip = ImGui.BeginTooltip();
        return instance;
    }

    public void Dispose()
    {
        if (shouldEndTooltip) ImGui.EndTooltip();
    }
}

public sealed class DisabledBlock : IDisposable
{
    private static readonly DisabledBlock instance = new();
    private DisabledBlock() { }

    public static DisabledBlock Begin()
    {
        ImGui.BeginDisabled();
        return instance;
    }

    public static DisabledBlock Begin(bool disabled = true)
    {
        ImGui.BeginDisabled(disabled);
        return instance;
    }

    public void Dispose() => ImGui.EndDisabled();
}

public sealed class ItemWidthBlock : IDisposable
{
    private static readonly ItemWidthBlock instance = new();
    private ItemWidthBlock() { }

    public static ItemWidthBlock Begin(float itemWidth)
    {
        ImGui.PushItemWidth(itemWidth);
        return instance;
    }

    public void Dispose() => ImGui.PopItemWidth();
}

public sealed class TextWrapPosBlock : IDisposable
{
    private static readonly TextWrapPosBlock instance = new();
    private TextWrapPosBlock() { }

    public static TextWrapPosBlock Begin()
    {
        ImGui.PushTextWrapPos();
        return instance;
    }

    public static TextWrapPosBlock Begin(float wrapLocalPosX)
    {
        ImGui.PushTextWrapPos(wrapLocalPosX);
        return instance;
    }

    public void Dispose() => ImGui.PopTextWrapPos();
}

public sealed class DragDropSourceBlock : IDisposable
{
    private static readonly DragDropSourceBlock instance = new();
    private bool shouldEndSource;

    private DragDropSourceBlock() { }

    public static DragDropSourceBlock Begin()
    {
        instance.shouldEndSource = ImGui.BeginDragDropSource();
        return instance;
    }

    public void Dispose()
    {
        if (shouldEndSource) ImGui.EndDragDropSource();
    }
}

public sealed class DragDropTargetBlock : IDisposable
{
    private static readonly DragDropTargetBlock instance = new();
    private bool shouldEndTarget;
    private DragDropTargetBlock() { }

    public static DragDropTargetBlock Begin()
    {
        instance.shouldEndTarget = ImGui.BeginDragDropTarget();
        return instance;
    }

    public void Dispose()
    {
        if (shouldEndTarget) ImGui.EndDragDropTarget();
    }
}

public sealed class ChildBlock : IDisposable
{
    private static readonly ChildBlock instance = new();
    private bool shouldEndChild;
    private ChildBlock() { }

    public static ChildBlock Begin(string strId)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId);
        return instance;
    }

    public static ChildBlock Begin(uint id)
    {
        instance.shouldEndChild = ImGui.BeginChild(id);
        return instance;
    }

    public static ChildBlock Begin(string strId, Vector2 size)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size);
        return instance;
    }

    public static ChildBlock Begin(string strId, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, childFlags);
        return instance;
    }

    public static ChildBlock Begin(string strId, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, windowFlags);
        return instance;
    }

    public static ChildBlock Begin(uint id, Vector2 size)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size);
        return instance;
    }

    public static ChildBlock Begin(uint id, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, childFlags);
        return instance;
    }

    public static ChildBlock Begin(uint id, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, windowFlags);
        return instance;
    }

    public static ChildBlock Begin(string strId, Vector2 size, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size, childFlags);
        return instance;
    }

    public static ChildBlock Begin(string strId, Vector2 size, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size, windowFlags);
        return instance;
    }

    public static ChildBlock Begin(uint id, Vector2 size, ImGuiChildFlags childFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size, childFlags);
        return instance;
    }

    public static ChildBlock Begin(string strId, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, childFlags, windowFlags);
        return instance;
    }

    public static ChildBlock Begin(uint id, Vector2 size, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size, windowFlags);
        return instance;
    }

    public static ChildBlock Begin(uint id, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, childFlags, windowFlags);
        return instance;
    }

    public static ChildBlock Begin(string strId, Vector2 size, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(strId, size, childFlags, windowFlags);
        return instance;
    }

    public static ChildBlock Begin(uint id, Vector2 size, ImGuiChildFlags childFlags, ImGuiWindowFlags windowFlags)
    {
        instance.shouldEndChild = ImGui.BeginChild(id, size, childFlags, windowFlags);
        return instance;
    }

    public void Dispose()
    {
        if (shouldEndChild) ImGui.EndChild();
    }
}

public sealed class ListBoxBlock : IDisposable
{
    private static readonly ListBoxBlock instance = new();
    private bool shouldEndListBox;
    private ListBoxBlock() { }

    public static ListBoxBlock Begin(string label)
    {
        instance.shouldEndListBox = ImGui.BeginListBox(label);
        return instance;
    }

    public static ListBoxBlock Begin(string label, Vector2 size)
    {
        instance.shouldEndListBox = ImGui.BeginListBox(label, size);
        return instance;
    }

    public void Dispose()
    {
        if (shouldEndListBox) ImGui.EndListBox();
    }
}

public sealed class MultiSelectBlock : IDisposable
{
    private static readonly MultiSelectBlock instance = new();
    private MultiSelectBlock() { }

    public static MultiSelectBlock Begin(ImGuiMultiSelectFlags flags)
    {
        ImGui.BeginMultiSelect(flags);
        return instance;
    }

    public static MultiSelectBlock Begin(ImGuiMultiSelectFlags flags, int selectionSize)
    {
        ImGui.BeginMultiSelect(flags, selectionSize);
        return instance;
    }

    public static MultiSelectBlock Begin(ImGuiMultiSelectFlags flags, int selectionSize, int itemsCount)
    {
        ImGui.BeginMultiSelect(flags, selectionSize, itemsCount);
        return instance;
    }

    public void Dispose() => ImGui.EndMultiSelect();
}