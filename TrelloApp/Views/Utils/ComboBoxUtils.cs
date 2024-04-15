using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrelloApp.Views.CustomControls;

namespace TrelloApp.Views.Utils
{
    public static class ComboBoxUtils
    {
        public static void HandleSelectionChanged(object sender, SelectionChangedEventArgs e, string themesResourcePath, string languagesResourcePath)
        {
            var selectedItem = (sender as CustomComboBox)?.SelectedItem as CustomComboBoxItem;
            if (selectedItem != null)
            {
                var resources = Application.Current.Resources;

                if (!string.IsNullOrEmpty(themesResourcePath) || !string.IsNullOrEmpty(languagesResourcePath))
                {
                    var themeResources = resources.MergedDictionaries
                        .Where(d => d.Source != null &&
                                    (themesResourcePath != null && d.Source.ToString().Contains(themesResourcePath)) ||
                                    (languagesResourcePath != null && d.Source.ToString().Contains(languagesResourcePath)))
                        .ToList();
                    foreach (var themeResource in themeResources)
                    {
                        resources.MergedDictionaries.Remove(themeResource);
                    }
                }

                if (!string.IsNullOrEmpty(themesResourcePath))
                {
                    var themeName = selectedItem.Content.ToString();
                    if (themeName == "Light" || themeName == "Світла")
                    {
                        resources.MergedDictionaries.Add(new ResourceDictionary
                        {
                            Source = new Uri(themesResourcePath + "LightTheme.xaml", UriKind.Relative)
                        });
                    }
                    else if (themeName == "Dark" || themeName == "Темна")
                    {
                        resources.MergedDictionaries.Add(new ResourceDictionary
                        {
                            Source = new Uri(themesResourcePath + "DarkTheme.xaml", UriKind.Relative)
                        });
                    }
                }
                else if (!string.IsNullOrEmpty(languagesResourcePath))
                {
                    var cultureName = selectedItem.Content.ToString();
                    var culture = new CultureInfo(cultureName == "UA" ? "uk-UA" : "en-US");

                    // Завантаження ресурсів мови
                    var languageResourcePath = $"{languagesResourcePath}{cultureName}.xaml";

                    var languageResource = new ResourceDictionary
                    {
                        Source = new Uri(languageResourcePath, UriKind.RelativeOrAbsolute)
                    };
                    resources.MergedDictionaries.Add(languageResource);
                }
            }
        }
    }
}
