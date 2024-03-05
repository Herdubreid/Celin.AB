using System.Diagnostics;

namespace Celin.AB.Views;

public partial class AboutPage : UraniumUI.Pages.UraniumContentPage
{
    public AboutPage(Host host)
    {
        InitializeComponent();
        BindingContext = host;
    }
}
