using System.ComponentModel;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class ChecklistModel : Checklist, IDataErrorInfo
    {
        private string _error;

        public string this[string columnName]
        {
            get
            {
                _error = null;

                if (columnName == nameof(TaskDescription))
                {
                    if (string.IsNullOrWhiteSpace(TaskDescription))
                        _error = "Назва повинна бути вказана";
                    if (TaskDescription.Length < 3)
                        _error = "Мінімальна довжина назви - 3 символи";
                    if (TaskDescription.Length > 50)
                        _error = "Максимальна довжина назви - 50 символів";
                }

                return _error;
            }
        }
        public string Error => _error;
    }
}