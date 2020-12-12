using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            AppCenter.Start("android={Your Android App secret here};", typeof(Analytics), typeof(Crashes));

            InitializeComponent();

            Host.Init();
            MainPage = Host.ServiceProvider.GetService<MainPage>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
