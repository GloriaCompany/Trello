using System;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.CheckVM;

namespace TrelloApp.ViewModels.ChecklistVM
{
    public class ChecklistViewModel : ViewModelBase
    {
        private ChecklistModel _checklist;
        public ChecklistModel Checklist
        {
            get { return _checklist; }
            set
            {
                _checklist = value;
                OnPropertyChanged(nameof(Checklist));
            }
        }

        private IChecklistRepository _checklistRepository;
        public IChecklistRepository ChecklistRepository
        {
            get { return _checklistRepository; }
            set { _checklistRepository = value; }
        }

        public ICommand LoadChecksCommand { get; set; }

        public ChecklistViewModel(ChecklistModel currentChecklist)
        {
            _checklist = currentChecklist;
            LoadChecksCommand = new RelayCommand(() => LoadChecks(_checklist.ChecklistID), CanLoadChecks);
        }

        private bool CanLoadChecks()
        {
            bool res = true;

            ((RelayCommand)LoadChecksCommand).RaiseCanExecuteChanged();

            return res;
        }
        public void LoadChecks(int chelistID)
        {
            try
            {
                //Load checks
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
