using System.Net;

namespace AgroTemp.Domain.Exceptions;

public abstract class AgroTempException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }

    public AgroTempException(string message) : base( message) 
    {
        
    }
}
