using Hexa.NET.GLFW;
using Serilog;
using System.Runtime.InteropServices;

namespace C.ImGuiGLFW;

public partial class ImGuiController
{
    private unsafe void CharCallback(GLFWwindow* window, uint codepoint)
    {
        try
        {
            _onCharCallback?.Invoke(codepoint);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(CharCallback)} Error");
            throw new Exception($"{nameof(CharCallback)} Error: {ex}");
        }
    }

    private unsafe void CharModsCallback(GLFWwindow* window, uint codepoint, int mods)
    {
        try
        {
            _onCharModsCallback?.Invoke(codepoint, mods);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(CharModsCallback)} Error");
            throw new Exception($"{nameof(CharModsCallback)} Error: {ex}");
        }
    }

    private unsafe void CursorEnterCallback(GLFWwindow* window, int entered)
    {
        try
        {
            _onCursorEnterCallback?.Invoke(entered != 0);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(CursorEnterCallback)} Error");
            throw new Exception($"{nameof(CursorEnterCallback)} Error: {ex}");
        }
    }

    private unsafe void CursorPosCallback(GLFWwindow* window, double xpos, double ypos)
    {
        try
        {
            _onCursorPosCallback?.Invoke(xpos, ypos);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(CursorPosCallback)} Error");
            throw new Exception($"{nameof(CursorPosCallback)} Error: {ex}");
        }
    }

    private unsafe void DropCallback(GLFWwindow* window, int pathCount, byte** paths)
    {
        try
        {
            List<string> filePaths = new(pathCount);
            for (int i = 0; i < pathCount; i++)
            {
                byte* pathPtr = paths[i];
                filePaths.Add(Marshal.PtrToStringUTF8((nint)pathPtr) ?? string.Empty);
            }
            _onDropCallback?.Invoke(pathCount, filePaths);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(DropCallback)} Error");
            throw new Exception($"{nameof(DropCallback)} Error: {ex}");
        }
    }

    private unsafe void GLFWErrorCallback(int errorCode, byte* description)
    {
        try
        {
            string errorMessage = Marshal.PtrToStringAnsi((IntPtr)description) ?? "Unknown error";
            _onGLFWErrorCallback?.Invoke(errorCode, errorMessage);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(GLFWErrorCallback)} Error");
            throw new Exception($"{nameof(GLFWErrorCallback)} Error: {ex}");
        }
    }

    private unsafe void FrameBufferSizeCallback(GLFWwindow* window, int width, int height)
    {
        try
        {
            _onFrameBufferSizeCallback?.Invoke(width, height);
            RenderFrameFromCallback();
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(FrameBufferSizeCallback)} Error");
            throw new Exception($"{nameof(FrameBufferSizeCallback)} Error: {ex}");
        }
    }

    private void JoystickCallback(int jid, int evnt)
    {
        try
        {
            _onJoystickCallback?.Invoke(jid, evnt);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(JoystickCallback)} Error");
            throw new Exception($"{JoystickCallback} Error: {ex}");
        }
    }

    private unsafe void KeyCallback(GLFWwindow* window, int key, int scancode, int action, int mods)
    {
        try
        {
            _onKeyCallback?.Invoke(key, scancode, action, mods);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(KeyCallback)} Error");
            throw new Exception($"{nameof(KeyCallback)} Error: {ex}");
        }
    }

    private unsafe void MonitorCallback(GLFWmonitor* monitor, int evnt)
    {
        try
        {
            _onMonitorCallback?.Invoke(evnt);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(MonitorCallback)} Error");
            throw new Exception($"{nameof(MonitorCallback)} Error: {ex}");
        }
    }

    private unsafe void MouseButtonCallback(GLFWwindow* window, int button, int action, int mods)
    {
        try
        {
            _onMouseButtonCallback?.Invoke(button, action, mods);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(MouseButtonCallback)} Error");
            throw new Exception($"{nameof(MouseButtonCallback)} Error: {ex}");
        }
    }

    private unsafe void ScrollCallback(GLFWwindow* window, double xoffset, double yoffset)
    {
        try
        {
            _onScrollCallback?.Invoke(xoffset, yoffset);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(ScrollCallback)} Error");
            throw new Exception($"{nameof(ScrollCallback)} Error: {ex}");
        }
    }

    private unsafe void WindowCloseCallback(GLFWwindow* window)
    {
        try
        {
            _onWindowCloseCallback?.Invoke();
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowCloseCallback)} Error");
            throw new Exception($"{WindowCloseCallback} Error: {ex}");
        }
    }

    private unsafe void WindowContentScaleCallback(GLFWwindow* window, float xscale, float yscale)
    {
        try
        {
            _onWindowContentScaleCallback?.Invoke(xscale, yscale);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowContentScaleCallback)} Error");
            throw new Exception($"{nameof(WindowContentScaleCallback)} Error: {ex}");
        }
    }

    private unsafe void WindowFocusCallback(GLFWwindow* window, int focused)
    {
        try
        {
            _onWindowFocusCallback?.Invoke(focused != 0);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowFocusCallback)} Error");
            throw new Exception($"{nameof(WindowFocusCallback)} Error: {ex}");
        }
    }

    private unsafe void WindowIconifyCallback(GLFWwindow* window, int iconified)
    {
        try
        {
            bool icon = iconified != 0;
            _onWindowIconifyCallback?.Invoke(icon);
            WindowSettings.Iconified = icon;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowIconifyCallback)} Error");
            throw new Exception($"{nameof(WindowIconifyCallback)} Error: {ex}");
        }
    }

    private unsafe void WindowMaximizeCallback(GLFWwindow* window, int maximized)
    {
        try
        {
            bool max = maximized != 0;
            _onWindowMaximizeCallback?.Invoke(max);
            WindowSettings.Maximized = max;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowMaximizeCallback)} Error");
            throw new Exception($"{nameof(WindowMaximizeCallback)} Error: {ex}");
        }
    }

    private unsafe void WindowRefreshCallback(GLFWwindow* window)
    {
        try
        {
            _onWindowRefreshCallback?.Invoke();
            RenderFrameFromCallback();
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowRefreshCallback)} Error");
            throw new Exception($"{nameof(WindowRefreshCallback)} Error: {ex}");
        }
    }

    private unsafe void WindowResizeCallback(GLFWwindow* window, int width, int height)
    {
        try
        {
            _onResizeCallback?.Invoke(new ResizeEventArgs(width, height));
            GL.Viewport(0, 0, (int)ClientSize.X, (int)ClientSize.Y);
            RenderFrameFromCallback();
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowResizeCallback)} Error");
            throw new Exception($"{nameof(WindowResizeCallback)} Error: {ex}");
        }
    }

    private unsafe void WindowPosCallback(GLFWwindow* window, int xpos, int ypos)
    {
        try
        {
            _onSetPosCallback?.Invoke(new SetPosEventArgs(xpos, ypos));
            RenderFrameFromCallback();
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{nameof(WindowPosCallback)} Error");
            throw new Exception($"{nameof(WindowPosCallback)} Error: {ex}");
        }
    }
}
