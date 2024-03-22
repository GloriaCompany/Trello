using System.Globalization;
using System.Windows;
using System;
using System.Windows.Controls;
using TrelloApp.Views.CustomControls;
using System.Linq;
using TrelloApp.Views.Utils;

namespace TrelloApp.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskDetails.xaml
    /// </summary>
    public partial class TaskDetails : Page
    {
        public TaskDetails()
        {
            InitializeComponent();
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }
    }
}
