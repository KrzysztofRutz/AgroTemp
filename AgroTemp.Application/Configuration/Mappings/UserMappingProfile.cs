using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Password, conf => conf.MapFrom(model => new string('*', model.Password.Length)));
    }
}
