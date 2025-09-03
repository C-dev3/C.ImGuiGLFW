using Hexa.NET.GLFW;

namespace C.ImGuiGLFW.ImGuiMethods.Web;

/// <summary>
/// Provides utility methods for working with the Chromium Embedded Framework (CEF),
/// including key mapping and input handling functionality.
/// </summary>
/// <remarks>
/// This static class contains helper methods that facilitate integration between
/// different input systems and CEF. It primarily handles conversion between
/// different key code formats to ensure proper input handling in CEF-based applications.
/// </remarks>
public static class CefHelper
{
    /// <summary>
    /// Maps a GLFW key code to its corresponding Windows virtual key code.
    /// </summary>
    /// <param name="key">The GLFW key code to map.</param>
    /// <returns>The corresponding Windows virtual key code.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the specified key is <see cref="GlfwKey.Unknown"/> or when no mapping exists for the given key.
    /// </exception>
    /// <remarks>
    /// This method provides a mapping between GLFW key codes and Windows virtual key codes,
    /// which is necessary when integrating GLFW-based input handling with CEF browser instances.
    /// </remarks>
    public static VirtualKey MapKeyCodeToVirtualKey(GlfwKey key) => key switch
    {
        GlfwKey.Unknown => throw new ArgumentOutOfRangeException(nameof(key), "Unknown key ocde"),
        GlfwKey.Enter => VirtualKey.Return,
        GlfwKey.Escape => VirtualKey.Escape,
        GlfwKey.Backspace => VirtualKey.Back,
        GlfwKey.Tab => VirtualKey.Tab,
        GlfwKey.Space => VirtualKey.Space,
        GlfwKey.A => VirtualKey.A,
        GlfwKey.B => VirtualKey.B,
        GlfwKey.C => VirtualKey.C,
        GlfwKey.D => VirtualKey.D,
        GlfwKey.E => VirtualKey.E,
        GlfwKey.F => VirtualKey.F,
        GlfwKey.G => VirtualKey.G,
        GlfwKey.H => VirtualKey.H,
        GlfwKey.I => VirtualKey.I,
        GlfwKey.J => VirtualKey.J,
        GlfwKey.K => VirtualKey.K,
        GlfwKey.L => VirtualKey.L,
        GlfwKey.M => VirtualKey.M,
        GlfwKey.N => VirtualKey.N,
        GlfwKey.O => VirtualKey.O,
        GlfwKey.P => VirtualKey.P,
        GlfwKey.Q => VirtualKey.Q,
        GlfwKey.R => VirtualKey.R,
        GlfwKey.S => VirtualKey.S,
        GlfwKey.T => VirtualKey.T,
        GlfwKey.U => VirtualKey.U,
        GlfwKey.V => VirtualKey.V,
        GlfwKey.W => VirtualKey.W,
        GlfwKey.X => VirtualKey.X,
        GlfwKey.Y => VirtualKey.Y,
        GlfwKey.Z => VirtualKey.Z,
        GlfwKey.F1 => VirtualKey.F1,
        GlfwKey.F2 => VirtualKey.F2,
        GlfwKey.F3 => VirtualKey.F3,
        GlfwKey.F4 => VirtualKey.F4,
        GlfwKey.F5 => VirtualKey.F5,
        GlfwKey.F6 => VirtualKey.F6,
        GlfwKey.F7 => VirtualKey.F7,
        GlfwKey.F8 => VirtualKey.F8,
        GlfwKey.F9 => VirtualKey.F9,
        GlfwKey.F10 => VirtualKey.F10,
        GlfwKey.F11 => VirtualKey.F11,
        GlfwKey.F12 => VirtualKey.F12,
        GlfwKey.F13 => VirtualKey.F13,
        GlfwKey.F14 => VirtualKey.F14,
        GlfwKey.F15 => VirtualKey.F15,
        GlfwKey.F16 => VirtualKey.F16,
        GlfwKey.F17 => VirtualKey.F17,
        GlfwKey.F18 => VirtualKey.F18,
        GlfwKey.F19 => VirtualKey.F19,
        GlfwKey.F20 => VirtualKey.F20,
        GlfwKey.F21 => VirtualKey.F21,
        GlfwKey.F22 => VirtualKey.F22,
        GlfwKey.F23 => VirtualKey.F23,
        GlfwKey.F24 => VirtualKey.F24,
        GlfwKey.Insert => VirtualKey.Insert,
        GlfwKey.Delete => VirtualKey.Delete,
        GlfwKey.Home => VirtualKey.Home,
        GlfwKey.End => VirtualKey.End,
        GlfwKey.PageUp => VirtualKey.Prior,
        GlfwKey.PageDown => VirtualKey.Next,
        GlfwKey.Left => VirtualKey.Left,
        GlfwKey.Right => VirtualKey.Right,
        GlfwKey.Up => VirtualKey.Up,
        GlfwKey.Down => VirtualKey.Down,
        GlfwKey.CapsLock => VirtualKey.Capital,
        GlfwKey.NumLock => VirtualKey.NumLock,
        GlfwKey.ScrollLock => VirtualKey.Scroll,
        GlfwKey.LeftControl => VirtualKey.LControl,
        GlfwKey.RightControl => VirtualKey.RControl,
        GlfwKey.LeftShift => VirtualKey.LShift,
        GlfwKey.RightShift => VirtualKey.RShift,
        GlfwKey.LeftAlt => VirtualKey.LMenu,
        GlfwKey.RightAlt => VirtualKey.RMenu,
        GlfwKey.LeftSuper => VirtualKey.LWin,
        GlfwKey.RightSuper => VirtualKey.RWin,
        GlfwKey.Menu => VirtualKey.Apps,
        GlfwKey.Key0 => VirtualKey.D0,
        GlfwKey.Key1 => VirtualKey.D1,
        GlfwKey.Key2 => VirtualKey.D2,
        GlfwKey.Key3 => VirtualKey.D3,
        GlfwKey.Key4 => VirtualKey.D4,
        GlfwKey.Key5 => VirtualKey.D5,
        GlfwKey.Key6 => VirtualKey.D6,
        GlfwKey.Key7 => VirtualKey.D7,
        GlfwKey.Key8 => VirtualKey.D8,
        GlfwKey.Key9 => VirtualKey.D9,
        GlfwKey.KpDivide => VirtualKey.Divide,
        GlfwKey.KpMultiply => VirtualKey.Multiply,
        GlfwKey.KpSubtract => VirtualKey.Subtract,
        GlfwKey.KpAdd => VirtualKey.Add,
        GlfwKey.KpEnter => VirtualKey.Return,
        GlfwKey.Kp0 => VirtualKey.Numpad0,
        GlfwKey.Kp1 => VirtualKey.Numpad1,
        GlfwKey.Kp2 => VirtualKey.Numpad2,
        GlfwKey.Kp3 => VirtualKey.Numpad3,
        GlfwKey.Kp4 => VirtualKey.Numpad4,
        GlfwKey.Kp5 => VirtualKey.Numpad5,
        GlfwKey.Kp6 => VirtualKey.Numpad6,
        GlfwKey.Kp7 => VirtualKey.Numpad7,
        GlfwKey.Kp8 => VirtualKey.Numpad8,
        GlfwKey.Kp9 => VirtualKey.Numpad9,
        GlfwKey.Period => VirtualKey.Decimal,
        GlfwKey.PrintScreen => VirtualKey.Snapshot,
        GlfwKey.Pause => VirtualKey.Pause,
        GlfwKey.Apostrophe => VirtualKey.Oem7,
        GlfwKey.Comma => VirtualKey.OemComma,
        GlfwKey.Minus => VirtualKey.OemMinus,
        GlfwKey.KpEqual => VirtualKey.OemPlus,
        GlfwKey.KpDecimal => VirtualKey.Decimal,
        GlfwKey.Slash => VirtualKey.Oem2,
        GlfwKey.Semicolon => VirtualKey.Oem1,
        GlfwKey.Equal => VirtualKey.OemPlus,
        GlfwKey.LeftBracket => VirtualKey.Oem4,
        GlfwKey.Backslash => VirtualKey.Oem5,
        GlfwKey.RightBracket => VirtualKey.Oem6,
        GlfwKey.GraveAccent => VirtualKey.Oem3,
        _ => throw new ArgumentOutOfRangeException(nameof(key), $"Unhandled KeyCode: {key}")
    };
}