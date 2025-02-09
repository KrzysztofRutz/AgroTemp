namespace AgroTemp.Mobile.ViewModels;

public static class Extensions
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<LoginViewModel>();
        services.AddTransient<ObjectViewModel>();
        services.AddTransient<AlarmViewModel>();
        services.AddTransient<ProbesWithDetailsViewModel>();
        services.AddTransient<ChartOfTemperatureViewModel>();
        services.AddTransient<ChartOfDeltaViewModel>();
        services.AddTransient<MoreInfoViewModel>();

        //ViewModels for popups are added on the 'AddViews()' method
        return services;
    }
}
