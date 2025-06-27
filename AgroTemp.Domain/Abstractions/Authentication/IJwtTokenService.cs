using AgroTemp.Domain.Authentication;
using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.Authentication;

public interface IJwtTokenService
{
    public LoginResponse GenerateJwttoken(User user);
}
