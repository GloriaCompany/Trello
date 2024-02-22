using System;
using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class TaskModel
    { 
        public int TaskID { get; set; }
        public UserModel UserID { get; set; } = new UserModel();
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CheckBoxModel> CheckBoxes { get; set; } = new List<CheckBoxModel>();
    }
}
