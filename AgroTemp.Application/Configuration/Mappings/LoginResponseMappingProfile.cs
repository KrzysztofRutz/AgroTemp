using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Authentication;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class LoginResponseMappingProfile : Profile
{
    public LoginResponseMappingProfile()
    {
        CreateMap<LoginResponse, LoginResponseDto>();
    }
}
