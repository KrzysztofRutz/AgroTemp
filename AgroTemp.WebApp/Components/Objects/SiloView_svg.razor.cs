using AgroTemp.WebApp.Models;
using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Objects;

public partial class SiloView_svg
{
    [Parameter]
    public Silo SiloObject { get; set; } = new();
    [Parameter]
    public IEnumerable<Probe> Probes { get; set; } = new List<Probe>();

    public int probePositionX = 150;
    public int probePositionY = 45;
}
