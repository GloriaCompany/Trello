using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class BoardModel
    {
        public int BoardID { get; set; }
        public string BoardName { get; set; }
        public List<ColumnModel> Columns { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
