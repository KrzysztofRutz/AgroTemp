using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using System.Windows.Input;

namespace AgroTemp.Mobile.ViewModels;

[QueryProperty(nameof(User), "user")]
public class EditActualUserViewModel : BaseViewModel
{
    private bool isBusy;
    public bool IsBusy
    {
        get { return isBusy; }
        set { SetValue(ref isBusy, value); }
    }

    private User user;
    public User User
    {
        get { return user; }
        set { SetValue(ref user, value); }
    }

    public ICommand EditUserCommand { get; set; }

    private readonly IUserService _userService;

    public EditActualUserViewModel(IUserService userService)
    {
        _userService = userService;

        EditUserCommand = new Command(async () => await EditUserAsync());
    }

    private async Task EditUserAsync()
    {
        try
        {
            IsBusy = true;

            await Task.Delay(2000);

            await _userService.UpdateAsync(User);

            await Shell.Current.DisplayAlert("Powodzenie", "Pomyślnie edytowano użytkownika.", "Ok");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Błąd", ex.Message, "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
