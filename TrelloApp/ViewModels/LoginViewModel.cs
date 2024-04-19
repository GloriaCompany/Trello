using System.Windows.Input;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;

namespace TrelloApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private string _password;
        private string _errorMessage;

        private IUserRepository _userRepository;
        private INavigator _navigator;

        //Properties
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        //Commands
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel(IUserRepository userRepository, INavigator navigator)
        {
            _userRepository = userRepository;
            _navigator = navigator;

            //Initialize commands
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }


        //Checks
        private bool CanExecuteLoginCommand(object obj)
        {
            return
                !string.IsNullOrWhiteSpace(Username) &&
                Username.Length >= 3 &&
                !string.IsNullOrWhiteSpace(Password) &&
                Password.Length >= 3;
        }
        private bool CanExecuteRegisterCommand(object obj)
        {
            return true;
        }

        //Executes
        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _userRepository.AuthenticateUser(Username, Password);

            if (isValidUser)
            {
                _navigator.GoTo("DashboardView.xaml");
            }
            else
            {
                ErrorMessage = "Invalid Username or Password";
            }
        }
        private void ExecuteRegisterCommand(object obj)
        {
            _navigator.GoTo("RegisterView.xaml");
        }
    }
}