using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User> GetByLoginAndPasswordAsync(string login, string password, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user);
}
