using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AgroTemp.WebApp.Components.Pages.Alarms
{
    public partial class ActiveAlarms
    {
        [Inject]
        public IAlarmService AlarmService { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }

        private IEnumerable<Alarm> _alarms = new List<Alarm>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {   
            if (firstRender)
            {
                _alarms = await AlarmService.GetActiveAlarmsAsync();

                StateHasChanged();
                await JS.InvokeVoidAsync("ApplyActiveAlarmsDatatable");
            }
            base.OnAfterRender(firstRender);
        }
    }
}
