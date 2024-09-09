using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class ReadingModuleIsAlreadyExistException : AgroTempException
{
    public string Name { get; set; }
    public ReadingModuleIsAlreadyExistException(string name)
        : base($"Reading module with name {name} already exists.")
    {
        Name = name;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
