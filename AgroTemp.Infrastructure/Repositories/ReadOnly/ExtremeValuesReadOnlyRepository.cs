using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories.ReadOnly;

internal class ExtremeValuesReadOnlyRepository : IExtremeValuesReadOnlyRepository
{
    private readonly AgroTempDbContext _dbContext;

    public ExtremeValuesReadOnlyRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<ExtremeValues>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.ExtremeValues.AsNoTracking().ToListAsync(cancellationToken);
}
