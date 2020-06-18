using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WeatherApp.Core;
using WeatherApp.Core.Models;

namespace WeatherApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWeatherService weatherService;

        [BindProperty(SupportsGet = true)]
        public string City { get; set; }

        public Weather Weather { get; set; }

        public IndexModel(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task OnGet()
        {
            if (!string.IsNullOrWhiteSpace(City))
            {
                Weather = await weatherService.GetWeatherAsync(City);
            }
        }
    }
}
