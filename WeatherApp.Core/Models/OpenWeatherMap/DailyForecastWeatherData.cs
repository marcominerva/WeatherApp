﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WeatherApp.Core.Models.OpenWeatherMap.Converters;

namespace WeatherApp.Core.Models.OpenWeatherMap
{
    public class DailyForecastWeatherData
    {
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(UnixToDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonPropertyName("temp")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherCondition> WeatherInfo { get; set; }

        [JsonPropertyName("speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("deg")]
        public int WindDegree { get; set; }

        [JsonPropertyName("clouds")]
        public int Cloudiness { get; set; }

        [JsonPropertyName("rain")]
        public double? Rain { get; set; }
    }
}
