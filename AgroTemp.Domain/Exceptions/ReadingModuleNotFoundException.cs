using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class ReadingModuleNotFoundException : AgroTempException
{
    public int Id { get; set; }
    public ReadingModuleNotFoundException(int id)
        :base($"Reading module with id {id} was not found.")
    {
        Id = id;
    }
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
