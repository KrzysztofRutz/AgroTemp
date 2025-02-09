using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface ITemperatureService
{
    Task<IEnumerable<Temperature>> GetByProbeIdAndBetweenStartDateTimeAndEndTimeAsync(int probeId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default);
}
