using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class ReadingModuleRepository : IReadingModuleRepository
{
    private readonly AgroTempDbContext _dbContext;

    public ReadingModuleRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ReadingModule> GetByIdAsync(int id, CancellationToken cancellation = default)
        => await _dbContext.ReadingModules.SingleOrDefaultAsync(m => m.Id == id, cancellation);

    public async Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellation = default)
        => await _dbContext.ReadingModules.AnyAsync(x => x.Name == name);

    public void Add(ReadingModule readingModule)
        => _dbContext.ReadingModules.Add(readingModule);

    public void Update(ReadingModule readingModule)
        => _dbContext.ReadingModules.Update(readingModule);

    public void Delete(ReadingModule readingModule)
        => _dbContext.Remove(readingModule);
}
