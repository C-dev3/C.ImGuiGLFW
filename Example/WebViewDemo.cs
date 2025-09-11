using C.ImGuiGLFW.Common;
using C.ImGuiGLFW.ImGuiMethods.Web;
using Hexa.NET.ImGui;

namespace Example;

internal class WebViewDemo : Window
{
    private WebView view = null!;

    public override void OnLoad()
    {
        view = new("https://google.com")
        {
            AutoResizeToContentRegion = true
        };
    }

    public override void PreDraw()
    {
        var mainViewport = ImGui.GetMainViewport();
        WindowSize = mainViewport.WorkSize;
        Position = mainViewport.WorkPos;
    }

    public override void OnDispose() => view.Dispose();

    protected override void Draw() => view.Draw("WebBrowser", true);
}
