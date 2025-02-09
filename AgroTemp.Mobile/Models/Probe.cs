namespace AgroTemp.Mobile.Models;

public class Probe : BaseModel
{
    public string Name { get; set; }
    public int SensorsCount { get; set; }
    public int NrFirstSensor { get; set; }
    public int SiloId { get; set; }
}
