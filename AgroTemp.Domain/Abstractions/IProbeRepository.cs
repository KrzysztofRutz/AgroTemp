using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IProbeRepository : IBaseRepository<Probe>
{
    Task<IEnumerable<Probe>> GetBySiloIdAsync(int siloId, CancellationToken cancellation = default);
}
