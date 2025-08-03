using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WebApp.Components.Objects.UserProfiles;

public partial class LoginDataCard
{
    [Parameter]
    public int UserId { get; set; }

    public LogViewModel LogViewModel { get; set; } = new();

    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public INotificationService NotificationService { get; set; }

    protected override async Task OnInitializedAsync()
        => await InitializeLoginDataAsync();

    private async Task SaveChangesAsync(EditContext args)
    {
        await UserService.UpdateLoginAsync(UserId, LogViewModel.Login);

        if (!string.IsNullOrWhiteSpace(LogViewModel.Password))
        {
            await UserService.UpdatePasswordAsync(UserId, LogViewModel.Password);
        }

        await NotificationService.ShowSuccessAsync("Pomyślnie zaktualizowano dane logowania.");
    }

    private async Task ResetLoginDataAsync(MouseEventArgs args)
        => await InitializeLoginDataAsync();

    private async Task InitializeLoginDataAsync()
    {
        var user = await UserService.GetByIdAsync(UserId);
        if (user == null)
        {
            await NotificationService.ShowErrorAsync("Wystąpił błąd podczas aktualizacji danych logowania.");
            return;
        }
        LogViewModel = new LogViewModel
        {
            Login = user.Login,
            Password = string.Empty // Password should not be displayed for security reasons
        };
    }
}
