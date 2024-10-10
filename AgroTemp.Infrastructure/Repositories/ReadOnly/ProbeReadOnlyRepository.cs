using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories.ReadOnly;

internal class ProbeReadOnlyRepository : IProbeReadOnlyRepository
{
    private readonly AgroTempDbContext _dbContext;

    public ProbeReadOnlyRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Probe>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Probes.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<Probe>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Probes.Include(x => x.Silo).Include(x => x.ReadingModule).ThenInclude(x => x.Temperatures).AsNoTracking().ToListAsync(cancellationToken);
}
