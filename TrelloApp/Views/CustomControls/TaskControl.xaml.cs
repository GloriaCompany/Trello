using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Repository;
using TrelloApp.ViewModels;
using TrelloDBLayer;

namespace TrelloApp.Views.CustomControls
{
    public partial class TaskControl : UserControl
    {
        public event EventHandler<EventArgs> ChangeColumnClicked;
        public event EventHandler<EventArgs> ChangePlaceClicked;

        public static readonly DependencyProperty AssignedUserAvatarProperty =
            DependencyProperty.Register("AssignedUserAvatar", typeof(string), typeof(TaskControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TaskNameProperty =
            DependencyProperty.Register("TaskName", typeof(string), typeof(TaskControl), new PropertyMetadata("Task Name"));

        public static readonly DependencyProperty BorderBackgroundProperty =
            DependencyProperty.Register("BorderBackground", typeof(Brush), typeof(TaskControl), new PropertyMetadata(Brushes.Transparent));

        public TaskControl()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            {
                DataContext.ToString();
                var viewModel = new ColumnViewModel(
                    FindResource("Navigation") as INavigator,
                    FindResource("UserRepository") as IUserRepository,
                    FindResource("ColumnRepository") as IColumnRepository,
                    FindResource("TaskRepository") as ITaskRepository);
                viewModel.Task = DataContext as Task;
                DataContext = viewModel;
            };
        }

        public string AssignedUserAvatar
        {
            get { return (string)GetValue(AssignedUserAvatarProperty); }
            set { SetValue(AssignedUserAvatarProperty, value); }
        }

        public string TaskName
        {
            get { return (string)GetValue(TaskNameProperty); }
            set { SetValue(TaskNameProperty, value); }
        }

        public Brush BorderBackground
        {
            get { return (Brush)GetValue(BorderBackgroundProperty); }
            set { SetValue(BorderBackgroundProperty, value); }
        }

        private void ChangePlaceButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePlaceClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ChangeColumnButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeColumnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as ColumnViewModel;
            if (viewModel != null)
            {
                var command = viewModel.LoadTaskViewCommand;
                if (command != null && command.CanExecute(null))
                {
                    command.Execute(null);
                }
            }
        }
    }
}
