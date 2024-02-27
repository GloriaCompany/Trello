using System.Collections.Generic;
using System.Linq;
using TrelloApp.Models;

namespace TrelloApp.ViewModels
{
    public class CheckBoxViewModel
    {
        public List<CheckBoxItemViewModel> CheckBoxItems { get; set; }

        public CheckBoxViewModel(List<CheckBoxModel> checkBoxModels)
        {
            CheckBoxItems = checkBoxModels.Select(x => new CheckBoxItemViewModel(x)).ToList();
        }
    }

    public class CheckBoxItemViewModel
    {
        public int CheckBoxID { get; set; }
        public string CheckBoxName { get; set; }
        public bool IsChecked { get; set; }

        public CheckBoxItemViewModel(CheckBoxModel checkBoxModel)
        {
            CheckBoxID = checkBoxModel.CheckBoxID;
            CheckBoxName = checkBoxModel.CheckBoxName;
            IsChecked = checkBoxModel.IsChecked;
        }
    }
}