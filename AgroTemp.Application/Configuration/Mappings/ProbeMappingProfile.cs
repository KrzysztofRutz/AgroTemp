using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class ProbeMappingProfile : Profile
{
    public ProbeMappingProfile()
    {
        CreateMap<Probe, ProbeDto>();

        //For GetAllProbeWithDetailsQuery
        CreateMap<Silo, SiloDto>();
        CreateMap<ReadingModule, ReadingModuleDto>();
        CreateMap<Probe, ProbeWithDetailsDto>();
        CreateMap<Temperature, TemperatureForOneProbeDto>()
            .ForMember(member => member.ListOfValues, conf => conf.MapFrom(src =>
                Enumerable.Range(1, 100)
                .Select(i => (double?)((ushort?)typeof(Temperature).GetProperty($"sensor{i}").GetValue(src)) / 100)
                .ToList()));
        CreateMap<DeltaTemperature, DeltaTemperatureForOneProbeDto>()
            .ForMember(member => member.ListOfValues, conf => conf.MapFrom(src =>
                Enumerable.Range(1, 100)
                .Select(i => (double?)((ushort?)typeof(DeltaTemperature).GetProperty($"sensor{i}").GetValue(src)) / 100)
                .ToList()));
    }
}
