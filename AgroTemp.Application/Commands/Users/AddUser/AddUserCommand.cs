using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Enums.User;


namespace AgroTemp.Application.Commands.Users.AddUser;

public class AddUserCommand : ICommand<UserDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string TypeOfUser { get; set; }
}
