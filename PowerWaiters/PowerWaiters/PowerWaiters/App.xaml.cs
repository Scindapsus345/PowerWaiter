using PowerWaiters.Views;
using Xamarin.Forms;

namespace PowerWaiters
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ProfilePage();
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
