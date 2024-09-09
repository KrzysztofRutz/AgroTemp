using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Probes.GetProbesBySiloId;

public record GetProbesBySiloIdQuery(int siloId) : IQuery<IEnumerable<ProbeDto>> 
{
}
