using System.Linq;
using WeatherApp.Core.Models.OpenWeatherMap;

namespace WeatherApp.Core.Models
{
    public class Weather
    {
        public string CityName { get; }

        public string ConditionIcon { get; }

        public string ConditionIconUrl => $"https://openweathermap.org/img/w/{ConditionIcon}.png";

        public string Condition { get; }

        public decimal Temperature { get; }

        public Weather(CurrentWeather weather)
        {
            CityName = weather.Name;
            Condition = weather.Conditions.First().Description;
            ConditionIcon = weather.Conditions.First().ConditionIcon;
            Temperature = weather.Detail.Temperature;
        }
    }
}
