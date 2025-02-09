using AgroTemp.Mobile.ViewModels;

namespace AgroTemp.Mobile.Views.Pages;

public partial class MoreInfoPage : ContentPage
{
	public MoreInfoPage(MoreInfoViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}