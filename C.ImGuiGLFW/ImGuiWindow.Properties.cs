using C.ImGuiGLFW.Data;
using Hexa.NET.GLFW;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
    private bool topMostChanged = false;
    private bool resizableChanged = false;
    private bool autoIconifyChanged = false;
    private bool showTitleBarChanged = false;
    private bool windowSizeLimitsChanged = false;
    private bool windowMaximizeChanged = false;
    private bool windowIconifyChanged = false;
    private bool backgroundColorChanged = true;
    private bool AnyConfigurationChanged => topMostChanged
        || resizableChanged
        || autoIconifyChanged
        || showTitleBarChanged
        || windowSizeLimitsChanged
        || windowMaximizeChanged
        || windowIconifyChanged;

    /// <summary>
    /// Gets or sets the size of the client area of the window in screen coordinates.
    /// </summary>
    public static unsafe Vector2 ClientSize
    {
        get
        {
            int width = 0;
            int height = 0;
            GLFW.GetWindowSize(Instance.window, ref width, ref height);
            return new(width, height);
        }

        set => GLFW.SetWindowSize(Instance.window, (int)value.X, (int)value.Y);
    }

    /// <summary>
    /// Gets or sets the position of the upper-left corner of the content area of the window in screen coordinates.
    /// </summary>
    public static unsafe Vector2 Position
    {
        get
        {
            int xpos = 0;
            int ypos = 0;
            GLFW.GetWindowPos(Instance.window, ref xpos, ref ypos);
            return new(xpos, ypos);
        }

        set => GLFW.SetWindowPos(Instance.window, (int)value.X, (int)value.Y);
    }

    /// <summary>
    /// Gets or sets the window title string.
    /// </summary>
    public static string Title
    {
        get => Instance.WindowSettings.Title;
        set
        {
            Instance.WindowSettings.Title = value;
            GLFW.SetWindowTitle(Instance.window, Instance.WindowSettings.Title);
        }
    }

    /// <summary>
    /// Gets or sets the frame rate frequency for window updates, clamped between 0 and MaxFrequency(500).
    /// </summary>
    public static double UpdateFrequency
    {
        get => Instance.WindowSettings.FrameRate;
        set => Instance.WindowSettings.FrameRate = value < 1.0 ? 0.0 : Math.Clamp(value, 0.0, MaxFrequency);
    }

    /// <summary>
    /// Gets or sets the opacity of the window, including any decorations.
    /// </summary>
    public static float Opacity
    {
        get => Instance.WindowSettings.Opacity;
        set
        {
            Instance.WindowSettings.Opacity = value;
            GLFW.SetWindowOpacity(Instance.window, Instance.WindowSettings.Opacity);
        }
    }

    /// <summary>
    /// Gets or sets whether the window should stay on top of other windows.
    /// </summary>
    public static bool TopMost
    {
        get => Instance.WindowSettings.TopMost;
        set
        {
            if (Instance.WindowSettings.TopMost == value) return;
            Instance.WindowSettings.TopMost = value;
            Instance.topMostChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether the window is resizable by the user.
    /// </summary>
    public static bool Resizable
    {
        get => Instance.WindowSettings.Resizable;
        set
        {
            if (Instance.WindowSettings.Resizable == value) return;
            Instance.WindowSettings.Resizable = value;
            Instance.resizableChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether the window will be automatically iconified when it loses focus in full screen mode.
    /// </summary>
    public static bool AutoIconify
    {
        get => Instance.WindowSettings.AutoIconify;
        set
        {
            if (Instance.WindowSettings.AutoIconify == value) return;
            Instance.WindowSettings.AutoIconify = value;
            Instance.autoIconifyChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether the window is maximized.
    /// </summary>
    public static bool Maximized
    {
        get => Instance.WindowSettings.Maximized;
        set
        {
            if (Instance.WindowSettings.Maximized == value) return;
            Instance.WindowSettings.Maximized = value;
            Instance.windowMaximizeChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether the window is iconified (minimized).
    /// </summary>
    public static bool Iconified
    {
        get => Instance.WindowSettings.Iconified;
        set
        {
            if (Instance.WindowSettings.Iconified == value) return;
            Instance.WindowSettings.Iconified = value;
            Instance.windowIconifyChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether the window title bar is visible.
    /// </summary>
    public static bool ShowTitleBar
    {
        get => Instance.WindowSettings.ShowTitleBar;
        set
        {
            if (Instance.WindowSettings.ShowTitleBar == value) return;
            Instance.WindowSettings.ShowTitleBar = value;
            Instance.showTitleBarChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether keyboard navigation is enabled for ImGui.
    /// </summary>
    public static bool NavEnableKeyboard
    {
        get => Instance.WindowSettings.NavEnableKeyboard;
        set
        {
            if (Instance.WindowSettings.NavEnableKeyboard == value) return;
            Instance.WindowSettings.NavEnableKeyboard = value;
            Instance.imGuiManager.navEnableKeyboardChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether gamepad navigation is enabled for ImGui.
    /// </summary>
    public static bool NavEnableGamePad
    {
        get => Instance.WindowSettings.NavEnableGamepad;
        set
        {
            if (Instance.WindowSettings.NavEnableGamepad == value) return;
            Instance.WindowSettings.NavEnableGamepad = value;
            Instance.imGuiManager.navEnableGamepadChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether ImGui docking functionality is enabled.
    /// </summary>
    public static bool DockingEnable
    {
        get => Instance.WindowSettings.DockingEnable;
        set
        {
            if (Instance.WindowSettings.DockingEnable == value) return;
            Instance.WindowSettings.DockingEnable = value;
            Instance.imGuiManager.dockingEnableChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets whether ImGui multi-viewport functionality is enabled.
    /// </summary>
    public static bool ViewportEnable
    {
        get => Instance.WindowSettings.ViewportsEnable;
        set
        {
            if (Instance.WindowSettings.ViewportsEnable == value) return;
            Instance.WindowSettings.ViewportsEnable = value;
        }
    }

    /// <summary>
    /// Gets or sets the ImGui style color scheme.
    /// </summary>
    public static StyleColors StyleColors
    {
        get => Instance.WindowSettings.StyleColors;
        set
        {
            Instance.WindowSettings.StyleColors = value;
            Instance.imGuiManager.ConfigureStylesColor();
        }
    }

    /// <summary>
    /// Gets or sets the size limits for the window (minimum and maximum dimensions).
    /// </summary>
    public static WindowSizeLimits SizeLimits
    {
        get => new(
            (int)Instance.WindowSettings.MinSize.X,
            (int)Instance.WindowSettings.MinSize.Y,
            (int)Instance.WindowSettings.MaxSize.X,
            (int)Instance.WindowSettings.MaxSize.Y
        );
        set
        {
            var current = SizeLimits;
            if (current.Equals(value)) return;

            Instance.WindowSettings.MinSize = new Vector2(value.MinWidth, value.MinHeight);
            Instance.WindowSettings.MaxSize = new Vector2(value.MaxWidth, value.MaxHeight);
            Instance.windowSizeLimitsChanged = true;
        }
    }

    /// <summary>
    /// Gets or sets the background color of the window as a Vector4 (RGBA).
    /// </summary>
    public static Vector4 BackgroundColor
    {
        get => Instance.WindowSettings.BackgroundColor;
        set
        {
            if (Instance.WindowSettings.BackgroundColor.Equals(value)) return;
            Instance.WindowSettings.BackgroundColor = value;
            Instance.backgroundColorChanged = true;
        }
    }

    /// <summary>
    /// Gets the index of the monitor associated with the current window instance.
    /// </summary>
    /// <value>
    /// The zero-based index of the monitor where the window is currently displayed.
    /// </value>
    /// <remarks>
    /// The monitor index is typically determined when the window is created or moved between displays.
    /// This value can be used with other display-related functions to query monitor properties.
    /// </remarks>
    public static int MonitorIndex => Instance.monitorIndex;

    /// <summary>
    /// Gets the OpenGL context interface for the current instance.
    /// </summary>
    /// <returns>An OpenGL interface object for making OpenGL calls.</returns>
    /// <remarks>
    /// This method provides access to the OpenGL API through the current context.
    /// The returned GL object should be used for all OpenGL rendering operations.
    /// Ensure the context is current before using the returned GL interface.
    /// </remarks>
    public static GL GetGL() => Instance.GL;

    /// <summary>
    /// Gets the bindings context for the current window instance.
    /// </summary>
    /// <returns>The <see cref="BindingsContext"/> associated with the current window.</returns>
    /// <remarks>
    /// The bindings context provides low-level OpenGL context management functionality.
    /// This can be used for advanced context operations and integration with other graphics libraries.
    /// </remarks>
    public static BindingsContext GetBindingsContext() => Instance.bindingsContext;

    /// <summary>
    /// Gets the monitor that the current window is displayed on.
    /// </summary>
    /// <returns>
    /// A <see cref="GLFWmonitorPtr"/> representing the monitor, or null if the window is in windowed mode.
    /// </returns>
    /// <remarks>
    /// This method returns the monitor for fullscreen windows, or null for windowed mode.
    /// The returned monitor pointer can be used with GLFW monitor-related functions to query display properties.
    /// </remarks>
    public static GLFWmonitorPtr GetWindowMonitor() => GLFW.GetWindowMonitor(Instance.window);

    /// <summary>
    /// Gets the current position of the cursor relative to the content area of the window.
    /// </summary>
    /// <returns>
    /// A tuple containing the cursor's x and y coordinates in pixels, relative to the top-left corner of the window's content area.
    /// </returns>
    /// <remarks>
    /// The coordinates are relative to the window's client area, not the screen.
    /// Coordinates can be negative if the cursor is outside the window bounds.
    /// The precision of the coordinates depends on the platform and input device.
    /// </remarks>
    public static (double xpos, double ypos) GetCursorPos()
    {
        double xpos = 0, ypos = 0;
        GLFW.GetCursorPos(Instance.window, ref xpos, ref ypos);
        return (xpos, ypos);
    }

    /// <summary>
    /// Gets the current state of the specified keyboard key.
    /// </summary>
    /// <param name="key">The keyboard key to query, typically using GLFW key constants.</param>
    /// <returns>
    /// The current state of the key: GLFW_PRESS if pressed, GLFW_RELEASE if released, 
    /// or GLFW_REPEAT if the key is being held down and generating repeat events.
    /// </returns>
    /// <remarks>
    /// This method polls the current state of a keyboard key rather than using event-based input.
    /// Key codes should use GLFW's predefined constants (e.g., GLFW_KEY_A, GLFW_KEY_SPACE).
    /// The method returns the immediate state, which is useful for continuous input handling like movement controls.
    /// </remarks>
    public static int GetKey(int key) => GLFW.GetKey(Instance.window, key);

    /// <summary>
    /// This function returns the contents of the system clipboard, if it contains or is convertible to a UTF-8 encoded string.
    /// If the clipboard is empty or if its contents cannot be converted, `NULL` is returned and a error is generated.
    /// </summary>
    public static string GetClipboardString() => GLFW.GetClipboardStringS(Instance.window);

    /// <summary>
    /// Retrieves the Win32 window handle (HWND) for the current GLFW window.
    /// </summary>
    /// <returns>
    /// A native integer pointer representing the Win32 window handle (HWND).
    /// Returns <see cref="nint.Zero"/> if the window is not available or if running on a non-Windows platform.
    /// </returns>
    /// <remarks>
    /// This method is Windows-specific and provides access to the underlying Win32 window handle,
    /// which can be used for advanced Windows API operations, such as:
    /// <list type="bullet">
    /// <item>Integrating with Windows-specific UI frameworks</item>
    /// <item>Implementing custom window decorations</item>
    /// <item>Accessing Windows messaging system</item>
    /// <item>Interoperating with other Windows applications</item>
    /// </list>
    /// <para>
    /// On non-Windows platforms (macOS, Linux), this method may return <see cref="nint.Zero"/>
    /// or throw a platform-specific exception.
    /// </para>
    /// </remarks>
    /// <exception cref="PlatformNotSupportedException">
    /// Thrown when called on non-Windows platforms where Win32 handles are not available.
    /// </exception>
    public static nint GetWin32Window() => GLFW.GetWin32Window(Instance.window);

    /// <summary>
    /// Gets the GLFW window pointer for the current application window.
    /// </summary>
    /// <returns>
    /// A <see cref="GLFWwindowPtr"/> representing the native GLFW window handle.
    /// </returns>
    /// <remarks>
    /// This method provides direct access to the underlying GLFW window pointer,
    /// which can be used for advanced GLFW operations such as:
    /// <list type="bullet">
    /// <item>Setting custom window callbacks</item>
    /// <item>Accessing low-level GLFW window properties</item>
    /// <item>Implementing custom input handling</item>
    /// <item>Integrating with other GLFW-based libraries</item>
    /// <item>Performing platform-specific window operations</item>
    /// </list>
    /// <para>
    /// The returned pointer is valid only while the ImGuiController instance is active.
    /// Using this pointer after the controller has been disposed may result in undefined behavior.
    /// </para>
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the ImGuiController has not been initialized or if the window has been destroyed.
    /// </exception>
    /// <seealso cref="GLFWwindowPtr"/>
    /// <seealso cref="GetWin32Window()"/>
    public static GLFWwindowPtr GetWwindowPtr() => Instance.window;

    /// <summary>
    /// This function brings the specified window to front and sets input focus.
    /// The window should already be visible and not iconified.
    /// </summary>
    public static void FocusWindow() => GLFW.FocusWindow(Instance.window);

    /// <summary>
    /// This function makes the specified window visible if it was previously hidden.
    /// If the window is already visible or is in full screen mode, this function does nothing.
    /// </summary>
    public static void ShowWindow() => GLFW.ShowWindow(Instance.window);

    /// <summary>
    /// This function hides the specified window if it was previously visible.
    /// If the window is already hidden or is in full screen mode, this function does nothing.
    /// </summary>
    public static void HideWindow() => GLFW.HideWindow(Instance.window);

    /// <summary>
    /// This function iconifies (minimizes) the specified window if it was previously restored.
    /// If the window is already iconified, this function does nothing.
    /// If the specified window is a full screen window, GLFW restores the original video mode of the monitor.
    /// The window's desired video mode is set again when the window is restored.
    /// </summary>
    public static void IconifyWindow() => Iconified = true;

    /// <summary>
    /// This function maximizes the specified window if it was previously not maximized.
    /// If the window is already maximized, this function does nothing.
    /// If the specified window is a full screen window, this function does nothing.
    /// </summary>
    public static void MaximizeWindow() => Maximized = true;

    /// <summary>
    /// This function restores the specified window if it was previously iconified(minimized) or maximized.
    /// If the window is already restored, this function does nothing.
    /// If the specified window is an iconified full screen window, its desired video mode is set again for its monitor when the window is restored.
    /// </summary>
    public static void RestoreWindow() => GLFW.RestoreWindow(Instance.window);

    /// <summary>
    /// This function returns the value of an attribute of the specified window or its OpenGL or OpenGL ES context.
    /// </summary>
    /// <param name="attrib">WindowAttributeIndex</param>
    /// <returns></returns>
    public static int GetWindowAttrib(int attrib) => GLFW.GetWindowAttrib(Instance.window, attrib);

    /// <summary>
    /// This function returns the compile-time generated [version string](of the GLFW library binary.
    /// It describes the version, platforms, compiler and any platform or operating system specific compile-time options.
    /// It should not be confused with the OpenGL or OpenGL ES version string, queried with `glGetString`.
    /// </summary>
    /// <returns>version string</returns>
    public static string GetGLFWVersionString() => GLFW.GetVersionStringS();

    /// <summary>
    /// Return a string describing the current GL connection
    /// </summary>
    /// <param name="name">GLStringName</param>
    /// <returns>describing string</returns>
    public static unsafe string GetGLString(GLStringName name) => Utility.PtrToUtf8String(Instance.GL.GetString(name));

    /// <summary>
    /// Sets the window's close flag to indicate that the window should be closed.
    /// </summary>
    public static void SetWindowShouldClose() => GLFW.SetWindowShouldClose(Instance.window, 1);

    /// <summary>
    /// Reads the color of a single pixel from the current framebuffer at the specified screen coordinates.
    /// </summary>
    /// <param name="x">The X coordinate of the pixel to read (in screen space).</param>
    /// <param name="y">The Y coordinate of the pixel to read (in screen space).</param>
    /// <returns>A Vector4 representing the RGBA color of the pixel with each component normalized to the range [0, 1].</returns>
    /// <remarks>
    /// This method uses OpenGL's glReadPixels to sample a single pixel from the currently bound framebuffer.
    /// The coordinates are in OpenGL screen space where (0,0) is typically at the bottom-left corner.
    /// The returned color values are floating-point values in the range [0, 1] for each RGBA component.
    /// This operation may cause a GPU-CPU synchronization point and should be used sparingly for performance reasons.
    /// </remarks>
    public static Vector4 GetPixelColor(int x, int y)
    {
        Span<float> pixel = stackalloc float[4];
        Instance.GL.ReadPixels(x, y, 1, 1, GLPixelFormat.Rgba, GLPixelType.Float, pixel);
        return new Vector4(pixel[0], pixel[1], pixel[2], pixel[3]);
    }

    /// <summary>
    /// Reads the RGB color of a single pixel from the current framebuffer at the specified screen coordinates.
    /// </summary>
    /// <param name="x">The X coordinate of the pixel to read (in screen space).</param>
    /// <param name="y">The Y coordinate of the pixel to read (in screen space).</param>
    /// <returns>A Vector3 representing the RGB color of the pixel with each component normalized to the range [0, 1].</returns>
    /// <remarks>
    /// This method uses OpenGL's glReadPixels to sample a single pixel from the currently bound framebuffer,
    /// reading only the RGB components and excluding alpha. The coordinates are in OpenGL screen space 
    /// where (0,0) is typically at the bottom-left corner. The returned color values are floating-point 
    /// values in the range [0, 1] for each RGB component.
    /// This operation may cause a GPU-CPU synchronization point and should be used sparingly for performance reasons.
    /// </remarks>
    public static Vector3 GetPixelColorRGB(int x, int y)
    {
        Span<float> pixel = stackalloc float[3];
        Instance.GL.ReadPixels(x, y, 1, 1, GLPixelFormat.Rgb, GLPixelType.Float, pixel);
        return new Vector3(pixel[0], pixel[1], pixel[2]);
    }

    /// <summary>
    /// Reads the color of a single pixel from the current framebuffer and returns it as a packed 32-bit unsigned integer.
    /// </summary>
    /// <param name="x">The X coordinate of the pixel to read (in screen space).</param>
    /// <param name="y">The Y coordinate of the pixel to read (in screen space).</param>
    /// <returns>A packed ABGR uint32 value where alpha is in the most significant byte and red is in the least significant byte.</returns>
    /// <remarks>
    /// This method uses OpenGL's glReadPixels to sample a single pixel from the currently bound framebuffer
    /// and packs the RGBA components into a single 32-bit unsigned integer. The coordinates are in OpenGL 
    /// screen space where (0,0) is typically at the bottom-left corner.
    /// The returned format is ABGR: Alpha in bits 31-24, Blue in bits 23-16, Green in bits 15-8, Red in bits 7-0.
    /// Each color component is represented as a byte value (0-255).
    /// This operation may cause a GPU-CPU synchronization point and should be used sparingly for performance reasons.
    /// </remarks>
    public static uint GetPixelColorUInt32(int x, int y)
    {
        Span<byte> pixel = stackalloc byte[4];
        Instance.GL.ReadPixels(x, y, 1, 1, GLPixelFormat.Rgba, GLPixelType.UnsignedByte, pixel);
        return (uint)(pixel[3] << 24 | pixel[2] << 16 | pixel[1] << 8 | pixel[0]);
    }

    /// <summary>
    /// Reads a rectangular region of pixels from the current framebuffer and returns them as an array of Vector4 colors.
    /// </summary>
    /// <param name="x">The X coordinate of the bottom-left corner of the region to read (in screen space).</param>
    /// <param name="y">The Y coordinate of the bottom-left corner of the region to read (in screen space).</param>
    /// <param name="width">The width of the region to read in pixels.</param>
    /// <param name="height">The height of the region to read in pixels.</param>
    /// <returns>An array of Vector4 RGBA colors with each component normalized to [0, 1]. The array is ordered row-major from bottom-left.</returns>
    /// <remarks>
    /// This method uses OpenGL's glReadPixels to sample a rectangular region from the currently bound framebuffer.
    /// The coordinates are in OpenGL screen space where (0,0) is typically at the bottom-left corner.
    /// The returned array contains width * height Vector4 elements, ordered in row-major format starting 
    /// from the bottom-left corner of the specified region. Each Vector4 represents an RGBA color with 
    /// floating-point components in the range [0, 1].
    /// This operation may cause a GPU-CPU synchronization point and should be used sparingly for performance reasons.
    /// Large regions will allocate significant memory and may impact performance.
    /// </remarks>
    public static Vector4[] ReadPixelRegion(int x, int y, int width, int height)
    {
        var pixels = new Vector4[width * height];
        Span<float> buffer = stackalloc float[width * height * 4];
        Instance.GL.ReadPixels(x, y, width, height, GLPixelFormat.Rgba, GLPixelType.Float, buffer);

        for (int i = 0; i < pixels.Length; i++)
        {
            int offset = i * 4;
            pixels[i] = new Vector4(buffer[offset], buffer[offset + 1], buffer[offset + 2], buffer[offset + 3]);
        }

        return pixels;
    }

    /// <summary>
    /// Reads a rectangular region of pixels from the current framebuffer and returns them as raw byte data.
    /// </summary>
    /// <param name="x">The X coordinate of the bottom-left corner of the region to read (in screen space).</param>
    /// <param name="y">The Y coordinate of the bottom-left corner of the region to read (in screen space).</param>
    /// <param name="width">The width of the region to read in pixels.</param>
    /// <param name="height">The height of the region to read in pixels.</param>
    /// <returns>A byte array containing raw RGBA pixel data where each pixel is represented by 4 consecutive bytes (R, G, B, A).</returns>
    /// <remarks>
    /// This method uses OpenGL's glReadPixels to sample a rectangular region from the currently bound framebuffer
    /// and returns the raw byte data without conversion. The coordinates are in OpenGL screen space where (0,0) 
    /// is typically at the bottom-left corner. The returned array contains width * height * 4 bytes, with each 
    /// pixel represented by 4 consecutive bytes in RGBA order. Each component is a byte value (0-255).
    /// The pixel data is ordered row-major from bottom-left. This method provides the most efficient way to 
    /// read pixel data when raw bytes are needed, avoiding floating-point conversion overhead.
    /// This operation may cause a GPU-CPU synchronization point and should be used sparingly for performance reasons.
    /// </remarks>
    public static byte[] ReadPixelRegionBytes(int x, int y, int width, int height)
    {
        byte[] pixels = new byte[width * height * 4];
        Instance.GL.ReadPixels(x, y, width, height, GLPixelFormat.Rgba, GLPixelType.UnsignedByte, pixels.AsSpan());
        return pixels;
    }
}
