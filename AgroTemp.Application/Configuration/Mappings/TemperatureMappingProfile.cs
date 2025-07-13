using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class TemperatureMappingProfile : Profile
{
    public TemperatureMappingProfile()
    {
        CreateMap<Temperature, TemperatureDto>();

        //For GetTemperaturesByProbeIdAndTimeIntervalQuery
        CreateMap<Temperature, TemperatureByIntervalTimeDto>()
            .ForMember(member => member.ListOfValues, conf => conf.MapFrom(src =>
                Enumerable.Range(1, 100)
                .Select(i => (double?)((ushort?)typeof(Temperature).GetProperty($"sensor{i}").GetValue(src)) / 100)
                .ToList()))
            .ForMember(member => member.DateTimeStamp, conf => conf.MapFrom(src => src.CreatedAt));
    }
}
