# About

C.ImGuiGLFW is a C# class library that simplifies the creation of ImGui-rendered windows. It uses OpenGL 4.6 core for rendering, GLFW for window management system, and Hexa.NET.ImGui for ImGui integration.

# Usage

Get C.ImGuiGLFW from NuGet using a console command:
```
dotnet add package C.ImGuiGLFW
```
Or simply find it via NuGet package manager GUI.

## Basic Setup

Initialize the ImGuiController in the Main() method of your program:

```csharp
ImGuiController.Initialize("MyApplication", modules: Module.All);
```

The `Initialize` method has multiple overloads to accommodate different initialization scenarios:

```csharp
// Basic initialization with default settings
ImGuiController.Initialize();

// Initialize with modules
ImGuiController.Initialize(modules: Module.All);

// Initialize with window title
ImGuiController.Initialize("MyApp");

// Initialize with title and modules
ImGuiController.Initialize("MyApp", Module.All);

// Initialize with title and dimensions
ImGuiController.Initialize("MyApp", 800, 600);

// Initialize with title, dimensions, and modules
ImGuiController.Initialize("MyApp", 800, 600, Module.All);

// Initialize with dimensions only
ImGuiController.Initialize(800, 600);

// Initialize with dimensions and modules
ImGuiController.Initialize(800, 600, Module.All);

// Initialize with dimensions and position
ImGuiController.Initialize(800, 600, new Vector2(100, 100));

// Initialize with dimensions, position, and modules
ImGuiController.Initialize(800, 600, new Vector2(100, 100), Module.Guizmo);

// Initialize with dimensions, position, and resizable flag
ImGuiController.Initialize(800, 600, new Vector2(100, 100), true);

// Initialize with dimensions, position, resizable flag, and modules
ImGuiController.Initialize(800, 600, new Vector2(100, 100), true, Module.Nodes, Module Plot);

// Initialize with dimensions and position coordinates
ImGuiController.Initialize(800, 600, 100, 100);

// Initialize with dimensions, position coordinates, and modules
ImGuiController.Initialize(800, 600, 100, 100, Module.Plot);

// Initialize with custom WindowSettings
ImGuiController.Initialize(windowSettings);

// Initialize with custom WindowSettings and modules
ImGuiController.Initialize(windowSettings, Module.All);
```

Parameters:
- `windowSettings`: Custom window settings (optional, reads from file if null)
- `title`: Window title
- `width`/`height`: Window dimensions in pixels
- `position`: Window position as Vector2 or separate X/Y coordinates
- `resizable`: Whether the window should be resizable
- `modules`: ImGui modules to initialize (optional params array)

## Event Handling

Subscribe to various events to handle user input and UI rendering:

```csharp
// Handle main menu bar rendering
ImGuiController.OnMainMenuBarRender += MainMenuBar;

// Handle character input events
ImGuiController.OnChar += OnCharInput;
```

## Adding Windows

Create and add your custom ImGui windows:

```csharp
var demoWindow = new DemoWindow();
ImGuiController.AddWindow(demoWindow);
```

## Running the Application

Start the main application loop:

```csharp
ImGuiController.Run();
```

## Example

Here's a minimal example:

```csharp
using System;
using C.ImGuiGLFW;

class Program
{
    static void Main()
    {
        // Initialize ImGuiController
        ImGuiController.Initialize("TESTWINDOW");
        
        // Set up event handlers
        ImGuiController.OnMainMenuBarRender += MainMenuBar;
        ImGuiController.OnChar += OnCharInput;
        
        // Create and add windows
        var demoWindow = new DemoWindow();
        ImGuiController.AddWindow(demoWindow);
        
        // Start the application
        ImGuiController.Run();
    }
    
    private static void MainMenuBar()
    {
        // Your main menu bar implementation
    }
    
    private static void OnCharInput(uint codepoint)
    {
        // Handle character input
    }
}
```

## Creating Custom Windows

To create custom windows, implement the appropriate window interface or base class:

```csharp
public class DemoWIndow : Window
{
    protected override void Draw()
    {
        ImGui.Text("Hello, World!");
    }
}
```

## Available Modules

The `Module` enum allows you to specify which ImGui modules to initialize:
- `Module.All`: Load all available modules
- `Module.Guizmo`: ImGuizmo for 3D gizmo manipulation
- `Module.Nodes`: ImNodes for node-based graph editing
- `Module.Plot`: ImPlot for data plotting and visualization

Multiple modules can be specified:
```csharp
// Load specific modules
ImGuiController.Initialize("MyApp", Module.Guizmo, Module.Plot);

// Load all modules (equivalent to Module.All)
ImGuiController.Initialize("MyApp", Module.Guizmo, Module.Nodes, Module.Plot);
```

## More Examples

For more detailed examples and advanced usage patterns, please visit the [here](https://github.com/C-dev3/C.ImGuiGLFWExample).

## Dependencies
This project depends on several NuGet packages. Run `dotnet list package` to see current versions, or check [THIRD-PARTY-NOTICES](https://github.com/C-dev3/C.ImGuiGLFWExample/raw/refs/heads/master/THIRD-PARTY-NOTICES.txt) for license details.