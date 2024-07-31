using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace WinformsBlazorEmbeddingTemplate;

public partial class Main : Form
{
    // C:\\Users\\[UserName]\\AppData\\Roaming\\WinformsBlazorTemplate\\Resources
    // I have left this in, just incase some might want an easy place to store files outside of the assembly path.
    public static readonly string AppPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "WinformsBlazorEmbeddingTemplate\\Resources");

    public Main()
    {
        InitializeComponent();
        SetUpBlazorWebView();
    }

    private void SetUpBlazorWebView()
    {
        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.AddMudServices();

        // this uses the ManifestEmbeddedFileProvider, this is basically middleware and will allow use of embedded resources
        // without the need to extract them.
        var blazorWebView = new EmbeddedBlazorWebView()
        {
            UseEmbeddedResources = true,
            Dock = DockStyle.Fill,
            HostPage = "index.html", // this will be Resources/index.html
            Services = services.BuildServiceProvider()
        };
        
        blazorWebView.RootComponents.Add<BlazorApp>("#app");
        Controls.Add(blazorWebView);
    }
}