using AgroTemp.WebApp.Enums;
using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
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

    private UserProfileCards ProfileCard { get; set; } = UserProfileCards.UserProfile;
    private User _user = new();

    protected override async Task OnInitializedAsync()
    {
        var user = await UserService.GetByIdAsync(UserId);

        if (user == null)
        {
            await NotificationService.ShowErrorAsync($"Brak użytkownika w bazie o Id {UserId}");
            return;
        }

        _user = user;
    }

    private void UpdateUserProfile(User user)
        => _user = user;

    private void SelectProfileCard()
        => ProfileCard = UserProfileCards.UserProfile;

    private void SelectLoginDataCard()
        => ProfileCard = UserProfileCards.LoginData;
}
