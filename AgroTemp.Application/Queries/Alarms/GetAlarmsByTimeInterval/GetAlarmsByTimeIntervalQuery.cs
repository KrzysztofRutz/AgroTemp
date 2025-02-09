using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Alarms.GetAlarmsByTimeInterval;

public record GetAlarmsByTimeIntervalQuery(DateTime startDate, DateTime endDate) : IQuery<IEnumerable<AlarmDto>>
{
}
