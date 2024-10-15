using AgroTemp.WWW.Services.Abstractions;
using BlazorBootstrap;

namespace AgroTemp.WWW.Services;

public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<WeatherForecastService>();
        services.AddScoped<ISiloService, SiloService>();
        services.AddSingleton <ModalService>();
        
        return services;
    }
}
