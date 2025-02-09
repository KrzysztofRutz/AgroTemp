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

    public async Task<Alarm> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Alarms.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

    public async Task<IEnumerable<Alarm>> GetAlarmsBetweenCreatedAtAndUpdatedAtAsync(DateTime createdAtTime, DateTime updatedAtTime, CancellationToken cancellationToken = default)
        => await _dbContext.Alarms.Where(x => x.CreatedAt >= createdAtTime && x.UpdatedAt <= updatedAtTime && x.CreatedAt != x.UpdatedAt).ToListAsync();

    public async Task<IEnumerable<Alarm>> GetActiveAlarmsAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Alarms.Where(x => x.CreatedAt == x.UpdatedAt).ToListAsync();

    public void Add(Alarm alarm)
        => _dbContext.Alarms.Add(alarm);
    
    public void Update(Alarm alarm)
        => _dbContext.Alarms.Update(alarm);  
}
