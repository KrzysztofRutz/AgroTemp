using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly AgroTempDbContext _dbContext;

    public UserRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

    public async Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellation = default)
        => await _dbContext.Users.AnyAsync(x => x.Login == name);

    public void Add(User user)
        => _dbContext.Users.Add(user);

    public void Update(User user)
        => _dbContext.Users.Update(user);

    public void Delete(User user)
        => _dbContext.Users.Remove(user);

    public async Task<User?> GetByLoginAndPasswordAsync(string login, string password, CancellationToken cancellationToken = default)
        => await _dbContext.Users.SingleOrDefaultAsync(u => u.Login == login && u.Password == password, cancellationToken);
}
