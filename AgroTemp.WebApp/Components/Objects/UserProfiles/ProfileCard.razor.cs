using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WebApp.Components.Objects.UserProfiles;

public partial class ProfileCard
{
    [Parameter] 
    public int UserId { get; set; }
    [Parameter]
    public UserViewModel UserViewModel { get; set; }
    [Parameter]
    public EventCallback<User> OnUserProfileUpdated { get; set; }

    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public INotificationService NotificationService { get; set; }

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

        await OnUserProfileUpdated.InvokeAsync(user);
    }

    private async Task ResetUserProfileAsync(MouseEventArgs args)
    {
        var user = await UserService.GetByIdAsync(UserId);
        UserViewModel = new UserViewModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            TypeOfUser = user.TypeOfUser
        };
    }
}
