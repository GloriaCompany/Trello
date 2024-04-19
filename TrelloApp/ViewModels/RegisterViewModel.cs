using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        //Fields
        private UserModel _user;
        private string _errorMessage;
        private IUserRepository _userRepository;

        //Properties
        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
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
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            User = new UserModel();

            //Initialize commands
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        //Checks
        private bool CanExecuteRegisterCommand(object obj)
        {
            return
                User.Username != null &&
                User.Email != null &&
                User.Password != null &&
                User.ConfirmPassword != null &&
                User.Password == User.ConfirmPassword;
        }

        //Executes
        private void ExecuteRegisterCommand(object obj)
        {
            User.Avatar = "/TrelloApp;component/Resources/userAvatar.png";
            _userRepository.CurrentUser = User;
            var user = new User()
            {
                Username = User.Username,
                Email = User.Email,
                Avatar = User.Avatar,
                Password = User.Password
            };
            _userRepository.AddUser(user);
        }
    }
}
