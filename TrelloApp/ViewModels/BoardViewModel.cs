using System.Collections.ObjectModel;
using System.Windows.Input;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        //Fields
        private User _user;
        private Board _board;
        private Column _column;

        private string _originalTitle;

        private IUserRepository _userRepository;
        private IBoardRepository _boardRepository;
        private IColumnRepository _columnRepository;
        private INavigator _navigator;

        private ObservableCollection<Column> _columns;
        private ObservableCollection<User> _teamUsers;

        //Properties
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }
        public Column Column
        {
            get => _column;
            set
            {
                _column = value;
                OnPropertyChanged(nameof(Column));
            }
        }

        public string OriginalTitle
        {
            get => _originalTitle;
            set
            {
                _originalTitle = value;
                OnPropertyChanged(nameof(OriginalTitle));
            }
        }

        public ObservableCollection<Column> Columns
        {
            get => _columns;
            set
            {
                _columns = value;
                OnPropertyChanged(nameof(Columns));
            }
        }
        public ObservableCollection<User> TeamUsers
        {
            get => _teamUsers;
            set
            {
                _teamUsers = value;
                OnPropertyChanged(nameof(TeamUsers));
            }
        }

        //Commands
        public ICommand LoadUserCommand { get; set; }
        public ICommand LoadColumnsCommand { get; set; }
        public ICommand UpdateBoardCommand { get; set; }
        public ICommand CancelUpdateBoardCommand { get; set; }
        public ICommand DelBoardCommand { get; set; }
        public ICommand AddColumnCommand { get; set; }
        public ICommand UpdateColumnCommand { get; set; }
        public ICommand LoadDashboardViewCommand { get; set; }

        public BoardViewModel(INavigator navigator, IUserRepository userRepository, IBoardRepository boardRepository, IColumnRepository columnRepository)
        {
            _userRepository = userRepository;
            _boardRepository = boardRepository;
            _columnRepository = columnRepository;
            _navigator = navigator;

            Column = new Column();
            User = _userRepository.CurrentUser;
            Board = _boardRepository.CurrentBoard;
            OriginalTitle = Board.Title;

            //Initialize collections
            Columns = new ObservableCollection<Column>();
            TeamUsers = new ObservableCollection<User>();

            //Initialize commands
            LoadUserCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);
            LoadColumnsCommand = new ViewModelCommand(ExecuteLoadColumnsCommand, CanExecuteLoadColumnsCommand);

            UpdateBoardCommand = new ViewModelCommand(ExecuteUpdateBoardCommand, CanExecuteUpdateBoardCommand);
            CancelUpdateBoardCommand = new ViewModelCommand(ExecuteCancelUpdateBoardCommand, CanExecuteCancelUpdateBoardCommand);
            DelBoardCommand = new ViewModelCommand(ExecuteDelBoardCommand, CanExecuteDelBoardCommand);

            AddColumnCommand = new ViewModelCommand(ExecuteAddColumnCommand, CanExecuteAddColumnCommand);
            UpdateColumnCommand = new ViewModelCommand(ExecuteUpdateColumnCommand, CanExecuteUpdateColumnCommand);

            LoadDashboardViewCommand = new ViewModelCommand(ExecuteLoadDashboardViewCommand, CanExecuteLoadDashboardViewCommand);

            //Default view
            ExecuteLoadUserCommand(null);
            ExecuteLoadColumnsCommand(null);
        }

        //Checks
        private bool CanExecuteLoadUserCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteLoadColumnsCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteUpdateBoardCommand(object obj)
        {
            return
                Board != null;
        }
        private bool CanExecuteCancelUpdateBoardCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteDelBoardCommand(object obj)
        {
            return
                Board != null;
        }
        private bool CanExecuteAddColumnCommand(object obj)
        {
            return true;
            //Column.Title != null;
        }
        private bool CanExecuteUpdateColumnCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteLoadDashboardViewCommand(object obj)
        {
            return true;
        }

        //Executes
        private void ExecuteLoadUserCommand(object obj)
        {
            User = _userRepository.CurrentUser;
            TeamUsers.Add(_userRepository.CurrentUser);
        }
        private void ExecuteLoadColumnsCommand(object obj)
        {
            Columns.Clear();
            var columnList = _columnRepository.GetColumnsByBoardID(Board.BoardID);
            Columns.Add(new Column() { BoardID = _boardRepository.CurrentBoard.BoardID, Title = "Test" });
            Columns.Add(new Column() { BoardID = _boardRepository.CurrentBoard.BoardID, Title = "Test 2" });
            Columns.Add(new Column() { BoardID = _boardRepository.CurrentBoard.BoardID, Title = "Test 3" });
            foreach (var column in columnList)
            {

                Columns.Add(column);
            }
        }
        private void ExecuteUpdateBoardCommand(object obj)
        {
            _boardRepository.UpdateBoard(Board);
        }
        private void ExecuteCancelUpdateBoardCommand(object obj)
        {
            Board.Title = OriginalTitle;
        }
        private void ExecuteDelBoardCommand(object obj)
        {
            _boardRepository.DelBoard(Board.BoardID);
            ExecuteLoadDashboardViewCommand(null);
        }
        private void ExecuteAddColumnCommand(object obj)
        {
            var _column = new Column()
            {
                BoardID = _boardRepository.CurrentBoard.BoardID,
                OrderIndex = 1,
                Title = "Test title",
                Color = "Red"
            };
            _columnRepository.AddColumn(_column);
            ExecuteLoadColumnsCommand(null);
        }
        private void ExecuteUpdateColumnCommand(object obj)
        {
            _columnRepository.UpdateColumn(Column);
        }
        private void ExecuteLoadDashboardViewCommand(object obj)
        {
            _navigator.GoTo("DashboardView.xaml");
        }
    }
}