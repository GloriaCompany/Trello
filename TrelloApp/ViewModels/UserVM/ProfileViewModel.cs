using Jewelry.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels.UserVM
{
    public class ProfileViewModel : ViewModelBase
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
        public IUserRepository UserRepository
        {
            get => _userRepository;
            set => _userRepository = value;
        }

        //Commands
        public ICommand LoadUserCommand { get; set; }
        public ICommand ProfileUpdateCommand { get; set; }

        public ProfileViewModel()
        {
            ProfileUpdateCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);
            ProfileUpdateCommand = new ViewModelCommand(ExecuteUpdateUserCommand, CanExecuteUpdateUserCommand);
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

        //Executes
        private void ExecuteLoadUserCommand(object obj)
        {
            
        }
        private void ExecuteUpdateUserCommand(object obj)
        {
           
        }
    }
}
