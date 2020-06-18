using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WeatherApp.Models.OpenWeatherMap.Converters;

namespace WeatherApp.Models.OpenWeatherMap
{
    public class ForecastWeatherData
    {
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(UnixToDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonPropertyName("main")]
        public ForecastWeatherDetail WeatherDetail { get; set; }

        [JsonPropertyName("weather")]
        public IEnumerable<WeatherCondition> Conditions { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }
}