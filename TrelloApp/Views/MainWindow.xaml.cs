using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using TrelloApp.Models;
using TrelloApp.Views.CustomControls;
using TrelloApp.Views.ResourcesTrello;

namespace TrelloApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public ObservableCollection<TaskModel> ColumnTasks { get; set; }
        public ObservableCollection<ColumnModel> Columns { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Columns = new ObservableCollection<ColumnModel>();
            ColumnTasks = new ObservableCollection<TaskModel>();
            DataContext = this;
        }

        private void TeamUsersListBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UsersPopup.IsOpen = !UsersPopup.IsOpen;
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// Отримуємо обрану тему в комбобоксі
            //var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;

            //// Отримуємо поточні ресурси додатку
            //var resources = Application.Current.Resources;

            //// Задаємо завантаження ресурсів в залежності від обраного елемента
            //if (selectedItem != null && selectedItem.Content.ToString() == "Light")
            //{
            //    // Завантажуємо світлу тему
            //    resources.MergedDictionaries.Add(new ResourceDictionary 
            //    { 
            //        Source = new Uri("/Views/ResourcesTrello/Themes/LightTheme.xaml", 
            //        UriKind.Relative) 
            //    });
            //}
            //else if (selectedItem != null && selectedItem.Content.ToString() == "Dark")
            //{
            //    // Завантажуємо темну тему
            //    resources.MergedDictionaries.Add(new ResourceDictionary 
            //    { 
            //        Source = new Uri("/Views/ResourcesTrello/Themes/DarkTheme.xaml", 
            //        UriKind.Relative) 
            //    });
            //}

            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;
            if (selectedItem != null)
            {
                var themeName = selectedItem.Content.ToString();
                ThemeManager.ChangeTheme(themeName);
            }
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;
            //if (selectedItem != null)
            //{
            //    var cultureName = selectedItem.Content.ToString();
            //    var culture = new CultureInfo(cultureName == "UA" ? "uk-UA" : "en-US");

            //    // Форматування шляху до ресурсів з мовами
            //    var languageResourcePath = $"/TrelloApp;component/Views/ResourcesTrello/Languages/{cultureName}.xaml";

            //    // Завантаження ресурсів мови
            //    var languageResource = new ResourceDictionary 
            //    { 
            //        Source = new Uri(languageResourcePath, 
            //        UriKind.RelativeOrAbsolute) 
            //    };
            //    Application.Current.Resources.MergedDictionaries.Add(languageResource);
            //}

            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;
            if (selectedItem != null)
            {
                var languageCode = selectedItem.Content.ToString();
                ThemeManager.ChangeLanguage(languageCode);
            }
        }
    }
}
