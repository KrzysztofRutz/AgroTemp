using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Enums.User;

namespace AgroTemp.Application.Commands.Users.UpdateUser;

public class UpdateUserCommand : ICommand
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string TypeOfUser { get; set; }
}
