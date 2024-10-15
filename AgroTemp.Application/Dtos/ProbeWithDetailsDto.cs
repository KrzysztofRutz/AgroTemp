namespace AgroTemp.Application.Dtos;

public class ProbeWithDetailsDto : ProbeDto
{
    public SiloDto Silo { get; set; }
    public ReadingModuleDto ReadingModule { get; set; }
    public List<ushort?> ActualTemperatures { get; set; }
    public List<ushort?> ActualDeltaTemperatures { get; set; }
}
