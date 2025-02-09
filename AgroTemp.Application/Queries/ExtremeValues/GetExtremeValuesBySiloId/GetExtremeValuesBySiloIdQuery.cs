using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.ExtremeValues.GetExtremeValuesBySiloId;

public record GetExtremeValuesBySiloIdQuery(int siloId) : IQuery<ExtremeValuesDto>
{
}
