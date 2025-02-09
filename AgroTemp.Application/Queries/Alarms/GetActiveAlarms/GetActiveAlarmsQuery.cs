using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Alarms.GetActiveAlarms;

public class GetActiveAlarmsQuery : IQuery<IEnumerable<AlarmDto>>
{
}
