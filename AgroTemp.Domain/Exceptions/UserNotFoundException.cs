using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class UserNotFoundException : AgroTempException
{
    public int Id { get; set; }
    public UserNotFoundException(int id)
        : base($"User with id {id} was not found.")
    {
        Id = id;
    }
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
