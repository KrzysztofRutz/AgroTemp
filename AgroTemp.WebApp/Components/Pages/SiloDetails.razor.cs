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

    private Silo _silo = new();
    private IEnumerable<Silo> _silos = new List<Silo>();
    private ExtremeValues _extremeValues = new();
    private IEnumerable<ProbeWithDetails> _probesWithDetails = new List<ProbeWithDetails>();
    private int _maxSensorCount = default;

    protected override async Task OnInitializedAsync()
    {
        _silos = await SiloService.GetAllAsync();
        _silo = await SiloService.GetByIdAsync(SiloId);
        _extremeValues = await ExtremeValuesService.GetBySiloIdAsync(SiloId);
        _probesWithDetails = await ProbeService.GetWithDeltailsBySiloIdAsync(SiloId);

        if (_probesWithDetails.Count() == 0)
        {
            return;
        }

        _maxSensorCount = _probesWithDetails.Max(x => x.SensorsCount);
    }

    private void NavigateToAnotherSilo_Click(int siloId)
        => Navigation.NavigateTo($"/Silo/{siloId}", forceLoad: true);
}
