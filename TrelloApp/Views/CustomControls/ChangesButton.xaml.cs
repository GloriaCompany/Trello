using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для ChangesButton.xaml
    /// </summary>
    public partial class ChangesButton : Button
    {
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ChangesButton), new PropertyMetadata(null));

        public ChangesButton()
        {
            InitializeComponent();
        }
    }
}
