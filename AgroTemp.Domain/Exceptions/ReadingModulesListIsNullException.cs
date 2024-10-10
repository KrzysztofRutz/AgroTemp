using System.Net;

namespace AgroTemp.Domain.Exceptions;

public class ReadingModulesListIsNullException : AgroTempException
{
	public ReadingModulesListIsNullException()
		: base("List of reading modules is null.")
	{
	}

	public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
