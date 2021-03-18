using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using System;
using WeatherApp.Core.Handlers;

namespace WeatherApp.Core
{
    public static class OpenWeatherMapExtensions
    {
        public static IServiceCollection AddOpenWeatherMap(this IServiceCollection services, Action<OpenWeatherMapSettings> configure)
        {
            var settings = new OpenWeatherMapSettings();
            configure?.Invoke(settings);

            services.AddMemoryCache();

            services.AddRefitClient<IOpenWeatherMapApi>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(settings.ServiceUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(_ =>
            {
                var handler = new QueryStringInjectorHttpMessageHandler();
                handler.Parameters.Add("units", "metric");
                handler.Parameters.Add("lang", "IT");
                handler.Parameters.Add("APPID", settings.ApiKey);

                return handler;
            })
            .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
            }));

            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }
    }
}
