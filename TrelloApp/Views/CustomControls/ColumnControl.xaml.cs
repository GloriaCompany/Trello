using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TrelloApp.Models;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.Views.CustomControls
{
    public partial class ColumnControl : UserControl
    {
        public static readonly DependencyProperty EditIconSourceProperty = DependencyProperty.Register(
            "EditIconSource", typeof(string), typeof(ColumnControl), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(ObservableCollection<TaskModel>), typeof(ColumnControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ColumnNameProperty =
            DependencyProperty.Register("ColumnName", typeof(string), typeof(ColumnControl), new PropertyMetadata("Column Name"));

        public string EditIconSource
        {
            get { return (string)GetValue(EditIconSourceProperty); }
            set { SetValue(EditIconSourceProperty, value); }
        }

        /*public ObservableCollection<Task> Tasks
        {
            get { return (ObservableCollection<Task>)GetValue(TasksProperty); }
            set { SetValue(TasksProperty, value); }
        }*/

        public string ColumnName
        {
            get { return (string)GetValue(ColumnNameProperty); }
            set { SetValue(ColumnNameProperty, value); }
        }

        public ColumnControl()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            {
                SubscribeToTaskControlEvents();

                DataContext.ToString();
                var viewModel = new ColumnViewModel(
                    FindResource("ColumnRepository") as IColumnRepository,
                    FindResource("TaskRepository") as ITaskRepository);
                viewModel.Column = DataContext as Column;
                DataContext = viewModel;
            };
        }

        private void SubscribeToTaskControlEvents()
        {
            foreach (var taskControl in GetTaskControls())
            {
                taskControl.ChangePlaceClicked += TaskControl_ChangePlaceClicked; // Подія зміни місця
                taskControl.ChangeColumnClicked += TaskControl_ChangeColumnClicked; // Подія зміни стовпця
            }
        }

        private IEnumerable<TaskControl> GetTaskControls()
        {
            var taskControls = new List<TaskControl>();

            // Отримання списку контролів задач
            foreach (var child in ContentStackPanel.Items)
            {
                if (child is TaskControl taskControl)
                {
                    taskControls.Add(taskControl);
                }
            }

            return taskControls;
        }

        private void TaskControl_ChangePlaceClicked(object sender, EventArgs e)
        {
            if (sender is TaskControl taskControl)
            {
                MoveTaskControlInSameColumn(sender, taskControl); // Переміщення задачі в тому ж самому стовпці
            }
        }

        private void MoveTaskControlInSameColumn(object sender, TaskControl taskControl)
        {
            // Визначення поточного стовпця
            var currentColumn = (sender as FrameworkElement).DataContext as Column;

            // Визначення батьківського StackPanel
            ListView parentPanel = FindListControl(taskControl);
            var list = parentPanel.ItemsSource as IList<Task>;
            // Отримання індексу поточного контролю задачі в StackPanel
            Task task = taskControl.DataContext as Task;
            int currentIndex = list.IndexOf(task);

            // Перевірка, чи поточний контроль задачі не є останнім у стовпці
            if (currentIndex < list.Count - 1)
            {
                // Знаходження наступного контролю задачі
                Task nextTaskControl = list[currentIndex + 1] as Task;

                // Видалення поточного контролю задачі з поточного місця
                list.Remove(task);

                // Додавання контролю задачі після наступного контролю задачі
                list.Insert(currentIndex + 1, task);
            }
            else
            {
                // Якщо контроль задачі вже знаходиться в кінці стовпця, перемістіть його на початок стовпця

                // Видалення поточного контролю задачі з поточного місця
                list.Remove(task);

                // Додавання контролю задачі на початок стовпця
                list.Insert(0, task);
            }
        }

        private void TaskControl_ChangeColumnClicked(object sender, EventArgs e)
        {
            if (sender is TaskControl taskControl)
            {
                MoveTaskControlToNextColumn(sender, taskControl); // Переміщення задачі в наступний стовпець
            }
        }

        private void MoveTaskControlToNextColumn(object sender, TaskControl taskControl)
        {
            // Визначення поточного стовпця
            //   var currentColumn = (sender as FrameworkElement).DataContext as Column;

            // Визначення батьківського StackPanel
            ListView parentPanel = FindListControl(taskControl);
            var list = parentPanel.ItemsSource as IList<Task>;
            // Отримання індексу поточного контролю задачі в StackPanel
            Task task = taskControl.DataContext as Task;
            int currentIndex = list.IndexOf(task);

            // Перевірка, чи поточний контроль задачі не є останнім у стовпці
            if (currentIndex < list.Count - 1)
            {
                // Знаходження наступного стовпця
                //var nextColumn = list[currentIndex + 1];

                // Видалення поточного контролю задачі з поточного місця
                list.Remove(task);

                // Додавання контролю задачі після наступного контролю задачі
                ItemsControl grandParentItemsControl = FindControl(parentPanel);
                int index = (grandParentItemsControl.ItemsSource as IList<Column>).IndexOf((parentPanel.DataContext as ColumnViewModel).Column);
                (grandParentItemsControl.ItemsSource as IList<Column>)[index + 1].Task.Insert(0, task);
            }
            else
            {
                // Якщо контроль задачі вже знаходиться в кінці стовпця, перемістіть його на початок стовпця

                // Видалення поточного контролю задачі з поточного місця
                list.Remove(task);

                // Додавання контролю задачі на початок стовпця
                list.Insert(0, task);
            }
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            // Визначення поточного стовпця
            ColumnControl currentColumn = this;

            // Визначення батьківського WrapPanel
            Panel parentPanel = FindWrapPanel(this);

            // Отримання індексу поточного ColumnControl в WrapPanel
            int currentIndex = parentPanel.Children.IndexOf(currentColumn);

            // Перевірка, чи поточний стовпець не є першим
            if (currentIndex > 0)
            {
                // Знаходження попереднього стовпця
                ColumnControl previousColumn = parentPanel.Children[currentIndex - 1] as ColumnControl;

                // Видалення поточного стовпця з WrapPanel
                parentPanel.Children.Remove(currentColumn);

                // Вставка поточного стовпця перед попереднім
                parentPanel.Children.Insert(currentIndex - 1, currentColumn);
            }
        }

        private void MoveRightButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsControl itemsControl = FindControl/*<ItemsControl>*/(this);
            var currentColumn = (sender as FrameworkElement).DataContext as Column;
            var list = itemsControl.ItemsSource as IList<Column>;
            // Отримання індексу поточного ColumnControl в WrapPanel
            int currentIndex = list.IndexOf(currentColumn);

            // Перевірка, чи поточний стовпець не є останнім
            if (currentIndex < list.Count - 1)
            {
                // Знаходження наступного стовпця
                var nextColumn = list[currentIndex + 1];

                // Видалення поточного стовпця з WrapPanel
                list.Remove(currentColumn);

                // Вставка поточного стовпця після наступного
                list.Insert(currentIndex + 1, currentColumn);
            }
            return;
            // Визначення поточного стовпця
            /*ColumnControl currentColumn = this;

            // Визначення батьківського WrapPanel
            Panel parentPanel = FindWrapPanel(this);

            // Отримання індексу поточного ColumnControl в WrapPanel
            int currentIndex = parentPanel.Children.IndexOf(currentColumn);

            // Перевірка, чи поточний стовпець не є останнім
            if (currentIndex < parentPanel.Children.Count - 1)
            {
                // Знаходження наступного стовпця
                ColumnControl nextColumn = parentPanel.Children[currentIndex + 1] as ColumnControl;

                // Видалення поточного стовпця з WrapPanel
                parentPanel.Children.Remove(currentColumn);

                // Вставка поточного стовпця після наступного
                parentPanel.Children.Insert(currentIndex + 1, currentColumn);
            }*/
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            addTaskPopup.IsOpen = true;
        }

        private void AddConfirmedTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskNameInput.Text))
            {
                // Додавання таску до колонки
                addTaskPopup.IsOpen = false;
            }
            else
            {
                MessageBox.Show("Please enter a task name.");
            }
        }

        private ListView FindListControl(DependencyObject element)
        {
            if (element == null)
                return null;
            if (VisualTreeHelper.GetParent(element) is ListView)
                return VisualTreeHelper.GetParent(element) as ListView;

            return FindListControl(VisualTreeHelper.GetParent(element));
        }

        private ItemsControl FindControl(DependencyObject element)
        {
            if (element == null)
                return null;
            if (VisualTreeHelper.GetParent(element) is ItemsControl)
                return VisualTreeHelper.GetParent(element) as ItemsControl;

            return FindControl(VisualTreeHelper.GetParent(element));
        }

        private Panel FindWrapPanel(FrameworkElement element)
        {
            if (element == null)
                return null;
            if (VisualTreeHelper.GetParent(element) is Panel)
                return VisualTreeHelper.GetParent(element) as Panel;

            return FindWrapPanel(VisualTreeHelper.GetParent(element) as FrameworkElement);
        }

        private StackPanel FindParentStackPanel(FrameworkElement element)
        {
            if (element == null)
                return null;

            if (element.Parent is StackPanel)
                return element.Parent as StackPanel;

            return FindParentStackPanel(element.Parent as FrameworkElement);
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseOverPopup(e))
            {
                addTaskPopup.IsOpen = false;
            }
        }

        private bool IsMouseOverPopup(MouseButtonEventArgs e)
        {
            if (addTaskPopup.IsOpen)
            {
                Point point = e.GetPosition(null);
                DependencyObject dependencyObject = VisualTreeHelper.HitTest(Application.Current.MainWindow, point)?.VisualHit;

                while (dependencyObject != null && dependencyObject != addTaskPopup)
                {
                    dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
                }

                return dependencyObject != null;
            }
            return false;
        }

        private void TaskControl_ChangeColumnClicked_1(object sender, EventArgs e)
        {

        }
    }
}
