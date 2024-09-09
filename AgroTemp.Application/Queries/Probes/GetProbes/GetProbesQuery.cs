using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;

namespace AgroTemp.Application.Queries.Probes.GetProbes;

public class GetProbesQuery : IQuery<IEnumerable<ProbeDto>>
{
}
