using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApp.Core.Models;
using WeatherApp.Core.Models.OpenWeatherMap;
using WeatherApp.Core.Settings;

namespace WeatherApp.Core
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly AppSettings settings;
        private readonly ILogger<WeatherService> logger;

        public WeatherService(IHttpClientFactory httpClientFactory, IOptions<AppSettings> settings, ILogger<WeatherService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.settings = settings.Value;
            this.logger = logger;
        }

        public async Task<Weather> GetWeatherAsync(string city)
        {
            try
            {
                logger.LogDebug("Getting weather condition for City...", city);

                var client = httpClientFactory.CreateClient(nameof(WeatherService));

                var uri = $"weather?q={city}&units=metric&APPID={settings.OpenWeatherMapApiKey}";
                using var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<CurrentWeather>();

                    logger.LogInformation("Weather condition for {City} retrieved", city);
                    return new Weather(content);
                }

                logger.LogError("Unable to retrieve weather condition for {City}. Error code: {ErrorCode}", city, (int)response.StatusCode);
                return null;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Critical error while trying to retrieve weather condition for {City}", city);
                return null;
            }
        }
    }
}
