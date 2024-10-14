namespace AgroTemp.Application.Dtos;

public class ExtremeValuesDto
{
    public int? MaxTemperature { get; set; }
    public int? MinTemperature { get; set; }
    public int? MaxDeltaTemperature { get; set; }
    public int SiloId { get; set; }
}
