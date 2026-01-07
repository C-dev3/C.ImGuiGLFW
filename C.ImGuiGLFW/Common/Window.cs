using Serilog;

namespace C.ImGuiGLFW.Common;

/// <summary>
/// Represents a base class for an ImGui window with lifecycle management, layout control, and rendering support.
/// Derived classes must implement the <see cref="Draw"/> method to render window content.
/// </summary>
public abstract class Window
{
    private bool internalLastIsOpen = false;
    private bool internalIsOpen = false;

    /// <summary>
    /// Gets or sets whether the window is currently open and visible.
    /// </summary>
    public bool IsOpen
    {
        get => internalIsOpen;
        set => internalIsOpen = value;
    }

    /// <summary>
    /// Gets or sets the ImGui window flags that control window behavior and appearance.
    /// </summary>
    public ImGuiWindowFlags Flags { get; set; } = ImGuiWindowFlags.None;

    /// <summary>
    /// Gets or sets the size of the window. If null, the window size will not be explicitly set.
    /// </summary>
    public Vector2? WindowSize { get; set; } = null;

    /// <summary>
    /// Gets or sets the condition under which the window size should be applied.
    /// </summary>
    public ImGuiCond SizeCondition { get; set; } = ImGuiCond.None;

    /// <summary>
    /// Gets or sets whether the window should be collapsed. If null, the collapsed state will not be explicitly set.
    /// </summary>
    public bool? Collapsed { get; set; } = null;

    /// <summary>
    /// Gets or sets a value indicating whether the window is maximized.
    /// </summary>
    public bool? IsMaximized { get; set; }

    /// <summary>
    /// Gets or sets the condition under which the window collapsed state should be applied.
    /// </summary>
    public ImGuiCond CollapsedCondition { get; set; } = ImGuiCond.None;

    /// <summary>
    /// Gets or sets the position of the window. If null, the window position will not be explicitly set.
    /// </summary>
    public Vector2? Position { get; set; } = null;

    /// <summary>
    /// Gets or sets the condition under which the window position should be applied.
    /// </summary>
    public ImGuiCond PositionCondition { get; set; } = ImGuiCond.None;

    /// <summary>
    /// Gets or sets the size constraints for the window, defining minimum and maximum sizes.
    /// </summary>
    public WindowSizeConstraints? WindowSizeConstraints { get; set; } = null;

    /// <summary>
    /// Gets or sets whether the window should display a close button in its title bar.
    /// </summary>
    public bool ShowCloseButton { get; set; } = true;

    /// <summary>
    /// Determines the priority of the window, which may influence rendering or update order when multiple windows are processed.
    /// </summary>
    public int Priority = 0;

    /// <summary>
    /// Gets the name of the window, which is displayed in the title bar.
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// Gets or sets the unique identifier used to distinguish this window instance in ImGui.
    /// </summary>
    public int Id;

    /// <summary>
    /// Gets or sets the identifier of the viewport associated with this instance.
    /// </summary>
    public uint? ViewportID { get; set; } = null;

    /// <summary>
    /// Initializes a new instance of the Window class with the specified name.
    /// </summary>
    /// <param name="name">The name to display in the window title bar.</param>
    protected Window(string name) => Name = name;

    /// <summary>
    /// Initializes a new instance of the Window class using the class type name as the window name.
    /// </summary>
    protected Window() => Name = GetType().Name;

    /// <summary>
    /// Performs internal window rendering logic, including lifecycle callbacks and error handling.
    /// This method is called by the framework to manage the window's visibility, layout, and content.
    /// </summary>
    public void InternalDraw()
    {
        if (!IsOpen)
        {
            if (internalIsOpen != internalLastIsOpen)
            {
                internalLastIsOpen = internalIsOpen;
                OnClose();
            }
        }

        if (internalLastIsOpen != internalIsOpen && internalIsOpen)
        {
            internalLastIsOpen = internalIsOpen;
            OnOpen();
        }

        if (!DrawConditions()) return;

        if (IsOpen)
        {
            try
            {
                ImGui.PushID(Id.ToString());

                try
                {
                    ApplyPreConditions();

                    PreDraw();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error in PreDraw for window {Name}");
                }

                ApplyConditions();

                if (ShowCloseButton ? ImGui.Begin(Name + "##" + Id, ref internalIsOpen, Flags) : ImGui.Begin(Name + "##" + Id, Flags))
                {
                    try
                    {
                        Draw();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, $"Error drawing window {Name}");
                    }
                }

                ImGui.End();

                try
                {
                    PostDraw();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Error in PostDraw for window {Name}");
                }
            }
            finally
            {
                ImGui.PopID();
            }
        }
    }

    private void ApplyConditions()
    {
        if (Position.HasValue) ImGui.SetNextWindowPos(Position.Value, PositionCondition);
        if (WindowSize.HasValue) ImGui.SetNextWindowSize(WindowSize.Value, SizeCondition);
        if (Collapsed.HasValue) ImGui.SetNextWindowCollapsed(Collapsed.Value, CollapsedCondition);
        if (WindowSizeConstraints.HasValue) ImGui.SetNextWindowSizeConstraints(WindowSizeConstraints.Value.MinSize, WindowSizeConstraints.Value.MaxSize);
    }

    private void ApplyPreConditions()
    {
        if (ViewportID.HasValue) ImGui.SetNextWindowViewport(ViewportID.Value);
        if (IsMaximized.HasValue && IsMaximized.Value) SetWindowMaximize();
    }

    private void SetWindowMaximize()
    {
        var mainViewport = ImGui.GetMainViewport();
        WindowSize = mainViewport.WorkSize;
        Position = mainViewport.WorkPos;
    }

    /// <summary>
    /// Called when the window is first loaded or initialized.
    /// </summary>
    public virtual void OnLoad() { }

    /// <summary>
    /// Called every update frame to perform per-frame logic.
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// Called when the window transitions from closed to open state.
    /// </summary>
    public virtual void OnOpen() { }

    /// <summary>
    /// Called before the main Draw method, allowing for pre-drawing setup.
    /// </summary>
    public virtual void PreDraw() { }

    /// <summary>
    /// Abstract method that must be implemented by derived classes to define the window's content rendering.
    /// </summary>
    protected abstract void Draw();

    /// <summary>
    /// Called after the main Draw method, allowing for post-drawing cleanup or additional rendering.
    /// </summary>
    public virtual void PostDraw() { }

    /// <summary>
    /// Called when the window transitions from open to closed state.
    /// </summary>
    public virtual void OnClose() { }

    /// <summary>
    /// Called when the window is being disposed of, allowing for resource cleanup.
    /// </summary>
    public virtual void OnDispose() { }

    /// <summary>
    /// Determines whether the window should be drawn in the current frame. Override to implement custom draw conditions.
    /// </summary>
    /// <returns>True if the window should be drawn, false otherwise.</returns>s
    public virtual bool DrawConditions() => true;

    /// <summary>
    /// Shows the window by setting <see cref="IsOpen"/> to true.
    /// </summary>
    public void Show() => IsOpen = true;

    /// <summary>
    /// Closes the window by setting <see cref="IsOpen"/> to false.
    /// </summary>
    public void Close() => IsOpen = false;

    /// <summary>
    /// Toggles the open state of the window.
    /// If the window is currently open, it will be closed; if closed, it will be opened.
    /// </summary>
    public void Toggle() => IsOpen ^= true;
}
