using C.ImGuiGLFW.Data;
using C.ImGuiGLFW.JsonConverters;
using System.Text.Json;

namespace C.ImGuiGLFW.Common;

public class WindowSettings
{
    internal const string DefaultWindowName = "GLFWWindow";
    public static readonly WindowSettings Default = new();

    private string title = DefaultWindowName;
    public string Title
    {
        get => string.IsNullOrEmpty(title) ? DefaultWindowName : title;
        set => title = string.IsNullOrEmpty(value) ? DefaultWindowName : value;
    }

    private int width = 1000;

    public int Width
    {
        get => Math.Clamp(width, 1, WindowSizeConstraints.MaxLimitInt);
        set => width = Math.Clamp(value, 1, WindowSizeConstraints.MaxLimitInt);
    }

    private int height = 800;

    public int Height
    {
        get => Math.Clamp(height, 1, WindowSizeConstraints.MaxLimitInt);
        set => height = Math.Clamp(value, 1, WindowSizeConstraints.MaxLimitInt);
    }

    public Vector2? position = null;
    public Vector2? Position
    {
        get => position;
        set => position = value;
    }

    private double frameRate = 60.0d;
    public double FrameRate
    {
        get => Math.Clamp(frameRate, 1, ImGuiController.MaxFrequency);
        set => frameRate = Math.Clamp(value, 1, ImGuiController.MaxFrequency);
    }

    private float opacity = 1.0f;

    public float Opacity
    {
        get => Math.Clamp(opacity, 0, 1);
        set => opacity = Math.Clamp(value, 0, 1);
    }

    public bool Maximized { get; set; } = false;

    public bool Iconified { get; set; } = false;

    public bool ShowTitleBar { get; set; } = true;

    public bool TopMost { get; set; } = false;

    public bool FocusedOnStartup { get; set; } = true;

    public bool Resizable { get; set; } = true;

    public bool AutoIconify { get; set; } = true;

    public bool NavEnableKeyboard { get; set; } = true;

    public bool NavEnableGamepad { get; set; } = true;

    public bool DockingEnable { get; set; } = false;

    public bool ViewportsEnable { get; set; } = false;

    public StyleColors StyleColors { get; set; } = StyleColors.Dark;

    private WindowSizeConstraints windowSizeConstraints = WindowSizeConstraints.Default;

    public WindowSizeConstraints WindowSizeConstraints
    {
        get => windowSizeConstraints;
        set => windowSizeConstraints = value;
    }

    public Vector2 MinSize
    {
        get => windowSizeConstraints.MinSize;
        set => windowSizeConstraints.MinSize = value;
    }

    public Vector2 MaxSize
    {
        get => windowSizeConstraints.MaxSize;
        set => windowSizeConstraints.MaxSize = value;
    }

    private Vector4 _backGroundColor = new(0.196f, 0.196f, 0.196f, 1);
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