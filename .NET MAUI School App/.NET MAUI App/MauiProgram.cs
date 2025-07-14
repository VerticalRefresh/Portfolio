using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Plugin.LocalNotification;

namespace Barham_C971
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            //Sets up notification plugin
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers =>
                {
                    //Sets up the date picker to not have an underline
#if ANDROID
                    DatePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
                    {
                        handler.PlatformView.Background = null;
                    });
#endif
                });


#if DEBUG
            // Enables logging for debugging
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
