using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface IProbeReadOnlyRepository : IBaseReadOnlyRepository<Probe>
{
    Task<IEnumerable<Probe>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);
}
