using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.ViewModels;
using UraniumUI.Dialogs;

namespace AgroTemp.Mobile.Views.Pages;

public partial class ProbesWithDetailsPage : ContentPage
{
    private readonly IDialogService _dialogService;

    public ProbesWithDetailsPage(ProbesWithDetailsViewModel viewModel, IDialogService dialogService)
	{
        InitializeComponent();

        BindingContext = viewModel;
        _dialogService = dialogService;
    }

    protected async override void OnAppearing()
    {      
        base.OnAppearing();

        using var progress = await _dialogService.DisplayProgressAsync("£adowanie", "£adowanie danych, proszê czekaæ.");

        await (BindingContext as ProbesWithDetailsViewModel).InitializeProbesWithDetailsListAsync();   
    }

    private async void GoToChartOfTemperatureButton_Clicked(object sender, EventArgs e)
    {
        var probe = ((VisualElement)sender).BindingContext as ProbeWithDetails;
        var settings = (BindingContext as ProbesWithDetailsViewModel).Settings;
        var extremeValues = (BindingContext as ProbesWithDetailsViewModel).ExtremeValues;

        await Shell.Current.GoToAsync(nameof(ChartOfTemperaturePage), true, new Dictionary<string, object>
        {
            { "probe", probe },
            { "settings", settings },
            { "extremeValues", extremeValues }
        });
    }   
    
    private async void GoToChartOfDeltaButton_Clicked(object sender, EventArgs e)
    {
        var probe = ((VisualElement)sender).BindingContext as ProbeWithDetails;
        var settings = (BindingContext as ProbesWithDetailsViewModel).Settings;
        var extremeValues = (BindingContext as ProbesWithDetailsViewModel).ExtremeValues;

        await Shell.Current.GoToAsync(nameof(ChartOfDeltaPage), true, new Dictionary<string, object>
        {
            { "probe", probe },
            { "settings", settings },
            { "extremeValues", extremeValues }
        });
    }
}