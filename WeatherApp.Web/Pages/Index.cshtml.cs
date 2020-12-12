using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WeatherApp.Core;
using WeatherApp.Core.Models;

namespace WeatherApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWeatherService weatherService;

        [BindProperty(SupportsGet = true)]
        public string City { get; set; }

        public Weather Weather { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IWeatherService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService;
        }

        public async Task OnGet()
        {
            if (!string.IsNullOrWhiteSpace(City))
            {
                var currentWeatherResponse = await weatherService.GetWeatherAsync(City);
                Weather = currentWeatherResponse.IsSuccessStatusCode ? new Weather(currentWeatherResponse.Content)
                    : null;
            }
        }
    }
}
