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
