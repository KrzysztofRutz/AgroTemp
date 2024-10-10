using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface ITemperatureRepository
{
	Task<Temperature> GetActualMeasureByReadingModuleIdAsync(int readingModuleId);
	Task<IEnumerable<Temperature>> GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(int readingModuleId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default);

	Task<IEnumerable<Temperature>> GetByReadingModuleIdAsync(int readingModuleId, CancellationToken cancellationToken = default);

	Task<Temperature> Add(ReadingModule readingModule);
}
