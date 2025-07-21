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

    public async Task ShowInfoAsync() => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "info");
    public async Task ShowSuccessAsync() => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "success");
    public async Task ShowWarningAsync() => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "warning");
    public async Task ShowErrorAsync() => await _js.InvokeVoidAsync("notifyInterop.notifySimple", "danger");
}
