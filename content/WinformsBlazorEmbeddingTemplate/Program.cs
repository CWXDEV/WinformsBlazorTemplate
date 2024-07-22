using WinformsBlazorEmbeddingTemplate.Helpers;

namespace WinformsBlazorEmbeddingTemplate;

static class Program
{
    [STAThread]
    static void Main()
    {
        SetupHelper.Instance.SetupDirectories();
        SetupHelper.Instance.SetupResources();
        ApplicationConfiguration.Initialize();
        Application.Run(new Main());
    }
}