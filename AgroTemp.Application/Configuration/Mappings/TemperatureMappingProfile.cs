using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class TemperatureMappingProfile : Profile
{
    public TemperatureMappingProfile()
    {
        CreateMap<Temperature, TemperatureDto>();
    }
}
