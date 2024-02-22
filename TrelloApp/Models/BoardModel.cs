using System;
using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class BoardModel
    {
        public int BoardID { get; set; }
        public string BoardName { get; set; }
        public List<ColumnModel> Columns { get; set; } = new List<ColumnModel>();
        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
