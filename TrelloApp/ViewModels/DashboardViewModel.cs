using System.Collections.Generic;
using System.ComponentModel;
using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    // TODO: Переделать логику

    public class DashboardViewModel : INotifyPropertyChanged
    {
        private DashboardModel dashboard;

        public DashboardViewModel()
        {
            dashboard = new DashboardModel();
        }

        public string Username
        {
            get { return dashboard.Username; }
            set { dashboard.Username = value; OnPropertyChanged(nameof(Username)); }
        }
        public string Avatar
        {
            get { return dashboard.Avatar; }
            set { dashboard.Avatar = value; OnPropertyChanged(nameof(Avatar)); }
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
