using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Windows.Forms;
using WeatherApp.Core;
using WeatherApp.WindowsForms.Settings;

namespace WeatherApp.WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder()
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
                })
                .ConfigureServices(ConfigureServices)
                .Build();

            var services = host.Services;
            var mainForm = services.GetRequiredService<MainForm>();

            Application.Run(mainForm);
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

            services.AddSingleton<MainForm>();
        }
    }
}
