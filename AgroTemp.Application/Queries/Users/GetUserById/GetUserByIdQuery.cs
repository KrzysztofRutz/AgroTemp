using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Users.GetUserById;

public record GetUserByIdQuery(int id) : IQuery<UserDto>
{
}
