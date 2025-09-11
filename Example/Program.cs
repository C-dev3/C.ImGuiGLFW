using C.ImGuiGLFW;
using C.ImGuiGLFW.Data;
using C.ImGuiGLFW.ImGuiMethods;
using Example;
using Hexa.NET.ImGui;

internal class Program
{
    private static readonly DemoWindow demoWindow = new("DemoTitle");
    private static void Main()
    {
        ImGuiController.Initialize($"TESTWINDOW", 1280, 720, true, Module.Nodes, Module.Plot);
        ImGuiController.OnMainMenuBarRender += MainMenuBar;
        ImGuiController.OnChar += OnCharInput;
        //ImGuiController.AddWindow(demoWindow);
        ImGuiController.AddWindow(new WebViewDemo());
        ImGuiController.Run();
    }

    private static void OnCharInput(uint codepoint) { }

    private static void MainMenuBar()
    {
        if (ImGui.BeginMenu("Windows"))
        {
            if (ImGui.MenuItem("Window Toggle"))
            {
                //demoWindow.Toggle();
            }
            ImGui.EndMenu();
        }
        ImGuiC.AlignMenuToRight("RightMenu", () => Console.WriteLine("RightMenu pressed!"));
    }
}