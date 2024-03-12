using System;
using System.Windows;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.CheckVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.TaskVM
{
    public class TaskViewModel : ViewModelBase
    {
        private TaskModel _task;
        public TaskModel Task
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

        public TaskViewModel(TaskModel currentTask)
        {
            LoadChecklists(currentTask.TaskID);
            _task = currentTask;
        }

        public void LoadChecklists(int taskID)
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
    }
}
