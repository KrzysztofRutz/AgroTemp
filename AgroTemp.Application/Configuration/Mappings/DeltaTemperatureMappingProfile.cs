using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class DeltaTemperatureMappingProfile : Profile
{
    public DeltaTemperatureMappingProfile()
    {
        CreateMap<DeltaTemperature, DeltaTemperatureDto>();

        //For GetDeltaTemperaturesByProbeIdAndTimeIntervalQuery
        CreateMap<DeltaTemperature, DeltaTemperatureByIntervalTimeDto>()
            .ForMember(member => member.ListOfTemperatures, conf => conf.MapFrom(src =>
                Enumerable.Range(1, 100)
                .Select(i => (double?)((ushort?)typeof(DeltaTemperature).GetProperty($"sensor{i}").GetValue(src)) / 100)
                .ToList()))
            .ForMember(member => member.DateTimeStamp, conf => conf.MapFrom(src => src.CreatedAt));
    }
}
