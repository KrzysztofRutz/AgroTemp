using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class ExtremeValuesRepository : IExtremeValuesRepository
{
    private readonly AgroTempDbContext _dbContext;

    public ExtremeValuesRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ExtremeValues> GetBySiloIdAsync(int siloId, CancellationToken cancellationToken = default)
        => await _dbContext.ExtremeValues.Where(x => x.SiloId == siloId).FirstAsync(cancellationToken);

    public void Add(ExtremeValues entity)
        => _dbContext.ExtremeValues.Add(entity);

    public void Update(ExtremeValues entity)
        => _dbContext.ExtremeValues.Update(entity);

    public void Delete(ExtremeValues entity)
        => _dbContext.ExtremeValues.Remove(entity);
}
