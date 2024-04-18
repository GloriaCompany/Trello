using System;
using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        //Fields
        private User _user;
        private string _errorMessage;

        private IUserRepository _userRepository;

        //Properties
        public User User
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
        public ICommand LoadUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public ICommand DelUserCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public ProfileViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            //Initialize commands
            LoadUserCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);
            UpdateUserCommand = new ViewModelCommand(ExecuteUpdateUserCommand, CanExecuteUpdateUserCommand);
            DelUserCommand = new ViewModelCommand(ExecuteDelUserCommand, CanExecuteDelUserCommand);
            LogoutCommand = new ViewModelCommand(ExecuteLogoutCommand, CanExecuteLogoutCommand);
        }

        //Checks
        private bool CanExecuteLoadUserCommand(object obj)
        {
            return
                User != null;
        }
        private bool CanExecuteUpdateUserCommand(object obj)
        {
            return
                !string.IsNullOrEmpty(User.Username) ||
                !string.IsNullOrEmpty(User.Email) ||
                !string.IsNullOrEmpty(User.Password) ||
                !string.IsNullOrEmpty(User.Avatar);
        }
        private bool CanExecuteDelUserCommand(object obj)
        {
            throw new NotImplementedException();
        }
        private bool CanExecuteLogoutCommand(object obj)
        {
            return
                User != null;
        }

        //Executes
        private void ExecuteLoadUserCommand(object obj)
        {
            User = _userRepository.GetUserByID(User.UserID);
        }
        private void ExecuteUpdateUserCommand(object obj)
        {
            _userRepository.UpdateUser(User);
        }
        private void ExecuteDelUserCommand(object obj)
        {
            _userRepository.DelUser(User.UserID);
        }
        private void ExecuteLogoutCommand(object obj)
        {
            _userRepository.CurrentUser = null;
        }
    }
}
