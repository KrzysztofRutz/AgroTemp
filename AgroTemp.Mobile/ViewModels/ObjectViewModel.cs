using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using AgroTemp.Mobile.Views.Pages;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AgroTemp.Mobile.ViewModels;

[QueryProperty(nameof(User), "user")]
public class ObjectViewModel : BaseViewModel
{
    private User user;
    public User User
    {
        get { return user; }
        set { SetValue(ref user, value); }
    }

    private ObservableCollection<Silo> _silosList;
    public ObservableCollection<Silo> SilosList
    {
        get { return _silosList; }
        set { SetValue(ref _silosList, value); }
    }

    public ICommand LogoutCommand { get; set; }
    public ICommand GoToEditActualUserCommand { get; set; }

    private readonly ISiloService _siloService;
    private readonly IPopupService _popupService;

    public ObjectViewModel(ISiloService siloService, IPopupService popupService)
    {
        _siloService = siloService;
        _popupService = popupService;

        LogoutCommand = new Command(async() => await NavigateToLoginPageAsync());
        GoToEditActualUserCommand = new Command(async () => await NavigateToEditActualUserPopupAsync());
    }

    public async Task InitializeSilosListAsync()
    {
        var result = await _siloService.GetAllAsync();

        SilosList = new ObservableCollection<Silo>(result);
    }

    private async Task NavigateToLoginPageAsync()
    {
        var result = await Shell.Current.DisplayAlert("Próba wylogowania", "Czy napewno chcesz wylogować się z aplikacji?", "Tak", "Nie");

        if (result)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage), true);
        }
    }

    private async Task NavigateToEditActualUserPopupAsync()
        => await _popupService.ShowPopupAsync<EditActualUserViewModel>(onPresenting: viewmodel => viewmodel.User = User);
}
