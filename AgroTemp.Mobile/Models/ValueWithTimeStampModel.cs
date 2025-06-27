namespace AgroTemp.Mobile.Models;

public class ValueWithTimeStampModel : BaseModel
{
    public DateTime DateTimeStamp { get; set; }
    public List<double?> ListOfValues { get; set; }
}
