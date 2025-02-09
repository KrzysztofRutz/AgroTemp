using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.ViewModels;

namespace AgroTemp.Mobile.Views.Pages;

public partial class ProbesWithDetailsPage : ContentPage
{
    public ProbesWithDetailsPage(ProbesWithDetailsViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;    
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await (BindingContext as ProbesWithDetailsViewModel).InitializeProbesWithDetailsListAsync();
    }

    private async void GoToChartOfTemperatureButton_Clicked(object sender, EventArgs e)
    {
        var probe = ((VisualElement)sender).BindingContext as ProbeWithDetails;
        var settings = (BindingContext as ProbesWithDetailsViewModel).Settings;

        await Shell.Current.GoToAsync(nameof(ChartOfTemperaturePage), true, new Dictionary<string, object>
        {
            { "probe", probe },
            { "settings", settings }
        });
    }   
    
    private async void GoToChartOfDeltaButton_Clicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ChartOfDeltaPage));
}