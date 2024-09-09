using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface ISiloReadOnlyRepository
{
    Task<IEnumerable<Silo>> GetAllAsync(CancellationToken cancellationToken = default);
}
