using System.Collections.Generic;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels
{
    public class BoardViewModel : ViewModelBase
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
    }
}
