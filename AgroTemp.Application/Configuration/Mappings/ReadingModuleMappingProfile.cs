using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class ReadingModuleMappingProfile : Profile
{
    public ReadingModuleMappingProfile()
    {
        CreateMap<ReadingModule, ReadingModuleDto>();
    }
}
