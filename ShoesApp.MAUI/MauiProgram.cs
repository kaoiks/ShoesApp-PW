using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using INF148151_148140.ShoesApp.MAUI.ViewModels;
using INF148151_148140.ShoesApp.BLC;

namespace INF148151_148140.ShoesApp.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //builder.Services.AddSingleton<ViewModels.FootwearCollectionViewModel>();
            builder.Services.AddSingleton<ProducerCollectionViewModel>();
            builder.Services.AddSingleton<ProducersPage>();
            builder.Services.AddSingleton<FootwearCollectionViewModel>();
            builder.Services.AddSingleton<FootwearsPage>();
            builder.Services.AddSingleton<BLController>(serviceProvider =>
            {
                string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
                return BLController.GetInstance(libraryName);
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
