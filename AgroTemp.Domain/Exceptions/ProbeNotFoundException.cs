using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class ProbeNotFoundException : AgroTempException
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProbeNotFoundException(int id)
        : base($"Probe with id {id} was not found.")
    {
        Id = id;
    }

    public ProbeNotFoundException(string name)
        : base($"Probe with name {name} was not found.")
    {
        Name = name;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
