using Syncfusion.Maui.Core.Hosting;
using AgroTemp.Mobile.Services;
using AgroTemp.Mobile.ViewModels;
using AgroTemp.Mobile.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using UraniumUI;

namespace AgroTemp.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .UseUraniumUI()         // UraniumUI kit documentation: https://enisn-projects.io/docs/en/uranium/latest
            .UseUraniumUIMaterial()
            .UseUraniumUIBlurs()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FontAwesomeBrandsRegular");
                fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesomeFreeRegular");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesomeFreeSolid");
                fonts.AddFont("SpaceGrotesk-Regular.ttf", "SpaceGroteskRegular");
                fonts.AddFont("Aleo-Regular.ttf", "AleoRegular");
            });
  
        builder.Services.AddCommunityToolkitDialogs();
        builder.Services.AddMopupsDialogs();

        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5043/") }); //For Android Emulator
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://192.168.1.18:5043/") }); //For Android Device

        builder.Services.AddServices();        

        builder.Services.AddViewModels();

        builder.Services.AddViews();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
