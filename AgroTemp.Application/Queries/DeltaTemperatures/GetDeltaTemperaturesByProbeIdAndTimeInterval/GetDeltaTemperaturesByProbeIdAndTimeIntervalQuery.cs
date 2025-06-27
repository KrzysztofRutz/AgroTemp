using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.DeltaTemperatures.GetDeltaTemperaturesByProbeIdAndTimeInterval;

public record GetDeltaTemperaturesByProbeIdAndTimeIntervalQuery(int probeId, DateTime startDateTime, DateTime endDateTime) : IQuery<IEnumerable<DeltaTemperatureByIntervalTimeDto>>
{
}
