using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Users.UpdateLogin;

public class UpdateLoginCommand : ICommand
{
    public int Id { get; set; }
    public string Login { get; set; }
}
