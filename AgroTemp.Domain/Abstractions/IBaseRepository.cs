using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellation = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
