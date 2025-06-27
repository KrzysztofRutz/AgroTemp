using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Commands.Authentication.Login;

public class LoginCommand : ICommand<LoginResponseDto>
{
    public string Login { get; set; }
    public string Password { get; set; }
}
