using System;
using System.Collections.Generic;
using System.Windows;
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

        public ColumnViewModel(ColumnModel currentColumn)
        {
            LoadTasks(currentColumn.ColumnID);
            _column = currentColumn;
        }

        public void LoadTasks(int columnID)
        {
            try
            {
                List<Task> columnTasks = _taskRepository.GetTasksByColumnID(columnID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
