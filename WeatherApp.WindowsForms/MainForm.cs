using System.Windows.Forms;
using WeatherApp.Core;

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


        private async void GetWeatherButton_Click(object sender, System.EventArgs e)
        {
            ConditionCityLabel.Text = null;
            ConditionImage.Image = null;
            ConditionLabel.Text = null;
            TemperatureLabel.Text = null;

            if (!string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                var weather = await weatherService.GetWeatherAsync(CityTextBox.Text);
                if (weather != null)
                {
                    ConditionCityLabel.Text = weather.CityName;
                    ConditionImage.Load(weather.ConditionIconUrl);
                    ConditionLabel.Text = weather.Condition;
                    TemperatureLabel.Text = $"{weather.Temperature} °C";
                }
                else
                {
                    MessageBox.Show($"Unable to retrieve weather codition for {CityTextBox.Text}.", "Weather Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
