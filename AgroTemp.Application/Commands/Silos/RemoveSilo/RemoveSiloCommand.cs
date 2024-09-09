using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Silos.RemoveSilo;

public record RemoveSiloCommand(int Id) : ICommand
{
}
