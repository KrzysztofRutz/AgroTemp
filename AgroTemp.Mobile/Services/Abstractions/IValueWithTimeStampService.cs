using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface IValueWithTimeStampService<T> where T : ValueWithTimeStampModel
{
    Task<IEnumerable<T>> GetByProbeIdAndBetweenStartDateTimeAndEndTimeAsync(int probeId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default);
}
