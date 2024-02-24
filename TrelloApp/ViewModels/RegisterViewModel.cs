using System.ComponentModel;
using System.Configuration;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private UserModel user;
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            user = new UserModel();
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }

        private bool CanRegister()
        {
            return 
                !string.IsNullOrEmpty(user.Username) && 
                !string.IsNullOrEmpty(user.Email) &&
                !string.IsNullOrEmpty(user.Password) &&
                !string.IsNullOrEmpty(user.Avatar);
        }
        private void Register()
        {
            using (var dbContext = new TrelloDataClassesDataContext(
                ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                var newUserEntity = new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    Avatar = user.Avatar
                };

                dbContext.User.InsertOnSubmit(newUserEntity);
                dbContext.SubmitChanges();

                //Переключение окна
            }
        }

        public int UserID
        {
            get { return user.UserID; }
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
        public string Email
        {
            get { return user.Email; }
            set { user.Email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string Avatar
        {
            get { return user.Avatar; }
            set { user.Avatar = value; OnPropertyChanged(nameof(Avatar)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
