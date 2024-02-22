using ColorPicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для CustomColorPicker.xaml
    /// </summary>
    public partial class CustomColorPicker : UserControl
    {
        public CustomColorPicker()
        {
            InitializeComponent();
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            Picker.Visibility = Visibility.Visible;
        }

        private void Picker_ColorChanged(object sender, RoutedEventArgs e)
        {
            var colorPicker = sender as StandardColorPicker;
            if (colorPicker != null)
            {
                var selectedColor = colorPicker.SelectedColor;
                colorRectangle.Fill = new SolidColorBrush(selectedColor);
                hexTextBlock.Text = $"#{selectedColor.R:X2}{selectedColor.G:X2}{selectedColor.B:X2}";
            }
        }
    }
}
