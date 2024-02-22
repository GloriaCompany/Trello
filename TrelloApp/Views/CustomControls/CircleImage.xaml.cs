using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для CircleImage.xaml
    /// </summary>
    public partial class CircleImage : UserControl
    {
        public CircleImage()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CircleImage), new PropertyMetadata(null, ImageSourceChanged));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        private static void ImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CircleImage;
            control?.UpdateImageSource(e.NewValue as ImageSource);
        }

        private void UpdateImageSource(ImageSource source)
        {
            imageBrush.ImageSource = source;
        }
    }
}
