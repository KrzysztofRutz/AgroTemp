using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Users.GetUserByLoginAndPassword;

public record GetUserByLoginAndPasswordQuery(string login, string password) : IQuery<UserDto>
{
}
