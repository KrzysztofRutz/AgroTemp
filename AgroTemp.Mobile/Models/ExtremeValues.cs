namespace AgroTemp.Mobile.Models;

public class ExtremeValues : BaseModel
{
    public int? MaxTemperature { get; set; }
    public int? MinTemperature { get; set; }
    public int? MaxDeltaTemperature { get; set; }
    public int SiloId { get; set; }
}
