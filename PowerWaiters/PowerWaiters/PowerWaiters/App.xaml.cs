using PowerWaiters.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PowerWaiters
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                "NjUxMzY1QDMyMzAyZTMxMmUzMGtZQytCVFN6MXV5RThIMnNZY21WdWJhSlVEUjd0NmFEOWg3akgvZWpicjg9");

            InitializeComponent(); 
            MainPage = new NavigationPage(new MainTabbedPage());
            DataRefresher.InitialGetAllData();
            Task.Run(DataRefresher.StartPolling);
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
