using Jewelry.ViewModel;
using System;
using System.Configuration;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;

        private Visibility _createDatabaseButtonVisibility;

        private IUserRepository _userRepository;

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
        public SecureString Password
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
        public event EventHandler SuccessfullyLoggedIn;

        //Commands
        public ICommand LoginCommand { get; set; }


        public LoginViewModel()
        {
            _userRepository = new UserRepository();

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        //Checks
        private bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username) && Username.Length >= 3 &&
                   Password != null && Password.Length >= 3;
        }


        //Executes
        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _userRepository.AuthenticateUser(Username, Password);

            if (isValidUser)
            {
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