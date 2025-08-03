using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface ISiloReadOnlyRepository : IBaseReadOnlyRepository<Silo>
{
    Task<IEnumerable<Silo>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);
}
