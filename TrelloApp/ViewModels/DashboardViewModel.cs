using System.Collections.ObjectModel;
using System.Windows.Input;
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

        public DashboardViewModel(IUserRepository userRepository, IBoardRepository boardRepository)
        {
            User = userRepository.CurrentUser;

            _boardRepository = boardRepository;
            _userRepository = userRepository;

            //Initialize collections
            Boards = new ObservableCollection<Board>();

            //Initialize commands
            SelectBoardCommand = new ViewModelCommand(ExecuteSelectBoardCommand, CanExecuteSelectBoardCommand);
            LoadUserCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);
            LoadBoardsCommand = new ViewModelCommand(ExecuteLoadBoardsCommand, CanExecuteLoadBoardsCommand);
            AddBoardCommand = new ViewModelCommand(ExecuteAddBoardCommand, CanExecuteAddBoardCommand);
            DelBoardCommand = new ViewModelCommand(ExecuteDelBoardCommand, CanExecuteDelBoardCommand);

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
                Board == null;
        }
        private bool CanExecuteDelBoardCommand(object obj)
        {
            return
                 Board != null;
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
            //for (int i = 1; i < 20; i++)
            //{
            //    boardList.Add(new Board { Title = "Title" + i.ToString()});
            //}

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
