namespace AgroTemp.WebApp.Services.Abstractions;

public interface INotificationService
{
    Task ShowInfoAsync();
    Task ShowSuccessAsync();
    Task ShowWarningAsync();
    Task ShowErrorAsync();
}
