using System;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.BoardVM;
using TrelloApp.Views;

namespace TrelloApp.ViewModels.UserVM
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private String _password;
        private string _errorMessage;

        private Visibility _createDatabaseButtonVisibility;
        public Visibility CreateDatabaseButtonVisibility
        {
            get { return _createDatabaseButtonVisibility; }
            set { _createDatabaseButtonVisibility = value; OnPropertyChanged(nameof(CreateDatabaseButtonVisibility)); }
        }

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
        public String Password
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

        //Events
        //public event EventHandler SuccessfullyLoggedIn;

        //Commands
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IUserRepository userRepository, INavigator navigator)
        {
            _userRepository = userRepository;
            _navigator = navigator;
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        //Checks
        private bool CanExecuteLoginCommand()
        {
            return !string.IsNullOrWhiteSpace(Username) && Username.Length >= 3 &&
                   Password != null && Password.Length >= 3;
        }

        //Executes
        private void ExecuteLoginCommand()
        {
            var isValidUser = _userRepository.AuthenticateUser(Username, Password);

            if (isValidUser)
            {
                //SuccessfullyLoggedIn?.Invoke(this, null);
                
                _navigator.GoTo("Dashboard.xaml");

                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
            }
            else
            {
                ErrorMessage = "Invalid Username or Password";
            }
        }
    }
}