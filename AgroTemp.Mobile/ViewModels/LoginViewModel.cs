using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using System.Windows.Input;
using UraniumUI.Dialogs;

namespace AgroTemp.Mobile.ViewModels;

public class LoginViewModel : BaseViewModel
{
    public User User { get; set; } = new User();

    private bool isVisibleFailOfLoginMessage;
    public bool IsVisibleFailOfLoginMessage 
    { 
        get { return isVisibleFailOfLoginMessage; }
        set { SetValue(ref isVisibleFailOfLoginMessage, value); }        
    }

    public ICommand LoginCommand { get; private set; }

    private readonly IUserService _userService;
    private readonly IDialogService _dialogService;

    public LoginViewModel(IUserService userService, IDialogService dialogService)
    {
        _userService = userService;
        _dialogService = dialogService;

        LoginCommand = new Command(async() => await LoginAndNavigateToAppShellAsync(User));
    }

    private async Task LoginAndNavigateToAppShellAsync(User user)
    {
        IsVisibleFailOfLoginMessage = false;

        using var progress = await _dialogService.DisplayProgressAsync("Ładowanie", "Ładowanie danych, proszę czekać.");
        
        if (string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
        {
            IsVisibleFailOfLoginMessage = true;

            return;
        }

        var result = await _userService.GetByLoginAndPasswordAsync(user.Login , user.Password);

        if (result == null)
        {
            IsVisibleFailOfLoginMessage = true;
            
            return;
        }

        await Shell.Current.GoToAsync("//object", true, new Dictionary<string, object>
        {
            {"user", result }
        });
    }
}
