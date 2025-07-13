using AgroTemp.Domain.Abstractions.Authentication;
using AgroTemp.Domain.Authentication;
using AgroTemp.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgroTemp.Infrastructure.Authentication;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public LoginResponse GenerateJwttoken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.TypeOfUser.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim("UserId", user.Id.ToString())
        };

        string secret = _configuration.GetValue<string>("Jwt:Secret");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "doseHieu",
            audience: "doseHieu",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
            );

        return new LoginResponse {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            TokenExpired = DateTime.Now.AddMinutes(30).Ticks
        };
    }
}
