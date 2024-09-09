using MediatR;

namespace AgroTemp.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
