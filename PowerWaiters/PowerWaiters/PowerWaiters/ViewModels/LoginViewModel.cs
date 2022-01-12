using System.Windows.Input;
using PowerWaiters.Models;
using PowerWaiters.Services;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class LoginViewModel : BindableObject
    {
        public ICommand LoginCommand { get; }

        private string waiterCode;
        public string WaiterCode
        {
            get => waiterCode;
            set
            {
                if (value == waiterCode)
                    return;
                waiterCode = value;
                OnPropertyChanged();
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (value == errorMessage)
                    return;
                errorMessage = value;
                OnPropertyChanged();
            }
        }


        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private void OnLogin()
        {
            var loginModel = new LoginModel()
            {
                UserName = WaiterCode,
                Password = WaiterCode
            };
            if (!LoginService.TryLogin(loginModel))
                ErrorMessage = "Неверный WaiterCode";
            else
                Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
