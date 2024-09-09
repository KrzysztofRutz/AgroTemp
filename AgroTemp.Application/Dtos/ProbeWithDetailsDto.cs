namespace AgroTemp.Application.Dtos;

public class ProbeWithDetailsDto : ProbeDto
{
    public SiloDto Silo { get; set; }
    public ReadingModuleDto ReadingModule { get; set; }
}
