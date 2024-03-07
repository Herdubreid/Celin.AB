using Celin.AB.Views;
using System.ComponentModel;

namespace Celin.AB;

public partial class App : Application
{
    public App(Host host, AppShell shell, AboutPage about)
    {
        InitializeComponent();

        MainPage = about;

        host.PropertyChanged += (object? _, PropertyChangedEventArgs e) =>
        {
            if (e.PropertyName == nameof(host.IsAuthenticated))
            {
                if (host.IsAuthenticated)
                {
                    MainPage = shell;
                    shell.GoToAsync("main");
                }
                else
                {
                    MainPage = about;
                }
            }
        };
    }
}
