using System.Collections.Generic;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class BoardModel : Board
    {
        // TODO: New Specific Model + Validations
        public string BoardTitle { get; set; }
        public List<ColumnModel> Columns { get; set; }
        public List<UserModel> Users { get; set; }

        public BoardModel(string boardtitle, List<ColumnModel> colums, List<UserModel> users)
        {
            BoardTitle = boardtitle;
            Columns = colums;
            Users = users;
        }
    }
}
