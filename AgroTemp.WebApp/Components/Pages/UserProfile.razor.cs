using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

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

    protected override async Task OnInitializedAsync()
    {       
        await InitializeUserProfileAsync();
    }

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

    private async Task InitializeUserProfileAsync()
    {
        var user = await UserService.GetByIdAsync(UserId);

        UserViewModel = new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            TypeOfUser = user.TypeOfUser,
            Email = user.Email
        };

        LogViewModel = new()
        {
            Login = user.Login,
            Password = user.Password,
        };
    }
}
