using AgroTemp.Domain.Enums.Silo;

namespace AgroTemp.Domain.Entities;

public class Silo : Entity
{
    public string Name { get; set; }
    public int Size { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public OrderSensors OrderSensors {  get; set; }
    public ExtremeValues ExtremeValues { get; set; }
    public ICollection<Probe> Probes { get; set; }
}
