using System.Collections.ObjectModel;
using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.BoardVM;
using TrelloApp.ViewModels.ColumnVM;
using TrelloApp.ViewModels.UserVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        //Fields
        private User _user;
        private Board _board;
        private Column _column;
        private ObservableCollection<Column> _columns;
        private IUserRepository _userRepository;
        private IBoardRepository _boardRepository;
        private IColumnRepository _columnRepository;

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
        public IUserRepository UserRepository
        {
            get => _userRepository;
            set => _userRepository = value;
        }
        public IBoardRepository BoardRepository
        {
            get => _boardRepository;
            set => _boardRepository = value;
        }
        public IColumnRepository ColumnRepository
        {
            get => _columnRepository;
            set => _columnRepository = value;
        }

        //Commands
        public ICommand UpdateBoardCommand { get; set; }
        public ICommand LoadUserCommand { get; set; }
        public ICommand LoadColumnsCommand { get; set; }
        public ICommand AddColumnCommand { get; set; }
        public ICommand DelColumnCommand { get; set; }
        public ICommand UpdateColumnCommand { get; set; }

        public BoardViewModel(IUserRepository userRepository)
        {
            _user = userRepository.LoggedUser;

            //Initialize collections
            Columns = new ObservableCollection<Column>();

            //Initialize commands
            UpdateBoardCommand = new ViewModelCommand(ExecuteUpdateBoardCommand, CanExecuteUpdateBoardCommand);
            LoadColumnsCommand = new ViewModelCommand(ExecuteLoadColumns, CanExecuteLoadColumnsCommand);
            AddColumnCommand = new ViewModelCommand(ExecuteAddColumn, CanExecuteAddColumnCommand);
            DelColumnCommand = new ViewModelCommand(ExecuteDelColumn, CanExecuteDelColumnCommand);
            UpdateColumnCommand = new ViewModelCommand(ExecuteUpdateColumn, CanExecuteUpdateColumnCommand);

            //Default view
            ExecuteLoadColumns(null);
        }

        //Checks
        private bool CanExecuteUpdateBoardCommand(object obj)
        {
            return
                Board != null;
        }
        private bool CanExecuteLoadColumnsCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteAddColumnCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteDelColumnCommand(object obj)
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
        private void ExecuteUpdateBoardCommand(object obj)
        {
            _boardRepository.UpdateBoard(Board);
        }
        private void ExecuteLoadColumns(object obj)
        {
            Columns.Clear();
            var columnList = _columnRepository.GetColumnsByBoardID(Board.BoardID);
            foreach (var column in columnList)
            {
                Columns.Add(column);
            }
        }
        private void ExecuteAddColumn(object obj)
        {
            _columnRepository.AddColumn(Column);
        }
        private void ExecuteDelColumn(object obj)
        {
            _columnRepository.DelColumn(Column.ColumnID);
        }
        private void ExecuteUpdateColumn(object obj)
        {
            _columnRepository.UpdateColumn(Column);
        }
    }
}