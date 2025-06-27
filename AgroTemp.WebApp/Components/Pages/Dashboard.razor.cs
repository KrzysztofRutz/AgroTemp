using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Pages;

public partial class Dashboard
{
    [Inject]
    public ISiloService SiloService { get; set; }
    [Inject]
    public IProbeService ProbeService { get; set; }
    private IEnumerable<Silo> Silos { get; set; }
    private IOrderedEnumerable<IGrouping<int, Silo>> SiloGroupByPositionY { get; set; }
    private Dictionary<int, IEnumerable<ProbeWithDetails>> probesBySiloId = new();

    protected override async Task OnInitializedAsync()
    {
        Silos = await SiloService.GetAllAsync();

        if (Silos == null)
        {
            return;
        }

        SiloGroupByPositionY = Silos.GroupBy(silo => silo.PositionY).OrderBy(group => group.Key);

        foreach (var silo in Silos)
        {
            var probes = await ProbeService.GetWithDeltailsBySiloIdAsync(silo.Id);

            probesBySiloId[silo.Id] = probes;
        }
    }
}
