using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AgroTemp.WebApp.Components.Pages.Alarms;

public partial class HistoryAlarms
{
    [Inject]
    public IAlarmService AlarmService { get; set; }
    [Inject]
    public IJSRuntime JS { get; set; }

    public TimeRangeViewModel Model { get; set; } = new();
    private IEnumerable<Alarm> _alarms = new List<Alarm>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _alarms = await AlarmService.GetAlarmsByTimeIntervalAsync(Model.StartAt, Model.EndAt);

            StateHasChanged();
            await JS.InvokeVoidAsync("ApplyHistoryAlarmsDatatable");
        }
        base.OnAfterRender(firstRender);
    }

    private async Task FilterAlarmsAsync()
    {
        _alarms = await AlarmService.GetAlarmsByTimeIntervalAsync(Model.StartAt, Model.EndAt);

        StateHasChanged();
        await JS.InvokeVoidAsync("ApplyHistoryAlarmsDatatable");
    }
}
