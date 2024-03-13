using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TrelloApp.Views.CustomControls
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return DependencyProperty.UnsetValue;

            string text = (string)value;
            bool isEmpty = string.IsNullOrEmpty(text);

            if (parameter != null && parameter.ToString() == "Inverse")
                isEmpty = !isEmpty;

            return isEmpty ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility))
                return DependencyProperty.UnsetValue;

            Visibility visibility = (Visibility)value;

            return visibility == Visibility.Visible;
        }
    }

}
