using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для CustomComboBoxItem.xaml
    /// </summary>
    public partial class CustomComboBoxItem : ComboBoxItem
    {
        public CustomComboBoxItem()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CustomComboBoxItem));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
    }
}
