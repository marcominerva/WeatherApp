using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Reflection;
using WeatherApp.Core;
using WeatherApp.Core.Settings;
using WeatherApp.Xamarin.Logging;
using Xamarin.Essentials;

namespace WeatherApp.Xamarin
{
    public static class Host
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Init()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("WeatherApp.Xamarin.appsettings.json");

            var host = new HostBuilder()
                        .ConfigureHostConfiguration(config =>
                        {
                            // Tell the host configuration where to find the files (this is required for Xamarin apps).
                            config.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });

                            // Read in the configuration file.
                            config.AddJsonStream(stream);
                        })
                        .ConfigureServices((context, services) =>
                        {
                            // Configure our local services and access the host configuration.
                            ConfigureServices(context, services);
                        })
                        .ConfigureLogging((hostingContext, loggerConfiguration) =>
                        {
                            loggerConfiguration.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                            loggerConfiguration.AddDebug();
                            loggerConfiguration.AddProvider(new AppCenterLoggerProvider());
                        })
                        .Build();

            // Save our service provider so we can use it later.
            ServiceProvider = host.Services;
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var appSettingsSection = context.Configuration.GetSection(nameof(AppSettings));
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection);

            services.AddHttpClient(nameof(WeatherService)).ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(appSettings.OpenWeatherMapUrl);
            })
            .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
            {
                // The AddTransientHttpErrorPolicy handles errors typical of Http calls:
                // Network failures (System.Net.Http.HttpRequestException)
                // HTTP 5XX status codes (server errors)
                // HTTP 408 status code (request timeout)
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
            }));

            services.AddScoped<IWeatherService, WeatherService>();

            // Register all the Windows of the applications.
            services.AddSingleton<MainPage>();
        }
    }
}
