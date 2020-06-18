using System.Text.Json.Serialization;

namespace WeatherApp.Models.OpenWeatherMap
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int Cloudiness { get; set; }
    }
}