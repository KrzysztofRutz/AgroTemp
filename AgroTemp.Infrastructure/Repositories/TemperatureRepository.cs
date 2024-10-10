using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
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

	public async Task<IEnumerable<Temperature>> GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(int readingModuleId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default)
		=> await _dbContext.Temperatures.Where(x => x.ReadingModuleId == readingModuleId & x.CreatedAt > startDateTime & x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0).ToListAsync(cancellationToken);

	public async Task<IEnumerable<Temperature>> GetByReadingModuleIdAsync(int readingModuleId, CancellationToken cancellationToken = default)
		=> await _dbContext.Temperatures.Where(x => x.ReadingModuleId == readingModuleId).ToListAsync(cancellationToken);

	public async Task<Temperature> Add(ReadingModule readingModule)
	{
		var temperature = await AgroTempModbus.ReadRegistersAsync(readingModule);

		_dbContext.Temperatures.Add(temperature);

		return temperature;
	}
}
