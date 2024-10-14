using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.Application.Dtos;

public class SettingsDto
{
    public int Id { get; set; }
    public string Language { get; set; }
    public int HourOfReading { get; set; }
    public FrequencyOfReading FrequencyOfReading { get; set; }
    public bool EnableSMSNotificationMode { get; set; }
    public bool EnableEmailNotificationMode { get; set; }
}
