using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IBasicRepository<T> where T : Entity
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellation = default);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
