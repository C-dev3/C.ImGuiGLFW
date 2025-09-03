using Hexa.NET.GLFW;

namespace C.ImGuiGLFW.Common;

/// <summary>
/// Provides a GLFW-based implementation of an OpenGL context for use with HexaGen runtime bindings.
/// </summary>
/// <param name="window">The GLFW window pointer to associate with this context.</param>
/// <remarks>
/// This class wraps a GLFW window to provide OpenGL context management functionality.
/// It implements the IGLContext interface to enable integration with HexaGen runtime systems.
/// The class handles context creation, activation, buffer swapping, and OpenGL function loading.
/// This is an unsafe class due to direct interop with native GLFW functions and pointer manipulation.
/// </remarks>
public unsafe class BindingsContext(GLFWwindowPtr window) : HexaGen.Runtime.IGLContext
{
    private GLFWwindowPtr window = window;

    /// <summary>
    /// Gets the native handle of the underlying GLFW window.
    /// </summary>
    /// <value>
    /// A native integer pointer representing the GLFW window handle.
    /// </value>
    /// <remarks>
    /// This handle can be used for direct interop with native APIs that require window handles.
    /// The handle remains valid as long as the associated GLFW window exists.
    /// </remarks>
    public nint Handle => (nint)window.Handle;

    /// <summary>
    /// Gets a value indicating whether this context is currently active on the calling thread.
    /// </summary>
    /// <value>
    /// <c>true</c> if this context is the current OpenGL context; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// OpenGL contexts are thread-local, meaning only one context can be current per thread.
    /// This property checks if the current thread's active context matches this instance.
    /// </remarks>
    public bool IsCurrent => GLFW.GetCurrentContext() == window;

    /// <summary>
    /// Releases all resources used by this context instance.
    /// </summary>
    /// <remarks>
    /// This implementation suppresses finalization to improve garbage collection performance.
    /// The underlying GLFW window is not destroyed by this method and must be managed separately.
    /// </remarks>
    public void Dispose() => GC.SuppressFinalize(this);

    /// <summary>
    /// Retrieves the address of an OpenGL function by name.
    /// </summary>
    /// <param name="procName">The name of the OpenGL function to retrieve.</param>
    /// <returns>
    /// A pointer to the requested OpenGL function, or <c>IntPtr.Zero</c> if the function is not available.
    /// </returns>
    /// <remarks>
    /// This method uses GLFW's function loading mechanism to retrieve OpenGL function pointers.
    /// The returned address can be used to create delegates for calling OpenGL functions.
    /// Function availability depends on the OpenGL version and supported extensions.
    /// </remarks>
    public nint GetProcAddress(string procName) => (nint)GLFW.GetProcAddress(procName);

    /// <summary>
    /// Determines whether the specified OpenGL extension is supported by the current context.
    /// </summary>
    /// <param name="extensionName">The name of the extension to check for support.</param>
    /// <returns>
    /// <c>true</c> if the extension is supported; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Extension support depends on the graphics driver and hardware capabilities.
    /// This method should be called after the context has been made current.
    /// </remarks>
    public bool IsExtensionSupported(string extensionName) => GLFW.ExtensionSupported(extensionName) != 0;

    /// <summary>
    /// Makes this OpenGL context current on the calling thread.
    /// </summary>
    /// <remarks>
    /// Only one OpenGL context can be current per thread at a time.
    /// Making a context current is required before calling OpenGL functions.
    /// This operation may be expensive and should be minimized in performance-critical code.
    /// </remarks>
    public void MakeCurrent() => GLFW.MakeContextCurrent(window);

    /// <summary>
    /// Swaps the front and back buffers of the associated window.
    /// </summary>
    /// <remarks>
    /// This method is used in double-buffered rendering to display the rendered frame.
    /// The swap operation presents the back buffer contents to the screen.
    /// This should be called after completing all rendering operations for a frame.
    /// </remarks>
    public void SwapBuffers() => GLFW.SwapBuffers(window);

    /// <summary>
    /// Sets the swap interval for buffer swapping operations.
    /// </summary>
    /// <param name="interval">
    /// The minimum number of screen updates to wait before swapping buffers.
    /// A value of 0 disables vsync, 1 enables vsync, and higher values create additional delays.
    /// </param>
    /// <remarks>
    /// This setting controls vertical synchronization (vsync) behavior.
    /// Setting interval to 1 typically limits the frame rate to the display's refresh rate.
    /// Setting interval to 0 allows unlimited frame rates but may cause screen tearing.
    /// </remarks>
    public void SwapInterval(int interval) => GLFW.SwapInterval(interval);

    /// <summary>
    /// Attempts to retrieve the address of an OpenGL function by name.
    /// </summary>
    /// <param name="procName">The name of the OpenGL function to retrieve.</param>
    /// <param name="procAddress">
    /// When this method returns, contains the address of the requested function if found,
    /// or <c>IntPtr.Zero</c> if the function is not available.
    /// </param>
    /// <returns>
    /// <c>true</c> if the function address was successfully retrieved; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method provides a safe way to attempt function loading without throwing exceptions.
    /// It is useful when checking for optional OpenGL functions or extensions.
    /// The returned address can be used to create delegates for calling OpenGL functions.
    /// </remarks>
    public bool TryGetProcAddress(string procName, out nint procAddress)
    {
        procAddress = (nint)GLFW.GetProcAddress(procName);
        return procAddress != 0;
    }
}
