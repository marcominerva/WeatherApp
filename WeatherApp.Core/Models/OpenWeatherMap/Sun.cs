using System;
using System.Text.Json.Serialization;
using WeatherApp.Core.Models.OpenWeatherMap.Converters;

namespace WeatherApp.Core.Models.OpenWeatherMap
{
    public class Sun
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonConverter(typeof(UnixToDateTimeConverter))]
        [JsonPropertyName("sunrise")]
        public DateTime Sunrise { get; set; }

        [JsonConverter(typeof(UnixToDateTimeConverter))]
        [JsonPropertyName("sunset")]
        public DateTime Sunset { get; set; }
    }
}