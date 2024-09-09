using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Probes.GetProbeById;

public record GetProbeByIdQuery(int Id) : IQuery<ProbeDto>
{
}
