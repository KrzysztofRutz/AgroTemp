using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class SettingsMappingProfile : Profile 
{
    public SettingsMappingProfile()
    {
        CreateMap<Settings, SettingsDto>();    
    }
}
