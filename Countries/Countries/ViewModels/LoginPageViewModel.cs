namespace Countries.ViewModels
{
    using Prism.Commands;
    using Prism.Navigation;

    public class LoginPageViewModel : ViewModelBase
    {
        public string Email { get; set; }

        private bool _isRunning;
        private bool _isEnabled;
        private string _password;

        private DelegateCommand _loginCommand;
        private DelegateCommand _registerCommand;
        private DelegateCommand _forgotPasswordCommand;

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Countries";
            IsEnabled = true;
        }

        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(LoginAsync));

        public DelegateCommand RegisterCommand =>
            _registerCommand ?? (_registerCommand = new DelegateCommand(RegisterAsync));

        public DelegateCommand ForgotPassword =>
            _forgotPasswordCommand ?? (_forgotPasswordCommand = new DelegateCommand(ForgotPasswordAsync));

        private void ForgotPasswordAsync()
        {
            //TODO: pending
        }

        private void RegisterAsync()
        {
            //TODO: pending
        }

        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Incorrect E-mail", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Incorrect Password", "OK");
                return;
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isRunning;
            set => SetProperty(ref _isEnabled, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }



    }
}
