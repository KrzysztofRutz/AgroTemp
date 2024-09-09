using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Silos.UpdateSilo;

public class UpdateSiloCommand : ICommand
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public int Size { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string OrderSensors { get; set; }
}
