using AgroTemp.WebApp.Enums;
using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Pages;

public partial class UserProfile
{
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public INotificationService NotificationService { get; set; }

    [Parameter]
    public int UserId { get; set; }
    private UserViewModel UserViewModel { get; set; } = new();
    private LogViewModel LogViewModel { get; set; } = new();
    private UserProfileCards ProfileCard { get; set; } = UserProfileCards.UserProfile;
    private User _user = new();
    protected override async Task OnInitializedAsync()
    {       
        await InitializeUserProfileAsync();
    }

    /*
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

        await NotificationService.ShowSuccessAsync();
    }

    private async Task ResetUserProfileAsync(MouseEventArgs args)
        => await InitializeUserProfileAsync();
    */

    private async Task InitializeUserProfileAsync()
    {
        _user = await UserService.GetByIdAsync(UserId);

        UserViewModel = new()
        {
            FirstName = _user.FirstName,
            LastName = _user.LastName,
            TypeOfUser = _user.TypeOfUser,
            Email = _user.Email
        };

        LogViewModel = new()
        {
            Login = _user.Login,
            Password = string.Empty // Password should not be displayed for security reasons
        };
    }

    private void UpdateUserProfile(User user)
        => _user = user;

    private void SelectProfileCard()
        => ProfileCard = UserProfileCards.UserProfile;

    private void SelectLoginDataCard()
        => ProfileCard = UserProfileCards.LoginData;
}
