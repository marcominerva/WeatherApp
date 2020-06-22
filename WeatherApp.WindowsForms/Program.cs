using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Serilog;
using System;
using System.Windows.Forms;
using WeatherApp.Core;
using WeatherApp.Core.Settings;

namespace WeatherApp.WindowsForms
{
    internal static class Program
    {
        private static IHost host;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context, services);
                })
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
                })
                .Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = host.Services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
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

            services.AddSingleton<IWeatherService, WeatherService>();

            // Register all the Forms of the applications.
            services.AddSingleton<MainForm>();
        }
    }
}
