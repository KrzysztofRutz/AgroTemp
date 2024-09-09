using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface IProbeReadOnlyRepository
{
    Task<IEnumerable<Probe>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Probe>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);
}
