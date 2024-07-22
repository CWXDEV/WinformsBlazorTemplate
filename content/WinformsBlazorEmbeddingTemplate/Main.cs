using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace WinformsBlazorEmbeddingTemplate;

public partial class Main : Form
{
    // C:\\Users\\[UserName]\\AppData\\Roaming\\WinformsBlazorTemplate\\Resources
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

        // HostPage will be the location of your "wwwroot" folder,
        // this would contain your index.html, css, js, anything you want to refrence in your Razor pages
        var blazorWebView = new BlazorWebView()
        {
            Dock = DockStyle.Fill,
            HostPage = Path.Combine(AppPath, "index.html"),
            Services = services.BuildServiceProvider()
        };
        blazorWebView.RootComponents.Add<BlazorApp>("#app");
        Controls.Add(blazorWebView);
    }
}