using System.Collections.ObjectModel;
using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        //Fields
        private Task _task;

        private IColumnRepository _columnRepository;
        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;
        private IChecklistRepository _checklistRepository;

        private ObservableCollection<Checklist> _checklists;

        //Properties
        public Task Task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }
        public ObservableCollection<Checklist> Checklists
        {
            get => _checklists;
            set
            {
                _checklists = value;
                OnPropertyChanged(nameof(Checklists));
            }
        }

        //Commands
        public ICommand DelTaskCommand { get; set; }
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand LoadChecklistsCommand { get; set; }

        public TaskViewModel(IColumnRepository columnRepository, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _columnRepository = columnRepository;
            _taskRepository = taskRepository;
            _userRepository = userRepository;

            Task = _taskRepository.CurrentTask;

            //Initialize collecntions
            Checklists = new ObservableCollection<Checklist>();

            //Initialize commands
            DelTaskCommand = new ViewModelCommand(ExecuteDelTaskCommand, CanExecuteDelTaskCommand);
            UpdateTaskCommand = new ViewModelCommand(ExecuteUpdateTaskCommand, CanExecuteUpdateTaskCommand);
            LoadChecklistsCommand = new ViewModelCommand(ExecuteLoadChecklistsCommand, CanExecuteLoadChecklistsCommand);

            //Default view
            ExecuteLoadChecklistsCommand(null);
        }

        //Checks
        private bool CanExecuteDelTaskCommand(object obj)
        {
            return
                Task != null;
        }
        private bool CanExecuteUpdateTaskCommand(object obj)
        {
            return
                Checklists != null;
        }
        private bool CanExecuteLoadChecklistsCommand(object obj)
        {
            return
                Task != null;
        }

        //Executes
        private void ExecuteDelTaskCommand(object obj)
        {
            _taskRepository.DelTask(Task.TaskID);
        }
        private void ExecuteUpdateTaskCommand(object obj)
        {
            _taskRepository.UpdateTask(Task);
        }
        private void ExecuteLoadChecklistsCommand(object obj)
        {
            Checklists.Clear();
            var checkList = _checklistRepository.GetChecklistsByTaskID(Task.TaskID);
            foreach (var check in checkList)
            {
                Checklists.Add(check);
            }
        }
    }
}
