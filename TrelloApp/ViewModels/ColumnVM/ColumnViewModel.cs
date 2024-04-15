using Jewelry.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            LoadTasksCommand = new ViewModelCommand(ExecuteLoadTasksCommand, CanExecuteLoadTasksCommand);
            AddTaskCommand = new ViewModelCommand(ExecuteAddTaskCommand, CanExecuteAddTaskCommand);
            DelTaskCommand = new ViewModelCommand(ExecuteDelTaskCommand, CanExecuteDelTaskCommand);
            UpdateTaskCommand = new ViewModelCommand(ExecuteUpdateTaskCommand, CanExecuteUpdateTaskCommand);
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
           
        }
        private void ExecuteAddTaskCommand(object obj)
        {
           
        }
        private void ExecuteDelTaskCommand(object obj)
        {
            
        }
        private void ExecuteUpdateTaskCommand(object obj)
        {
           
        }
    }
}
