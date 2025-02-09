namespace AgroTemp.Mobile.Models;

public class ProbeWithDetails : Probe
{
    public Silo Silo { get; set; }
    public List<double?> ActualTemperatures { get; set; }
    public List<double?> ActualDeltaTemperatures { get; set; }
}


