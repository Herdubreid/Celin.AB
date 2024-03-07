using System.Diagnostics;
using UraniumUI.Pages;

namespace Celin.AB.Views;

public partial class MainPage : UraniumContentPage
{
    private void ABSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Debug.WriteLine(e);

        _shell.GoToView(e.SelectedItem as W01012B.Row);
    }
    readonly AppShell _shell;
    public MainPage(AppShell shell, SearchAndSelect searchAndSelect)
    {
        InitializeComponent();

        _shell = shell;
        BindingContext = searchAndSelect;
    }

}