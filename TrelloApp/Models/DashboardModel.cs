using System;
using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class DashboardModel
    {
        public string Title { get; set; }
        public List<TaskDetailesModel> Tasks { get; set; }

        public DashboardModel()
        {
            Tasks = new List<TaskDetailesModel>();
        }
    }
}
