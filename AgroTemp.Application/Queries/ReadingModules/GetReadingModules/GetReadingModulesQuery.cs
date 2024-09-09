using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.ReadingModules.GetReadingModules;

public record GetReadingModulesQuery : IQuery<IEnumerable<ReadingModuleDto>> 
{
}
