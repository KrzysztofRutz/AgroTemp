using AgroTemp.Mobile.ViewModels;
using AgroTemp.Mobile.Views.Pages;
using AgroTemp.Mobile.Views.Popups;
using CommunityToolkit.Maui;

namespace AgroTemp.Mobile.Views;

public static class Extensions
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        //Pages
        services.AddTransient<LoginPage>();
        services.AddTransient<ObjectPage>();
        services.AddTransient<AlarmPage>();
        services.AddTransient<ProbesWithDetailsPage>();
        services.AddTransient<ChartOfTemperaturePage>();
        services.AddTransient<ChartOfDeltaPage>();
        services.AddTransient<MoreInfoPage>();

        //Popups
        services.AddTransientPopup<EditActualUserPopup, EditActualUserViewModel>();

        return services;
    }
}
