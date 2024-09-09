using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Probes.GetProbesWithDetails;

public record GetProbesWithDetailsQuery : IQuery<IEnumerable<ProbeWithDetailsDto>>
{
}
