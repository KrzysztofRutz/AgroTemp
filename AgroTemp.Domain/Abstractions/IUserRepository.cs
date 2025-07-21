using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLoginAndPasswordAsync(string login, string password, CancellationToken cancellationToken = default);
    Task UpdateLoginAsync(int id, string login);
    Task UpdatePasswordAsync(int id, string password);
    Task UpdateUserParametersAsync(User user);
}
