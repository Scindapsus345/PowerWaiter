using PowerWaiter.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PowerWaiter.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}