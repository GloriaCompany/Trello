using System.Collections.Generic;
using System.ComponentModel;
using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    internal class DashboardViewModel : INotifyPropertyChanged
    {
        private DashboardModel dashboard;

        public DashboardViewModel()
        {
            dashboard = new DashboardModel();
        }

        public string UserName
        {
            get { return dashboard.UserName; }
            set { dashboard.UserName = value; OnPropertyChanged(nameof(UserName)); }
        }
        public int AvatarID
        {
            get { return dashboard.AvatarID; }
            set { dashboard.AvatarID = value; OnPropertyChanged(nameof(AvatarID)); }
        }
        public List<BoardModel> Boards
        {
            get { return dashboard.Boards; }
            set { dashboard.Boards = value; OnPropertyChanged(nameof(Boards)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
