using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.ReadingModules.RemoveReadingModule;

public record RemoveReadingModuleCommand(int Id) : ICommand
{
}
