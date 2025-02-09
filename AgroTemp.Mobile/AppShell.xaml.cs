using AgroTemp.Mobile.Views.Pages;

namespace AgroTemp.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(ProbesWithDetailsPage), typeof(ProbesWithDetailsPage));
        Routing.RegisterRoute(nameof(ChartOfTemperaturePage), typeof(ChartOfTemperaturePage));
        Routing.RegisterRoute(nameof(ChartOfDeltaPage), typeof(ChartOfDeltaPage));
    }
}
