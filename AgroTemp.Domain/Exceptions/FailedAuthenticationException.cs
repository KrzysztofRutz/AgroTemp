using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class FailedAuthenticationException : AgroTempException
{
    public FailedAuthenticationException()
        : base("Invalid login or password.")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}
