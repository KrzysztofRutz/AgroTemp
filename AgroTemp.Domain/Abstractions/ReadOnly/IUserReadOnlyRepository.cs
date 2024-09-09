using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface IUserReadOnlyRepository
{
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
}
