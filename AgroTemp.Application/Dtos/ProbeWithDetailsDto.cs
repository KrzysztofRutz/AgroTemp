namespace AgroTemp.Application.Dtos;

public class ProbeWithDetailsDto : ProbeDto
{
    public SiloDto Silo { get; set; }
    public ReadingModuleDto ReadingModule { get; set; }
    public List<double?> ActualTemperatures { get; set; }
    public List<double?> ActualDeltaTemperatures { get; set; }
}
