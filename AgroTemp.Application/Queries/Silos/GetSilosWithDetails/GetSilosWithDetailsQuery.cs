using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Silos.GetSilosWithDetails;

public record GetSilosWithDetailsQuery : IQuery<IEnumerable<SiloWithDetailsDto>>
{
}
