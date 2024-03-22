using System.Globalization;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrelloApp.Views.CustomControls;

namespace TrelloApp.Views
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            this.PreviewMouseDown += Dashboard_PreviewMouseDown;
        }

        private void AddBoardBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            addBoardPopup.IsOpen = true;
        }

        private void AddConfirmedBoardButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BoardNameInput.Text))
            {
                // Додавання дошки
                addBoardPopup.IsOpen = false;
            }
            else
            {
                MessageBox.Show("Please enter a board name.");
            }
        }

        private void Dashboard_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseOverPopup(e))
            {
                addBoardPopup.IsOpen = false;
            }
        }

        private bool IsMouseOverPopup(MouseButtonEventArgs e)
        {
            if (addBoardPopup.IsOpen)
            {
                Point point = e.GetPosition(null);
                return addBoardPopup
                    .PlacementTarget?
                    .TransformToVisual(this)
                    .TransformBounds(addBoardPopup.PlacementRectangle)
                    .Contains(point) 
                    ?? false;
            }
            return false;
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Отримуємо обрану тему в комбобоксі
            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;

            // Отримуємо поточні ресурси додатку
            var resources = Application.Current.Resources;

            // Задаємо завантаження ресурсів в залежності від обраного елемента
            if (selectedItem != null 
                && selectedItem.Content.ToString() == "Light"
                || selectedItem.Content.ToString() == "Світла")
            {
                // Завантажуємо світлу тему
                resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("/Views/ResourcesTrello/Themes/LightTheme.xaml",
                    UriKind.Relative)
                });
            }
            else if (selectedItem != null 
                  && selectedItem.Content.ToString() == "Dark"
                  || selectedItem.Content.ToString() == "Темна")
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
