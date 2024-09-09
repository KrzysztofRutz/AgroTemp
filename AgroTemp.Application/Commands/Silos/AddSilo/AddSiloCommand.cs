using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Commands.Silos.AddSilo;

public class AddSiloCommand : ICommand<SiloDto>
{
    public string Name { get; set; }
    public int Size { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string OrderSensors { get; set; }
}
