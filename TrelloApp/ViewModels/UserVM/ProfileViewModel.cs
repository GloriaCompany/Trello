﻿using System;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels.UserVM
{
    public class ProfileViewModel : ViewModelBase
    {
        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        public ICommand LoadUserCommand { get; set; }
        public ICommand ProfileUpdateCommand { get; set; }

        public ProfileViewModel()
        {
            ProfileUpdateCommand = new RelayCommand(() => LoadUser(User.UserID), CanLoadUser);
            ProfileUpdateCommand = new RelayCommand(UpdateUser, CanUpdateUser);
        }

        private bool CanLoadUser()
        {
            bool res =
                User != null;

            ((RelayCommand)LoadUserCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void LoadUser(int userID)
        {
            try
            {
                User = (UserModel)_userRepository.GetUserByID(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanUpdateUser()
        {
            bool res =
                !string.IsNullOrEmpty(User.Username) ||
                !string.IsNullOrEmpty(User.Email) ||
                !string.IsNullOrEmpty(User.Password) ||
                !string.IsNullOrEmpty(User.Avatar);

            ((RelayCommand)ProfileUpdateCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void UpdateUser()
        {
            try
            {
                if (!CanUpdateUser())
                {
                    MessageBox.Show("Перевірте правильність введених даних, будь-ласка.");
                    return;
                }

                _userRepository.UpdateUser(User);

                MessageBox.Show("Дані користувача змінено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
