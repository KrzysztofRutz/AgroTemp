using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.ExtremeValues.GetExtremeValues;

public record GetExtremeValuesQuery : IQuery<IEnumerable<ExtremeValuesDto>>
{
}
