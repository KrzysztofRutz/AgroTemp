using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface IBaseReadOnlyRepository <T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
