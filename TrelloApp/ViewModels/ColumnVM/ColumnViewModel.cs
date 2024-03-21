using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.TaskVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.ColumnVM
{
    public class ColumnViewModel : ViewModelBase
    {
        private ColumnModel _column;
        public ColumnModel Column
        {
            get { return _column; }
            set
            {
                _column = value;
                OnPropertyChanged(nameof(Column));
            }
        }

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

        private List<TaskModel> _tasks;
        public List<TaskModel> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        private IColumnRepository _columnRepository;
        public IColumnRepository ColumnRepository
        {
            get { return _columnRepository; }
            set { _columnRepository = value; }
        }

        private ITaskRepository _taskRepository;
        public ITaskRepository TaskRepository
        {
            get { return _taskRepository; }
            set { _taskRepository = value; }
        }

        public ICommand LoadTasksCommand { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand DelTaskCommand { get; set; }
        public ICommand UpdateTaskCommand { get; set; }

        public ColumnViewModel()
        {
            LoadTasksCommand = new RelayCommand(() => LoadTasks(Column.ColumnID), CanLoadTasks);
            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
            DelTaskCommand = new RelayCommand(() => DelTask(Task.TaskID), CanDelTask);
            UpdateTaskCommand = new RelayCommand(UpdateTask, CanUpdateTask);
        }

        private bool CanLoadTasks()
        {
            bool res =
               Task != null;

            ((RelayCommand)LoadTasksCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void LoadTasks(int columnID)
        {
            try
            {
                List<Task> dbTasks = _taskRepository.GetTasksByColumnID(columnID);
                Tasks = dbTasks.Select(dbTask => new TaskModel
                {
                    TaskID = dbTask.TaskID,
                    Title = dbTask.Title,
                    Description = dbTask.Description,
                    AssignedUserID = dbTask.AssignedUserID
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanAddTask()
        {
            bool res =
                Column != null;

            ((RelayCommand)AddTaskCommand).RaiseCanExecuteChanged();

            return res;
        }

        private void AddTask()
        {
            try
            {
                _taskRepository.AddTask(Task);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanDelTask()
        {
            bool res =
                Task != null;

            ((RelayCommand)DelTaskCommand).RaiseCanExecuteChanged();

            return res;
        }
        private void DelTask(int taskID)
        {
            try
            {
                _taskRepository.DelTask(taskID);
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
