using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherAsync(string city);
    }
}