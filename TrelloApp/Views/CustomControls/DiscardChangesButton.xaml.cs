using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для DiscardChangesButton.xaml
    /// </summary>
    public partial class DiscardChangesButton : UserControl
    {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
        "ImageSource", typeof(ImageSource), typeof(DiscardChangesButton), new PropertyMetadata(default(ImageSource)));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public DiscardChangesButton()
        {
            InitializeComponent();
        }
    }
}
