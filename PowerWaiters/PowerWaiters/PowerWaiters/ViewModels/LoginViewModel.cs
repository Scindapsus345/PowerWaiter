using System.Windows.Input;
using PowerWaiters.Models;
using PowerWaiters.Services;
using Xamarin.Forms;

namespace PowerWaiters.ViewModels
{
    class LoginViewModel : BindableObject
    {
        public ICommand LoginCommand { get; }

        private string login;
        public string Login
        {
            get => login;
            set
            {
                if (value == login)
                    return;
                login = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (value == password)
                    return;
                password = value;
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
                Username = Login,
                Password = Password
            };
            if (!LoginService.TryLogin(loginModel))
                ErrorMessage = "Неверный WaiterCode";
            else
            {
                Client.IsBlocked = false;
                Application.Current.MainPage.Navigation.PopAsync();
                DataRefresher.InitialGetAllData();
            }
        }
    }
}
