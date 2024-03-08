using System.Collections.Generic;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class BoardModel : Board
    {
        // TODO: New Specific Model + Validations
        public int BoardID { get; }
        public string BoardTitle { get; set; }
        public int AdminID { get; set; }
        public List<ColumnModel> Columns { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
