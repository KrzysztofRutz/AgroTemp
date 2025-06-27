using AgroTemp.WebApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AgroTemp.WebApp.Components.Objects;

public partial class SiloView
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    [Inject] 
    public IJSRuntime JS { get; set; }

    [Parameter]
    public Silo Silo { get; set; } = new();
    [Parameter] 
    public IEnumerable<ProbeWithDetails> Probes { get; set; } = new List<ProbeWithDetails>();
    [Parameter]
    public string CanvasId { get; set; } = $"siloCanvas-{Guid.NewGuid():N}";

    protected override async Task OnAfterRenderAsync(bool firstRender)
        => await JS.InvokeVoidAsync("drawSilo", CanvasId, Silo.Name, Probes);

    private void GoToPage()
        => Navigation.NavigateTo($"/Silo/{Silo.Id}");
}
