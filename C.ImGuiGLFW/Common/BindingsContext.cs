using Hexa.NET.GLFW;

namespace C.ImGuiGLFW.Common;

internal unsafe class BindingsContext(GLFWwindowPtr window) : HexaGen.Runtime.IGLContext
{
    private GLFWwindowPtr window = window;

    public nint Handle => (nint)window.Handle;

    public bool IsCurrent => GLFW.GetCurrentContext() == window;

    public void Dispose() { }

    public nint GetProcAddress(string procName) => (nint)GLFW.GetProcAddress(procName);

    public bool IsExtensionSupported(string extensionName) => GLFW.ExtensionSupported(extensionName) != 0;

    public void MakeCurrent() => GLFW.MakeContextCurrent(window);

    public void SwapBuffers() => GLFW.SwapBuffers(window);

    public void SwapInterval(int interval) => GLFW.SwapInterval(interval);

    public bool TryGetProcAddress(string procName, out nint procAddress)
    {
        procAddress = (nint)GLFW.GetProcAddress(procName);
        return procAddress != 0;
    }
}
