using AgroTemp.Mobile.ViewModels;
using CommunityToolkit.Maui.Views;

namespace AgroTemp.Mobile.Views.Popups;

public partial class EditActualUserPopup : Popup
{
	public EditActualUserPopup(EditActualUserViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}