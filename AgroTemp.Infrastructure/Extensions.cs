using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.Authentication;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Infrastructure.Authentication;
using AgroTemp.Infrastructure.Context;
using AgroTemp.Infrastructure.Repositories;
using AgroTemp.Infrastructure.Repositories.ReadOnly;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AgroTemp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var secret = configuration.GetValue<string>("Jwt:Secret");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "doseHieu",
                ValidAudience = "doseHieu",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };
        });

        services.AddAuthorization();

        services.AddScoped<IJwtTokenService, JwtTokenService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAlarmRepository, AlarmRepository>();

        services.AddScoped<IProbeReadOnlyRepository, ProbeReadOnlyRepository>();
        services.AddScoped<IProbeRepository, ProbeRepository>();

        services.AddScoped<IReadingModuleReadOnlyRepository, ReadingModuleReadOnlyRepository>();
        services.AddScoped<IReadingModuleRepository, ReadingModuleRepository>();

        services.AddScoped<ISiloReadOnlyRepository, SiloReadOnlyRepository>();
        services.AddScoped<ISiloRepository, SiloRepository>();

        services.AddScoped<IUserReadOnlyRepository, UsersReadOnlyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

		services.AddScoped<ITemperatureRepository, TemperatureRepository>();

        services.AddScoped<IDeltaTemperatureRepository, DeltaTemperatureRepository>();

        services.AddScoped<ISettingsRepository, SettingsRepository>();

        services.AddScoped<IExtremeValuesReadOnlyRepository, ExtremeValuesReadOnlyRepository>();
        services.AddScoped<IExtremeValuesRepository, ExtremeValuesRepository>();

        services.AddDbContext<AgroTempDbContext>(options => options.UseMySql(configuration.GetConnectionString("AgroTempCS"), 
            ServerVersion.AutoDetect(configuration.GetConnectionString("AgroTempCS"))));
        
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
