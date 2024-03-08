using System.Collections.Generic;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        // TODO: New Logic

        private BoardModel board;

        public BoardViewModel()
        {
            board = new BoardModel();
        }

        public int BoardID
        {
            get { return board.BoardID; }
        }
        public string BoardTitle
        {
            get { return board.Title; }
            set { board.Title = value; OnPropertyChanged(nameof(BoardTitle)); }
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
