using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TrelloApp.Views.CustomControls
{
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
            Loaded += (sender, e) =>
            {
                SubscribeToTaskControlEvents();
            };
        }

        private void SubscribeToTaskControlEvents()
        {
            foreach (var taskControl in GetTaskControls())
            {
                taskControl.ChangePlaceClicked += TaskControl_ChangePlaceClicked;
                taskControl.ChangeColumnClicked += TaskControl_ChangeColumnClicked;
            }
        }

        private IEnumerable<TaskControl> GetTaskControls()
        {
            var taskControls = new List<TaskControl>();

            foreach (var child in ContentStackPanel.Children)
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
                MoveTaskControlInSameColumn(taskControl);
            }
        }

        private void MoveTaskControlInSameColumn(TaskControl taskControl)
        {
            // Определяем текущую колонку
            ColumnControl currentColumn = this;

            // Определяем родительский StackPanel
            StackPanel parentPanel = FindParentStackPanel(taskControl);

            // Находим индекс текущего TaskControl в StackPanel
            int currentIndex = parentPanel.Children.IndexOf(taskControl);

            // Проверяем, не является ли текущий TaskControl последним в колонке
            if (currentIndex < parentPanel.Children.Count - 1)
            {
                // Находим следующий TaskControl
                TaskControl nextTaskControl = parentPanel.Children[currentIndex + 1] as TaskControl;

                // Удаляем TaskControl из текущего места
                parentPanel.Children.Remove(taskControl);

                // Добавляем TaskControl после следующего TaskControl
                parentPanel.Children.Insert(currentIndex + 1, taskControl);
            }
            else
            {
                // Если TaskControl уже находится в конце колонки, перемещаем его в начало колонки

                // Удаляем TaskControl из текущего места
                parentPanel.Children.Remove(taskControl);

                // Добавляем TaskControl в начало колонки
                parentPanel.Children.Insert(0, taskControl);
            }
        }

        private void TaskControl_ChangeColumnClicked(object sender, EventArgs e)
        {
            if (sender is TaskControl taskControl)
            {
                MoveTaskControlToNextColumn(taskControl);
            }
        }

        private void MoveTaskControlToNextColumn(TaskControl taskControl)
        {
            // Определяем текущую колонку
            ColumnControl currentColumn = this;

            // Определяем родительский WrapPanel
            WrapPanel parentPanel = FindWrapPanel(this);

            // Находим индекс текущего ColumnControl в WrapPanel
            int currentIndex = parentPanel.Children.IndexOf(currentColumn);

            // Проверяем, не является ли текущий ColumnControl последним перед кнопкой "Добавить колонку"
            if (currentIndex < parentPanel.Children.Count - 1)
            {
                // Находим следующий ColumnControl
                ColumnControl nextColumn = parentPanel.Children[currentIndex + 1] as ColumnControl;

                // Удаляем TaskControl из текущей колонки
                ContentStackPanel.Children.Remove(taskControl);

                // Добавляем TaskControl в следующую колонку
                nextColumn.ContentStackPanel.Children.Add(taskControl);
            }
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            // Определяем текущую колонку
            ColumnControl currentColumn = this;

            // Определяем родительский WrapPanel
            WrapPanel parentPanel = FindWrapPanel(this);

            // Находим индекс текущего ColumnControl в WrapPanel
            int currentIndex = parentPanel.Children.IndexOf(currentColumn);

            // Проверяем, не является ли текущая колонка первой
            if (currentIndex > 0)
            {
                // Находим предыдущую колонку
                ColumnControl previousColumn = parentPanel.Children[currentIndex - 1] as ColumnControl;

                // Удаляем текущую колонку из WrapPanel
                parentPanel.Children.Remove(currentColumn);

                // Вставляем текущую колонку перед предыдущей
                parentPanel.Children.Insert(currentIndex - 1, currentColumn);
            }
        }

        private void MoveRightButton_Click(object sender, RoutedEventArgs e)
        {
            // Определяем текущую колонку
            ColumnControl currentColumn = this;

            // Определяем родительский WrapPanel
            WrapPanel parentPanel = FindWrapPanel(this);

            // Находим индекс текущего ColumnControl в WrapPanel
            int currentIndex = parentPanel.Children.IndexOf(currentColumn);

            // Проверяем, не является ли текущая колонка последней
            if (currentIndex < parentPanel.Children.Count - 1)
            {
                // Находим следующую колонку
                ColumnControl nextColumn = parentPanel.Children[currentIndex + 1] as ColumnControl;

                // Удаляем текущую колонку из WrapPanel
                parentPanel.Children.Remove(currentColumn);

                // Вставляем текущую колонку после следующей
                parentPanel.Children.Insert(currentIndex + 1, currentColumn);
            }
        }

        private WrapPanel FindWrapPanel(FrameworkElement element)
        {
            if (element == null)
                return null;

            if (element.Parent is WrapPanel)
                return element.Parent as WrapPanel;

            return FindWrapPanel(element.Parent as FrameworkElement);
        }

        private StackPanel FindParentStackPanel(FrameworkElement element)
        {
            if (element == null)
                return null;

            if (element.Parent is StackPanel)
                return element.Parent as StackPanel;

            return FindParentStackPanel(element.Parent as FrameworkElement);
        }
    }
}
