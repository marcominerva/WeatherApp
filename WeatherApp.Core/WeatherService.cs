using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Core.Models.OpenWeatherMap;

namespace WeatherApp.Core
{
    public class WeatherService : IWeatherService
    {
        private readonly IOpenWeatherMapApi openWeatherMapApi;
        private readonly ILogger logger;
        private readonly IMemoryCache cache;

        public WeatherService(IOpenWeatherMapApi openWeatherMapApi, ILogger<WeatherService> logger,
            IMemoryCache cache)
        {
            this.openWeatherMapApi = openWeatherMapApi;
            this.logger = logger;
            this.cache = cache;
        }

        public async Task<ApiResponse<CurrentWeather>> GetWeatherAsync(string city, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting weather condition for {City}...", city);

            var key = $"weather-{city}";
            if (cache.TryGetValue<ApiResponse<CurrentWeather>>(key, out var cacheResponse))
            {
                logger.LogDebug("Retrieving value for {City} from cache", city);
                return cacheResponse;
            }

            var response = await openWeatherMapApi.GetWeatherAsync(city, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("Unable to retrieve weather condition: {StatusCode}", response.StatusCode);
            }
            else
            {
                cache.Set(key, response, TimeSpan.FromMinutes(1));
            }

            return response;
        }
    }
}
