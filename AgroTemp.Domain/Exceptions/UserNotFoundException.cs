using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class UserNotFoundException : AgroTempException
{
    public int Id { get; set; }
    public string Login {  get; set; } = string.Empty;
    public UserNotFoundException(int id)
        : base($"User with id {id} was not found.")
    {
        Id = id;
    }

    public UserNotFoundException(string login)
        : base($"User with login {login} was not found.")
    {
        Login = login;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
