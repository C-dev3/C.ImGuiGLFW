using System.Runtime.InteropServices;
using System.Text;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    public static ImGuiIOPtr IO => ImGui.GetIO();
    public static ref ImGuiConfigFlags ConfigFlags => ref IO.ConfigFlags;
    public static ref ImGuiBackendFlags BackendFlags => ref IO.BackendFlags;
    public static ref Vector2 DisplaySize => ref IO.DisplaySize;
    public static ref Vector2 DisplayFrameBufferScale => ref IO.DisplayFramebufferScale;
    public static ref float DeltaTime => ref IO.DeltaTime;
    public static ref float IniSavingRate => ref IO.IniSavingRate;
    public static unsafe string IniFileName
    {
        get
        {
            byte* ptr = IO.IniFilename;
            if (ptr == null) return string.Empty;
            return Marshal.PtrToStringUTF8((IntPtr)ptr) ?? string.Empty;
        }
        set
        {
            var io = IO.Handle;
            if (string.IsNullOrEmpty(value))
            {
                io->IniFilename = null;
                return;
            }
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(value);
            IntPtr ptr = Marshal.AllocHGlobal(utf8Bytes.Length);
            Marshal.Copy(utf8Bytes, 0, ptr, utf8Bytes.Length);
            Marshal.WriteByte(ptr, utf8Bytes.Length, 0);
            io->IniFilename = (byte*)ptr;
        }
    }
    public static unsafe string LogFilename
    {
        get
        {
            byte* ptr = IO.LogFilename;
            if (ptr == null) return string.Empty;
            return Marshal.PtrToStringUTF8((IntPtr)ptr) ?? string.Empty;
        }
        set
        {
            var io = IO.Handle;
            if (string.IsNullOrEmpty(value))
            {
                io->LogFilename = null;
                return;
            }
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(value);
            IntPtr ptr = Marshal.AllocHGlobal(utf8Bytes.Length);
            Marshal.Copy(utf8Bytes, 0, ptr, utf8Bytes.Length);
            Marshal.WriteByte(ptr, utf8Bytes.Length, 0);
            io->LogFilename = (byte*)ptr;
        }
    }
    public static ref ImFontAtlasPtr Fonts => ref IO.Fonts;
    public static ref ImFontPtr FontsDefault => ref IO.FontDefault;
    public static ref bool FontAllowUserScaling => ref IO.FontAllowUserScaling;
    public static ref bool ConfigNavSwapGamepadButtons => ref IO.ConfigNavSwapGamepadButtons;
    public static ref bool ConfigNavMoveSetMousePos => ref IO.ConfigNavMoveSetMousePos;
    public static ref bool ConfigNavCaptureKeyboard => ref IO.ConfigNavCaptureKeyboard;
    public static ref bool ConfigNavEscapeClearFocusItem => ref IO.ConfigNavEscapeClearFocusItem;
    public static ref bool ConfigNavEscapeClearFocusWindow => ref IO.ConfigNavEscapeClearFocusWindow;
    public static ref bool ConfigNavCursorVisibleAuto => ref IO.ConfigNavCursorVisibleAuto;
    public static ref bool ConfigNavCursorVisibleAlways => ref IO.ConfigNavCursorVisibleAlways;
    public static ref bool ConfigDockingNoSplit => ref IO.ConfigDockingNoSplit;
    public static ref bool ConfigDockingWithShift => ref IO.ConfigDockingWithShift;
    public static ref bool ConfigDockingAlwaysTabBar => ref IO.ConfigDockingAlwaysTabBar;
    public static ref bool ConfigDockingTransparentPayload => ref IO.ConfigDockingTransparentPayload;
    public static ref bool ConfigViewportsNoAutoMerge => ref IO.ConfigViewportsNoAutoMerge;
    public static ref bool ConfigViewportsNoTaskBarIcon => ref IO.ConfigViewportsNoTaskBarIcon;
    public static ref bool ConfigViewportsNoDecoration => ref IO.ConfigViewportsNoDecoration;
    public static ref bool ConfigViewportsNoDefaultParent => ref IO.ConfigViewportsNoDefaultParent;
    public static ref bool ConfigDpiScaleFonts => ref IO.ConfigDpiScaleFonts;
    public static ref bool ConfigDpiScaleViewports => ref IO.ConfigDpiScaleViewports;
    public static ref bool MouseDrawCursor => ref IO.MouseDrawCursor;
    public static ref bool ConfigMacOSXBehaviors => ref IO.ConfigMacOSXBehaviors;
    public static ref bool ConfigInputTrickleEventQueue => ref IO.ConfigInputTrickleEventQueue;
    public static ref bool ConfigInputTextCursorBlink => ref IO.ConfigInputTextCursorBlink;
    public static ref bool ConfigInputTextEnterKeepActive => ref IO.ConfigInputTextEnterKeepActive;
    public static ref bool ConfigDragClickToInputText => ref IO.ConfigDragClickToInputText;
    public static ref bool ConfigWindowsResizeFromEdges => ref IO.ConfigWindowsResizeFromEdges;
    public static ref bool ConfigWindowsMoveFromTitleBarOnly => ref IO.ConfigWindowsMoveFromTitleBarOnly;
    public static ref bool ConfigWindowsCopyContentsWithCtrlC => ref IO.ConfigWindowsCopyContentsWithCtrlC;
    public static ref bool ConfigScrollbarScrollByPage => ref IO.ConfigScrollbarScrollByPage;
    public static ref float ConfigMemoryCompactTimer => ref IO.ConfigMemoryCompactTimer;
    public static ref float MouseDoubleClickTime => ref IO.MouseDoubleClickTime;
    public static ref float MouseDoubleClickMaxDist => ref IO.MouseDoubleClickMaxDist;
    public static ref float MouseDragThreshold => ref IO.MouseDragThreshold;
    public static ref float KeyRepeatDelay => ref IO.KeyRepeatDelay;
    public static ref float KeyRepeatRate => ref IO.KeyRepeatRate;
    public static ref bool ConfigErrorRecovery => ref IO.ConfigErrorRecovery;
    public static ref bool ConfigErrorRecoveryEnableAssert => ref IO.ConfigErrorRecoveryEnableAssert;
    public static ref bool ConfigErrorRecoveryEnableDebugLog => ref IO.ConfigErrorRecoveryEnableDebugLog;
    public static ref bool ConfigErrorRecoveryEnableTooltip => ref IO.ConfigErrorRecoveryEnableTooltip;
    public static ref bool ConfigDebugIsDebuggerPresent => ref IO.ConfigDebugIsDebuggerPresent;
    public static ref bool ConfigDebugHighlightIdConflicts => ref IO.ConfigDebugHighlightIdConflicts;
    public static ref bool ConfigDebugHighlightIdConflictsShowItemPicker => ref IO.ConfigDebugHighlightIdConflictsShowItemPicker;
    public static ref bool ConfigDebugBeginReturnValueOnce => ref IO.ConfigDebugBeginReturnValueOnce;
    public static ref bool ConfigDebugBeginReturnValueLoop => ref IO.ConfigDebugBeginReturnValueLoop;
    public static ref bool ConfigDebugIgnoreFocusLoss => ref IO.ConfigDebugIgnoreFocusLoss;
    public static ref bool ConfigDebugIniSettings => ref IO.ConfigDebugIniSettings;
    public static unsafe string BackendPlatformName
    {
        get
        {
            byte* ptr = IO.BackendPlatformName;
            if (ptr == null) return string.Empty;
            return Marshal.PtrToStringUTF8((IntPtr)ptr) ?? string.Empty;
        }
        set
        {
            var io = IO.Handle;
            if (string.IsNullOrEmpty(value))
            {
                io->BackendPlatformName = null;
                return;
            }
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(value);
            IntPtr ptr = Marshal.AllocHGlobal(utf8Bytes.Length);
            Marshal.Copy(utf8Bytes, 0, ptr, utf8Bytes.Length);
            Marshal.WriteByte(ptr, utf8Bytes.Length, 0);
            io->BackendPlatformName = (byte*)ptr;
        }
    }
    public static unsafe string BackendRendererName
    {
        get
        {
            byte* ptr = IO.BackendRendererName;
            if (ptr == null) return string.Empty;
            return Marshal.PtrToStringUTF8((IntPtr)ptr) ?? string.Empty;
        }
        set
        {
            var io = IO.Handle;
            if (string.IsNullOrEmpty(value))
            {
                io->BackendRendererName = null;
                return;
            }
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(value);
            IntPtr ptr = Marshal.AllocHGlobal(utf8Bytes.Length);
            Marshal.Copy(utf8Bytes, 0, ptr, utf8Bytes.Length);
            Marshal.WriteByte(ptr, utf8Bytes.Length, 0);
            io->BackendRendererName = (byte*)ptr;
        }
    }
    public static ref bool WantCaptureMouse => ref IO.WantCaptureMouse;
    public static ref bool WantCaptureKeyboard => ref IO.WantCaptureKeyboard;
    public static ref bool WantTextInput => ref IO.WantTextInput;
    public static ref bool WantSetMousePos => ref IO.WantSetMousePos;
    public static ref bool WantSaveIniSettings => ref IO.WantSaveIniSettings;
    public static ref bool NavActive => ref IO.NavActive;
    public static ref bool NavVisible => ref IO.NavVisible;
    public static ref float Framerate => ref IO.Framerate;
    public static ref int MetricsRenderVertices => ref IO.MetricsRenderVertices;
    public static ref int MetricsRenderIndices => ref IO.MetricsRenderIndices;
    public static ref int MetricsRenderWindows => ref IO.MetricsRenderWindows;
    public static ref int MetricsActiveWindows => ref IO.MetricsActiveWindows;
    public static ref Vector2 MouseDelta => ref IO.MouseDelta;
    public static ref ImGuiContextPtr Ctx => ref IO.Ctx;
    public static ref Vector2 MousePos => ref IO.MousePos;
    public static Span<bool> MouseDown => IO.MouseDown;
    public static ref float MouseWheel => ref IO.MouseWheel;
    public static ref float MouseWheelH => ref IO.MouseWheelH;
    public static ref ImGuiMouseSource MouseSource => ref IO.MouseSource;
    public static ref uint MouseHoveredViewport => ref IO.MouseHoveredViewport;
    public static ref bool KeyCtrl => ref IO.KeyCtrl;
    public static ref bool KeyShift => ref IO.KeyShift;
    public static ref bool KeyAlt => ref IO.KeyAlt;
    public static ref bool KeySuper => ref IO.KeySuper;
    public static ref int KeyMods => ref IO.KeyMods;
    public static Span<ImGuiKeyData> KeysData => IO.KeysData;
    public static ref bool WantCaptureMouseUnlessPopupClose => ref IO.WantCaptureMouseUnlessPopupClose;
    public static ref Vector2 MousePosPrev => ref IO.MousePosPrev;
    public static Span<Vector2> MouseClickedPos => IO.MouseClickedPos;
    public static Span<double> MouseClickedTime => IO.MouseClickedTime;
    public static Span<bool> MouseClicked => IO.MouseClicked;
    public static Span<bool> MouseDoubleClicked => IO.MouseDoubleClicked;
    public static Span<ushort> MouseClickedCount => IO.MouseClickedCount;
    public static Span<ushort> MouseClickedLastCount => IO.MouseClickedLastCount;
    public static Span<bool> MouseReleased => IO.MouseReleased;
    public static Span<double> MouseReleasedTime => IO.MouseReleasedTime;
    public static Span<bool> MouseDownOwned => IO.MouseDownOwned;
    public static Span<bool> MouseDownOwnedUnlessPopupClose => IO.MouseDownOwnedUnlessPopupClose;
    public static ref bool MouseWheelRequestAxisSwap => ref IO.MouseWheelRequestAxisSwap;
    public static ref bool MouseCtrlLeftAsRightClick => ref IO.MouseCtrlLeftAsRightClick;
    public static Span<float> MouseDownDuration => IO.MouseDownDuration;
    public static Span<float> MouseDownDurationPrev => IO.MouseDownDurationPrev;
    public static Span<Vector2> MouseDragMaxDistanceAbs => IO.MouseDragMaxDistanceAbs;
    public static Span<float> MouseDragMaxDistanceSqr => IO.MouseDragMaxDistanceSqr;
    public static ref float PenPressure => ref IO.PenPressure;
    public static ref bool AppFocusLost => ref IO.AppFocusLost;
    public static ref bool AppAcceptingEvents => ref IO.AppAcceptingEvents;
    public static ref ushort InputQueueSurrogate => ref IO.InputQueueSurrogate;
    public static ref ImVector<uint> InputQueueCharacters => ref IO.InputQueueCharacters;
    public static void AddFocusEvent(bool focused) => IO.AddFocusEvent(focused);
    public static void AddInputCharacter(uint c) => IO.AddInputCharacter(c);
    public static void AddInputCharactersUTF8(ReadOnlySpan<byte> str) => IO.AddInputCharactersUTF8(str);
    public static void AddInputCharactersUTF8(string str) => IO.AddInputCharactersUTF8(str);
    public static void AddInputCharacterUTF16(ushort c) => IO.AddInputCharacterUTF16(c);
    public static void AddKeyAnalogEvent(ImGuiKey key, bool down, float v) => IO.AddKeyAnalogEvent(key, down, v);
    public static void AddKeyEvent(ImGuiKey key, bool down) => IO.AddKeyEvent(key, down);
    public static void AddMouseButtonEvent(int button, bool down) => IO.AddMouseButtonEvent(button, down);
    public static void AddMousePosEvent(float x, float y) => IO.AddMousePosEvent(x, y);
    public static void AddMouseSourceEvent(ImGuiMouseSource source) => IO.AddMouseSourceEvent(source);
    public static void AddMouseViewportEvent(uint id) => IO.AddMouseViewportEvent(id);
    public static void AddMouseWheelEvent(float wheelX, float wheelY) => IO.AddMouseWheelEvent(wheelX, wheelY);
    public static void ClearEventQueue() => IO.ClearEventsQueue();
    public static void ClearInputKeys() => IO.ClearInputKeys();
    public static void ClearInputMouse() => IO.ClearInputMouse();
    public static void Destroy() => IO.Destroy();
    public static void SetAppAcceptingEvents(bool acceptingEvents) => IO.SetAppAcceptingEvents(acceptingEvents);
    public static void SetKeyEventNativeData(ImGuiKey key, int nativeKeycode, int nativeScancode, int nativeLegacyIndex) => IO.SetKeyEventNativeData(key, nativeKeycode, nativeScancode, nativeLegacyIndex);
    public static void SetKeyEventNativeData(ImGuiKey key, int nativeKeycode, int nativeScancode) => IO.SetKeyEventNativeData(key, nativeKeycode, nativeScancode);
}
