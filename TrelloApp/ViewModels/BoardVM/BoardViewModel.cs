using System;
using System.Collections.Generic;
using System.Windows;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.UserVM;
using TrelloApp.ViewModels.BoardVM;
using TrelloApp.ViewModels.ColumnVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private BoardModel _board;
        public BoardModel Board
        {
            get { return _board; }
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }

        private ColumnModel _column;
        public ColumnModel Column
        {
            get { return _column; }
            set
            {
                _column = value;
                OnPropertyChanged(nameof(Column));
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        private IBoardRepository _boardRepository;
        public IBoardRepository BoardRepository
        {
            get { return _boardRepository; }
            set { _boardRepository = value; }
        }

        private IColumnRepository _columnRepository;
        public IColumnRepository ColumnRepository
        {
            get { return _columnRepository; }
            set { _columnRepository = value; }
        }

        public BoardViewModel(UserModel currentUser, BoardModel currentBoard)
        {
            LoadUser(currentUser.UserID);
            LoadColumns(currentBoard.BoardID);
            _board = currentBoard;
        }

        private void LoadUser(int userID)
        {
            try
            {
                User = _userRepository.GetUserByID(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadColumns(int boardID)
        {
            try
            {
                List<Column> borderColumns = _columnRepository.GetColumnsByBoardID(boardID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
