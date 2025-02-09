using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class AlarmMappingProfile : Profile
{
    public AlarmMappingProfile()
    {
        CreateMap<Alarm, AlarmDto>();
    }
}
