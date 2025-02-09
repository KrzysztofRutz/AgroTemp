using AgroTemp.Mobile.ViewModels;

namespace AgroTemp.Mobile.Views.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}