using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.JSInterop;

namespace AgroTemp.WebApp.Services;

public class NotificationService : INotificationService
{
    private readonly IJSRuntime _js;

    public NotificationService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task ShowInfoAsync(string message) => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "info", message);
    public async Task ShowSuccessAsync(string message) => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "success", message);
    public async Task ShowWarningAsync(string message) => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "warning", message);
    public async Task ShowErrorAsync(string message) => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "danger", message);
}
