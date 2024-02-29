using System.Collections.Generic;
using System.ComponentModel;
using TrelloApp.Models;
namespace TrelloApp.ViewModels
{
    // TODO: Переделать логику

    public class TaskViewModel : INotifyPropertyChanged
    {
        private TaskModel task;

        public TaskViewModel()
        {
            task = new TaskModel();
        }

        public int TaskID
        {
            get { return task.TaskID; }
        }
        public int UserID
        {
            get { return task.UserID; }
            set { task.UserID = value; OnPropertyChanged(nameof(UserID)); }
        }
        public string Title
        {
            get { return task.Title; }
            set { task.Title = value; OnPropertyChanged(nameof(Title)); }
        }
        public string Description
        {
            get { return task.Description; }
            set { task.Description = value; OnPropertyChanged(nameof(Description)); }
        }
        public List<CheckBoxModel> CheckBoxes
        {
            get { return task.CheckBoxes; }
            set { task.CheckBoxes = value; OnPropertyChanged(nameof(CheckBoxes)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
