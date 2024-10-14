using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class DeltaTemperatureMappingProfile : Profile
{
    public DeltaTemperatureMappingProfile()
    {
        CreateMap<DeltaTemperature, DeltaTemperatureDto>();
    }
}
