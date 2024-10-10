using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Commands.Temperatures.AddTemperature;

public class AddTemperatureCommand : ICommand<IEnumerable<TemperatureDto>>
{
}
