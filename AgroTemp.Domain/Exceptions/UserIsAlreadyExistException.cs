using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class UserIsAlreadyExistException : AgroTempException
{
    public string Login {  get; set; }

    public UserIsAlreadyExistException(string login)
        :base($"User with login {login} already exists.")
    {
        Login = login;
    }
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
