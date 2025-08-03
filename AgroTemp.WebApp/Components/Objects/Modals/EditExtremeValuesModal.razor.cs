using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AgroTemp.WebApp.Components.Objects.Modals;

public partial class EditExtremeValuesModal
{
    [Parameter]
    public SiloWithDetails SiloWithDetails { get; set; }
    [Parameter]
    public string ModalId { get; set; }
    [Parameter] 
    public EventCallback OnUpdatedCallback { get; set; }

    [Inject]
    public IExtremeValuesService ExtremeValuesService { get; set; }
    [Inject]
    public INotificationService NotificationService { get; set; }

    [SupplyParameterFromForm]
    public ExtremeValuesViewModel Model { get; set; }

    protected override void OnInitialized()
        => Model ??= new() 
        { 
            MaxTemperature = SiloWithDetails.ExtremeValues?.MaxTemperature ?? 0,
            MinTemperature = SiloWithDetails.ExtremeValues?.MinTemperature ?? 0,
            MaxDeltaTemperature = SiloWithDetails.ExtremeValues?.MaxDeltaTemperature ?? 0,
        };

    private async Task EditExtremeValuesAsync(EditContext args)
    {
        var extremeValues = new ExtremeValues
        {
            SiloId = SiloWithDetails.Id,
            MinTemperature = Model.MinTemperature,
            MaxTemperature = Model.MaxTemperature,
            MaxDeltaTemperature = Model.MaxDeltaTemperature,
        };

        await ExtremeValuesService.UpdateAsync(extremeValues);

        await OnUpdatedCallback.InvokeAsync();
    }
}
