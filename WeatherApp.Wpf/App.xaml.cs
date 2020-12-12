using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Windows;
using WeatherApp.Core;
using WeatherApp.Wpf.Settings;

namespace WeatherApp.Wpf
{
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context, services);
                })
                .Build();
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

            // Register all the Windows of the applications.
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
