using System.Collections.ObjectModel;
using System.Windows.Input;
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

        private IColumnRepository _columnRepository;
        private ITaskRepository _taskRepository;

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
        public ICommand LoadTasksCommand { get; set; }
        public ICommand SelectTaskCommand { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand UpdateTaskCommand { get; set; }

        public ColumnViewModel(IColumnRepository columnRepository, ITaskRepository taskRepository)
        {
            _columnRepository = columnRepository;
            _taskRepository = taskRepository;

            Column = _columnRepository.CurrentColumn;

            //Initialize collections
            Tasks = new ObservableCollection<Task>();

            //Initialize commands
            UpdateColumnCommand = new ViewModelCommand(ExecuteUpdateColumnCommand, CanExecuteUpdateColumnCommand);
            LoadTasksCommand = new ViewModelCommand(ExecuteLoadTasksCommand, CanExecuteLoadTasksCommand);
            SelectTaskCommand = new ViewModelCommand(ExecuteSelectTaskCommand, CanExecuteSelectTaskCommand);
            AddTaskCommand = new ViewModelCommand(ExecuteAddTaskCommand, CanExecuteAddTaskCommand);
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
        private bool CanExecuteUpdateColumnCommand(object obj)
        {
            return
                Column != null;
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

        //Executes
        private void ExecuteUpdateColumnCommand(object obj)
        {
            _columnRepository.UpdateColumn(Column);
        }
        private void ExecuteLoadTasksCommand(object obj)
        {
            Tasks.Clear();
            var taskList = _taskRepository.GetTasksByColumnID(Column.ColumnID);
            foreach (var task in taskList)
            {
                Tasks.Add(task);
            }
        }
        private void ExecuteSelectTaskCommand(object obj)
        {
            _taskRepository.CurrentTask = Task;
        }
        private void ExecuteAddTaskCommand(object obj)
        {
            _taskRepository.AddTask(Task);
        }
        private void ExecuteUpdateTaskCommand(object obj)
        {
            _taskRepository.UpdateTask(Task);
        }
    }
}
