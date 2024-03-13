using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.BoardVM;
using TrelloApp.ViewModels.ColumnVM;
using TrelloApp.ViewModels.UserVM;
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

        private Column _column;
        public Column Column
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

        public ICommand UpdateBoardCommand { get; set; }
        public ICommand LoadUserCommand { get; set; }
        public ICommand LoadColumnsCommand { get; set; }
        public ICommand AddColumnCommand { get; set; }
        public ICommand DelColumnCommand { get; set; }
        public ICommand UpdateColumnCommand { get; set; }

        public BoardViewModel(UserModel currentUser, BoardModel currentBoard)
        {
            _user = currentUser;
            _board = currentBoard;
            UpdateBoardCommand = new RelayCommand(UpdateBoard, CanUpdateBoard);
            LoadUserCommand = new RelayCommand(() => LoadUser(_user.UserID), CanLoadUser);
            LoadColumnsCommand = new RelayCommand(() => LoadColumns(_user.UserID), CanLoadColumns);
            AddColumnCommand = new RelayCommand(AddColumn, CanAddColumn);
            DelColumnCommand = new RelayCommand(() => DelColumn(Column.ColumnID), CanDelColumn);
            UpdateColumnCommand = new RelayCommand(UpdateColumn, CanUpdateColumn);
        }

        private bool CanUpdateBoard()
        {
            bool res =
                Board != null;

            ((RelayCommand)UpdateBoardCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void UpdateBoard()
        {
            try
            {
                if (!CanUpdateBoard())
                {
                    MessageBox.Show("Перевірте правильність введених даних, будь-ласка.");
                    return;
                }

                _boardRepository.UpdateBoard(Board);

                MessageBox.Show("Дані дошки змінено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private bool CanLoadColumns()
        {
            bool res =
                Column != null;

            ((RelayCommand)LoadColumnsCommand).RaiseCanExecuteChanged();

            return res;
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

        private bool CanAddColumn()
        {
            bool res =
                Column != null;

            ((RelayCommand)UpdateBoardCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void AddColumn()
        {
            try
            {
                Column newColumn = new Column();
                _columnRepository.AddColumn(newColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanDelColumn()
        {
            bool res =
                Column != null;

            ((RelayCommand)UpdateBoardCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void DelColumn(int columnID)
        {
            try
            {
                _columnRepository.DelColumn(columnID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanUpdateColumn()
        {
            bool res =
                Column != null;

            ((RelayCommand)UpdateBoardCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void UpdateColumn()
        {
            try
            {
                if (!CanUpdateBoard())
                {
                    MessageBox.Show("Перевірте правильність введених даних, будь-ласка.");
                    return;
                }

                _columnRepository.UpdateColumn(Column);

                MessageBox.Show("Дані дошки змінено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
