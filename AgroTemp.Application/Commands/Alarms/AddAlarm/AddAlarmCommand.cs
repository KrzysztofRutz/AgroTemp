using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Commands.Alarms.AddAlarm;

public class AddAlarmCommand : ICommand<AlarmDto>
{
    public string Description { get; set; }
    public string ObjectName { get; set; }
}
