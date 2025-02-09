using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Alarms.UpdateAlarm;

public class UpdateAlarmCommand : ICommand
{
    public int Id { get; set; }
}
