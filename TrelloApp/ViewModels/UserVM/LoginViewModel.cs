using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloDBLayer;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.UserVM;

namespace TrelloApp.ViewModels.UserVM
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UserModel user;
        private readonly IUserRepository userRepository;

        public event EventHandler SuccessfullyLoggedIn;

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            user = new UserModel();
            userRepository = new UserRepository();

            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin()
        {
            return
                !string.IsNullOrEmpty(user.Username) &&
                !string.IsNullOrEmpty(user.Password);
        }

        private void Login()
        {
            try
            {
                var existingUser = userRepository.GetUserByID(user.UserID);

                if (existingUser != null && existingUser.Username == user.Username && existingUser.Password == user.Password)
                {
                    SuccessfullyLoggedIn?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Помилка: Невірне ім'я користувача або пароль.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        public string Username
        {
            get { return user.Username; }
            set { user.Username = value; OnPropertyChanged(nameof(Username)); }
        }
        public string Password
        {
            get { return user.Password; }
            set { user.Password = value; OnPropertyChanged(nameof(Password)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}