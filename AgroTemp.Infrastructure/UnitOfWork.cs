using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AgroTemp.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly AgroTempDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(AgroTempDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        await _context.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntities()
    {
        var entries = _context
            .ChangeTracker
            .Entries<Entity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.Now;
                _logger.LogInformation($"{entry.Context.Model} has new object at {DateTime.Now}");
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.Now;
                _logger.LogInformation($"{entry.Context.Model} has updated object with {entry.Entity.Id} at {DateTime.Now}");
            }
        }
    }
}
