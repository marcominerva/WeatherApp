using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using WeatherApp.Core;
using WeatherApp.Mobile.Logging;
using WeatherApp.Mobile.Settings;
using Xamarin.Essentials;

namespace WeatherApp.Mobile
{
    public static class Host
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Init()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("WeatherApp.Mobile.appsettings.json");

            var host = new HostBuilder()
                .ConfigureHostConfiguration(config =>
                {
                    // Tell the host configuration where to find the files (this is required for Xamarin apps).
                    config.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });

                    config.AddJsonStream(stream);
                })
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging((context, loggerConfiguration) =>
                {
                    loggerConfiguration.AddConfiguration(context.Configuration.GetSection("Logging"));
                    loggerConfiguration.AddDebug();
                    loggerConfiguration.AddProvider(new AppCenterLoggerProvider());
                })
                .Build();

            ServiceProvider = host.Services;
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var appSettingsSection = context.Configuration.GetSection(nameof(AppSettings));
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddOpenWeatherMap(options =>
            {
                options.ApiKey = appSettings.OpenWeatherMapApiKey;
                options.ServiceUrl = appSettings.OpenWeatherMapUrl;
            });

            services.AddSingleton<MainPage>();
        }
    }
}
