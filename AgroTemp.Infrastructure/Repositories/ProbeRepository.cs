using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class ProbeRepository : IProbeRepository
{
    private readonly AgroTempDbContext _dbContext;

    public ProbeRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Probe> GetByIdAsync(int id, CancellationToken cancellation = default)
        => await _dbContext.Probes.SingleOrDefaultAsync(x => x.Id == id, cancellation);

    public async Task<IEnumerable<Probe>> GetBySiloIdAsync(int siloId, CancellationToken cancellation = default)
        => await _dbContext.Probes.Where(x => x.SiloId == siloId).ToListAsync(cancellation);

    public async Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellation = default)
        => await _dbContext.Probes.AnyAsync(x => x.Name == name);

    public void Add(Probe probe)
        => _dbContext.Probes.Add(probe);

    public void Update(Probe probe)
        => _dbContext.Probes.Update(probe);

    public void Delete(Probe probe)
        => _dbContext.Probes.Remove(probe);
}
