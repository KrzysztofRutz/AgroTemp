using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class SiloIsAlreadyExistException : AgroTempException
{
    public string Name { get; set; }

    public SiloIsAlreadyExistException(string name)
        : base($"Silo with {name} is already exist.")
    {
        
    }
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
