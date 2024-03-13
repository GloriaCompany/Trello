using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class TaskModel
    {
        
        public int? TaskID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CheckBoxModel> CheckBoxes { get; set; }

        
        public TaskModel(int userId, string title, string description, List<CheckBoxModel> checkBoxes)
        {
            UserID = userId;
            Title = title;
            Description = description;
            CheckBoxes = checkBoxes;
        }

        
        public TaskModel()
        {
            CheckBoxes = new List<CheckBoxModel>();
        }
    }
}