using System.Text.Json.Serialization;

namespace WeatherApp.Core.Models.OpenWeatherMap
{
    public class WeatherCondition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Condition { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string ConditionIcon { get; set; }
    }
}