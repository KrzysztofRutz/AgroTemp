using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Pages;

public partial class SiloDetails
{
    [Parameter]
    public int SiloId { get; set; }
    [Inject]
    public NavigationManager Navigation { get; set; }
    [Inject]
    public ISiloService SiloService { get; set; }
    [Inject]
    public IProbeService ProbeService { get; set; }
    [Inject]
    public IExtremeValuesService ExtremeValuesService { get; set; }
    private Silo silo = new();
    private IEnumerable<Silo> silos = new List<Silo>();
    private ExtremeValues extremeValues = new();
    private IEnumerable<ProbeWithDetails> probesWithDetails = new List<ProbeWithDetails>();
    private int maxSensorCount = default;

    protected override async Task OnInitializedAsync()
    {
        silos = await SiloService.GetAllAsync();
        silo = await SiloService.GetByIdAsync(SiloId);
        probesWithDetails = await ProbeService.GetWithDeltailsBySiloIdAsync(SiloId);

        if (probesWithDetails.Count() == 0)
        {
            return;
        }

        extremeValues = await ExtremeValuesService.GetBySiloIdAsync(SiloId);

        maxSensorCount = probesWithDetails.Max(x => x.SensorsCount);
    }

    private void NavigateToAnotherSilo_Click(int siloId)
        => Navigation.NavigateTo($"/Silo/{siloId}", forceLoad: true);
}
