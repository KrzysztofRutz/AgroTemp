using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AgroTemp.WebApp.Components.Pages;

public partial class Settings
{
    [Inject]
    public ISettingsService SettingsService { get; set; }
    [Inject]
    public ISiloService SiloService { get; set; }
    [Inject]
    public IJSRuntime JS { get; set; }

    private IEnumerable<SiloWithDetails> _silosWithDetailsList = new List<SiloWithDetails>();
    private Models.Settings _settings = new ();
    public bool _isCardExtremeValuesExplained = false;

    protected override async Task OnInitializedAsync()
    {
        _settings = await SettingsService.GetAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _settings = await SettingsService.GetAsync();
            _silosWithDetailsList = await SiloService.GetAllWithDeltailsAsync();      

            StateHasChanged();
            await JS.InvokeVoidAsync("ApplyExtremeValuesDatatable");
            
        }
        base.OnAfterRender(firstRender);
    }     

    private async Task OnUpdatedHandler()
        => _silosWithDetailsList = await SiloService.GetAllWithDeltailsAsync();

    private async Task ChangeExtremeValuesCardBodyStateAsync(bool isExplained)
    {
        _isCardExtremeValuesExplained = isExplained;

        StateHasChanged();
        await JS.InvokeVoidAsync("ApplyExtremeValuesDatatable");
    }
}
