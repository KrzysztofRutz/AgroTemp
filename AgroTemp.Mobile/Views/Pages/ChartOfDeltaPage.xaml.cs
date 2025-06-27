using AgroTemp.Mobile.ViewModels;

namespace AgroTemp.Mobile.Views.Pages;

public partial class ChartOfDeltaPage : ContentPage
{
	public ChartOfDeltaPage(ChartOfDeltaViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await (BindingContext as ChartOfDeltaViewModel).InitializeDataSeriesAsync();
    }

    private void DateTimeAxis_LabelCreated(object sender, Syncfusion.Maui.Charts.ChartAxisLabelEventArgs e)
    {
        DateTime date = DateTime.Parse(e.Label);

        e.Label = date.ToString("dd.MM.yyyy HH:mm");
    }
}