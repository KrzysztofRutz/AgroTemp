using AgroTemp.Mobile.ViewModels;
using Syncfusion.Maui.Charts;
using UraniumUI.Dialogs;

namespace AgroTemp.Mobile.Views.Pages;

public partial class ChartOfTemperaturePage : ContentPage
{
    private readonly IDialogService _dialogService;

    public ChartOfTemperaturePage(ChartOfTemperatureViewModel viewModel, IDialogService dialogService)
	{
		InitializeComponent();

		BindingContext = viewModel;
        _dialogService = dialogService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await (BindingContext as ChartOfTemperatureViewModel).InitializeDataSeriesAsync();    
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();

        using var progress = await _dialogService.DisplayProgressAsync("£adowanie", "£adowanie danych, proszê czekaæ.");
    }

    private void DateTimeAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
    {
        DateTime date = DateTime.Parse(e.Label);

        e.Label = date.ToString("dd.MM.yyyy HH:mm");
    }
}