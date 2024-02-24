using System.Collections.Generic;
using System.ComponentModel;
using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        private BoardModel board;

        public BoardViewModel()
        {
            board = new BoardModel();
        }

        public int BoardID
        {
            get { return board.BoardID; }
        }
        public string BoardName
        {
            get { return board.BoardName; }
            set { board.BoardName = value; OnPropertyChanged(nameof(BoardName)); }
        }
        public List<ColumnModel> Columns
        {
            get { return board.Columns; }
            set { board.Columns = value; OnPropertyChanged(nameof(Columns)); }
        }
        public List<UserModel> Users
        {
            get { return board.Users; }
            set { board.Users = value; OnPropertyChanged(nameof(Users)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
