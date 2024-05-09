using System.Windows;
using System.Windows.Controls;
using TrelloDBLayer;

namespace TrelloApp.Helpers
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
