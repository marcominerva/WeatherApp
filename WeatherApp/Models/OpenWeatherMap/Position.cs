﻿using System.Text.Json.Serialization;

namespace WeatherApp.Models.OpenWeatherMap
{
    public class Position
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
}