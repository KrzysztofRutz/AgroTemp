using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Enums.Probe;

namespace AgroTemp.Application.Commands.Probes.AddProbe;

public class AddProbeCommand : ICommand<ProbeDto>
{
    public string Name { get; set; }
    public int SensorsCount { get; set; }
    public int NrFirstSensor { get; set; }
    public NrCircle NrOfCircle { get; set; }
    public int SiloId { get; set; }
    public int ReadingModuleId { get; set; }
}
