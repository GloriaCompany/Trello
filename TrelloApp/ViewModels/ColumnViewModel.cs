﻿using System.Collections.Generic;
using System.Linq;
using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    public class ColumnViewModel
    {
        public int ColumnID { get; set; }
        public string ColumnName { get; set; }
        public List<TaskViewModel> TaskDetails { get; set; }

        public ColumnViewModel(ColumnModel columnModel)
        {
            ColumnID = columnModel.ColumnID;
            ColumnName = columnModel.ColumnName;
        }
    }
}