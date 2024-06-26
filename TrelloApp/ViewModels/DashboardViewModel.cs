﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        //Fields
        private Board _board;
        private User _user;

        private ObservableCollection<Board> _boards;

        private IUserRepository _userRepository;
        private IBoardRepository _boardRepository;
        private INavigator _navigator;

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
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
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

        //Commands
        public ICommand LoadUserCommand { get; set; }
        public ICommand SelectBoardCommand { get; set; }
        public ICommand LoadBoardsCommand { get; set; }
        public ICommand AddBoardCommand { get; set; }
        public ICommand DelBoardCommand { get; set; }

        public ICommand LoadBoardViewCommand { get; set; }
        public ICommand LoadProfileViewCommand { get; set; }

        public DashboardViewModel(INavigator navigator, IUserRepository userRepository, IBoardRepository boardRepository)
        {
            User = userRepository.CurrentUser;
            Board = new Board();

            _boardRepository = boardRepository;
            _userRepository = userRepository;
            _navigator = navigator;

            //Initialize collections
            Boards = new ObservableCollection<Board>();

            //Initialize commands
            SelectBoardCommand = new ViewModelCommand(ExecuteSelectBoardCommand, CanExecuteSelectBoardCommand);
            LoadUserCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);
            LoadBoardsCommand = new ViewModelCommand(ExecuteLoadBoardsCommand, CanExecuteLoadBoardsCommand);
            AddBoardCommand = new ViewModelCommand(ExecuteAddBoardCommand, CanExecuteAddBoardCommand);
            DelBoardCommand = new ViewModelCommand(ExecuteDelBoardCommand, CanExecuteDelBoardCommand);

            LoadBoardViewCommand = new ViewModelCommand(ExecuteLoadBoardViewCommand, CanExecuteLoadBoardViewCommand);
            LoadProfileViewCommand = new ViewModelCommand(ExecuteLoadProfileViewCommand, CanExecuteLoadProfileViewCommand);

            //Default view
            ExecuteLoadUserCommand(null);
            ExecuteLoadBoardsCommand(null);
        }

        //Checks
        private bool CanExecuteLoadUserCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteSelectBoardCommand(object obj)
        {
            return
                Board != null;
        }
        private bool CanExecuteLoadBoardsCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteAddBoardCommand(object obj)
        {
            return
                Board.Title != null;
        }
        private bool CanExecuteDelBoardCommand(object obj)
        {
            return
                 Board != null;
        }
        private bool CanExecuteLoadBoardViewCommand(object obj)
        {
            return
                Board != null;
        }
        private bool CanExecuteLoadProfileViewCommand(object obj)
        {
            return
                User != null;
        }

        //Executes
        private void ExecuteLoadUserCommand(object obj)
        {
            User = _userRepository.CurrentUser;
        }
        private void ExecuteSelectBoardCommand(object obj)
        {
            _boardRepository.CurrentBoard = Board;
        }
        private void ExecuteLoadBoardsCommand(object obj)
        {
            Boards.Clear();
            var boardList = _boardRepository.GetBoardsByUserID(User.UserID);
            boardList.Insert(0, new Board { Title = "Placeholder" });

            /*For testing*/
            /*for (int i = 1; i < 20; i++)
            {
                boardList.Add(new Board { Title = "Title" + i.ToString() });
            }*/

            foreach (var board in boardList)
            {
                Boards.Add(board);
            }
        }
        private void ExecuteAddBoardCommand(object obj)
        {
            var _board = new Board()
            {
                AdminID = User.UserID,
                User = User,
                Title = Board.Title
            };
            _boardRepository.AddBoard(_board);

            ExecuteLoadBoardsCommand(null);
        }

        private void ExecuteDelBoardCommand(object obj)
        {
            _boardRepository.DelBoard(Board.BoardID);
        }
        private void ExecuteLoadBoardViewCommand(object obj)
        {
            _boardRepository.CurrentBoard = Board;
            _navigator.GoTo("BoardView.xaml");
        }
        private void ExecuteLoadProfileViewCommand(object obj)
        {
            _navigator.GoTo("ProfileView.xaml");
        }
    }
}
