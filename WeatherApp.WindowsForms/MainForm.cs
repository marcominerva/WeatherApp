using System;
using System.Linq;
using System.Windows.Forms;
using WeatherApp.Core;
using WeatherApp.Core.Models.OpenWeatherMap;

namespace WeatherApp.WindowsForms
{
    public partial class MainForm : Form
    {
        private readonly IWeatherService weatherService;

        public MainForm(IWeatherService weatherService)
        {
            InitializeComponent();

            this.weatherService = weatherService;
        }

        private async void GetCurrentWeatherButton_Click(object sender, EventArgs e)
        {
            ConditionCityLabel.Text = null;
            ConditionImage.Image = null;
            ConditionLabel.Text = null;
            TemperatureLabel.Text = null;

            if (!string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                var currentWeatherResponse =
                    await weatherService.GetWeatherAsync(CityTextBox.Text);

                if (currentWeatherResponse.IsSuccessStatusCode)
                {
                    var weather = currentWeatherResponse.Content;
                    ConditionCityLabel.Text = weather.Name;
                    ConditionImage.Load($"https://openweathermap.org/img/w/{weather.Conditions.First().ConditionIcon}.png");
                    ConditionLabel.Text = weather.Conditions.First().Description;
                    TemperatureLabel.Text = $"{weather.Detail.Temperature} °C";
                }
                else
                {
                    var error = await currentWeatherResponse.Error.GetContentAsAsync<Error>();
                    MessageBox.Show($"Unable to retrieve weather codition for {CityTextBox.Text}: {error.Message}.", "Weather Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
