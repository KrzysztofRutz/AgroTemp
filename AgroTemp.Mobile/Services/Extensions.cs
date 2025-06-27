using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using AgroTemp.WWW.Services;

namespace AgroTemp.Mobile.Services;

public static class Extensions
{
    public static IServiceCollection AddServices (this IServiceCollection services)
    {
        services.AddSingleton<ISiloService, SiloService>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IProbeService, ProbeService>();
        services.AddSingleton<IExtremeValuesService, ExtremeValuesService>();
        services.AddSingleton<IAlarmService, AlarmService>();
        services.AddSingleton<IValueWithTimeStampService<Temperature>, TemperatureService>();
        services.AddSingleton<IValueWithTimeStampService<Delta>, DeltaService>();
        services.AddSingleton<ISettingsService, SettingsService>();

        return services;
    }
}
