using AgroTemp.Mobile.ViewModels;
using Syncfusion.Maui.Charts;

namespace AgroTemp.Mobile.Views.Pages;

public partial class ChartOfTemperaturePage : ContentPage
{
    public ChartOfTemperaturePage(ChartOfTemperatureViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await (BindingContext as ChartOfTemperatureViewModel).InitializeDataSeriesAsync();    
    }

    private void DateTimeAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
    {
        DateTime date = DateTime.Parse(e.Label);

        e.Label = date.ToString("dd.MM.yyyy HH:mm");
    }
}