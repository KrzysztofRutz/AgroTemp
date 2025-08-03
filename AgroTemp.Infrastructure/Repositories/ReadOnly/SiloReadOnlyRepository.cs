using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories.ReadOnly;

internal class SiloReadOnlyRepository : ISiloReadOnlyRepository
{
    private readonly AgroTempDbContext _dbContext;

    public SiloReadOnlyRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Silo>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Silos.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<Silo>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Silos.Include(x => x.ExtremeValues).AsNoTracking().ToListAsync(cancellationToken);
}
