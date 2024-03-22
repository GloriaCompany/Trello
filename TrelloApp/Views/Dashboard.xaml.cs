using System.Globalization;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrelloApp.Views.CustomControls;
using System.Linq;

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
            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;
            if (selectedItem != null)
            {
                var resources = Application.Current.Resources;
                // Видаляємо попередні ресурси теми
                var themeResources = resources.MergedDictionaries.Where(d => d.Source != null && d.Source.ToString().Contains("/Views/ResourcesTrello/Themes/")).ToList();
                foreach (var themeResource in themeResources)
                {
                    resources.MergedDictionaries.Remove(themeResource);
                }

                var themeName = selectedItem.Content.ToString();
                if (themeName == "Light" || themeName == "Світла")
                {
                    resources.MergedDictionaries.Add(new ResourceDictionary
                    {
                        Source = new Uri("/Views/ResourcesTrello/Themes/LightTheme.xaml", UriKind.Relative)
                    });
                }
                else if (themeName == "Dark" || themeName == "Темна")
                {
                    resources.MergedDictionaries.Add(new ResourceDictionary
                    {
                        Source = new Uri("/Views/ResourcesTrello/Themes/DarkTheme.xaml", UriKind.Relative)
                    });
                }
            }
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;
            if (selectedItem != null)
            {
                var resources = Application.Current.Resources;
                // Видаляємо попередні ресурси мови
                var languageResources = resources.MergedDictionaries.Where(d => d.Source != null && d.Source.ToString().Contains("/Views/ResourcesTrello/Languages/")).ToList();
                foreach (var resource in languageResources)
                {
                    resources.MergedDictionaries.Remove(resource);
                }

                var cultureName = selectedItem.Content.ToString();
                var culture = new CultureInfo(cultureName == "UA" ? "uk-UA" : "en-US");

                // Форматування шляху до ресурсів з мовами
                var languageResourcePath = $"/TrelloApp;component/Views/ResourcesTrello/Languages/{cultureName}.xaml";

                // Завантаження ресурсів мови
                var languageResource = new ResourceDictionary
                {
                    Source = new Uri(languageResourcePath, UriKind.RelativeOrAbsolute)
                };
                resources.MergedDictionaries.Add(languageResource);
            }
        }
    }
}
