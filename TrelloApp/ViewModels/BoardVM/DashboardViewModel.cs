using Jewelry.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.UserVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.BoardVM
{
    public class DashboardViewModel : ViewModelBase
    {
        //Fields
        private Board _board;
        private ObservableCollection<Board> _boards;
        private User _user;
        private IUserRepository _userRepository;
        private IBoardRepository _boardRepository;

        //Properties
        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }
        public ObservableCollection<Board> Boards
        {
            get => _boards;
            set
            {
                _boards = value;
                OnPropertyChanged(nameof(Boards));
            }
        }
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public IBoardRepository BoardRepository
        {
            get { return _boardRepository; }
            set { _boardRepository = value; }
        }

        //Commands
        public ICommand LoadUserCommand { get; set; }
        public ICommand LoadBoardsCommand { get; set; }
        public ICommand AddBoardCommand { get; set; }
        public ICommand DelBoardCommand { get; set; }

        public DashboardViewModel(IUserRepository userRepository, IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
            _userRepository = userRepository;
            _user = userRepository.LoggedUser;

            //Initialize collections
            Boards = new ObservableCollection<Board>();

            //Initialize commands
            LoadBoardsCommand = new ViewModelCommand(ExecuteLoadBoardsCommand, CanExecuteLoadBoardsCommand);
            AddBoardCommand = new ViewModelCommand(ExecuteAddBoardCommand, CanExecuteAddBoardCommand);
            DelBoardCommand = new ViewModelCommand(ExecuteDelBoardCommand, CanExecuteDelBoardCommand);

            //Default view
            ExecuteLoadBoardsCommand(null);
        }

        //Checks
        private bool CanExecuteLoadBoardsCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteAddBoardCommand(object obj)
        {
            return
                Board == null;
        }
        private bool CanExecuteDelBoardCommand(object obj)
        {
            return
                 Board != null;
        }

        //Executes
        private void ExecuteLoadBoardsCommand(object obj)
        {
            Boards.Clear();
            var boardList = _boardRepository.GetBoardsByUserID(User.UserID);
            foreach (var board in boardList)
            {
                Boards.Add(board);
            }
        }
        private void ExecuteAddBoardCommand(object obj)
        {
            _boardRepository.AddBoard(Board);
        }
        private void ExecuteDelBoardCommand(object obj)
        {
            _boardRepository.DelBoard(Board.BoardID);
        }
    }
}
