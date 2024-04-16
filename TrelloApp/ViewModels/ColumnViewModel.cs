using Jewelry.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.TaskVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.ColumnVM
{
    public class ColumnViewModel : ViewModelBase
    {
        //Fields
        private Column _column;
        private Task _task;
        private ObservableCollection<Task> _tasks;
        private IColumnRepository _columnRepository;
        private ITaskRepository _taskRepository;

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
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
        public IColumnRepository ColumnRepository
        {
            get => _columnRepository;
            set => _columnRepository = value;
        }
        public ITaskRepository TaskRepository
        {
            get => _taskRepository;
            set => _taskRepository = value;
        }

        //Commands
        public ICommand LoadTasksCommand { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand DelTaskCommand { get; set; }
        public ICommand UpdateTaskCommand { get; set; }

        public ColumnViewModel()
        {
            //Initialize collections
            Tasks = new ObservableCollection<Task>();

            //Initialize commands
            LoadTasksCommand = new ViewModelCommand(ExecuteLoadTasksCommand, CanExecuteLoadTasksCommand);
            AddTaskCommand = new ViewModelCommand(ExecuteAddTaskCommand, CanExecuteAddTaskCommand);
            DelTaskCommand = new ViewModelCommand(ExecuteDelTaskCommand, CanExecuteDelTaskCommand);
            UpdateTaskCommand = new ViewModelCommand(ExecuteUpdateTaskCommand, CanExecuteUpdateTaskCommand);

            //Default view
            ExecuteLoadTasksCommand(null);
        }

        //Checks
        private bool CanExecuteLoadTasksCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteAddTaskCommand(object obj)
        {
            return
                Column != null;
        }
        private bool CanExecuteDelTaskCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteUpdateTaskCommand(object obj)
        {
            return
                Task != null;
        }

        //Executes
        private void ExecuteLoadTasksCommand(object obj)
        {
            Tasks.Clear();
            var taskList = _taskRepository.GetTasksByColumnID(Column.ColumnID);
            foreach (var task in taskList)
            {
                Tasks.Add(task);
            }
        }
        private void ExecuteAddTaskCommand(object obj)
        {
            _taskRepository.AddTask(Task);
        }
        private void ExecuteDelTaskCommand(object obj)
        {
            _taskRepository.DelTask(Task.TaskID);
        }
        private void ExecuteUpdateTaskCommand(object obj)
        {
            _taskRepository.UpdateTask(Task);
        }
    }
}
