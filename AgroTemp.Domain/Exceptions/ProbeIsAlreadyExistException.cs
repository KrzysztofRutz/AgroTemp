using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class ProbeIsAlreadyExistException : AgroTempException
{
    public string Name { get; set; }

    public ProbeIsAlreadyExistException(string name)
        : base($"Probe with name {name} already exists.")
    {
        Name = name;
    }
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
