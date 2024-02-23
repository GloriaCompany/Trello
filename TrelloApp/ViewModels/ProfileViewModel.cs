using System.ComponentModel;
using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    internal class ProfileViewModel : INotifyPropertyChanged
    {
        private UserModel user;

        public ProfileViewModel()
        {
            user = new UserModel();
        }

        public int UserID
        {
            get { return user.UserID; }
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
        public string Email
        {
            get { return user.Email; }
            set { user.Email = value; OnPropertyChanged(nameof(Email)); }
        }
        public int AvatarID
        {
            get { return user.AvatarID; }
            set { user.AvatarID = value; OnPropertyChanged(nameof(AvatarID)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
