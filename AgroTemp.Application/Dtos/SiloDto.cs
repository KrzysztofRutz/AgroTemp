namespace AgroTemp.Application.Dtos;

public class SiloDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string OrderSensors { get; set; }
}
