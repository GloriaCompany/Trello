using Jewelry.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.CheckVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.TaskVM
{
    public class TaskViewModel : ViewModelBase
    {
        //Fields
        private Task _task;
        private ObservableCollection<Checklist> _checklists;
        private ITaskRepository _taskRepository;
        private IChecklistRepository _checklistRepository;

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
        public ITaskRepository TaskRepository
        {
            get => _taskRepository;
            set => _taskRepository = value;
        }
        public IChecklistRepository ChecklistRepository
        {
            get => _checklistRepository;
            set => _checklistRepository = value;
        }

        //Commands
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand LoadChecklistsCommand { get; set; }

        public TaskViewModel()
        {
            //Initialize collecntions
            Checklists = new ObservableCollection<Checklist>();

            //Initialize commands
            UpdateTaskCommand = new ViewModelCommand(ExecuteUpdateTaskCommand, CanExecuteUpdateTaskCommand);
            LoadChecklistsCommand = new ViewModelCommand(ExecuteLoadChecklistsCommand, CanExecuteLoadChecklistsCommand);

            //Default view
            ExecuteLoadChecklistsCommand(null);
        }

        //Checks
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
