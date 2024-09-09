using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.ReadingModules.GetReadingModuleById;

public record GetReadingModuleByIdQuery(int Id) : IQuery<ReadingModuleDto> 
{
}
