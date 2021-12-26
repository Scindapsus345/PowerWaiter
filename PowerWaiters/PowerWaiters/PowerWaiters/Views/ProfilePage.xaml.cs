using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PowerWaiters.ViewModels;

namespace PowerWaiters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }
    }
}