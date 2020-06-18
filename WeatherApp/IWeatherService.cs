using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherAsync(string city);
    }
}