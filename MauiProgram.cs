using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.Core.Hosting;

namespace MauiMediaPlayer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
        .UseMauiApp<App>()
        .ConfigureSyncfusionCore()
        .UseMauiCommunityToolkit()
        .UseMauiCommunityToolkitMediaElement()
       

            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Free-Solid-900.otf", "FontSolid-Icon");
                fonts.AddFont("Free-Regular-400.otf", "FontRegular-Icon");
                fonts.AddFont("Brands-Regular-400.otf", "FontBrands-Icon");
                fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesign-Icon");
            });
        builder.Services.AddSingleton<ShowVideoPageModel>();
        builder.Services.AddSingleton<MainPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
