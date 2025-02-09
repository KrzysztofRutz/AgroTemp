using AgroTemp.Mobile.Views.Pages;

namespace AgroTemp.Mobile;

public partial class App : Application
{
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY5MTM4MkAzMjM4MmUzMDJlMzBCM2xLdUU1NHlvblpvaElTVDEzb1BYTGVacEEwSDRGRU4zekxoSVk1aHBVPQ==");    // Register license key to Syncfusion Controls here

        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override async void OnStart()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));

        base.OnStart();
    }
}
