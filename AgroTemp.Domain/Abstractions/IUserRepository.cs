using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLoginAndPasswordAsync(string login, string password, CancellationToken cancellationToken = default);
}
