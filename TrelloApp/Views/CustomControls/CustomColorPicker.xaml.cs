using ColorPicker;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            if (colorPickerPopup.IsOpen)
            {
                colorPickerPopup.IsOpen = false;
            }
            else
            {
                colorPickerPopup.IsOpen = true;
            }
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
