using Refit;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Core.Models.OpenWeatherMap;

namespace WeatherApp.Core
{
    public interface IOpenWeatherMapApi
    {
        [Get("/weather")]
        Task<ApiResponse<CurrentWeather>> GetWeatherAsync([AliasAs("q")] string city,
            CancellationToken cancellationToken = default);
    }
}