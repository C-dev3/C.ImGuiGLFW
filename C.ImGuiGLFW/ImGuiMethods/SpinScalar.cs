using System.Text;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    /// <summary>
    /// Creates a spin scaler widget that combines an input field with up/down arrow buttons.
    /// This widget allows users to input values directly or increment/decrement using buttons.
    /// </summary>
    /// <param name="label">The label for the widget</param>
    /// <param name="dataType">The data type of the value being edited</param>
    /// <param name="dataPtr">Pointer to the data being modified</param>
    /// <param name="step">Pointer to the normal step value for increment/decrement</param>
    /// <param name="stepFast">Pointer to the fast step value (used when Ctrl is held)</param>
    /// <param name="format">Format string for displaying the value (null for default)</param>
    /// <param name="flags">Input text flags to control behavior</param>
    /// <returns>True if the value was changed</returns>
    public static unsafe bool SpinScaler(string label, ImGuiDataType dataType, void* dataPtr,
        void* step, void* stepFast, string? format, ImGuiInputTextFlags flags)
    {
        var window = ImGuiP.GetCurrentWindow();
        if (window.SkipItems)
            return false;

        var style = ImGui.GetStyle();
        bool valueChanged = false;

        // Set up input text flags
        if ((flags & (ImGuiInputTextFlags.CharsHexadecimal | ImGuiInputTextFlags.CharsScientific)) == 0)
            flags |= ImGuiInputTextFlags.CharsDecimal;
        flags |= ImGuiInputTextFlags.AutoSelectAll;

        if (step != null)
        {
            float buttonSize = ImGui.GetFrameHeight();

            ImGui.BeginGroup(); // Allow caller to query item data
            ImGui.PushID(label);

            // Set width for input field, leaving space for buttons
            float itemWidth = Math.Max(1.0f, ImGui.CalcItemWidth() - (buttonSize + style.ItemInnerSpacing.X) * 2);
            ImGui.SetNextItemWidth(itemWidth);

            // Convert format string to byte pointer if provided
            byte* formatPtr = null;
            byte[] formatBytes;
            if (!string.IsNullOrEmpty(format))
            {
                formatBytes = Encoding.UTF8.GetBytes(format + "\0"); // Add null terminator
                fixed (byte* ptr = formatBytes)
                {
                    formatPtr = ptr;
                }
            }

            // Use InputScalar instead of InputText - this handles the data type conversion automatically
            if (ImGui.InputScalar($"##input", dataType, dataPtr, null, null, formatPtr, flags))
            {
                valueChanged = true;
            }

            // Step buttons
            var backupFramePadding = style.FramePadding;
            style.FramePadding.X = style.FramePadding.Y;

            bool isReadOnly = (flags & ImGuiInputTextFlags.ReadOnly) != 0;
            ImGui.SameLine(0, style.ItemInnerSpacing.X);

            // Custom arrow button layout - replicating the original C++ behavior
            float frameHeight = ImGui.GetFrameHeight();
            float arrowSize = (float)Math.Floor(frameHeight * 0.45f);
            float arrowSpacing = frameHeight - 2.0f * arrowSize;

            ImGui.BeginGroup();
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(style.ItemSpacing.X, arrowSpacing));

            ImGui.BeginDisabled(isReadOnly);

            var buttonSize2 = new Vector2(arrowSize, arrowSize);

            var orgFontSize = ImGui.GetDrawListSharedData().FontSize;
            ImGui.GetDrawListSharedData().FontSize = arrowSize;

            // Up arrow button
            if (ImGuiP.ArrowButtonEx("##up", ImGuiDir.Up, buttonSize2))
            {
                void* stepToUse = (ImGui.GetIO().KeyCtrl && stepFast != null) ? stepFast : step;
                DataTypeApplyOp(dataType, '+', dataPtr, dataPtr, stepToUse);
                valueChanged = true;
            }

            // Down arrow button
            if (ImGuiP.ArrowButtonEx("##down", ImGuiDir.Down, buttonSize2))
            {
                void* stepToUse = (ImGui.GetIO().KeyCtrl && stepFast != null) ? stepFast : step;
                DataTypeApplyOp(dataType, '-', dataPtr, dataPtr, stepToUse);
                valueChanged = true;
            }
            ImGui.GetDrawListSharedData().FontSize = orgFontSize;

            ImGui.EndDisabled();
            ImGui.PopStyleVar(1);
            ImGui.EndGroup();

            // Render label if provided
            if (!string.IsNullOrEmpty(label))
            {
                ImGui.SameLine(0, style.ItemInnerSpacing.X);
                ImGui.Text(label);
            }

            style.FramePadding = backupFramePadding;
            ImGui.PopID();
            ImGui.EndGroup();
        }
        else
        {
            byte* formatPtr = null;
            byte[] formatBytes;
            if (!string.IsNullOrEmpty(format))
            {
                formatBytes = Encoding.UTF8.GetBytes(format + "\0");
                fixed (byte* ptr = formatBytes)
                {
                    formatPtr = ptr;
                }
            }

            if (ImGui.InputScalar(label, dataType, dataPtr, null, null, formatPtr, flags))
            {
                valueChanged = true;
            }
        }

        if (valueChanged)
        {
            ImGuiP.MarkItemEdited(ImGui.GetItemID());
        }

        return valueChanged;
    }

    /// <summary>
    /// Overload for integer values with default step of 1
    /// </summary>
    /// <param name="label">The label for the widget</param>
    /// <param name="value">Reference to the integer value</param>
    /// <param name="step">Step value for increment/decrement (default: 1)</param>
    /// <param name="stepFast">Fast step value when Ctrl is held (default: 10)</param>
    /// <param name="format">Format string for display (default: "%d")</param>
    /// <param name="flags">Input text flags</param>
    /// <returns>True if the value was changed</returns>
    public static unsafe bool SpinScaler(string label, ref int value, int step = 1, int stepFast = 10,
        string format = "%d", ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
    {
        fixed (int* valuePtr = &value)
        {
            return SpinScaler(label, ImGuiDataType.S32, valuePtr, &step, &stepFast, format, flags);
        }
    }

    /// <summary>
    /// Overload for float values with default step of 0.1
    /// </summary>
    /// <param name="label">The label for the widget</param>
    /// <param name="value">Reference to the float value</param>
    /// <param name="step">Step value for increment/decrement (default: 0.1f)</param>
    /// <param name="stepFast">Fast step value when Ctrl is held (default: 1.0f)</param>
    /// <param name="format">Format string for display (default: "%.3f")</param>
    /// <param name="flags">Input text flags</param>
    /// <returns>True if the value was changed</returns>
    public static unsafe bool SpinScaler(string label, ref float value, float step = 0.1f, float stepFast = 1.0f,
        string format = "%.3f", ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
    {
        fixed (float* valuePtr = &value)
        {
            return SpinScaler(label, ImGuiDataType.Float, valuePtr, &step, &stepFast, format, flags);
        }
    }

    /// <summary>
    /// Overload for double values with default step of 0.1
    /// </summary>
    /// <param name="label">The label for the widget</param>
    /// <param name="value">Reference to the double value</param>
    /// <param name="step">Step value for increment/decrement (default: 0.1)</param>
    /// <param name="stepFast">Fast step value when Ctrl is held (default: 1.0)</param>
    /// <param name="format">Format string for display (default: "%.6f")</param>
    /// <param name="flags">Input text flags</param>
    /// <returns>True if the value was changed</returns>
    public static unsafe bool SpinScaler(string label, ref double value, double step = 0.1, double stepFast = 1.0,
        string format = "%.6f", ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
    {
        fixed (double* valuePtr = &value)
        {
            return SpinScaler(label, ImGuiDataType.Double, valuePtr, &step, &stepFast, format, flags);
        }
    }

    // Helper method for applying operations to different data types
    private static unsafe void DataTypeApplyOp(ImGuiDataType dataType, char op, void* output, void* arg1, void* arg2)
    {
        switch (dataType)
        {
            case ImGuiDataType.S8:
                sbyte val1_s8 = *(sbyte*)arg1;
                sbyte val2_s8 = *(sbyte*)arg2;
                *(sbyte*)output = (sbyte)(op == '+' ? val1_s8 + val2_s8 : val1_s8 - val2_s8);
                break;
            case ImGuiDataType.U8:
                byte val1_u8 = *(byte*)arg1;
                byte val2_u8 = *(byte*)arg2;
                *(byte*)output = (byte)(op == '+' ? val1_u8 + val2_u8 : val1_u8 - val2_u8);
                break;
            case ImGuiDataType.S16:
                short val1_s16 = *(short*)arg1;
                short val2_s16 = *(short*)arg2;
                *(short*)output = (short)(op == '+' ? val1_s16 + val2_s16 : val1_s16 - val2_s16);
                break;
            case ImGuiDataType.U16:
                ushort val1_u16 = *(ushort*)arg1;
                ushort val2_u16 = *(ushort*)arg2;
                *(ushort*)output = (ushort)(op == '+' ? val1_u16 + val2_u16 : val1_u16 - val2_u16);
                break;
            case ImGuiDataType.S32:
                int val1_s32 = *(int*)arg1;
                int val2_s32 = *(int*)arg2;
                *(int*)output = op == '+' ? val1_s32 + val2_s32 : val1_s32 - val2_s32;
                break;
            case ImGuiDataType.U32:
                uint val1_u32 = *(uint*)arg1;
                uint val2_u32 = *(uint*)arg2;
                *(uint*)output = op == '+' ? val1_u32 + val2_u32 : val1_u32 - val2_u32;
                break;
            case ImGuiDataType.S64:
                long val1_s64 = *(long*)arg1;
                long val2_s64 = *(long*)arg2;
                *(long*)output = op == '+' ? val1_s64 + val2_s64 : val1_s64 - val2_s64;
                break;
            case ImGuiDataType.U64:
                ulong val1_u64 = *(ulong*)arg1;
                ulong val2_u64 = *(ulong*)arg2;
                *(ulong*)output = op == '+' ? val1_u64 + val2_u64 : val1_u64 - val2_u64;
                break;
            case ImGuiDataType.Float:
                float val1_f = *(float*)arg1;
                float val2_f = *(float*)arg2;
                *(float*)output = op == '+' ? val1_f + val2_f : val1_f - val2_f;
                break;
            case ImGuiDataType.Double:
                double val1_d = *(double*)arg1;
                double val2_d = *(double*)arg2;
                *(double*)output = op == '+' ? val1_d + val2_d : val1_d - val2_d;
                break;
        }
    }
}
