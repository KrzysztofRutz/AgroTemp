using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.Domain.Abstractions;

public interface ITemperatureRepository
{
	Task<Temperature> GetActualMeasureByReadingModuleIdAsync(int readingModuleId);
	Task<IEnumerable<Temperature>> GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(int readingModuleId, DateTime startDateTime, DateTime endDateTime, int HourOfReading, FrequencyOfReading frequencyOfReading = FrequencyOfReading.Every24hours, CancellationToken cancellationToken = default);

	Task<IEnumerable<Temperature>> GetByReadingModuleIdAsync(int readingModuleId, CancellationToken cancellationToken = default);

	Task<Temperature> Add(ReadingModule readingModule);
}
