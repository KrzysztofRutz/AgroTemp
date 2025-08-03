using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class SiloMappingProfile : Profile
{
    public SiloMappingProfile()
    {
        CreateMap<Silo, SiloDto>();

        // For GetAllSiloWithDetailsQuery
        CreateMap<ExtremeValues, ExtremeValuesDto>();
        CreateMap<Silo, SiloWithDetailsDto>();
    }
}
