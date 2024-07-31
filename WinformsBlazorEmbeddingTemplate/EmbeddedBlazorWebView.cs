using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.FileProviders;

namespace WinformsBlazorEmbeddingTemplate;

/// <summary>
/// To try explain what this extension basically does:
/// we override the CreateFileProvider method and allow the option to use
/// ManifestEmbeddedFileProvider, this means paths will be resolved to your embedded resources
/// for example, you have an index.html in Resources, when Webview requests that, it will be resolved to that embedded resource
/// another helpful tip if you have used BlazorWebView before is imagine the Resources folder just like your wwwroot folder.
/// </summary>
public class EmbeddedBlazorWebView : BlazorWebView
{
    public bool UseEmbeddedResources { get; init; }
    public IFileProvider EmbeddedFilesProvider { get; set; }

    public override IFileProvider CreateFileProvider(string contentRootDir)
    {
        if (!UseEmbeddedResources)
        {
            return base.CreateFileProvider(contentRootDir);
        }

        EmbeddedFilesProvider = new ManifestEmbeddedFileProvider(typeof(Program).Assembly, "Resources");
        return EmbeddedFilesProvider;
    }
}