using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    // TODO: Переделать логику

    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UserModel user;
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            user = new UserModel();
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
            using (var dbContext = new TrelloDataClassesDataContext(
                ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                var existingUser = dbContext.User.SingleOrDefault(
                    u =>
                    u.Username == user.Username &&
                    u.Password == user.Password);

                if (existingUser != null)
                {
                    dbContext.SubmitChanges();
                    //Переключение окна
                }
                else
                {
                    //Пользователь не найден
                }
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
