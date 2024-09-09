using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Infrastructure.Context;
using AgroTemp.Infrastructure.Repositories;
using AgroTemp.Infrastructure.Repositories.ReadOnly;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgroTemp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
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

        services.AddDbContext<AgroTempDbContext>(options => options.UseMySql(configuration.GetConnectionString("AgroTempCS"), ServerVersion.AutoDetect(configuration.GetConnectionString("AgroTempCS"))));
        
        return services;
    }
}
