using System;
using System.Windows;
using System.Windows.Controls;

namespace TrelloApp.Views.CustomControls
{
    public partial class TaskControl : UserControl
    {
        public event EventHandler<EventArgs> ChangeColumnClicked;
        public event EventHandler<EventArgs> ChangePlaceClicked;

        public TaskControl()
        {
            InitializeComponent();
        }

        private void ChangePlaceButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePlaceClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ChangeColumnButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeColumnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
