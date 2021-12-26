using PowerWaiters.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PowerWaiters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PurposesPage : ContentPage
    {
        public PurposesPage()
        {
            InitializeComponent();
            BindingContext = new PurposesViewModel();
        }
    }
}