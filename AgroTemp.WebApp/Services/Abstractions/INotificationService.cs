namespace AgroTemp.WebApp.Services.Abstractions;

public interface INotificationService
{
    Task ShowInfoAsync(string message);
    Task ShowSuccessAsync(string message);
    Task ShowWarningAsync(string message);
    Task ShowErrorAsync(string message);
}
