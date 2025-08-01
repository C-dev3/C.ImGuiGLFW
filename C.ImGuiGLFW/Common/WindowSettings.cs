using C.ImGuiGLFW.Data;
using C.ImGuiGLFW.JsonConverters;
using System.Text.Json;

namespace C.ImGuiGLFW.Common;

/// <summary>
/// Represents configuration settings for an ImGui GLFW window, including size, position, appearance, behavior, and serialization.
/// </summary>
public class WindowSettings
{
    internal const string DefaultWindowName = "GLFWWindow";

    /// <summary>
    /// Gets the default <see cref="WindowSettings"/> instance with standard values.
    /// </summary>
    public static readonly WindowSettings Default = new();

    private string title = DefaultWindowName;
    /// <summary>
    /// Gets or sets the title of the window.
    /// If not set or empty, a default title is used.
    /// </summary>
    public string Title
    {
        get => string.IsNullOrEmpty(title) ? DefaultWindowName : title;
        set => title = string.IsNullOrEmpty(value) ? DefaultWindowName : value;
    }

    private int width = 1000;
    /// <summary>
    /// Gets or sets the width of the window in pixels, clamped to a valid range.
    /// </summary>
    public int Width
    {
        get => Math.Clamp(width, 1, WindowSizeConstraints.MaxLimitInt);
        set => width = Math.Clamp(value, 1, WindowSizeConstraints.MaxLimitInt);
    }

    private int height = 800;
    /// <summary>
    /// Gets or sets the height of the window in pixels, clamped to a valid range.
    /// </summary>
    public int Height
    {
        get => Math.Clamp(height, 1, WindowSizeConstraints.MaxLimitInt);
        set => height = Math.Clamp(value, 1, WindowSizeConstraints.MaxLimitInt);
    }

    private Vector2? position = null;
    /// <summary>
    /// Gets or sets the position of the window on the screen.
    /// If null, the window position is not explicitly set.
    /// </summary>
    public Vector2? Position
    {
        get => position;
        set => position = value;
    }

    private double frameRate = 60.0d;
    /// <summary>
    /// Gets or sets the target frame rate (refresh rate) of the window, clamped to a valid range.
    /// </summary>
    public double FrameRate
    {
        get => Math.Clamp(frameRate, 1, ImGuiController.MaxFrequency);
        set => frameRate = Math.Clamp(value, 1, ImGuiController.MaxFrequency);
    }

    private float opacity = 1.0f;
    /// <summary>
    /// Gets or sets the opacity of the window, between 0 (transparent) and 1 (fully opaque).
    /// </summary>
    public float Opacity
    {
        get => Math.Clamp(opacity, 0, 1);
        set => opacity = Math.Clamp(value, 0, 1);
    }

    /// <summary>
    /// Gets or sets whether the window should start maximized.
    /// </summary>
    public bool Maximized { get; set; } = false;

    /// <summary>
    /// Gets or sets whether the window should start minimized (iconified).
    /// </summary>
    public bool Iconified { get; set; } = false;

    /// <summary>
    /// Gets or sets whether the window title bar should be visible.
    /// </summary>
    public bool ShowTitleBar { get; set; } = true;

    /// <summary>
    /// Gets or sets whether the window should be kept on top of other windows.
    /// </summary>
    public bool TopMost { get; set; } = false;

    /// <summary>
    /// Gets or sets whether the window should be focused when the application starts.
    /// </summary>
    public bool FocusedOnStartup { get; set; } = true;

    /// <summary>
    /// Gets or sets whether the window can be resized by the user.
    /// </summary>
    public bool Resizable { get; set; } = true;

    /// <summary>
    /// Gets or sets whether the window should automatically minimize when the application loses focus in fullscreen.
    /// </summary>
    public bool AutoIconify { get; set; } = true;

    /// <summary>
    /// Gets or sets whether keyboard navigation is enabled in ImGui.
    /// </summary>
    public bool NavEnableKeyboard { get; set; } = true;

    /// <summary>
    /// Gets or sets whether gamepad navigation is enabled in ImGui.
    /// </summary>
    public bool NavEnableGamepad { get; set; } = true;

    /// <summary>
    /// Gets or sets whether ImGui docking is enabled.
    /// </summary>
    public bool DockingEnable { get; set; } = false;

    /// <summary>
    /// Gets or sets whether multi-viewport support is enabled in ImGui.
    /// </summary>
    public bool ViewportsEnable { get; set; } = false;

    /// <summary>
    /// Gets or sets the base ImGui style color theme for the window.
    /// </summary>
    public StyleColors StyleColors { get; set; } = StyleColors.Dark;

    private WindowSizeConstraints windowSizeConstraints = WindowSizeConstraints.Default;
    /// <summary>
    /// Gets or sets the constraints for the window's minimum and maximum size.
    /// </summary>
    public WindowSizeConstraints WindowSizeConstraints
    {
        get => windowSizeConstraints;
        set => windowSizeConstraints = value;
    }

    /// <summary>
    /// Gets or sets the minimum allowed size of the window.
    /// </summary>
    public Vector2 MinSize
    {
        get => windowSizeConstraints.MinSize;
        set => windowSizeConstraints.MinSize = value;
    }

    /// <summary>
    /// Gets or sets the maximum allowed size of the window.
    /// </summary>
    public Vector2 MaxSize
    {
        get => windowSizeConstraints.MaxSize;
        set => windowSizeConstraints.MaxSize = value;
    }

    private Vector4 _backGroundColor = new(0.196f, 0.196f, 0.196f, 1);
    /// <summary>
    /// Gets or sets the background clear color of the window.
    /// Values are clamped between 0 and 1 for each channel (RGBA).
    /// </summary>
    public Vector4 BackgroundColor
    {
        get => _backGroundColor;

        set
        {
            _backGroundColor = new Vector4(
                Math.Clamp(value.X, 0, 1),
                Math.Clamp(value.Y, 0, 1),
                Math.Clamp(value.Z, 0, 1),
                Math.Clamp(value.W, 0, 1)
                );
        }
    }

    /// <summary>
    /// Gets the file path where the window configuration JSON is saved or loaded from.
    /// </summary>
    public static readonly string Location = Path.GetDirectoryName(AppContext.BaseDirectory) + "\\" + "windowconfig.json";
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Converters =
        {
            new Vector2Converter(),
            new Vector4Converter(),
            new WindowSizeConstraintsJsonConverter(),
            new Vector2NullableConverter()
        },
    };

    /// <summary>
    /// Reads window settings from a JSON configuration file.
    /// Returns <see cref="Default"/> if the file does not exist or parsing fails.
    /// </summary>
    /// <returns>A <see cref="WindowSettings"/> instance loaded from file, or default.</returns>
    public static WindowSettings ReadFromFile()
    {
        try
        {
            if (!File.Exists(Location)) return Default;
            string jsonString = File.ReadAllText(Location);
            var settings = JsonSerializer.Deserialize<WindowSettings>(jsonString, Options);
            return settings ?? Default;
        }
        catch { return Default; }
    }

    /// <summary>
    /// Saves the current window settings to the configuration file.
    /// </summary>
    /// <returns><c>true</c> if the settings were successfully written; otherwise, <c>false</c>.</returns>
    public bool Write()
    {
        try
        {
            var directoryPath = Path.GetDirectoryName(Location);
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string jsonString = JsonSerializer.Serialize(this, Options);
            File.WriteAllText(Location, jsonString);
            return true;
        }
        catch
        {
            return false;
        }
    }
}