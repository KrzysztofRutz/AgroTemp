using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Users.RemoveUser;

public record RemoveUserCommand (int Id) : ICommand
{
}
