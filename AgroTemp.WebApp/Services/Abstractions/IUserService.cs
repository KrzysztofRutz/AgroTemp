﻿using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Services.Abstractions;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User> GetByLoginAndPasswordAsync(string login, string password, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user);
}
