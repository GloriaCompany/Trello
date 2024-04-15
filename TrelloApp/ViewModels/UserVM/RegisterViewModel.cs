﻿using Jewelry.ViewModel;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels.UserVM
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
        public IUserRepository UserRepository
        {
            get => _userRepository;
        }

        //Commands
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _user = new UserModel();
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        //Checks
        private bool CanExecuteRegisterCommand(object obj)
        {
            return
                User != null &&
                User.Error == null &&
                User.Password == User.ConfirmPassword;
        }

        //Executes
        private void ExecuteRegisterCommand(object obj)
        {
            _userRepository.LoggedUser = User;
        }
    }
}
