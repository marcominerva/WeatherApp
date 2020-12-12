using System;
using System.Windows;
using System.Windows.Media.Imaging;
using WeatherApp.Core;
using WeatherApp.Core.Models;
using WeatherApp.Core.Models.OpenWeatherMap;

namespace WeatherApp.Wpf
{
    public partial class MainWindow : Window
    {
        private readonly IWeatherService weatherService;

        public MainWindow(IWeatherService weatherService)
        {
            InitializeComponent();

            this.weatherService = weatherService;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ConditionCityTextBlock.Text = null;
            ConditionImage.Source = null;
            ConditionTextBlock.Text = null;
            TemperatureTextBlock.Text = null;

            if (!string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                var currentWeatherResponse =
                    await weatherService.GetWeatherAsync(CityTextBox.Text);

                if (currentWeatherResponse.IsSuccessStatusCode)
                {
                    var weather = new Weather(currentWeatherResponse.Content);
                    ConditionCityTextBlock.Text = weather.CityName;
                    ConditionImage.Source = new BitmapImage(new Uri(weather.ConditionIconUrl));
                    ConditionTextBlock.Text = weather.Condition;
                    TemperatureTextBlock.Text = $"{weather.Temperature} °C";
                }
                else
                {
                    var error = await currentWeatherResponse.Error.GetContentAsAsync<Error>();
                    MessageBox.Show($"Unable to retrieve weather codition for {CityTextBox.Text}: {error.Message}.", "Weather Client", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
