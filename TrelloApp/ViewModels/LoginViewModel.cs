using System.ComponentModel;
using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private UserModel user;

        public LoginViewModel()
        {
            user = new UserModel();
        }

        public string UserName
        {
            get { return user.UserName; }
            set { user.UserName = value; OnPropertyChanged(nameof(UserName)); }
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
