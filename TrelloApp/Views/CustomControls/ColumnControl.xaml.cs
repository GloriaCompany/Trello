using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для ColumnControl.xaml
    /// </summary>
    public partial class ColumnControl : UserControl
    {
        public static readonly DependencyProperty EditIconSourceProperty = DependencyProperty.Register(
            "EditIconSource", typeof(string), typeof(ColumnControl), new PropertyMetadata(default(string)));

        public string EditIconSource
        {
            get { return (string)GetValue(EditIconSourceProperty); }
            set { SetValue(EditIconSourceProperty, value); }
        }

        public ColumnControl()
        {
            InitializeComponent();
        }
    }
}
