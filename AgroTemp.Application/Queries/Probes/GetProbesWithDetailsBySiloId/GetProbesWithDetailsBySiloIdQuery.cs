using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Probes.GetProbesWithDetailsBySiloId;

public record GetProbesWithDetailsBySiloIdQuery(int siloId) : IQuery<IEnumerable<ProbeWithDetailsDto>>
{
}
