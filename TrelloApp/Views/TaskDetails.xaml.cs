using System.Globalization;
using System.Windows;
using System;
using System.Windows.Controls;
using TrelloApp.Views.CustomControls;

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
            // Отримуємо обрану тему в комбобоксі
            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;

            // Отримуємо поточні ресурси додатку
            var resources = Application.Current.Resources;

            // Задаємо завантаження ресурсів в залежності від обраного елемента
            if (selectedItem != null && selectedItem.Content.ToString() == "Light")
            {
                // Завантажуємо світлу тему
                resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("/Views/ResourcesTrello/Themes/LightTheme.xaml",
                    UriKind.Relative)
                });
            }
            else if (selectedItem != null && selectedItem.Content.ToString() == "Dark")
            {
                // Завантажуємо темну тему
                resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("/Views/ResourcesTrello/Themes/DarkTheme.xaml",
                    UriKind.Relative)
                });
            }
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;
            if (selectedItem != null)
            {
                var cultureName = selectedItem.Content.ToString();
                var culture = new CultureInfo(cultureName == "UA" ? "uk-UA" : "en-US");

                // Форматування шляху до ресурсів з мовами
                var languageResourcePath = $"/TrelloApp;component/Views/ResourcesTrello/Languages/{cultureName}.xaml";

                // Завантаження ресурсів мови
                var languageResource = new ResourceDictionary
                {
                    Source = new Uri(languageResourcePath,
                    UriKind.RelativeOrAbsolute)
                };
                Application.Current.Resources.MergedDictionaries.Add(languageResource);
            }
        }
    }
}
