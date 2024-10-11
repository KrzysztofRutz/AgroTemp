using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.Domain.Entities;

public class Settings : Entity
{
    public Language Language { get; set; }
    public int HourOfReading { get; set; }
    public FrequencyOfReading FrequencyOfReading { get; set; }
    public bool EnableSMSNotificationMode { get; set; }
    public bool EnableEmailNotificationMode { get; set; }  
}
