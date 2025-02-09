namespace AgroTemp.Mobile.Models;

public class Temperature : BaseModel
{
    public DateTime DateTimeStamp { get; set; }
    public List<double?> ListOfTemperatures { get; set; }
}
