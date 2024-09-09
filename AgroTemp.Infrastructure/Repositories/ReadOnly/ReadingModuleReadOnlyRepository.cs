using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories.ReadOnly;

internal class ReadingModuleReadOnlyRepository : IReadingModuleReadOnlyRepository
{
    private readonly AgroTempDbContext _dbContext;

    public ReadingModuleReadOnlyRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<ReadingModule>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.ReadingModules.AsNoTracking().ToListAsync(cancellationToken);
}
