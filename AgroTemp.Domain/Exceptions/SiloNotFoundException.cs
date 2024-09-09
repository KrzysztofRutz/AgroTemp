using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class SiloNotFoundException : AgroTempException
{
    public int Id { get; set; }
    public SiloNotFoundException(int id)
        : base($"Silo with id {id} was not found.")
    {
        Id = id;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
