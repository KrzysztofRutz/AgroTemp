using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Pages.Alarms;

public partial class HistoryAlarms
{
    [Inject]
    public IAlarmService AlarmService { get; set; }
    public TimeRangeViewModel Model { get; set; } = new();
    private IEnumerable<Alarm> _alarms = new List<Alarm>();

    protected override async Task OnInitializedAsync()
        => _alarms = await AlarmService.GetAlarmsByTimeIntervalAsync(Model.StartAt, Model.EndAt);

    private async Task FilterAlarmsAsync()
        => _alarms = await AlarmService.GetAlarmsByTimeIntervalAsync(Model.StartAt, Model.EndAt);
}
