using AgroTemp.WebApp.Enums;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;

namespace AgroTemp.WebApp.Components.Objects.Widgets;

public partial class EditFrequencyOfReadingWidget
{
    [Parameter]
    public int FrequencyOfReading { get; set; }

    [Inject]
    public ISettingsService SettingsService { get; set; }
    [Inject]
    public IJSRuntime JS { get; set; }

    public FrequencyOfReadingViewModel Model { get; set; } = new();

    private bool _isFrequencyOfReadingEdited = false;

    protected override void OnParametersSet()
    {
        Enum.TryParse<FrequencyOfReading>(FrequencyOfReading.ToString(), out var frequencyOfReading);
        Model.Value = frequencyOfReading;
    }

    private void OpenEditFrequencyOfReading(MouseEventArgs args)
        => _isFrequencyOfReadingEdited = true;

    private void CloseEditFrequencyOfReading(MouseEventArgs args)
    {
        Enum.TryParse<FrequencyOfReading>(FrequencyOfReading.ToString(), out var frequencyOfReading);
        Model.Value = frequencyOfReading;
        _isFrequencyOfReadingEdited = false;
    }

    private async Task EditFrequencyOfReadingAsync(EditContext args)
    {
        await SettingsService.UpdateFrequencyOfReadingAsync((int)Model.Value);

        _isFrequencyOfReadingEdited = false;
    }
}
