using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Users.UpdatePassword;

public class UpdatePasswordCommand : ICommand
{
    public int Id { get; set; }
    public string Password { get; set; }
}
