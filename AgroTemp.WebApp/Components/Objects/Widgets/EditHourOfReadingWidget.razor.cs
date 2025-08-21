using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;

namespace AgroTemp.WebApp.Components.Objects.Widgets;

public partial class EditHourOfReadingWidget
{
    [Parameter]
    public int? HourOfReading { get; set; }

    [Inject]
    public IJSRuntime JS { get; set; }
    [Inject]
    public ISettingsService SettingsService { get; set; }

    public HourOfReadingViewModel Model { get; set; } = new();

    private bool _isHourOfReadingEdited = false;

    protected override void OnParametersSet()
    {
        Model.Value = $"{HourOfReading}:00";
    }

    private async Task EditHourOfReadingAsync(EditContext args)
    {
        Model.Value = await JS.InvokeAsync<string?>("GetTimeValue");

        var hourOfReadingSplit = Model.Value.Split(":");

        await SettingsService.UpdateHourOfReadingAsync(int.Parse(hourOfReadingSplit[0]));

        _isHourOfReadingEdited = false;
    }

    private async Task OpenEditHourOfReadingAsync(MouseEventArgs args)
    {
        _isHourOfReadingEdited = true;

        await Task.Delay(1);
        await JS.InvokeVoidAsync("InitTimePicker");
    }

    private void CloseEditHourOfReadingAsync(MouseEventArgs args)
    {
        Model.Value = $"{HourOfReading}:00";
        _isHourOfReadingEdited = false;
    }
}
