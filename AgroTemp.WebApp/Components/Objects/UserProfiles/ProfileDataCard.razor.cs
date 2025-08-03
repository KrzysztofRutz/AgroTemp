using AgroTemp.WebApp.Authentication.StateContainers;
using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WebApp.Components.Objects.UserProfiles;

public partial class ProfileDataCard
{
    [Parameter] 
    public int UserId { get; set; }

    public UserViewModel UserViewModel { get; set; } = new();
    [Parameter]
    public EventCallback<User> OnUserProfileUpdated { get; set; }

    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public INotificationService NotificationService { get; set; }
    [Inject]
    public UserState UserState { get; set; }

    protected override async Task OnInitializedAsync()
        => await InitializeUserProfileDataAsync();

    private async Task SaveChangesAsync(EditContext args)
    {
        var user = new User()
        {
            Id = UserId,
            FirstName = UserViewModel.FirstName,
            LastName = UserViewModel.LastName,
            Email = UserViewModel.Email,
            TypeOfUser = UserViewModel.TypeOfUser,
        };

        await UserService.UpdateUserParametersAsync(user);
        await NotificationService.ShowSuccessAsync("Pomyślnie zaktualizowano dane użytkownika.");

        await OnUserProfileUpdated.InvokeAsync(user);
        UserState.SetUser(user);
    }

    private async Task ResetUserProfileAsync(MouseEventArgs args)
        => await InitializeUserProfileDataAsync();

    private async Task InitializeUserProfileDataAsync()
    {
        var user = await UserService.GetByIdAsync(UserId);

        if (user == null)
        {
            await NotificationService.ShowErrorAsync("Wystąpił błąd podczas aktualizacji danych użytkownika.");
            return;
        }

        UserViewModel = new UserViewModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            TypeOfUser = user.TypeOfUser
        };
    }
}
