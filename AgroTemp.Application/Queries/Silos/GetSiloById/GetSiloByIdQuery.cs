using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Silos.GetSiloById;

public record GetSiloByIdQuery(int Id) : IQuery<SiloDto>
{
}
