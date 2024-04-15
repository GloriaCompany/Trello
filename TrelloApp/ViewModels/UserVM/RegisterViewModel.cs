using Jewelry.ViewModel;
using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public class RegisterViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _errorMessage;
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
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
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
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
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
        public IUserRepository UserRepository
        {
            get => _userRepository;
        }

        //Commands
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        //Checks
        private bool CanExecuteRegisterCommand(object obj)
        {
            return
                !string.IsNullOrWhiteSpace(Username) &&
                Username.Length >= 3 &&
                !string.IsNullOrWhiteSpace(Email) &&
                Email.Length >= 3 &&
                !string.IsNullOrWhiteSpace(Password) &&
                Password.Length >= 3 &&
                !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                ConfirmPassword == Password;
        }

        //Executes
        private void ExecuteRegisterCommand(object obj)
        {
            var user = new User()
            {
                Username = Username,
                Email = Email,
                Password = Password,
                Avatar = null
            };

            _userRepository.LoggedUser = user;
        }
    }
}
