using AgroTemp.WebApp.Services.Abstractions;

namespace AgroTemp.WebApp.Services;

public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISiloService, SiloService>();
        services.AddScoped<IProbeService, ProbeService>();
        services.AddScoped<IAlarmService, AlarmService>();
        services.AddScoped<IExtremeValuesService, ExtremeValuesService>();

        return services;
    }
}
