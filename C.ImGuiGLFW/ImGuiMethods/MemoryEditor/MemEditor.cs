using System.Runtime.InteropServices;
using System.Text;

namespace C.ImGuiGLFW.ImGuiMethods.MemoryEditor;

public unsafe class MemEditor
{
    public bool Open = true;
    public bool ReadOnly = true;
    public int Cols = 16;
    public bool OptShowOptions = true;
    public bool OptShowDataPreview = false;
    public bool OptShowHexII = false;
    public bool OptShowAscii = true;
    public bool OptGreyOutZeroes = true;
    public bool OptUpperCaseHex = true;
    public int OptMidColsCount = 8;
    public int OptAddrDigitsCount = 0;
    public float OptFooterExtraHeight = 0.0f;
    public uint HighlightColor = 0x50FFFFFF; // IM_COL32(255, 255, 255, 50)

    // Function handlers
    public delegate byte ReadFnDelegate(IntPtr memData, nuint offset, IntPtr userData);
    public delegate void WriteFnDelegate(IntPtr memData, nuint offset, byte data, IntPtr userData);
    public delegate bool HighlightFnDelegate(IntPtr memData, nuint offset, IntPtr userData);
    public delegate uint BgColorFnDelegate(IntPtr memData, nuint offset, IntPtr userData);

    public ReadFnDelegate? ReadFn = null;
    public WriteFnDelegate? WriteFn = null;
    public HighlightFnDelegate? HighlightFn = null;
    public BgColorFnDelegate? BgColorFn = null;
    public IntPtr UserData = IntPtr.Zero;

    // Public read-only data
    public bool MouseHovered = false;
    public nuint MouseHoveredAddr = 0;

    // Internal State
    private bool ContentsWidthChanged = false;
    private nuint DataPreviewAddr = nuint.MaxValue;
    private nuint DataEditingAddr = nuint.MaxValue;
    private bool DataEditingTakeFocus = false;
    private readonly byte[] DataInputBuf = new byte[32];
    private readonly byte[] AddrInputBuf = new byte[32];
    private nuint GotoAddr = nuint.MaxValue;
    private nuint HighlightMin = nuint.MaxValue;
    private nuint HighlightMax = nuint.MaxValue;
    private int PreviewEndianness = 0;
    private ImGuiDataType PreviewDataType = ImGuiDataType.S32;

    public void GotoAddrAndHighlight(nuint addrMin, nuint addrMax)
    {
        GotoAddr = addrMin;
        HighlightMin = addrMin;
        HighlightMax = addrMax;
    }

    private void CalcSizes(Sizes s, nuint memSize, nuint baseDisplayAddr)
    {
        var style = ImGui.GetStyle();
        s.AddrDigitsCount = OptAddrDigitsCount;

        if (s.AddrDigitsCount == 0)
        {
            for (nuint n = baseDisplayAddr + memSize - 1; n > 0; n >>= 4)
                s.AddrDigitsCount++;
        }
        s.LineHeight = ImGui.GetTextLineHeight();
        s.GlyphWidth = ImGui.CalcTextSize("F").X + 1;
        s.HexCellWidth = (float)(int)(s.GlyphWidth * 2.5f);
        s.SpacingBetweenMidCols = (float)(int)(s.HexCellWidth * 0.25f);
        s.OffsetHexMinX = (s.AddrDigitsCount + 2) * s.GlyphWidth;
        s.OffsetHexMaxX = s.OffsetHexMinX + (s.HexCellWidth * Cols);
        s.OffsetAsciiMinX = s.OffsetAsciiMaxX = s.OffsetHexMaxX;
        if (OptShowAscii)
        {
            s.OffsetAsciiMinX = s.OffsetHexMaxX + s.GlyphWidth * 1;
            if (OptMidColsCount > 0)
                s.OffsetAsciiMinX += (float)((Cols + OptMidColsCount - 1) / OptMidColsCount) * s.SpacingBetweenMidCols;
            s.OffsetAsciiMaxX = s.OffsetAsciiMinX + Cols * s.GlyphWidth;
        }
        s.WindowWidth = s.OffsetAsciiMaxX + style.ScrollbarSize + style.WindowPadding.X * 2 + s.GlyphWidth;
    }

    public void DrawWindow(string title, IntPtr memData, nuint memSize, nuint baseDisplayAddr = 0x0000)
    {
        Sizes s = new();
        CalcSizes(s, memSize, baseDisplayAddr);
        ImGui.SetNextWindowSize(new Vector2(s.WindowWidth, s.WindowWidth * 0.60f), ImGuiCond.FirstUseEver);
        ImGui.SetNextWindowSizeConstraints(new Vector2(0f), new Vector2(s.WindowWidth, float.MaxValue));

        Open = true;
        if (ImGui.Begin(title, ref Open, ImGuiWindowFlags.NoScrollbar))
        {
            DrawContents(memData, memSize, baseDisplayAddr);
            if (ContentsWidthChanged)
            {
                CalcSizes(s, memSize, baseDisplayAddr);
                ImGui.SetWindowSize(new Vector2(s.WindowWidth, ImGui.GetWindowSize().Y));
            }
        }
        ImGui.End();
    }

    public void DrawContents(IntPtr memDataVoid, nuint memSize, nuint baseDisplayAddr = 0x0000)
    {
        if (Cols < 1)
            Cols = 1;

        byte* memData = (byte*)memDataVoid;
        Sizes s = new();
        CalcSizes(s, memSize, baseDisplayAddr);
        ImGuiStylePtr style = ImGui.GetStyle();

        Vector2 contentsPosStart = ImGui.GetCursorScreenPos();

        float heightSeparator = style.ItemSpacing.Y;
        float footerHeight = OptFooterExtraHeight;
        if (OptShowOptions)
            footerHeight += heightSeparator + ImGui.GetFrameHeightWithSpacing() * 1;
        if (OptShowDataPreview)
            footerHeight += heightSeparator + ImGui.GetFrameHeightWithSpacing() * 1 + ImGui.GetTextLineHeightWithSpacing() * 3;

        ImGui.BeginChild("##scrolling", new Vector2(-float.Epsilon, -footerHeight), ImGuiChildFlags.None, ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoNav);
        ImDrawListPtr drawList = ImGui.GetWindowDrawList();

        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(0, 0));
        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 0));

        Vector2 availSize = ImGui.GetContentRegionAvail();
        int lineTotalCount = (int)((memSize + (nuint)Cols - 1) / (nuint)Cols);

        bool dataNext = false;

        if (DataEditingAddr >= memSize)
            DataEditingAddr = nuint.MaxValue;
        if (DataPreviewAddr >= memSize)
            DataPreviewAddr = nuint.MaxValue;

        nuint previewDataTypeSize = OptShowDataPreview ? DataTypeGetSize(PreviewDataType) : 0;

        nuint dataEditingAddrNext = nuint.MaxValue;
        if (DataEditingAddr != nuint.MaxValue)
        {
            if (ImGui.IsKeyPressed(ImGuiKey.UpArrow) && DataEditingAddr >= (nuint)Cols)
                dataEditingAddrNext = DataEditingAddr - (nuint)Cols;
            else if (ImGui.IsKeyPressed(ImGuiKey.DownArrow) && DataEditingAddr < memSize - (nuint)Cols)
                dataEditingAddrNext = DataEditingAddr + (nuint)Cols;
            else if (ImGui.IsKeyPressed(ImGuiKey.LeftArrow) && DataEditingAddr > 0)
                dataEditingAddrNext = DataEditingAddr - 1;
            else if (ImGui.IsKeyPressed(ImGuiKey.RightArrow) && DataEditingAddr < memSize - 1)
                dataEditingAddrNext = DataEditingAddr + 1;
        }

        Vector2 windowPos = ImGui.GetWindowPos();
        if (OptShowAscii)
            drawList.AddLine(new Vector2(windowPos.X + s.OffsetAsciiMinX - s.GlyphWidth, windowPos.Y),
                new Vector2(windowPos.X + s.OffsetAsciiMinX - s.GlyphWidth, windowPos.Y + 9999),
                ImGui.GetColorU32(ImGuiCol.Border));

        uint colorText = ImGui.GetColorU32(ImGuiCol.Text);
        uint colorDisabled = OptGreyOutZeroes ? ImGui.GetColorU32(ImGuiCol.TextDisabled) : colorText;

        string formatAddress = OptUpperCaseHex ? $"%0{s.AddrDigitsCount}X: " : $"%0{s.AddrDigitsCount}x: ";
        string formatByte = OptUpperCaseHex ? "%02X" : "%02x";
        string formatByteSpace = OptUpperCaseHex ? "%02X " : "%02x ";

        MouseHovered = false;
        MouseHoveredAddr = 0;

        using (var clipper = new ListClipper(lineTotalCount, itemsHeight: s.LineHeight))
        {
            foreach (int lineI in clipper.Rows)
            {
                nuint addr = (nuint)lineI * (nuint)Cols;
                ImGui.Text(string.Format(formatAddress, baseDisplayAddr + addr));

                // Draw Hexadecimal
                for (int n = 0; n < Cols && addr < memSize; n++, addr++)
                {
                    float bytePosX = s.OffsetHexMinX + s.HexCellWidth * n;
                    if (OptMidColsCount > 0)
                        bytePosX += (float)(n / OptMidColsCount) * s.SpacingBetweenMidCols;
                    ImGui.SameLine(bytePosX);

                    bool isHighlightFromUserRange = (addr >= HighlightMin && addr < HighlightMax);
                    bool isHighlightFromUserFunc = (HighlightFn != null && HighlightFn(memDataVoid, addr, UserData));
                    bool isHighlightFromPreview = (addr >= DataPreviewAddr && addr < DataPreviewAddr + previewDataTypeSize);

                    uint bgColor = 0;
                    bool isNextByteHighlighted = false;
                    if (isHighlightFromUserRange || isHighlightFromUserFunc || isHighlightFromPreview)
                    {
                        isNextByteHighlighted = (addr + 1 < memSize) && ((HighlightMax != nuint.MaxValue && addr + 1 < HighlightMax) ||
                            (HighlightFn != null && HighlightFn(memDataVoid, addr + 1, UserData)) ||
                            (addr + 1 < DataPreviewAddr + previewDataTypeSize));
                        bgColor = HighlightColor;
                    }
                    else if (BgColorFn != null)
                    {
                        isNextByteHighlighted = (addr + 1 < memSize) && ((BgColorFn(memDataVoid, addr + 1, UserData) & 0xFF000000) != 0);
                        bgColor = BgColorFn(memDataVoid, addr, UserData);
                    }

                    if (bgColor != 0)
                    {
                        float bgWidth = s.GlyphWidth * 2;
                        if (isNextByteHighlighted || (n + 1 == Cols))
                        {
                            bgWidth = s.HexCellWidth;
                            if (OptMidColsCount > 0 && n > 0 && (n + 1) < Cols && ((n + 1) % OptMidColsCount) == 0)
                                bgWidth += s.SpacingBetweenMidCols;
                        }
                        Vector2 pos = ImGui.GetCursorScreenPos();
                        drawList.AddRectFilled(pos, new Vector2(pos.X + bgWidth, pos.Y + s.LineHeight), bgColor);
                    }

                    if (DataEditingAddr == addr)
                    {
                        // Display text input on current byte
                        bool dataWrite = false;
                        ImGui.PushID((int)addr);
                        if (DataEditingTakeFocus)
                        {
                            ImGui.SetKeyboardFocusHere(0);
                            byte b = ReadFn != null ? ReadFn(memDataVoid, addr, UserData) : memData[addr];
                            Encoding.ASCII.GetBytes(string.Format(formatByte, b), 0, 2, DataInputBuf, 0);
                        }

                        ImGui.SetNextItemWidth(s.GlyphWidth * 2);
                        ImGuiInputTextFlags flags = ImGuiInputTextFlags.CharsHexadecimal | ImGuiInputTextFlags.EnterReturnsTrue |
                            ImGuiInputTextFlags.AutoSelectAll | ImGuiInputTextFlags.NoHorizontalScroll | ImGuiInputTextFlags.AlwaysOverwrite;
                        if (ReadOnly)
                            flags |= ImGuiInputTextFlags.ReadOnly;

                        fixed (byte* bufPtr = DataInputBuf)
                        {
                            if (ImGui.InputText("##data".ToUTF8Ptr(), bufPtr, 32))
                                dataWrite = dataNext = true;
                            else if (!DataEditingTakeFocus && !ImGui.IsItemActive())
                                DataEditingAddr = dataEditingAddrNext = nuint.MaxValue;
                        }

                        DataEditingTakeFocus = false;

                        if (!ReadOnly && dataWrite)
                        {
                            string inputStr = Encoding.ASCII.GetString(DataInputBuf, 0, Array.IndexOf(DataInputBuf, (byte)0));
                            if (byte.TryParse(inputStr, System.Globalization.NumberStyles.HexNumber, null, out byte value))
                            {
                                if (WriteFn != null)
                                    WriteFn(memDataVoid, addr, value, UserData);
                                else
                                    memData[addr] = value;
                            }
                        }

                        if (ImGui.IsItemHovered())
                        {
                            MouseHovered = true;
                            MouseHoveredAddr = addr;
                        }
                        ImGui.PopID();
                    }
                    else
                    {
                        byte b = ReadFn != null ? ReadFn(memDataVoid, addr, UserData) : memData[addr];

                        if (OptShowHexII)
                        {
                            if ((b >= 32 && b < 128))
                                ImGui.Text($".{(char)b} ");
                            else if (b == 0xFF && OptGreyOutZeroes)
                                ImGui.TextDisabled("## ");
                            else if (b == 0x00)
                                ImGui.Text("   ");
                            else
                                ImGui.Text(string.Format(formatByteSpace, b));
                        }
                        else
                        {
                            if (b == 0 && OptGreyOutZeroes)
                                ImGui.TextDisabled("00 ");
                            else
                                ImGui.Text(string.Format(formatByteSpace, b));
                        }

                        if (ImGui.IsItemHovered())
                        {
                            MouseHovered = true;
                            MouseHoveredAddr = addr;
                            if (ImGui.IsMouseClicked(ImGuiMouseButton.Left))
                            {
                                DataEditingTakeFocus = true;
                                dataEditingAddrNext = addr;
                            }
                        }
                    }
                }

                if (OptShowAscii)
                {
                    ImGui.SameLine(s.OffsetAsciiMinX);
                    Vector2 pos = ImGui.GetCursorScreenPos();
                    addr = (nuint)lineI * (nuint)Cols;

                    ImGui.PushID(lineI);
                    if (ImGui.InvisibleButton("ascii", new Vector2(s.OffsetAsciiMaxX - s.OffsetAsciiMinX, s.LineHeight)))
                    {
                        float mouseOffX = ImGui.GetIO().MousePos.X - pos.X;
                        nuint mouseAddr = (mouseOffX >= 0.0f && mouseOffX < s.OffsetAsciiMaxX - s.OffsetAsciiMinX) ?
                            addr + (nuint)(mouseOffX / s.GlyphWidth) : nuint.MaxValue;
                        DataEditingAddr = DataPreviewAddr = mouseAddr;
                        DataEditingTakeFocus = true;
                    }
                    if (ImGui.IsItemHovered())
                    {
                        float mouseOffX = ImGui.GetIO().MousePos.X - pos.X;
                        MouseHovered = true;
                        MouseHoveredAddr = (mouseOffX >= 0.0f && mouseOffX < s.OffsetAsciiMaxX - s.OffsetAsciiMinX) ?
                            addr + (nuint)(mouseOffX / s.GlyphWidth) : nuint.MaxValue;
                    }
                    ImGui.PopID();

                    for (int n = 0; n < Cols && addr < memSize; n++, addr++)
                    {
                        if (addr == DataEditingAddr)
                        {
                            drawList.AddRectFilled(pos, new Vector2(pos.X + s.GlyphWidth, pos.Y + s.LineHeight),
                                ImGui.GetColorU32(ImGuiCol.FrameBg));
                            drawList.AddRectFilled(pos, new Vector2(pos.X + s.GlyphWidth, pos.Y + s.LineHeight),
                                ImGui.GetColorU32(ImGuiCol.TextSelectedBg));
                        }
                        else if (BgColorFn != null)
                        {
                            drawList.AddRectFilled(pos, new Vector2(pos.X + s.GlyphWidth, pos.Y + s.LineHeight),
                                BgColorFn(memDataVoid, addr, UserData));
                        }

                        byte c = ReadFn != null ? ReadFn(memDataVoid, addr, UserData) : memData[addr];
                        char displayC = (c < 32 || c >= 128) ? '.' : (char)c;
                        string charStr = displayC.ToString();
                        fixed (byte* strPtr = Encoding.UTF8.GetBytes(charStr))
                        {
                            drawList.AddText(pos, (displayC == (char)c) ? colorText : colorDisabled, strPtr);
                        }
                        pos.X += s.GlyphWidth;
                    }
                }
            }
        }

        ImGui.PopStyleVar(2);
        float childWidth = ImGui.GetWindowSize().X;
        ImGui.EndChild();

        Vector2 backupPos = ImGui.GetCursorScreenPos();
        ImGui.SetCursorPosX(s.WindowWidth);
        ImGui.Dummy(new Vector2(0.0f, 0.0f));
        ImGui.SetCursorScreenPos(backupPos);

        if (dataNext && DataEditingAddr + 1 < memSize)
        {
            DataEditingAddr = DataPreviewAddr = DataEditingAddr + 1;
            DataEditingTakeFocus = true;
        }
        else if (dataEditingAddrNext != nuint.MaxValue)
        {
            DataEditingAddr = DataPreviewAddr = dataEditingAddrNext;
            DataEditingTakeFocus = true;
        }

        bool lockShowDataPreview = OptShowDataPreview;
        if (OptShowOptions)
        {
            ImGui.Separator();
            DrawOptionsLine(s, memDataVoid, memSize, baseDisplayAddr);
        }

        if (lockShowDataPreview)
        {
            ImGui.Separator();
            DrawPreviewLine(s, memDataVoid, memSize, baseDisplayAddr);
        }

        if (GotoAddr != nuint.MaxValue)
        {
            if (GotoAddr < memSize)
            {
                ImGui.BeginChild("##scrolling");
                ImGui.SetScrollY((GotoAddr / (nuint)Cols) * ImGui.GetTextLineHeight() - availSize.Y * 0.5f);
                ImGui.EndChild();
                DataEditingAddr = DataPreviewAddr = GotoAddr;
                DataEditingTakeFocus = true;
            }
            GotoAddr = nuint.MaxValue;
        }

        Vector2 contentsPosEnd = new(contentsPosStart.X + childWidth, ImGui.GetCursorScreenPos().Y);
        if (OptShowOptions)
        {
            if (ImGui.IsMouseHoveringRect(contentsPosStart, contentsPosEnd))
                if (ImGui.IsWindowHovered(ImGuiHoveredFlags.ChildWindows) && ImGui.IsMouseReleased(ImGuiMouseButton.Right))
                    ImGui.OpenPopup("OptionsPopup");
        }

        if (ImGui.BeginPopup("OptionsPopup"))
        {
            ImGui.SetNextItemWidth(s.GlyphWidth * 7 + style.FramePadding.X * 2.0f);
            if (ImGui.DragInt("##cols", ref Cols, 0.2f, 4, 32, "%d cols"))
            {
                ContentsWidthChanged = true;
                if (Cols < 1) Cols = 1;
            }
            ImGui.Checkbox("Show Data Preview", ref OptShowDataPreview);
            ImGui.Checkbox("Show HexII", ref OptShowHexII);
            if (ImGui.Checkbox("Show Ascii", ref OptShowAscii))
                ContentsWidthChanged = true;
            ImGui.Checkbox("Grey out zeroes", ref OptGreyOutZeroes);
            ImGui.Checkbox("Uppercase Hex", ref OptUpperCaseHex);

            ImGui.EndPopup();
        }
    }

    private void DrawOptionsLine(Sizes s, IntPtr memData, nuint memSize, nuint baseDisplayAddr)
    {
        ImGuiStylePtr style = ImGui.GetStyle();
        string formatRange = OptUpperCaseHex ?
            $"Range %0{s.AddrDigitsCount}X..%0{s.AddrDigitsCount}X" :
            $"Range %0{s.AddrDigitsCount}x..%0{s.AddrDigitsCount}x";

        if (ImGui.Button("Options"))
            ImGui.OpenPopup("OptionsPopup");

        ImGui.SameLine();
        ImGui.Text(string.Format(formatRange, baseDisplayAddr, baseDisplayAddr + memSize - 1));
        ImGui.SameLine();
        ImGui.SetNextItemWidth((s.AddrDigitsCount + 1) * s.GlyphWidth + style.FramePadding.X * 2.0f);

        fixed (byte* bufPtr = AddrInputBuf)
        {
            if (ImGui.InputText("##addr".ToUTF8Ptr(), bufPtr, 32,
                ImGuiInputTextFlags.CharsHexadecimal | ImGuiInputTextFlags.EnterReturnsTrue))
            {
                string inputStr = Encoding.ASCII.GetString(AddrInputBuf, 0, Array.IndexOf(AddrInputBuf, (byte)0));
                if (nuint.TryParse(inputStr, System.Globalization.NumberStyles.HexNumber, null, out nuint gotoAddr))
                {
                    GotoAddr = gotoAddr - baseDisplayAddr;
                    HighlightMin = HighlightMax = nuint.MaxValue;
                }
            }
        }
    }

    private void DrawPreviewLine(Sizes s, IntPtr memDataVoid, nuint memSize, nuint baseDisplayAddr)
    {
        byte* memData = (byte*)memDataVoid;
        ImGuiStylePtr style = ImGui.GetStyle();
        ImGui.AlignTextToFramePadding();
        ImGui.Text("Preview as:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth((s.GlyphWidth * 10.0f) + style.FramePadding.X * 2.0f + style.ItemInnerSpacing.X);

        ImGuiDataType[] supportedDataTypes = [
                ImGuiDataType.S8, ImGuiDataType.U8, ImGuiDataType.S16, ImGuiDataType.U16,
                ImGuiDataType.S32, ImGuiDataType.U32, ImGuiDataType.S64, ImGuiDataType.U64,
                ImGuiDataType.Float, ImGuiDataType.Double
            ];

        if (ImGui.BeginCombo("##combo_type", DataTypeGetDesc(PreviewDataType), ImGuiComboFlags.HeightLargest))
        {
            foreach (var dataType in supportedDataTypes)
            {
                if (ImGui.Selectable(DataTypeGetDesc(dataType), PreviewDataType == dataType))
                    PreviewDataType = dataType;
            }
            ImGui.EndCombo();
        }

        ImGui.SameLine();
        ImGui.SetNextItemWidth((s.GlyphWidth * 6.0f) + style.FramePadding.X * 2.0f + style.ItemInnerSpacing.X);
        ImGui.Combo("##combo_endianness", ref PreviewEndianness, "LE\0BE\0\0");

        StringBuilder buf = new(128);
        float x = s.GlyphWidth * 6.0f;
        bool hasValue = DataPreviewAddr != nuint.MaxValue;

        if (hasValue)
            DrawPreviewData(DataPreviewAddr, memData, memSize, PreviewDataType, DataFormat.Dec, buf);
        ImGui.Text("Dec"); ImGui.SameLine(x); ImGui.TextUnformatted(hasValue ? buf.ToString() : "N/A");

        if (hasValue)
            DrawPreviewData(DataPreviewAddr, memData, memSize, PreviewDataType, DataFormat.Hex, buf);
        ImGui.Text("Hex"); ImGui.SameLine(x); ImGui.TextUnformatted(hasValue ? buf.ToString() : "N/A");

        if (hasValue)
            DrawPreviewData(DataPreviewAddr, memData, memSize, PreviewDataType, DataFormat.Bin, buf);
        ImGui.Text("Bin"); ImGui.SameLine(x); ImGui.TextUnformatted(hasValue ? buf.ToString() : "N/A");
    }

    private static string DataTypeGetDesc(ImGuiDataType dataType)
    {
        string[] descs = ["Int8", "Uint8", "Int16", "Uint16", "Int32", "Uint32", "Int64", "Uint64", "Float", "Double"];
        return descs[(int)dataType];
    }

    private static nuint DataTypeGetSize(ImGuiDataType dataType)
    {
        nuint[] sizes = [1, 1, 2, 2, 4, 4, 8, 8, sizeof(float), sizeof(double)];
        return sizes[(int)dataType];
    }

    private void DrawPreviewData(nuint addr, byte* memData, nuint memSize, ImGuiDataType dataType, DataFormat dataFormat, StringBuilder outBuf)
    {
        outBuf.Clear();
        byte[] buf = new byte[8];
        nuint elemSize = DataTypeGetSize(dataType);
        nuint size = addr + elemSize > memSize ? memSize - addr : elemSize;

        if (ReadFn != null)
        {
            for (nuint i = 0; i < size; i++)
                buf[i] = ReadFn((IntPtr)memData, addr + i, UserData);
        }
        else
        {
            Marshal.Copy((IntPtr)(memData + addr), buf, 0, (int)size);
        }

        if (dataFormat == DataFormat.Bin)
        {
            byte[] binbuf = new byte[8];
            EndiannessCopy(binbuf, buf, (int)size);
            outBuf.Append(FormatBinary(binbuf, (int)size * 8));
            return;
        }

        switch (dataType)
        {
            case ImGuiDataType.S8:
                {
                    sbyte data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x2}", data & 0xFF);
                    break;
                }
            case ImGuiDataType.U8:
                {
                    byte data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x2}", data);
                    break;
                }
            case ImGuiDataType.S16:
                {
                    short data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x4}", data & 0xFFFF);
                    break;
                }
            case ImGuiDataType.U16:
                {
                    ushort data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x4}", data);
                    break;
                }
            case ImGuiDataType.S32:
                {
                    int data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x8}", data);
                    break;
                }
            case ImGuiDataType.U32:
                {
                    uint data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x8}", data);
                    break;
                }
            case ImGuiDataType.S64:
                {
                    long data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x16}", data);
                    break;
                }
            case ImGuiDataType.U64:
                {
                    ulong data = 0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("0x{0:x16}", data);
                    break;
                }
            case ImGuiDataType.Float:
                {
                    float data = 0.0f;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("{0:x}", BitConverter.SingleToInt32Bits(data));
                    break;
                }
            case ImGuiDataType.Double:
                {
                    double data = 0.0;
                    EndiannessCopy(ref data, buf, (int)size);
                    if (dataFormat == DataFormat.Dec) outBuf.AppendFormat("{0}", data);
                    else if (dataFormat == DataFormat.Hex) outBuf.AppendFormat("{0:x}", BitConverter.DoubleToInt64Bits(data));
                    break;
                }
        }
    }

    private static bool IsBigEndian() => !BitConverter.IsLittleEndian;

    private void EndiannessCopy<T>(ref T dst, byte[] src, int size) where T : struct
    {
        byte[] temp = new byte[size];
        Array.Copy(src, temp, size);

        if ((PreviewEndianness == 1 && !IsBigEndian()) || (PreviewEndianness == 0 && IsBigEndian()))
        {
            Array.Reverse(temp);
        }

        if (typeof(T) == typeof(sbyte) || typeof(T) == typeof(byte))
            dst = (T)(object)temp[0];
        else if (typeof(T) == typeof(short))
            dst = (T)(object)BitConverter.ToInt16(temp, 0);
        else if (typeof(T) == typeof(ushort))
            dst = (T)(object)BitConverter.ToUInt16(temp, 0);
        else if (typeof(T) == typeof(int))
            dst = (T)(object)BitConverter.ToInt32(temp, 0);
        else if (typeof(T) == typeof(uint))
            dst = (T)(object)BitConverter.ToUInt32(temp, 0);
        else if (typeof(T) == typeof(long))
            dst = (T)(object)BitConverter.ToInt64(temp, 0);
        else if (typeof(T) == typeof(ulong))
            dst = (T)(object)BitConverter.ToUInt64(temp, 0);
        else if (typeof(T) == typeof(float))
            dst = (T)(object)BitConverter.ToSingle(temp, 0);
        else if (typeof(T) == typeof(double))
            dst = (T)(object)BitConverter.ToDouble(temp, 0);
    }

    private void EndiannessCopy(byte[] dst, byte[] src, int size)
    {
        if ((PreviewEndianness == 1 && !IsBigEndian()) || (PreviewEndianness == 0 && IsBigEndian()))
        {
            for (int i = 0; i < size; i++)
                dst[i] = src[size - 1 - i];
        }
        else
        {
            Array.Copy(src, dst, size);
        }
    }

    private static string FormatBinary(byte[] buf, int width)
    {
        StringBuilder outBuf = new();
        int n = width / 8;
        for (int j = n - 1; j >= 0; j--)
        {
            for (int i = 0; i < 8; i++)
                outBuf.Append((buf[j] & (1 << (7 - i))) != 0 ? '1' : '0');
            outBuf.Append(' ');
        }
        return outBuf.ToString();
    }
}
