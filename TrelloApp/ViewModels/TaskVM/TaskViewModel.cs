using System;
using System.Windows;
using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.CheckVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.TaskVM
{
    public class TaskViewModel : ViewModelBase
    {
        private Task _task;
        public Task Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }

        private Checklist _checklist; //ChecklistModel
        public Checklist Checklist
        {
            get { return _checklist; }
            set
            {
                _checklist = value;
                OnPropertyChanged(nameof(Checklist));
            }
        }

        private ITaskRepository _taskRepository;
        public ITaskRepository TaskRepository
        {
            get { return _taskRepository; }
            set { _taskRepository = value; }
        }

        private IChecklistRepository _checklistRepository;
        public IChecklistRepository ChecklistRepository
        {
            get { return _checklistRepository; }
            set { _checklistRepository = value; }
        }

        public ICommand UpdateTaskCommand { get; set; }
        public ICommand LoadChecklistsCommand { get; set; }

        public TaskViewModel(Task currentTask)
        {
            _task = currentTask;
            UpdateTaskCommand = new RelayCommand(UpdateTask, CanUpdateTask);
            LoadChecklistsCommand = new RelayCommand(() => LoadChecklists(_task.TaskID), CanLoadChecklists);
        }

        private bool CanLoadChecklists()
        {
            bool res =
                Checklist != null;

            ((RelayCommand)LoadChecklistsCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void LoadChecklists(int taskID)
        {
            try
            {
                Checklist taskChecklist = _checklistRepository.GetChecklistByTaskID(taskID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanUpdateTask()
        {
            bool res =
                Task != null;

            ((RelayCommand)UpdateTaskCommand).RaiseCanExecuteChanged();

            return res;

        }
        private void UpdateTask()
        {
            try
            {
                if (!CanUpdateTask())
                {
                    MessageBox.Show("Перевірте правильність введених даних, будь-ласка.");
                    return;
                }

                _taskRepository.UpdateTask(Task);

                MessageBox.Show("Дані дошки змінено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
