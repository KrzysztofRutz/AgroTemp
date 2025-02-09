namespace AgroTemp.Domain.Enums.Alarm;

public enum Description : byte
{
    HighTemperature,
    LowTemperature,
    HighDeltaTemperature,
    NoConnectionWithModuleId,
}
