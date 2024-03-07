using Celin.AB.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using System.Reflection;
using UraniumUI;

namespace Celin.AB
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .UseUraniumUIBlurs()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddMaterialSymbolsFonts();
                });

            /* Config */
            var a = Assembly.GetExecutingAssembly();
            var settings = $"{a.GetName().Name}.Resources.appsettings.json";
            using var stream = a.GetManifestResourceStream(settings)
                ?? throw new ArgumentNullException(nameof(a.GetManifestResourceStream));
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(config);

            /* Services */
            builder.Services
                .AddCommunityToolkitDialogs()
                .AddSingleton<Host>()
                .AddSingleton<AppShell>()
                .AddSingleton<MainPage>()
                .AddSingleton<AboutPage>()
                .AddTransient<SearchAndSelect>();

            /* Logger */
            var loggingSection = config.GetSection("Logging");
            builder.Services.AddLogging(log =>
            {
                log.AddConfiguration(loggingSection);
#if DEBUG
                log.AddDebug();
#endif
                log.AddConsole();
            });

            return builder.Build();
        }
    }
}
