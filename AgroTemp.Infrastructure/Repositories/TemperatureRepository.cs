using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Settings;
using AgroTemp.Infrastructure.Context;
using AgroTemp.Infrastructure.Modbus;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class TemperatureRepository : ITemperatureRepository
{
	private readonly AgroTempDbContext _dbContext;

	public TemperatureRepository(AgroTempDbContext dbContext)
    {
		_dbContext = dbContext;
	}

	public async Task<Temperature> GetActualMeasureByReadingModuleIdAsync(int readingModuleId)
		=> await _dbContext.Temperatures.Where(x => x.ReadingModuleId == readingModuleId).FirstAsync();

	public async Task<IEnumerable<Temperature>> GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(int readingModuleId, DateTime startDateTime, DateTime endDateTime, int HourOfReading, FrequencyOfReading frequencyOfReading = FrequencyOfReading.Every24hours, CancellationToken cancellationToken = default) =>
		frequencyOfReading switch
		{
			FrequencyOfReading.Every1hour => await _dbContext.Temperatures
				.Where(x => x.ReadingModuleId == readingModuleId & x.CreatedAt > startDateTime & x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0)
				.ToListAsync(cancellationToken),

            FrequencyOfReading.Every3hours => await _dbContext.Temperatures
				.Where(x => x.ReadingModuleId == readingModuleId && x.CreatedAt > startDateTime && x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0 && 
				(x.CreatedAt.Hour == HourOfReading || x.CreatedAt.Hour == (HourOfReading + 3) % 24 || x.CreatedAt.Hour == (HourOfReading + 6) % 24 || x.CreatedAt.Hour == (HourOfReading + 9) % 24 || x.CreatedAt.Hour == (HourOfReading + 12) % 24 || x.CreatedAt.Hour == (HourOfReading + 15) % 24 || x.CreatedAt.Hour == (HourOfReading + 18) % 24 || x.CreatedAt.Hour == (HourOfReading + 21) % 24))
				.ToListAsync(cancellationToken),

            FrequencyOfReading.Every6hours => await _dbContext.Temperatures
				.Where(x => x.ReadingModuleId == readingModuleId && x.CreatedAt > startDateTime && x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0 &&
				(x.CreatedAt.Hour == HourOfReading || x.CreatedAt.Hour == (HourOfReading + 6) % 24 || x.CreatedAt.Hour == (HourOfReading + 12) % 24 || x.CreatedAt.Hour == (HourOfReading + 18) % 24))
				.ToListAsync(cancellationToken),

            FrequencyOfReading.Every12hours => await _dbContext.Temperatures
				.Where(x => x.ReadingModuleId == readingModuleId && x.CreatedAt > startDateTime && x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0 &&
				(x.CreatedAt.Hour == HourOfReading || x.CreatedAt.Hour == (HourOfReading + 12) % 24))
				.ToListAsync(cancellationToken),

            FrequencyOfReading.Every24hours => await _dbContext.Temperatures
				.Where(x => x.ReadingModuleId == readingModuleId && x.CreatedAt > startDateTime && x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0 &&
				x.CreatedAt.Hour == HourOfReading)
				.ToListAsync(cancellationToken),
        };

	public async Task<IEnumerable<Temperature>> GetByReadingModuleIdAsync(int readingModuleId, CancellationToken cancellationToken = default)
		=> await _dbContext.Temperatures.Where(x => x.ReadingModuleId == readingModuleId).ToListAsync(cancellationToken);

	public async Task<Temperature> Add(ReadingModule readingModule)
	{
		var temperature = await AgroTempModbus.ReadRegistersAsync(readingModule);

		_dbContext.Temperatures.Add(temperature);

		return temperature;
	}
}
