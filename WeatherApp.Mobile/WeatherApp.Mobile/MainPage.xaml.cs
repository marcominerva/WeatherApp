using System;
using WeatherApp.Core;
using WeatherApp.Core.Models;
using Xamarin.Forms;

namespace WeatherApp.Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly IWeatherService weatherService;

        public MainPage(IWeatherService weatherService)
        {
            InitializeComponent();

            this.weatherService = weatherService;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ConditionCityLabel.Text = null;
            ConditionImage.Source = null;
            ConditionLabel.Text = null;
            TemperatureLabel.Text = null;

            if (!string.IsNullOrWhiteSpace(CityEntry.Text))
            {
                var currentWeatherResponse = await weatherService.GetWeatherAsync(CityEntry.Text);
                if (currentWeatherResponse.IsSuccessStatusCode)
                {
                    var weather = new Weather(currentWeatherResponse.Content);
                    ConditionCityLabel.Text = weather.CityName;
                    ConditionImage.Source = ImageSource.FromUri(new Uri(weather.ConditionIconUrl));
                    ConditionLabel.Text = weather.Condition;
                    TemperatureLabel.Text = $"{weather.Temperature} °C";
                }
                else
                {
                    await DisplayAlert("Weather Mobile App", $"Unable to retrieve weather codition for {CityEntry.Text}.", "OK");
                }
            }
        }
    }
}
