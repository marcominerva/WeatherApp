﻿using System.Text.Json.Serialization;

namespace WeatherApp.Models.OpenWeatherMap
{
    public class CurrentWeatherDetail
    {
        [JsonPropertyName("temp")]
        public decimal Temperature { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}