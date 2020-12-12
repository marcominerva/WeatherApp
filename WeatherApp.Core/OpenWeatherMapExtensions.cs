using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using System;
using System.Text.Json;
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

            services.AddRefitClient<IOpenWeatherMapApi>(new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions(JsonSerializerDefaults.Web))
            })
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
                // The AddTransientHttpErrorPolicy handles errors typical of Http calls:
                // Network failures (System.Net.Http.HttpRequestException)
                // HTTP 5XX status codes (server errors)
                // HTTP 408 status code (request timeout)
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
            }));

            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }
    }
}
