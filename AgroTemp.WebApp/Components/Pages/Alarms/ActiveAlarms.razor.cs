using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Pages.Alarms
{
    public partial class ActiveAlarms
    {
        [Inject]
        public IAlarmService AlarmService { get; set; } 
        private IEnumerable<Alarm> _alarms = new List<Alarm>();

        protected override async Task OnInitializedAsync()
            => _alarms = await AlarmService.GetActiveAlarmsAsync();
    }
}
