using AgroTemp.Domain.Enums.Probe;

namespace AgroTemp.Domain.Entities;

public class Probe : Entity
{
    public string Name { get; set; }
    public int SensorsCount { get; set; }
    public int NrFirstSensor {  get; set; }
    public NrCircle NrOfCircle { get; set; }
    public int SiloId { get; set; }
    public Silo Silo { get; set; } 
    public int ReadingModuleId { get; set; }
    public ReadingModule ReadingModule { get; set; }
}
