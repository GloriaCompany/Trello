using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private UserModel _user;
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            _user = new UserModel();
            RegisterCommand = new RelayCommand(Register, CanRegister);
            ((RelayCommand)RegisterCommand).CanExecuteChanged += RegisterCommand_CanExecuteChanged;
        }

        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private void RegisterCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            ((RelayCommand)RegisterCommand).RaiseCanExecuteChanged();
        }

        private bool CanRegister()
        {
            bool res =
                !string.IsNullOrEmpty(User.Username) &&
                !string.IsNullOrEmpty(User.Email) &&
                !string.IsNullOrEmpty(User.Password) &&
                !string.IsNullOrEmpty(User.PasswordConfirmation);

            ((RelayCommand)RegisterCommand).RaiseCanExecuteChanged();

            return res;
        }

        private void Register()
        {
            //MessageBox.Show("Clicked");
            using (var dbContext = new TrelloDataClassesDataContext(
                ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                var newUserEntity = new User
                {
                    Username = User.Username,
                    Password = User.Password,
                    Email = User.Email,
                    Avatar = User.Avatar
                };

                dbContext.User.InsertOnSubmit(newUserEntity);
                dbContext.SubmitChanges();

                //MessageBox.Show("Registered");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
