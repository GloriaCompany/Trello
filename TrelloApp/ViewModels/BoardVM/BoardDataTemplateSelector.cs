using System.Windows.Controls;
using System.Windows;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.BoardVM
{
    public class BoardDataTemplateSelector : DataTemplateSelector
    {
        private const string PlaceHolderTitle = "Placeholder";

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return (item as Board).Title == PlaceHolderTitle 
                ? (container as FrameworkElement).FindResource("BoardPlaceholder") as DataTemplate
                : (container as FrameworkElement).FindResource("RealBoard") as DataTemplate;
        }
    }
}
