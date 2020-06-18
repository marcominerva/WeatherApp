using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace WeatherApp.Xamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IWeatherService weatherService;

        public MainPage(IWeatherService weatherService)
        {
            InitializeComponent();

            this.weatherService = weatherService;
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            ConditionCityLabel.Text = null;
            ConditionImage.Source = null;
            ConditionLabel.Text = null;
            TemperatureLabel.Text = null;

            if (!string.IsNullOrWhiteSpace(CityEntry.Text))
            {
                var weather = await weatherService.GetWeatherAsync(CityEntry.Text);
                if (weather != null)
                {
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
