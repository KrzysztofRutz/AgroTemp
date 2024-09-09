using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class AlarmRepository : IAlarmRepository
{
    private readonly AgroTempDbContext _dbContext;

    public AlarmRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Alarm>> GetAlarmsByBetweenCreatedAtAndUpdatedAtAsync(DateTime createdAtTime, DateTime updatedAtTime, CancellationToken cancellationToken = default)
        => await _dbContext.Alarms.Where(x => x.CreatedAt >= createdAtTime && x.UpdatedAt <= updatedAtTime).ToListAsync();

    public void Add(Alarm alarm)
        => _dbContext.Alarms.Add(alarm);
    
    public void Update(Alarm alarm)
        => _dbContext.Alarms.Update(alarm);  
}
