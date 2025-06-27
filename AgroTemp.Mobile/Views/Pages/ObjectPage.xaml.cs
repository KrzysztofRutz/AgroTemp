using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.ViewModels;
using UraniumUI.Dialogs;

namespace AgroTemp.Mobile.Views.Pages;

public partial class ObjectPage : ContentPage
{
    private readonly IDialogService _dialogService;

    public ObjectPage(ObjectViewModel viewModel, IDialogService dialogService)
	{       
        InitializeComponent();

        BindingContext = viewModel;
        _dialogService = dialogService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		await (BindingContext as ObjectViewModel).InitializeSilosListAsync();
    }

    private async void GoToProbesWithDetailsButton_Clicked(object sender, EventArgs e)
    {
        var silo = ((VisualElement)sender).BindingContext as Silo;

        //using var progress = await _dialogService.DisplayProgressAsync("£adowanie", "£adowanie danych, proszê czekaæ.");

        if (silo == null)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(ProbesWithDetailsPage), true, new Dictionary<string, object>
        {
            {"silo", silo }
        });
    }
}