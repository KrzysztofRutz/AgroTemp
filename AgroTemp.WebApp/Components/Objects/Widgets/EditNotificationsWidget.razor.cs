using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WebApp.Components.Objects.Widgets;

public partial class EditNotificationsWidget
{
    [Parameter]
    public bool IsSMSEnabled { get; set; }
    [Parameter]
    public bool IsEmailEnabled { get; set; }

    [Inject]
    public ISettingsService SettingsService { get; set; } 

    public NotificationsViewModel Model { get; set; } = new();
    private bool _isNotificationsEdited = false;

    protected override void OnParametersSet()
    {
        Model.IsSMSEnabled = IsSMSEnabled;
        Model.IsEmailEnabled = IsEmailEnabled;
    }

    private async Task EditNotificationsAsync(EditContext args)
    {
        await SettingsService.UpdateNotificationsAsync(Model.IsSMSEnabled, Model.IsEmailEnabled);
        _isNotificationsEdited = false;
    }

    private void OpenEditNotifications(MouseEventArgs args)
        => _isNotificationsEdited = true;

    private void CloseEditNotifications(MouseEventArgs args)
    {
        Model.IsSMSEnabled = IsSMSEnabled;
        Model.IsEmailEnabled = IsEmailEnabled;
        _isNotificationsEdited = false;
    }
}
