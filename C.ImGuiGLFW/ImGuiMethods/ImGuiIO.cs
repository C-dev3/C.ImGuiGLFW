using System.Runtime.InteropServices;
using System.Text;

namespace C.ImGuiGLFW.ImGuiMethods;

public static partial class ImGuiC
{
    /// <summary>
    /// Gets the ImGui IO object that contains all input/output related configuration and state.
    /// </summary>
    /// <remarks>
    /// This property provides direct access to ImGui's main IO structure, which contains
    /// configuration flags, input state, display information, and various settings that
    /// control ImGui's behavior.
    /// </remarks>
    public static ImGuiIOPtr IO => ImGui.GetIO();

    /// <summary>
    /// Gets a reference to the configuration flags that control ImGui's main features.
    /// </summary>
    /// <remarks>
    /// Configuration flags control major ImGui features such as navigation, docking, viewports,
    /// and DPI awareness. These flags are typically set during application initialization
    /// and affect the overall behavior of the ImGui system.
    /// </remarks>
    public static ref ImGuiConfigFlags ConfigFlags => ref IO.ConfigFlags;

    /// <summary>
    /// Gets a reference to the backend capability flags set by the platform and renderer backends.
    /// </summary>
    /// <remarks>
    /// Backend flags indicate what features are supported by the current platform and renderer
    /// backends. These are typically set by the backend implementation and should not be
    /// modified by user code.
    /// </remarks>
    public static ref ImGuiBackendFlags BackendFlags => ref IO.BackendFlags;

    /// <summary>
    /// Gets a reference to the display size in pixels.
    /// </summary>
    /// <remarks>
    /// This represents the size of the main display/window in pixels. It's typically set by
    /// the platform backend during window resize events and is used by ImGui for layout
    /// calculations and clipping.
    /// </remarks>
    public static ref Vector2 DisplaySize => ref IO.DisplaySize;

    /// <summary>
    /// Gets a reference to the display framebuffer scale factor.
    /// </summary>
    /// <remarks>
    /// This scale factor accounts for high-DPI displays where the framebuffer resolution
    /// may be different from the window size in screen coordinates. It's typically set
    /// by the platform backend and used for proper rendering on retina/high-DPI displays.
    /// </remarks>
    public static ref Vector2 DisplayFrameBufferScale => ref IO.DisplayFramebufferScale;

    /// <summary>
    /// Gets a reference to the time elapsed during the last frame in seconds.
    /// </summary>
    /// <remarks>
    /// Delta time is used by ImGui for animations, input timing, and other time-based
    /// calculations. It should be updated each frame by the main application loop.
    /// </remarks>
    public static ref float DeltaTime => ref IO.DeltaTime;

    /// <summary>
    /// Gets a reference to the minimum time between INI file saves in seconds.
    /// </summary>
    /// <remarks>
    /// This setting controls how frequently ImGui automatically saves its configuration
    /// to the INI file. A higher value reduces disk I/O but may result in some settings
    /// being lost if the application crashes.
    /// </remarks>
    public static ref float IniSavingRate => ref IO.IniSavingRate;

    /// <summary>
    /// Gets or sets the path to the INI settings file.
    /// </summary>
    /// <remarks>
    /// The INI file is used to persist window positions, sizes, and other user interface
    /// settings between application sessions. Setting this to null or empty disables
    /// INI file functionality. The file is automatically loaded on startup and saved
    /// when settings change.
    /// </remarks>
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

    /// <summary>
    /// Gets or sets the path to the log file for debug output.
    /// </summary>
    /// <remarks>
    /// When set, ImGui will write debug information and logging output to this file.
    /// This is primarily used for debugging purposes and performance analysis.
    /// Setting this to null or empty disables log file output.
    /// </remarks>
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

    /// <summary>
    /// Gets a reference to the font atlas that manages all loaded fonts.
    /// </summary>
    /// <remarks>
    /// The font atlas contains all fonts loaded into ImGui and manages texture generation
    /// for font rendering. Fonts must be loaded before the first frame is rendered.
    /// </remarks>
    public static ref ImFontAtlasPtr Fonts => ref IO.Fonts;

    /// <summary>
    /// Gets a reference to the default font used when no other font is specified.
    /// </summary>
    /// <remarks>
    /// This is automatically set to the first font in the font atlas, or a built-in
    /// pixel-perfect font if no fonts are loaded. It's used as the fallback font
    /// for all text rendering.
    /// </remarks>
    public static ref ImFontPtr FontsDefault => ref IO.FontDefault;

    /// <summary>
    /// Gets a reference to the flag that controls whether users can scale fonts with Ctrl+Mouse Wheel.
    /// </summary>
    /// <remarks>
    /// When enabled, users can zoom the font size up and down using Ctrl+Mouse Wheel.
    /// This affects the global font scale and is applied to all text rendering.
    /// </remarks>
    public static ref bool FontAllowUserScaling => ref IO.FontAllowUserScaling;

    /// <summary>
    /// Gets a reference to the flag that controls whether gamepad face buttons are swapped for navigation.
    /// </summary>
    /// <remarks>
    /// When enabled, swaps the A/B and X/Y gamepad buttons for navigation purposes.
    /// This is useful for accommodating different gamepad conventions across regions.
    /// </remarks>
    public static ref bool ConfigNavSwapGamepadButtons => ref IO.ConfigNavSwapGamepadButtons;

    /// <summary>
    /// Gets a reference to the flag that controls whether navigation moves set the mouse position.
    /// </summary>
    /// <remarks>
    /// When enabled, keyboard/gamepad navigation will also move the mouse cursor to
    /// the focused item. This can provide better visual feedback but may interfere
    /// with mouse usage.
    /// </remarks>
    public static ref bool ConfigNavMoveSetMousePos => ref IO.ConfigNavMoveSetMousePos;

    /// <summary>
    /// Gets a reference to the flag that controls whether navigation captures keyboard input.
    /// </summary>
    /// <remarks>
    /// When enabled, keyboard navigation will capture keyboard input events, preventing
    /// them from being processed by other systems. This should be enabled for proper
    /// keyboard navigation support.
    /// </remarks>
    public static ref bool ConfigNavCaptureKeyboard => ref IO.ConfigNavCaptureKeyboard;

    /// <summary>
    /// Gets a reference to the flag that controls whether Escape clears the focused item.
    /// </summary>
    /// <remarks>
    /// When enabled, pressing Escape will clear focus from the currently focused item,
    /// allowing for easy focus management in navigation scenarios.
    /// </remarks>
    public static ref bool ConfigNavEscapeClearFocusItem => ref IO.ConfigNavEscapeClearFocusItem;

    /// <summary>
    /// Gets a reference to the flag that controls whether Escape clears window focus.
    /// </summary>
    /// <remarks>
    /// When enabled, pressing Escape will clear focus from the current window,
    /// which can be useful for modal dialog management and window navigation.
    /// </remarks>
    public static ref bool ConfigNavEscapeClearFocusWindow => ref IO.ConfigNavEscapeClearFocusWindow;

    /// <summary>
    /// Gets a reference to the flag that controls automatic navigation cursor visibility.
    /// </summary>
    /// <remarks>
    /// When enabled, the navigation cursor is automatically shown when using keyboard/gamepad
    /// navigation and hidden when using mouse input. This provides intuitive visual feedback.
    /// </remarks>
    public static ref bool ConfigNavCursorVisibleAuto => ref IO.ConfigNavCursorVisibleAuto;

    /// <summary>
    /// Gets a reference to the flag that controls whether the navigation cursor is always visible.
    /// </summary>
    /// <remarks>
    /// When enabled, the navigation cursor remains visible at all times during navigation,
    /// regardless of input method. This can be useful for accessibility or debugging.
    /// </remarks>
    public static ref bool ConfigNavCursorVisibleAlways => ref IO.ConfigNavCursorVisibleAlways;

    /// <summary>
    /// Gets a reference to the flag that disables docking node splitting.
    /// </summary>
    /// <remarks>
    /// When enabled, prevents users from creating new docking splits within existing
    /// dock nodes. Existing docked windows can still be rearranged within their nodes.
    /// </remarks>
    public static ref bool ConfigDockingNoSplit => ref IO.ConfigDockingNoSplit;

    /// <summary>
    /// Gets a reference to the flag that requires holding Shift for docking operations.
    /// </summary>
    /// <remarks>
    /// When enabled, users must hold the Shift key while dragging windows to enable
    /// docking functionality. This prevents accidental docking during normal window movement.
    /// </remarks>
    public static ref bool ConfigDockingWithShift => ref IO.ConfigDockingWithShift;

    /// <summary>
    /// Gets a reference to the flag that forces tab bars on all dock nodes.
    /// </summary>
    /// <remarks>
    /// When enabled, dock nodes always display tab bars even when containing only
    /// a single window. This provides consistent visual appearance across all dock nodes.
    /// </remarks>
    public static ref bool ConfigDockingAlwaysTabBar => ref IO.ConfigDockingAlwaysTabBar;

    /// <summary>
    /// Gets a reference to the flag that enables transparent payloads during docking.
    /// </summary>
    /// <remarks>
    /// When enabled, drag payloads (the visual representation of dragged content)
    /// are rendered with transparency during docking operations, providing better
    /// visual feedback of the target location.
    /// </remarks>
    public static ref bool ConfigDockingTransparentPayload => ref IO.ConfigDockingTransparentPayload;

    /// <summary>
    /// Gets a reference to the flag that prevents automatic viewport merging.
    /// </summary>
    /// <remarks>
    /// When enabled, prevents ImGui from automatically merging viewports back into
    /// the main viewport when they could be consolidated. This maintains viewport
    /// separation even when it might not be necessary.
    /// </remarks>
    public static ref bool ConfigViewportsNoAutoMerge => ref IO.ConfigViewportsNoAutoMerge;

    /// <summary>
    /// Gets a reference to the flag that prevents taskbar icons for secondary viewports.
    /// </summary>
    /// <remarks>
    /// When enabled, secondary viewports (windows outside the main viewport) will not
    /// create separate taskbar icons. This keeps the taskbar cleaner for multi-viewport
    /// applications.
    /// </remarks>
    public static ref bool ConfigViewportsNoTaskBarIcon => ref IO.ConfigViewportsNoTaskBarIcon;

    /// <summary>
    /// Gets a reference to the flag that disables window decorations on secondary viewports.
    /// </summary>
    /// <remarks>
    /// When enabled, secondary viewports are created without standard window decorations
    /// (title bars, borders, etc.), creating a more seamless multi-window experience.
    /// </remarks>
    public static ref bool ConfigViewportsNoDecoration => ref IO.ConfigViewportsNoDecoration;

    /// <summary>
    /// Gets a reference to the flag that prevents using the main viewport as parent for secondary viewports.
    /// </summary>
    /// <remarks>
    /// When enabled, secondary viewports are not parented to the main viewport window,
    /// which can affect window management and behavior on some platforms.
    /// </remarks>
    public static ref bool ConfigViewportsNoDefaultParent => ref IO.ConfigViewportsNoDefaultParent;

    /// <summary>
    /// Gets a reference to the flag that enables font scaling based on DPI.
    /// </summary>
    /// <remarks>
    /// When enabled, fonts are automatically scaled based on the display DPI,
    /// ensuring consistent text size across different display densities.
    /// </remarks>
    public static ref bool ConfigDpiScaleFonts => ref IO.ConfigDpiScaleFonts;

    /// <summary>
    /// Gets a reference to the flag that enables viewport scaling based on DPI.
    /// </summary>
    /// <remarks>
    /// When enabled, entire viewports are scaled based on DPI, ensuring consistent
    /// UI element sizes across different display densities.
    /// </remarks>
    public static ref bool ConfigDpiScaleViewports => ref IO.ConfigDpiScaleViewports;

    /// <summary>
    /// Gets a reference to the flag that controls whether ImGui draws the mouse cursor.
    /// </summary>
    /// <remarks>
    /// When enabled, ImGui will draw its own mouse cursor instead of using the
    /// system cursor. This is useful when the system cursor needs to be hidden
    /// or when custom cursor rendering is required.
    /// </remarks>
    public static ref bool MouseDrawCursor => ref IO.MouseDrawCursor;

    /// <summary>
    /// Gets a reference to the flag that enables macOS-specific behaviors.
    /// </summary>
    /// <remarks>
    /// When enabled, ImGui adopts macOS-specific behaviors such as different
    /// keyboard shortcuts (Cmd instead of Ctrl) and other platform conventions.
    /// </remarks>
    public static ref bool ConfigMacOSXBehaviors => ref IO.ConfigMacOSXBehaviors;

    /// <summary>
    /// Gets a reference to the flag that enables event queue trickling for input processing.
    /// </summary>
    /// <remarks>
    /// When enabled, input events are processed gradually over multiple frames
    /// instead of all at once, which can help prevent input lag in some scenarios.
    /// </remarks>
    public static ref bool ConfigInputTrickleEventQueue => ref IO.ConfigInputTrickleEventQueue;

    /// <summary>
    /// Gets a reference to the flag that controls text cursor blinking.
    /// </summary>
    /// <remarks>
    /// When enabled, text input cursors will blink at regular intervals.
    /// Disabling this creates a solid, non-blinking cursor.
    /// </remarks>
    public static ref bool ConfigInputTextCursorBlink => ref IO.ConfigInputTextCursorBlink;

    /// <summary>
    /// Gets a reference to the flag that keeps text input active after pressing Enter.
    /// </summary>
    /// <remarks>
    /// When enabled, text input fields remain active and focused after the user
    /// presses Enter, allowing for continuous text entry without re-focusing.
    /// </remarks>
    public static ref bool ConfigInputTextEnterKeepActive => ref IO.ConfigInputTextEnterKeepActive;

    /// <summary>
    /// Gets a reference to the flag that allows clicking and dragging to select text input.
    /// </summary>
    /// <remarks>
    /// When enabled, users can click and drag on drag controls to directly input
    /// text values, providing an alternative input method for numeric controls.
    /// </remarks>
    public static ref bool ConfigDragClickToInputText => ref IO.ConfigDragClickToInputText;

    /// <summary>
    /// Gets a reference to the flag that enables window resizing from edges.
    /// </summary>
    /// <remarks>
    /// When enabled, windows can be resized by dragging from their edges in addition
    /// to corner handles, providing more resize options for better usability.
    /// </remarks>
    public static ref bool ConfigWindowsResizeFromEdges => ref IO.ConfigWindowsResizeFromEdges;

    /// <summary>
    /// Gets a reference to the flag that restricts window movement to title bars only.
    /// </summary>
    /// <remarks>
    /// When enabled, windows can only be moved by dragging their title bars,
    /// preventing accidental window movement when clicking elsewhere in the window.
    /// </remarks>
    public static ref bool ConfigWindowsMoveFromTitleBarOnly => ref IO.ConfigWindowsMoveFromTitleBarOnly;

    /// <summary>
    /// Gets a reference to the flag that enables copying window contents with Ctrl+C.
    /// </summary>
    /// <remarks>
    /// When enabled, pressing Ctrl+C will copy the visible contents of the focused
    /// window to the clipboard, which can be useful for debugging or documentation.
    /// </remarks>
    public static ref bool ConfigWindowsCopyContentsWithCtrlC => ref IO.ConfigWindowsCopyContentsWithCtrlC;

    /// <summary>
    /// Gets a reference to the flag that controls scrollbar behavior.
    /// </summary>
    /// <remarks>
    /// When enabled, clicking on scrollbar tracks scrolls by full pages instead
    /// of single steps, providing faster navigation through long content.
    /// </remarks>
    public static ref bool ConfigScrollbarScrollByPage => ref IO.ConfigScrollbarScrollByPage;

    /// <summary>
    /// Gets a reference to the timer interval for memory compaction in seconds.
    /// </summary>
    /// <remarks>
    /// Controls how frequently ImGui performs memory compaction to reduce
    /// memory fragmentation. A value of 0.0 disables automatic compaction.
    /// </remarks>
    public static ref float ConfigMemoryCompactTimer => ref IO.ConfigMemoryCompactTimer;

    /// <summary>
    /// Gets a reference to the maximum time between mouse clicks to register as a double-click.
    /// </summary>
    /// <remarks>
    /// Defines the time window in seconds during which two consecutive mouse clicks
    /// are considered a double-click. Typical values range from 0.3 to 0.5 seconds.
    /// </remarks>
    public static ref float MouseDoubleClickTime => ref IO.MouseDoubleClickTime;

    /// <summary>
    /// Gets a reference to the maximum distance between mouse clicks to register as a double-click.
    /// </summary>
    /// <remarks>
    /// Defines the maximum distance in pixels that the mouse can move between clicks
    /// while still registering as a double-click. This accounts for minor hand tremor.
    /// </remarks>
    public static ref float MouseDoubleClickMaxDist => ref IO.MouseDoubleClickMaxDist;

    /// <summary>
    /// Gets a reference to the distance threshold before mouse dragging is detected.
    /// </summary>
    /// <remarks>
    /// Defines how far the mouse must move in pixels before a drag operation is
    /// initiated. This prevents accidental dragging from minor mouse movements.
    /// </remarks>
    public static ref float MouseDragThreshold => ref IO.MouseDragThreshold;

    /// <summary>
    /// Gets a reference to the delay before key repeat starts in seconds.
    /// </summary>
    /// <remarks>
    /// Defines how long a key must be held before key repeat begins.
    /// This matches typical operating system keyboard repeat behavior.
    /// </remarks>
    public static ref float KeyRepeatDelay => ref IO.KeyRepeatDelay;

    /// <summary>
    /// Gets a reference to the rate of key repeat events per second.
    /// </summary>
    /// <remarks>
    /// Defines how many repeat events are generated per second while a key
    /// is held down after the initial delay period expires.
    /// </remarks>
    public static ref float KeyRepeatRate => ref IO.KeyRepeatRate;

    /// <summary>
    /// Gets a reference to the flag that enables error recovery mechanisms.
    /// </summary>
    /// <remarks>
    /// When enabled, ImGui attempts to recover from certain error conditions
    /// instead of crashing, which can improve application stability during development.
    /// </remarks>
    public static ref bool ConfigErrorRecovery => ref IO.ConfigErrorRecovery;

    /// <summary>
    /// Gets a reference to the flag that enables assertion during error recovery.
    /// </summary>
    /// <remarks>
    /// When enabled along with error recovery, ImGui will trigger assertions
    /// when recovering from errors, helping with debugging while maintaining stability.
    /// </remarks>
    public static ref bool ConfigErrorRecoveryEnableAssert => ref IO.ConfigErrorRecoveryEnableAssert;

    /// <summary>
    /// Gets a reference to the flag that enables debug logging during error recovery.
    /// </summary>
    /// <remarks>
    /// When enabled, error recovery operations are logged to the debug output,
    /// providing visibility into recovery actions for debugging purposes.
    /// </remarks>
    public static ref bool ConfigErrorRecoveryEnableDebugLog => ref IO.ConfigErrorRecoveryEnableDebugLog;

    /// <summary>
    /// Gets a reference to the flag that enables tooltips during error recovery.
    /// </summary>
    /// <remarks>
    /// When enabled, error recovery operations may display tooltips with
    /// information about the recovery action, providing user feedback.
    /// </remarks>
    public static ref bool ConfigErrorRecoveryEnableTooltip => ref IO.ConfigErrorRecoveryEnableTooltip;

    /// <summary>
    /// Gets a reference to the flag indicating whether a debugger is present.
    /// </summary>
    /// <remarks>
    /// This flag can be used to modify behavior when running under a debugger,
    /// such as enabling additional debug features or changing assertion behavior.
    /// </remarks>
    public static ref bool ConfigDebugIsDebuggerPresent => ref IO.ConfigDebugIsDebuggerPresent;

    /// <summary>
    /// Gets a reference to the flag that enables highlighting of ID conflicts.
    /// </summary>
    /// <remarks>
    /// When enabled, ImGui will visually highlight items that have conflicting IDs,
    /// which helps identify and resolve ID collision issues during development.
    /// </remarks>
    public static ref bool ConfigDebugHighlightIdConflicts => ref IO.ConfigDebugHighlightIdConflicts;

    /// <summary>
    /// Gets a reference to the flag that shows the item picker for ID conflicts.
    /// </summary>
    /// <remarks>
    /// When enabled along with ID conflict highlighting, provides an item picker
    /// interface to help identify and navigate to conflicting items.
    /// </remarks>
    public static ref bool ConfigDebugHighlightIdConflictsShowItemPicker => ref IO.ConfigDebugHighlightIdConflictsShowItemPicker;

    /// <summary>
    /// Gets a reference to the flag that controls debug Begin() return value behavior.
    /// </summary>
    /// <remarks>
    /// When enabled, forces Begin() functions to return false once for debugging
    /// purposes, helping to test code paths that handle collapsed/hidden windows.
    /// </remarks>
    public static ref bool ConfigDebugBeginReturnValueOnce => ref IO.ConfigDebugBeginReturnValueOnce;

    /// <summary>
    /// Gets a reference to the flag that loops debug Begin() return value behavior.
    /// </summary>
    /// <remarks>
    /// When enabled, continuously alternates Begin() return values for debugging,
    /// helping to thoroughly test both visible and hidden window code paths.
    /// </remarks>
    public static ref bool ConfigDebugBeginReturnValueLoop => ref IO.ConfigDebugBeginReturnValueLoop;

    /// <summary>
    /// Gets a reference to the flag that ignores focus loss for debugging.
    /// </summary>
    /// <remarks>
    /// When enabled, ImGui ignores focus loss events, which can be useful for
    /// debugging applications that lose focus frequently during development.
    /// </remarks>
    public static ref bool ConfigDebugIgnoreFocusLoss => ref IO.ConfigDebugIgnoreFocusLoss;

    /// <summary>
    /// Gets a reference to the flag that enables debug output for INI settings.
    /// </summary>
    /// <remarks>
    /// When enabled, ImGui outputs debug information about INI file loading,
    /// saving, and parsing operations, helping diagnose configuration issues.
    /// </remarks>
    public static ref bool ConfigDebugIniSettings => ref IO.ConfigDebugIniSettings;

    /// <summary>
    /// Gets or sets the name of the platform backend.
    /// </summary>
    /// <remarks>
    /// This string identifies the platform backend being used (e.g., "imgui_impl_glfw").
    /// It's typically set by the backend implementation and used for debugging and
    /// feature detection purposes.
    /// </remarks>
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

    /// <summary>
    /// Gets or sets the name of the renderer backend.
    /// </summary>
    /// <remarks>
    /// This string identifies the renderer backend being used (e.g., "imgui_impl_opengl3").
    /// It's typically set by the backend implementation and used for debugging and
    /// feature detection purposes.
    /// </remarks>
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

    /// <summary>
    /// Gets a reference to the flag indicating whether ImGui wants to capture mouse input.
    /// </summary>
    /// <remarks>
    /// When true, indicates that ImGui is actively using mouse input and the application
    /// should not process mouse events. This helps coordinate input handling between
    /// ImGui and the application.
    /// </remarks>
    public static ref bool WantCaptureMouse => ref IO.WantCaptureMouse;

    /// <summary>
    /// Gets a reference to the flag indicating whether ImGui wants to capture keyboard input.
    /// </summary>
    /// <remarks>
    /// When true, indicates that ImGui is actively using keyboard input and the application
    /// should not process keyboard events. This helps coordinate input handling between
    /// ImGui and the application.
    /// </remarks>
    public static ref bool WantCaptureKeyboard => ref IO.WantCaptureKeyboard;

    /// <summary>
    /// Gets a reference to the flag indicating whether ImGui wants text input.
    /// </summary>
    /// <remarks>
    /// When true, indicates that ImGui has an active text input field and the application
    /// should enable text input methods and character input events.
    /// </remarks>
    public static ref bool WantTextInput => ref IO.WantTextInput;

    /// <summary>
    /// Gets a reference to the flag indicating whether ImGui wants to set the mouse position.
    /// </summary>
    /// <remarks>
    /// When true, indicates that ImGui wants to control the mouse cursor position,
    /// typically during navigation or when mouse position needs to be synchronized.
    /// </remarks>
    public static ref bool WantSetMousePos => ref IO.WantSetMousePos;

    /// <summary>
    /// Gets a reference to the flag indicating whether INI settings should be saved.
    /// </summary>
    /// <remarks>
    /// When true, indicates that ImGui settings have changed and should be saved
    /// to the INI file. The application can use this to trigger manual saves.
    /// </remarks>
    public static ref bool WantSaveIniSettings => ref IO.WantSaveIniSettings;

    /// <summary>
    /// Gets a reference to the flag indicating whether navigation is active.
    /// </summary>
    /// <remarks>
    /// When true, indicates that keyboard/gamepad navigation is currently active
    /// and the navigation system is processing input events.
    /// </remarks>
    public static ref bool NavActive => ref IO.NavActive;

    /// <summary>
    /// Gets a reference to the flag indicating whether navigation is visible.
    /// </summary>
    /// <remarks>
    /// When true, indicates that navigation visual elements (such as the navigation
    /// cursor) should be displayed to provide user feedback.
    /// </remarks>
    public static ref bool NavVisible => ref IO.NavVisible;

    /// <summary>
    /// Gets a reference to the application framerate estimate in frames per second.
    /// </summary>
    /// <remarks>
    /// This value is calculated by ImGui based on recent delta time values and
    /// provides an estimate of the application's rendering performance.
    /// </remarks>
    public static ref float Framerate => ref IO.Framerate;

    /// <summary>
    /// Gets a reference to the number of vertices rendered in the last frame.
    /// </summary>
    /// <remarks>
    /// This metric provides information about rendering complexity and can be
    /// used for performance monitoring and optimization purposes.
    /// </remarks>
    public static ref int MetricsRenderVertices => ref IO.MetricsRenderVertices;

    /// <summary>
    /// Gets a reference to the number of indices rendered in the last frame.
    /// </summary>
    /// <remarks>
    /// This metric indicates the number of triangle indices processed during
    /// rendering and helps assess rendering workload and performance.
    /// </remarks>
    public static ref int MetricsRenderIndices => ref IO.MetricsRenderIndices;

    /// <summary>
    /// Gets a reference to the number of windows rendered in the last frame.
    /// </summary>
    /// <remarks>
    /// This metric counts the total number of windows that were actually
    /// rendered (visible) during the last frame, excluding collapsed windows.
    /// </remarks>
    public static ref int MetricsRenderWindows => ref IO.MetricsRenderWindows;

    /// <summary>
    /// Gets a reference to the number of active windows in the application.
    /// </summary>
    /// <remarks>
    /// This metric counts all active windows, including both visible and
    /// collapsed windows that are part of the current ImGui context.
    /// </remarks>
    public static ref int MetricsActiveWindows => ref IO.MetricsActiveWindows;

    /// <summary>
    /// Gets a reference to the mouse movement delta since the last frame.
    /// </summary>
    /// <remarks>
    /// This vector represents the change in mouse position between the current
    /// and previous frames, useful for detecting mouse movement and calculating
    /// movement-based interactions.
    /// </remarks>
    public static ref Vector2 MouseDelta => ref IO.MouseDelta;

    /// <summary>
    /// Gets a reference to the ImGui context pointer.
    /// </summary>
    /// <remarks>
    /// This provides access to the current ImGui context, which contains all
    /// the internal state and data structures used by the ImGui system.
    /// </remarks>
    public static ref ImGuiContextPtr Ctx => ref IO.Ctx;

    /// <summary>
    /// Gets a reference to the current mouse position in screen coordinates.
    /// </summary>
    /// <remarks>
    /// This position is updated each frame and represents the mouse cursor
    /// location relative to the display area. Invalid positions are represented
    /// as (-FLT_MAX, -FLT_MAX).
    /// </remarks>
    public static ref Vector2 MousePos => ref IO.MousePos;

    /// <summary>
    /// Gets a span of boolean values indicating which mouse buttons are currently pressed.
    /// </summary>
    /// <remarks>
    /// This array contains the pressed state for each mouse button, typically
    /// indexed as 0=left, 1=right, 2=middle, with additional buttons for
    /// extended mouse support.
    /// </remarks>
    public static Span<bool> MouseDown => IO.MouseDown;

    /// <summary>
    /// Gets a reference to the vertical mouse wheel delta.
    /// </summary>
    /// <remarks>
    /// This value represents the vertical scroll wheel movement since the last frame.
    /// Positive values indicate scrolling up, negative values indicate scrolling down.
    /// </remarks>
    public static ref float MouseWheel => ref IO.MouseWheel;

    /// <summary>
    /// Gets a reference to the horizontal mouse wheel delta.
    /// </summary>
    /// <remarks>
    /// This value represents the horizontal scroll wheel movement since the last frame.
    /// Positive values indicate scrolling right, negative values indicate scrolling left.
    /// </remarks>
    public static ref float MouseWheelH => ref IO.MouseWheelH;

    /// <summary>
    /// Gets a reference to the source of the current mouse input.
    /// </summary>
    /// <remarks>
    /// This indicates whether mouse input is coming from an actual mouse,
    /// touch input, or pen input, allowing for input-specific behavior adjustments.
    /// </remarks>
    public static ref ImGuiMouseSource MouseSource => ref IO.MouseSource;

    /// <summary>
    /// Gets a reference to the ID of the viewport currently under the mouse cursor.
    /// </summary>
    /// <remarks>
    /// This value identifies which viewport the mouse is currently hovering over
    /// in multi-viewport applications. A value of 0 indicates no specific viewport.
    /// </remarks>
    public static ref uint MouseHoveredViewport => ref IO.MouseHoveredViewport;

    /// <summary>
    /// Gets a reference to the flag indicating whether the Ctrl key is pressed.
    /// </summary>
    /// <remarks>
    /// This flag is updated based on keyboard input and is used throughout
    /// ImGui for modifier key combinations and shortcuts.
    /// </remarks>
    public static ref bool KeyCtrl => ref IO.KeyCtrl;

    /// <summary>
    /// Gets a reference to the flag indicating whether the Shift key is pressed.
    /// </summary>
    /// <remarks>
    /// This flag is updated based on keyboard input and is used throughout
    /// ImGui for modifier key combinations and extended selection operations.
    /// </remarks>
    public static ref bool KeyShift => ref IO.KeyShift;

    /// <summary>
    /// Gets a reference to the flag indicating whether the Alt key is pressed.
    /// </summary>
    /// <remarks>
    /// This flag is updated based on keyboard input and is used throughout
    /// ImGui for modifier key combinations and menu navigation.
    /// </remarks>
    public static ref bool KeyAlt => ref IO.KeyAlt;

    /// <summary>
    /// Gets a reference to the flag indicating whether the Super/Windows key is pressed.
    /// </summary>
    /// <remarks>
    /// This flag is updated based on keyboard input and represents the Windows key
    /// on PC or Cmd key on Mac, used for system-level shortcuts and modifiers.
    /// </remarks>
    public static ref bool KeySuper => ref IO.KeySuper;

    /// <summary>
    /// Gets a reference to the combined modifier key state as a bitmask.
    /// </summary>
    /// <remarks>
    /// This value combines all modifier key states into a single integer bitmask
    /// for convenient checking of multiple modifiers simultaneously.
    /// </remarks>
    public static ref int KeyMods => ref IO.KeyMods;

    /// <summary>
    /// Gets a span of key data structures containing detailed information for each key.
    /// </summary>
    /// <remarks>
    /// This array contains detailed state information for each key, including
    /// press/release timing, repeat information, and analog values for gamepad inputs.
    /// </remarks>
    public static Span<ImGuiKeyData> KeysData => IO.KeysData;

    /// <summary>
    /// Gets a reference to the flag indicating mouse capture preference unless a popup is closing.
    /// </summary>
    /// <remarks>
    /// This flag provides more nuanced mouse capture behavior, allowing applications
    /// to handle mouse input even when popups are in the process of closing.
    /// </remarks>
    public static ref bool WantCaptureMouseUnlessPopupClose => ref IO.WantCaptureMouseUnlessPopupClose;

    /// <summary>
    /// Gets a reference to the previous frame's mouse position.
    /// </summary>
    /// <remarks>
    /// This position represents the mouse cursor location from the previous frame,
    /// useful for calculating mouse movement and velocity.
    /// </remarks>
    public static ref Vector2 MousePosPrev => ref IO.MousePosPrev;

    /// <summary>
    /// Gets a span of positions where each mouse button was clicked.
    /// </summary>
    /// <remarks>
    /// This array stores the screen coordinates where each mouse button was
    /// initially pressed, used for drag distance calculations and click validation.
    /// </remarks>
    public static Span<Vector2> MouseClickedPos => IO.MouseClickedPos;

    /// <summary>
    /// Gets a span of timestamps when each mouse button was clicked.
    /// </summary>
    /// <remarks>
    /// This array stores the time values when each mouse button was pressed,
    /// used for double-click detection and timing-based interactions.
    /// </remarks>
    public static Span<double> MouseClickedTime => IO.MouseClickedTime;

    /// <summary>
    /// Gets a span of flags indicating which mouse buttons were clicked this frame.
    /// </summary>
    /// <remarks>
    /// This array indicates which mouse buttons transitioned from up to down
    /// state during the current frame, representing new click events.
    /// </remarks>
    public static Span<bool> MouseClicked => IO.MouseClicked;

    /// <summary>
    /// Gets a span of flags indicating which mouse buttons were double-clicked this frame.
    /// </summary>
    /// <remarks>
    /// This array indicates which mouse buttons registered as double-clicks
    /// during the current frame, based on timing and distance thresholds.
    /// </remarks>
    public static Span<bool> MouseDoubleClicked => IO.MouseDoubleClicked;

    /// <summary>
    /// Gets a span of click counts for each mouse button.
    /// </summary>
    /// <remarks>
    /// This array tracks the current click count for each mouse button,
    /// supporting multi-click detection beyond simple double-clicks.
    /// </remarks>
    public static Span<ushort> MouseClickedCount => IO.MouseClickedCount;

    /// <summary>
    /// Gets a span of previous click counts for each mouse button.
    /// </summary>
    /// <remarks>
    /// This array stores the click count from the previous frame for each
    /// mouse button, used for click count change detection.
    /// </remarks>
    public static Span<ushort> MouseClickedLastCount => IO.MouseClickedLastCount;

    /// <summary>
    /// Gets a span of flags indicating which mouse buttons were released this frame.
    /// </summary>
    /// <remarks>
    /// This array indicates which mouse buttons transitioned from down to up
    /// state during the current frame, representing button release events.
    /// </remarks>
    public static Span<bool> MouseReleased => IO.MouseReleased;

    /// <summary>
    /// Gets a span of timestamps when each mouse button was released.
    /// </summary>
    /// <remarks>
    /// This array stores the time values when each mouse button was released,
    /// used for click duration calculations and interaction timing.
    /// </remarks>
    public static Span<double> MouseReleasedTime => IO.MouseReleasedTime;

    /// <summary>
    /// Gets a span of flags indicating which mouse buttons are owned by ImGui.
    /// </summary>
    /// <remarks>
    /// This array indicates which mouse button press events were initiated
    /// over ImGui elements, helping coordinate input handling with the application.
    /// </remarks>
    public static Span<bool> MouseDownOwned => IO.MouseDownOwned;

    /// <summary>
    /// Gets a span of flags indicating mouse button ownership unless a popup is closing.
    /// </summary>
    /// <remarks>
    /// This array provides more nuanced ownership information, considering
    /// popup closing states in the ownership determination.
    /// </remarks>
    public static Span<bool> MouseDownOwnedUnlessPopupClose => IO.MouseDownOwnedUnlessPopupClose;

    /// <summary>
    /// Gets a reference to the flag requesting mouse wheel axis swapping.
    /// </summary>
    /// <remarks>
    /// When true, indicates that the application should swap horizontal and
    /// vertical mouse wheel axes, typically for specialized input handling.
    /// </remarks>
    public static ref bool MouseWheelRequestAxisSwap => ref IO.MouseWheelRequestAxisSwap;

    /// <summary>
    /// Gets a reference to the flag enabling Ctrl+Left Click as Right Click.
    /// </summary>
    /// <remarks>
    /// When enabled, Ctrl+Left Click is treated as a right-click, providing
    /// an alternative way to access context menus on systems with limited mouse buttons.
    /// </remarks>
    public static ref bool MouseCtrlLeftAsRightClick => ref IO.MouseCtrlLeftAsRightClick;

    /// <summary>
    /// Gets a span of durations each mouse button has been held down.
    /// </summary>
    /// <remarks>
    /// This array tracks how long each mouse button has been continuously
    /// pressed, useful for long-press detection and hold-based interactions.
    /// </remarks>
    public static Span<float> MouseDownDuration => IO.MouseDownDuration;

    /// <summary>
    /// Gets a span of previous frame durations each mouse button was held down.
    /// </summary>
    /// <remarks>
    /// This array stores the hold duration from the previous frame for each
    /// mouse button, useful for duration change detection and timing calculations.
    /// </remarks>
    public static Span<float> MouseDownDurationPrev => IO.MouseDownDurationPrev;

    /// <summary>
    /// Gets a span of maximum drag distances for each mouse button in absolute coordinates.
    /// </summary>
    /// <remarks>
    /// This array tracks the maximum distance each mouse button has been dragged
    /// from its initial click position, useful for drag threshold detection.
    /// </remarks>
    public static Span<Vector2> MouseDragMaxDistanceAbs => IO.MouseDragMaxDistanceAbs;

    /// <summary>
    /// Gets a span of maximum squared drag distances for each mouse button.
    /// </summary>
    /// <remarks>
    /// This array stores the squared distance values for efficient distance
    /// comparisons without requiring square root calculations.
    /// </remarks>
    public static Span<float> MouseDragMaxDistanceSqr => IO.MouseDragMaxDistanceSqr;

    /// <summary>
    /// Gets a reference to the pen pressure value for stylus input.
    /// </summary>
    /// <remarks>
    /// This value represents the pressure applied by a stylus or pen input device,
    /// ranging from 0.0 (no pressure) to 1.0 (maximum pressure).
    /// </remarks>
    public static ref float PenPressure => ref IO.PenPressure;

    /// <summary>
    /// Gets a reference to the flag indicating whether the application has lost focus.
    /// </summary>
    /// <remarks>
    /// When true, indicates that the application window is not currently focused,
    /// which can be used to pause certain operations or reduce resource usage.
    /// </remarks>
    public static ref bool AppFocusLost => ref IO.AppFocusLost;

    /// <summary>
    /// Gets a reference to the flag indicating whether the application is accepting events.
    /// </summary>
    /// <remarks>
    /// When false, indicates that the application is not accepting input events,
    /// typically during minimized states or when input should be suspended.
    /// </remarks>
    public static ref bool AppAcceptingEvents => ref IO.AppAcceptingEvents;

    /// <summary>
    /// Gets a reference to the surrogate character for UTF-16 input processing.
    /// </summary>
    /// <remarks>
    /// This value is used internally for handling UTF-16 surrogate pairs during
    /// text input processing, ensuring proper Unicode character handling.
    /// </remarks>
    public static ref ushort InputQueueSurrogate => ref IO.InputQueueSurrogate;

    /// <summary>
    /// Gets a reference to the queue of input characters waiting to be processed.
    /// </summary>
    /// <remarks>
    /// This queue contains Unicode codepoints for characters that have been
    /// input but not yet processed by ImGui's text input system.
    /// </remarks>
    public static ref ImVector<uint> InputQueueCharacters => ref IO.InputQueueCharacters;

    /// <summary>
    /// Adds a focus event to the input queue.
    /// </summary>
    /// <param name="focused">True if the application gained focus, false if it lost focus.</param>
    /// <remarks>
    /// This method should be called by the platform backend when the application
    /// window gains or loses focus to properly handle focus-related behavior.
    /// </remarks>
    public static void AddFocusEvent(bool focused) => IO.AddFocusEvent(focused);

    /// <summary>
    /// Adds a character input event to the input queue.
    /// </summary>
    /// <param name="c">The Unicode codepoint of the character to add.</param>
    /// <remarks>
    /// This method should be called by the platform backend for each character
    /// input event, typically from keyboard or other text input methods.
    /// </remarks>
    public static void AddInputCharacter(uint c) => IO.AddInputCharacter(c);

    /// <summary>
    /// Adds UTF-8 encoded characters to the input queue.
    /// </summary>
    /// <param name="str">A span of UTF-8 encoded bytes representing the text to add.</param>
    /// <remarks>
    /// This method processes UTF-8 encoded text and adds the corresponding
    /// Unicode characters to the input queue for text input processing.
    /// </remarks>
    public static void AddInputCharactersUTF8(ReadOnlySpan<byte> str) => IO.AddInputCharactersUTF8(str);

    /// <summary>
    /// Adds UTF-8 encoded characters to the input queue.
    /// </summary>
    /// <param name="str">A string containing the text to add to the input queue.</param>
    /// <remarks>
    /// This method converts the string to UTF-8 and adds the corresponding
    /// Unicode characters to the input queue for text input processing.
    /// </remarks>
    public static void AddInputCharactersUTF8(string str) => IO.AddInputCharactersUTF8(str);

    /// <summary>
    /// Adds a UTF-16 character to the input queue.
    /// </summary>
    /// <param name="c">The UTF-16 character code to add.</param>
    /// <remarks>
    /// This method handles UTF-16 character input, including proper processing
    /// of surrogate pairs for characters outside the Basic Multilingual Plane.
    /// </remarks>
    public static void AddInputCharacterUTF16(ushort c) => IO.AddInputCharacterUTF16(c);

    /// <summary>
    /// Adds an analog key event to the input queue.
    /// </summary>
    /// <param name="key">The key that generated the event.</param>
    /// <param name="down">True if the key is pressed, false if released.</param>
    /// <param name="v">The analog value associated with the key (0.0 to 1.0).</param>
    /// <remarks>
    /// This method is used for analog input devices like gamepad triggers and
    /// analog sticks that provide continuous values rather than simple on/off states.
    /// </remarks>
    public static void AddKeyAnalogEvent(ImGuiKey key, bool down, float v) => IO.AddKeyAnalogEvent(key, down, v);

    /// <summary>
    /// Adds a key event to the input queue.
    /// </summary>
    /// <param name="key">The key that generated the event.</param>
    /// <param name="down">True if the key is pressed, false if released.</param>
    /// <remarks>
    /// This method should be called by the platform backend for each key press
    /// and release event to properly handle keyboard input in ImGui.
    /// </remarks>
    public static void AddKeyEvent(ImGuiKey key, bool down) => IO.AddKeyEvent(key, down);

    /// <summary>
    /// Adds a mouse button event to the input queue.
    /// </summary>
    /// <param name="button">The mouse button index (0=left, 1=right, 2=middle, etc.).</param>
    /// <param name="down">True if the button is pressed, false if released.</param>
    /// <remarks>
    /// This method should be called by the platform backend for each mouse button
    /// press and release event to properly handle mouse input in ImGui.
    /// </remarks>
    public static void AddMouseButtonEvent(int button, bool down) => IO.AddMouseButtonEvent(button, down);

    /// <summary>
    /// Adds a mouse position event to the input queue.
    /// </summary>
    /// <param name="x">The X coordinate of the mouse position.</param>
    /// <param name="y">The Y coordinate of the mouse position.</param>
    /// <remarks>
    /// This method should be called by the platform backend when the mouse position
    /// changes to keep ImGui's mouse tracking accurate and responsive.
    /// </remarks>
    public static void AddMousePosEvent(float x, float y) => IO.AddMousePosEvent(x, y);

    /// <summary>
    /// Adds a mouse source event to the input queue.
    /// </summary>
    /// <param name="source">The source of the mouse input (mouse, touch, pen, etc.).</param>
    /// <remarks>
    /// This method indicates the source of mouse input, allowing ImGui to adapt
    /// its behavior based on the input method (e.g., different behavior for touch vs mouse).
    /// </remarks>
    public static void AddMouseSourceEvent(ImGuiMouseSource source) => IO.AddMouseSourceEvent(source);

    /// <summary>
    /// Adds a mouse viewport event to the input queue.
    /// </summary>
    /// <param name="id">The ID of the viewport the mouse is hovering over.</param>
    /// <remarks>
    /// This method is used in multi-viewport applications to track which viewport
    /// the mouse cursor is currently positioned over.
    /// </remarks>
    public static void AddMouseViewportEvent(uint id) => IO.AddMouseViewportEvent(id);

    /// <summary>
    /// Adds a mouse wheel event to the input queue.
    /// </summary>
    /// <param name="wheelX">The horizontal wheel delta.</param>
    /// <param name="wheelY">The vertical wheel delta.</param>
    /// <remarks>
    /// This method should be called by the platform backend for mouse wheel scroll
    /// events, supporting both vertical and horizontal scrolling.
    /// </remarks>
    public static void AddMouseWheelEvent(float wheelX, float wheelY) => IO.AddMouseWheelEvent(wheelX, wheelY);

    /// <summary>
    /// Clears all events from the input queue.
    /// </summary>
    /// <remarks>
    /// This method removes all pending input events from the queue, effectively
    /// discarding any unprocessed input. Use with caution as it may cause input loss.
    /// </remarks>
    public static void ClearEventQueue() => IO.ClearEventsQueue();

    /// <summary>
    /// Clears all keyboard input state.
    /// </summary>
    /// <remarks>
    /// This method resets all key states to unpressed, clearing any held keys
    /// and key-related input state. Useful for handling focus loss scenarios.
    /// </remarks>
    public static void ClearInputKeys() => IO.ClearInputKeys();

    /// <summary>
    /// Clears all mouse input state.
    /// </summary>
    /// <remarks>
    /// This method resets all mouse button states and related mouse input data,
    /// clearing any held buttons and mouse-related input state.
    /// </remarks>
    public static void ClearInputMouse() => IO.ClearInputMouse();

    /// <summary>
    /// Destroys the IO object and cleans up associated resources.
    /// </summary>
    /// <remarks>
    /// This method should be called during application shutdown to properly
    /// release resources associated with the ImGui IO system.
    /// </remarks>
    public static void Destroy() => IO.Destroy();

    /// <summary>
    /// Sets whether the application is accepting input events.
    /// </summary>
    /// <param name="acceptingEvents">True to accept events, false to ignore them.</param>
    /// <remarks>
    /// This method controls whether ImGui processes input events, allowing
    /// applications to temporarily suspend input processing when appropriate.
    /// </remarks>
    public static void SetAppAcceptingEvents(bool acceptingEvents) => IO.SetAppAcceptingEvents(acceptingEvents);

    /// <summary>
    /// Sets native platform data for a key event.
    /// </summary>
    /// <param name="key">The ImGui key.</param>
    /// <param name="nativeKeycode">The platform-specific key code.</param>
    /// <param name="nativeScancode">The platform-specific scan code.</param>
    /// <param name="nativeLegacyIndex">The legacy key index for backward compatibility.</param>
    /// <remarks>
    /// This method associates platform-specific key information with ImGui keys,
    /// enabling better integration with platform-specific key handling and debugging.
    /// </remarks>
    public static void SetKeyEventNativeData(ImGuiKey key, int nativeKeycode, int nativeScancode, int nativeLegacyIndex) => IO.SetKeyEventNativeData(key, nativeKeycode, nativeScancode, nativeLegacyIndex);

    /// <summary>
    /// Sets native platform data for a key event.
    /// </summary>
    /// <param name="key">The ImGui key.</param>
    /// <param name="nativeKeycode">The platform-specific key code.</param>
    /// <param name="nativeScancode">The platform-specific scan code.</param>
    /// <remarks>
    /// This method associates platform-specific key information with ImGui keys,
    /// enabling better integration with platform-specific key handling and debugging.
    /// </remarks>
    public static void SetKeyEventNativeData(ImGuiKey key, int nativeKeycode, int nativeScancode) => IO.SetKeyEventNativeData(key, nativeKeycode, nativeScancode);
}