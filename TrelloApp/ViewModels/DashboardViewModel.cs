using System;
using System.Collections.Generic;
using System.Windows;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.BoardVM;
using TrelloApp.ViewModels.UserVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
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

        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public DashboardViewModel(UserModel currentUser)
        {
            LoadUser(currentUser.UserID);
            LoadBoards(currentUser.UserID);
            _user = currentUser;
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

        private void LoadUser(int userID)
        {
            try
            {
                User = (UserModel)_userRepository.GetUserByID(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadBoards(int userID)
        {
            try
            {
                //Board, BoardModel? Need Fix
                List<Board> userBoards = _boardRepository.GetBoardsByUserID(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
