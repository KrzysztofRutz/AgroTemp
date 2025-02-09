using AgroTemp.Mobile.ViewModels;

namespace AgroTemp.Mobile.Views.Pages;

public partial class AlarmPage : ContentPage
{
	public AlarmPage(AlarmViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await (BindingContext as AlarmViewModel).InitializeAlarmsActiveListAsync();
    }
}