using PowerWaiters.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PowerWaiters
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainTabbedPage();
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
