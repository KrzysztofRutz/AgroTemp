namespace AgroTemp.Domain.Entities;

public class ExtremeValues : Entity
{
    public int? MaxTemperature { get; set; }
    public int? MinTemperature { get; set; }
    public int? MaxDeltaTemperature { get; set; }
    public int SiloId { get; set; }
    public Silo Silo { get; set; }
}
