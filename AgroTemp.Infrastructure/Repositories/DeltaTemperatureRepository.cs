using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class DeltaTemperatureRepository : IDeltaTemperatureRepository
{
    private readonly AgroTempDbContext _dbContext;

    public DeltaTemperatureRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<DeltaTemperature> GetActualMeasureByReadingModuleIdAsync(int readingModuleId)
        => await _dbContext.DeltaTemperatures.Where(x => x.ReadingModuleId == readingModuleId).FirstAsync();

    public async Task<IEnumerable<DeltaTemperature>> GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(int readingModuleId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default)
        => await _dbContext.DeltaTemperatures.Where(x => x.ReadingModuleId == readingModuleId & x.CreatedAt > startDateTime & x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0).ToListAsync(cancellationToken);

    public async Task<IEnumerable<DeltaTemperature>> GetByReadingModuleIdAsync(int readingModuleId, CancellationToken cancellationToken = default)
        => await _dbContext.DeltaTemperatures.Where(x => x.ReadingModuleId == readingModuleId).ToListAsync(cancellationToken);

    public async Task<DeltaTemperature> Add(int readingModuleId)
    {
        var actualTemperature = await _dbContext.Temperatures.Where(x => x.ReadingModuleId == readingModuleId).OrderByDescending(x => x.Id).Select(s => new ushort?[] { s.sensor1, s.sensor2 }).FirstAsync();

        var yesterday = DateTime.Today.AddDays(-1);
        string HourOfReading =  _dbContext.Settings.Select(setting => setting.HourOfReading).ToString();
        var dayBeforeTemperature = await _dbContext.Temperatures.Where(x => x.CreatedAt == yesterday.AddHours(double.Parse(HourOfReading)) & x.ReadingModuleId == readingModuleId).Select(s => new ushort?[] { s.sensor1, s.sensor2 }).FirstAsync();

        List<ushort> listOfDeltaTemperatures = new List<ushort>();
        for ( int i = 0; i <100; i++)
        {
            var result = actualTemperature[i] - dayBeforeTemperature[i];

            listOfDeltaTemperatures.Add((ushort)result);
        }

        throw new NotImplementedException();
    }
}
