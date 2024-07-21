using $safeprojectname$.Helpers;

namespace $safeprojectname$;

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