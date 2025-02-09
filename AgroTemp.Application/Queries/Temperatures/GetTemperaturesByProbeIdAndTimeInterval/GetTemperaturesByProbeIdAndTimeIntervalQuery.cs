using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Temperatures.GetTemperaturesByTimeInterval;

public record GetTemperaturesByProbeIdAndTimeIntervalQuery(int probeId, DateTime startDateTime, DateTime endDateTime) : IQuery<IEnumerable<TemperatureByIntervalTimeDto>>
{
}
