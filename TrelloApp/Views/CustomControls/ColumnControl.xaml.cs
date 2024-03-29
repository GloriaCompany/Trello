﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TrelloApp.Models;

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

        public ObservableCollection<TaskModel> Tasks
        {
            get { return (ObservableCollection<TaskModel>)GetValue(TasksProperty); }
            set { SetValue(TasksProperty, value); }
        }

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
                MoveTaskControlInSameColumn(taskControl); // Переміщення задачі в тому ж самому стовпці
            }
        }

        private void MoveTaskControlInSameColumn(TaskControl taskControl)
        {
            // Визначення поточного стовпця
            ColumnControl currentColumn = this;

            // Визначення батьківського StackPanel
            StackPanel parentPanel = FindParentStackPanel(taskControl);

            // Отримання індексу поточного контролю задачі в StackPanel
            int currentIndex = parentPanel.Children.IndexOf(taskControl);

            // Перевірка, чи поточний контроль задачі не є останнім у стовпці
            if (currentIndex < parentPanel.Children.Count - 1)
            {
                // Знаходження наступного контролю задачі
                TaskControl nextTaskControl = parentPanel.Children[currentIndex + 1] as TaskControl;

                // Видалення поточного контролю задачі з поточного місця
                parentPanel.Children.Remove(taskControl);

                // Додавання контролю задачі після наступного контролю задачі
                parentPanel.Children.Insert(currentIndex + 1, taskControl);
            }
            else
            {
                // Якщо контроль задачі вже знаходиться в кінці стовпця, перемістіть його на початок стовпця

                // Видалення поточного контролю задачі з поточного місця
                parentPanel.Children.Remove(taskControl);

                // Додавання контролю задачі на початок стовпця
                parentPanel.Children.Insert(0, taskControl);
            }
        }

        private void TaskControl_ChangeColumnClicked(object sender, EventArgs e)
        {
            if (sender is TaskControl taskControl)
            {
                MoveTaskControlToNextColumn(taskControl); // Переміщення задачі в наступний стовпець
            }
        }

        private void MoveTaskControlToNextColumn(TaskControl taskControl)
        {
            // Визначення поточного стовпця
            ColumnControl currentColumn = this;

            // Визначення батьківського WrapPanel
            WrapPanel parentPanel = FindWrapPanel(this);

            // Отримання індексу поточного ColumnControl в WrapPanel
            int currentIndex = parentPanel.Children.IndexOf(currentColumn);

            // Перевірка, чи поточний ColumnControl не є останнім перед кнопкою "Додати стовпець"
            if (currentIndex < parentPanel.Children.Count - 1)
            {
                // Знаходження наступного ColumnControl
                ColumnControl nextColumn = parentPanel.Children[currentIndex + 1] as ColumnControl;

                // Видалення задачі з поточного стовпця
                ContentStackPanel.Children.Remove(taskControl);

                // Додавання задачі в наступний стовпець
                nextColumn.ContentStackPanel.Children.Add(taskControl);
            }
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            // Визначення поточного стовпця
            ColumnControl currentColumn = this;

            // Визначення батьківського WrapPanel
            WrapPanel parentPanel = FindWrapPanel(this);

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
            // Визначення поточного стовпця
            ColumnControl currentColumn = this;

            // Визначення батьківського WrapPanel
            WrapPanel parentPanel = FindWrapPanel(this);

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
            }
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
    }
}
