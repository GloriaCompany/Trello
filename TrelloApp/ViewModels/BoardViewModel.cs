using System.Collections.ObjectModel;
using System.Windows.Input;
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

        private IUserRepository _userRepository;
        private IBoardRepository _boardRepository;
        private IColumnRepository _columnRepository;

        private ObservableCollection<Column> _columns;

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
        public ObservableCollection<Column> Columns
        {
            get => _columns;
            set
            {
                _columns = value;
                OnPropertyChanged(nameof(Columns));
            }
        }

        //Commands
        public ICommand LoadUserCommand { get; set; }
        public ICommand LoadColumnsCommand { get; set; }
        public ICommand UpdateBoardCommand { get; set; }
        public ICommand DelBoardCommand { get; set; }
        public ICommand AddColumnCommand { get; set; }
        public ICommand UpdateColumnCommand { get; set; }

        public BoardViewModel(IUserRepository userRepository, IBoardRepository boardRepository)
        {
            _userRepository = userRepository;
            _boardRepository = boardRepository;

            User = _userRepository.CurrentUser;
            Board = _boardRepository.CurrentBoard;

            //Initialize collections
            Columns = new ObservableCollection<Column>();

            //Initialize commands
            LoadUserCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);
            LoadColumnsCommand = new ViewModelCommand(ExecuteLoadColumnsCommand, CanExecuteLoadColumnsCommand);
            UpdateBoardCommand = new ViewModelCommand(ExecuteUpdateBoardCommand, CanExecuteUpdateBoardCommand);
            DelBoardCommand = new ViewModelCommand(ExecuteDelBoardCommand, CanExecuteDelBoardCommand);
            AddColumnCommand = new ViewModelCommand(ExecuteAddColumnCommand, CanExecuteAddColumnCommand);
            UpdateColumnCommand = new ViewModelCommand(ExecuteUpdateColumnCommand, CanExecuteUpdateColumnCommand);

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
        private bool CanExecuteDelBoardCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteAddColumnCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteUpdateColumnCommand(object obj)
        {
            return
                Column != null;
        }

        //Executes
        private void ExecuteLoadUserCommand(object obj)
        {
            User = _userRepository.CurrentUser;
        }
        private void ExecuteLoadColumnsCommand(object obj)
        {
            Columns.Clear();
            var columnList = _columnRepository.GetColumnsByBoardID(Board.BoardID);
            foreach (var column in columnList)
            {
                Columns.Add(column);
            }
        }
        private void ExecuteUpdateBoardCommand(object obj)
        {
            _boardRepository.UpdateBoard(Board);
        }
        private void ExecuteDelBoardCommand(object obj)
        {
            _columnRepository.DelColumn(Column.ColumnID);
        }
        private void ExecuteAddColumnCommand(object obj)
        {
            _columnRepository.AddColumn(Column);
        }
        private void ExecuteUpdateColumnCommand(object obj)
        {
            _columnRepository.UpdateColumn(Column);
        }
    }
}