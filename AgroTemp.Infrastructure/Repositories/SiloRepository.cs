using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class SiloRepository : ISiloRepository
{
    private readonly AgroTempDbContext _dbContext;

    public SiloRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Silo> GetByIdAsync(int id, CancellationToken cancellation = default)
        => await _dbContext.Silos.SingleOrDefaultAsync(x => x.Id == id, cancellation);

    public async Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellation = default)
        => await _dbContext.Silos.AnyAsync(x => x.Name == name);

    public void Add(Silo silo)
        => _dbContext.Silos.Add(silo);

    public void Update(Silo silo)
        => _dbContext?.Silos.Update(silo);

    public void Delete(Silo silo)
        => _dbContext.Silos.Remove(silo);   
}
