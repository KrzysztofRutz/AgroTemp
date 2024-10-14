using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.Application.Commands.Settings.UpdateFrequencyOfReading;

public class UpdateFrequencyOfReadingCommand : ICommand
{
    public FrequencyOfReading FrequencyOfReading { get; set; }
}
