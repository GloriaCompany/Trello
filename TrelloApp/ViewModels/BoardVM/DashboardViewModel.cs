using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
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

        public ICommand LoadUserCommand { get; set; }
        public ICommand LoadBoardsCommand { get; set; }
        public ICommand AddBoardCommand { get; set; }
        public ICommand DelBoardCommand { get; set; }

        public DashboardViewModel(UserModel currentUser)
        {
            _user = currentUser;
            LoadUserCommand = new RelayCommand(() => LoadUser(_user.UserID), CanLoadUser);
            LoadBoardsCommand = new RelayCommand(() => LoadBoards(_user.UserID), CanLoadBoards);
            AddBoardCommand = new RelayCommand(AddBoard, CanAddBoard);
            DelBoardCommand = new RelayCommand(() => DelBoard(Board.BoardID), CanDelBoard);
        }

        private bool CanLoadUser()
        {
            bool res =
                User != null;

            ((RelayCommand)LoadUserCommand).RaiseCanExecuteChanged();

            return res;
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

        private bool CanLoadBoards()
        {
            bool res =
                Board != null;

            ((RelayCommand)LoadBoardsCommand).RaiseCanExecuteChanged();

            return res;
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

        private bool CanAddBoard()
        {
            bool res =
                Board != null;

            ((RelayCommand)AddBoardCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void AddBoard()
        {
            try
            {
                Board newBoard = new Board();
                _boardRepository.AddBoard(newBoard);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanDelBoard()
        {
            bool res =
                Board != null;

            ((RelayCommand)DelBoardCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void DelBoard(int boardID)
        {
            try
            {
                _boardRepository.DelBoard(boardID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
