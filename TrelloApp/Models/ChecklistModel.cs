using System.Collections.Generic;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class ChecklistModel
    {
        public int CheckBoxID { get; }
        public string CheckBoxName { get; set; }
        public bool IsChecked { get; set; }

        public ChecklistModel(int checkboxid, string checkboxname, bool ischecked)
        {
            CheckBoxID = checkboxid;
            CheckBoxName = checkboxname;
            IsChecked = ischecked;
        }

        #region Валідація
        private string _error;

        public string this[string columnName]
        {
            get
            {
                _error = null;
                if (columnName == nameof(CheckBoxID))
                {
                    if (CheckBoxID <= 0)
                        _error = "ID повинен бути більше за нуль";
                }
                else if (columnName == nameof(CheckBoxName))
                {
                    if (string.IsNullOrWhiteSpace(CheckBoxName))
                        _error = "Назва повинна бути вказана";
                    else if (CheckBoxName.Length < 3)
                        _error = "Мінімальна довжина назви - 3 символи";
                    else if (CheckBoxName.Length > 50)
                        _error = "Максимальна довжина назви - 50 символів";
                }
                else if (columnName == nameof(IsChecked))
                {
                    if (IsChecked != true && IsChecked != false)
                        _error = "Поле має бути типу bool";
                }
                return _error;
            }
        }

        public string Error => _error;
        #endregion
    }
}
