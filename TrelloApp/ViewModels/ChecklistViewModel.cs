using System.Windows.Input;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class ChecklistViewModel : ViewModelBase
    {
        //Fields
        private Checklist _checklist;
        private IChecklistRepository _checklistRepository;

        //Properties
        public Checklist Checklist
        {
            get => _checklist;
            set
            {
                _checklist = value;
                OnPropertyChanged(nameof(Checklist));
            }
        }
        public IChecklistRepository ChecklistRepository
        {
            get => _checklistRepository;
            set => _checklistRepository = value;
        }

        //Commands
        public ICommand LoadChecksCommand { get; set; }

        public ChecklistViewModel()
        {
            LoadChecksCommand = new ViewModelCommand(ExecuteLoadChecksCommand, CanExecuteLoadChecksCommand);
        }

        //Checks
        private bool CanExecuteLoadChecksCommand(object obj)
        {
            return true;
        }

        //Executes
        public void ExecuteLoadChecksCommand(object obj)
        {

        }
    }
}
