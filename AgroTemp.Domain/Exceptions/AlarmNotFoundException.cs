using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class AlarmNotFoundException : AgroTempException
{
    public int Id { get; set; }
    public AlarmNotFoundException(int id)
        : base($"Alarm with id {id} was not found.")
    {
        Id = id;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
