using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для SubmitChangesButton.xaml
    /// </summary>
    public partial class SubmitChangesButton : UserControl
    {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
        "ImageSource", typeof(ImageSource), typeof(SubmitChangesButton), new PropertyMetadata(default(ImageSource)));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public SubmitChangesButton()
        {
            InitializeComponent();
        }
    }
}
