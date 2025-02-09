namespace AgroTemp.Mobile.Models;

public class Settings : BaseModel
{
    public string Language { get; set; }
    public int HourOfReading { get; set; }
    public int FrequencyOfReading { get; set; }
    public bool EnableSMSNotificationMode { get; set; }
    public bool EnableEmailNotificationMode { get; set; }
}
