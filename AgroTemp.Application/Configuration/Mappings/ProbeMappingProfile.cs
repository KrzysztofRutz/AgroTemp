using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class ProbeMappingProfile : Profile
{
    public ProbeMappingProfile()
    {
        CreateMap<Probe, ProbeDto>();

        CreateMap<Silo, SiloDto>();
        CreateMap<ReadingModule, ReadingModuleDto>();
        CreateMap<Probe, ProbeWithDetailsDto>();
    }
}
