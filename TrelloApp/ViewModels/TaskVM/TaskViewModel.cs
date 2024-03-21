using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
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

        private List<ChecklistModel> _checklists;
        public List<ChecklistModel> Checklists
        {
            get { return _checklists; }
            set
            {
                _checklists = value;
                OnPropertyChanged(nameof(Checklists));
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

        public TaskViewModel()
        {
            UpdateTaskCommand = new RelayCommand(UpdateTask, CanUpdateTask);
            LoadChecklistsCommand = new RelayCommand(() => LoadChecklists(_task.TaskID), CanLoadChecklists);
        }

        private bool CanLoadChecklists()
        {
            bool res =
                Checklists != null;

            ((RelayCommand)LoadChecklistsCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void LoadChecklists(int taskID)
        {
            try
            {
                List<Checklist> dbChecklists = _checklistRepository.GetChecklistsByTaskID(taskID);
                Checklists = dbChecklists.Select(dbChecklist => new ChecklistModel
                {
                    ChecklistID = dbChecklist.ChecklistID,
                    IsCompleted = dbChecklist.IsCompleted,
                    TaskID = dbChecklist.TaskID,
                    TaskDescription = dbChecklist.TaskDescription
                }).ToList();
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

                MessageBox.Show("Дані таску змінено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
