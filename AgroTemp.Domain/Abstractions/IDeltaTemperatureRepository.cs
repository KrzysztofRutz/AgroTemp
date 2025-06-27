using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.Domain.Abstractions;

public interface IDeltaTemperatureRepository
{
    Task<DeltaTemperature> GetActualMeasureByReadingModuleIdAsync(int readingModuleId);
    Task<IEnumerable<DeltaTemperature>> GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(int readingModuleId, DateTime startDateTime, DateTime endDateTime, int HourOfReading, CancellationToken cancellationToken = default);
    Task<IEnumerable<DeltaTemperature>> GetByReadingModuleIdAsync(int readingModuleId, CancellationToken cancellationToken = default);

    Task<DeltaTemperature> Add(int readingModuleId);
}
