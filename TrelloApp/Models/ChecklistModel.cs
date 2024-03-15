using System.Collections.Generic;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class ChecklistModel
    {
        // TODO: New Specific Model + Validations
        public int CheckBoxID { get; }
        public string CheckBoxName { get; set; }
        public bool IsChecked { get; set; }

        public ChecklistModel(int checkboxid, string checkboxname, bool ischecked)
        {
            CheckBoxID = checkboxid;
            CheckBoxName = checkboxname;
            IsChecked = ischecked;
        }
    }
}
