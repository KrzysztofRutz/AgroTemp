using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class ExtremeValuesMappingProfile : Profile
{
    public ExtremeValuesMappingProfile()
    {
        CreateMap<ExtremeValues, ExtremeValuesDto>();
    }
}
