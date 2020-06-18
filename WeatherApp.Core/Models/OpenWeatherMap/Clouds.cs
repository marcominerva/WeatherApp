using System.Text.Json.Serialization;

namespace WeatherApp.Core.Models.OpenWeatherMap
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int Cloudiness { get; set; }
    }
}