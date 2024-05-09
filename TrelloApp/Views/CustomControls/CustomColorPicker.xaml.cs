using ColorPicker;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    public partial class CustomColorPicker : UserControl
    {
        public CustomColorPicker()
        {
            InitializeComponent();
        }

        // Зависимое свойство для биндинга цвета в формате HEX строки
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(string), typeof(CustomColorPicker), new PropertyMetadata("#FFFFFF", OnSelectedColorChanged));

        // Свойство CLR-обертка для SelectedColorProperty
        public string SelectedColor
        {
            get { return (string)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        // Обработчик изменения SelectedColor
        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = (CustomColorPicker)d;
            if (picker != null && e.NewValue is string hexColor)
            {
                picker.colorRectangle.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexColor));
                picker.hexTextBlock.Text = hexColor;
            }
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            colorPickerPopup.IsOpen = !colorPickerPopup.IsOpen;
        }

        private void Picker_ColorChanged(object sender, RoutedEventArgs e)
        {
            if (sender is StandardColorPicker colorPicker)
            {
                SelectedColor = ColorToHex(colorPicker.SelectedColor);
            }
        }

        // Метод для преобразования Color в HEX строку
        private string ColorToHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}
