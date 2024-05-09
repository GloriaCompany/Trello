using System.ComponentModel;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class BoardModel : Board, IDataErrorInfo
    {
        private string _error;

        public string this[string columnName]
        {
            get
            {
                _error = null;

                if (columnName == nameof(Title))
                {
                    if (string.IsNullOrWhiteSpace(Title))
                        _error = "Назва дошки є обов'язковою";
                    else if (Title.Length > 100)
                        _error = "Максимальна довжина назви дошки - 100 символів";
                    else if (Title.Length < 3)
                        _error = "Мінімальна довжина назви дошки - 3 символи";
                }

                return _error;
            }
        }

        public string Error => _error;
    }
}