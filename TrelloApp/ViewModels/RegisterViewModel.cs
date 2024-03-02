using System;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
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

        public IUserRepository UserRepository { get; set; } 

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            _user = new UserModel();
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }

        private bool CanRegister()
        {
            bool res =
                User != null &&
                User.Password == User.ConfirmPassword;

            ((RelayCommand)RegisterCommand).RaiseCanExecuteChanged();

            return res;
        }

        private void Register()
        {
            try
            {
                if (!CanRegister())
                {
                    MessageBox.Show("Заповніть усі поля форми, будь-ласка.");
                    return;
                }

                UserRepository.AddUser(User);

                MessageBox.Show("Користувача зареєстровано.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
