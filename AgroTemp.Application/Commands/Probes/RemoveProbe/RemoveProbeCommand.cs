using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Probes.RemoveProbe;

public record RemoveProbeCommand(int Id) : ICommand
{   
}
