using AgroTemp.Mobile.ViewModels;

namespace AgroTemp.Mobile.Views.Pages;

public partial class ChartOfDeltaPage : ContentPage
{
	public ChartOfDeltaPage(ChartOfDeltaViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}