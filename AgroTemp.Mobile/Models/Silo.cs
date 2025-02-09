namespace AgroTemp.Mobile.Models;

public class Silo : BaseModel
{
    public string Name { get; set; }
    public int Size { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string OrderSensors { get; set; }
}
