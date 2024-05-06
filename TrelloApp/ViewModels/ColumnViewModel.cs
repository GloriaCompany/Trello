using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class ColumnViewModel : ViewModelBase
    {
        //Fields
        private Column _column;
        private Task _task;
        private User _user;

        private IColumnRepository _columnRepository;
        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;
        private INavigator _navigator;

        private ObservableCollection<Task> _tasks;

        //Properties
        public Column Column
        {
            get => _column;
            set
            {
                _column = value;
                OnPropertyChanged(nameof(Column));
            }
        }
        public Task Task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
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
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        //Commands
        public ICommand UpdateColumnCommand { get; set; }
        public ICommand DelColumnCommand { get; set; }
        public ICommand LoadTasksCommand { get; set; }
        public ICommand SelectTaskCommand { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand DelTaskCommand { get; set; }

        public ICommand LoadTaskViewCommand { get; set; }
        public ICommand LoadBoardViewCommand { get; set; }

        public ColumnViewModel(INavigator navigator, Column currentColumn, IUserRepository userRepository, IColumnRepository columnRepository, ITaskRepository taskRepository)
        {
            _columnRepository = columnRepository;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _navigator = navigator;

            Task = new Task();
            Column = currentColumn;
            User = _userRepository.CurrentUser;

            //Initialize collections
            Tasks = new ObservableCollection<Task>();

            //Initialize commands
            UpdateColumnCommand = new ViewModelCommand(ExecuteUpdateColumnCommand, CanExecuteUpdateColumnCommand);
            DelColumnCommand = new ViewModelCommand(ExecuteDelColumnCommand, CanExecuteDelColumnCommand);
            LoadTasksCommand = new ViewModelCommand(ExecuteLoadTasksCommand, CanExecuteLoadTasksCommand);
            SelectTaskCommand = new ViewModelCommand(ExecuteSelectTaskCommand, CanExecuteSelectTaskCommand);
            AddTaskCommand = new ViewModelCommand(ExecuteAddTaskCommand, CanExecuteAddTaskCommand);
            UpdateTaskCommand = new ViewModelCommand(ExecuteUpdateTaskCommand, CanExecuteUpdateTaskCommand);
            DelTaskCommand = new ViewModelCommand(ExecuteDelTaskCommand, CanExecuteDelTaskCommand);

            LoadTaskViewCommand = new ViewModelCommand(ExecuteLoadTaskViewCommand, CanExecuteLoadTaskViewCommand);
            LoadBoardViewCommand = new ViewModelCommand(ExecuteLoadBoardViewCommand, CanExecuteLoadBoardViewCommand);

            //Default view
            ExecuteLoadTasksCommand(null);
        }

        //Checks
        private bool CanExecuteLoadTasksCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteUpdateColumnCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteDelColumnCommand(object obj)
        {
            return true;
            //Column != null;
        }
        private bool CanExecuteSelectTaskCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteAddTaskCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteUpdateTaskCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteDelTaskCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteLoadTaskViewCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteLoadBoardViewCommand(object obj)
        {
            return true;
        }

        //Executes
        private void ExecuteUpdateColumnCommand(object obj)
        {
            _columnRepository.UpdateColumn(Column);
        }
        private void ExecuteDelColumnCommand(object obj)
        {
            _columnRepository.DelColumn(Column.ColumnID);
            ExecuteLoadBoardViewCommand(null);
        }
        private void ExecuteLoadTasksCommand(object obj)
        {
            Tasks.Clear();
            var taskList = _taskRepository.GetTasksByColumnID(Column.ColumnID);
            //var taskList = new List<Task>();

            /*For testing*/
            //for (int i = 1; i < 4; i++)
            //{
            //    taskList.Add(new Task { Title = "Title" + i.ToString() });
            //}

            foreach (var task in taskList)
            {
                Tasks.Add(task);
            }
        }
        private void ExecuteLoadBoardViewCommand(object obj)
        {
            _navigator.GoTo("BoardView.xaml");
        }
        private void ExecuteSelectTaskCommand(object obj)
        {
            _taskRepository.CurrentTask = Task;
        }
        private void ExecuteAddTaskCommand(object obj)
        {
            var _task = new Task
            {
                Color = "Red",
                Title = "Title",
                Column = Column,
                Checklist = null,
                ColumnID = Column.ColumnID,
                User = User,
                Description = "Description",
            };
            _taskRepository.AddTask(_task);
            ExecuteLoadTasksCommand(null);
        }
        private void ExecuteUpdateTaskCommand(object obj)
        {
            _taskRepository.UpdateTask(Task);
        }
        private void ExecuteDelTaskCommand(object obj)
        {
            _taskRepository.DelTask(Task.TaskID);
        }
        private void ExecuteLoadTaskViewCommand(object obj)
        {
            _taskRepository.CurrentTask = Task;
            _navigator.GoTo("TaskView.xaml");
        }
    }
}
