using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Settings.UpdateHourOfReading;

public class UpdateHourOfReadingCommand : ICommand
{
    public int HourOfReading { get; set; }
}
