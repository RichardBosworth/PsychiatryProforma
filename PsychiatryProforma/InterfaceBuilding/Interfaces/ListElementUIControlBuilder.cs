using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class ListElementUIControlBuilder : IElementUIControlBuilder
    {
        public FrameworkElement GenerateControl(Element element)
        {
            var listElement = element as ListElement;

            var stackPanel = HelperElementGenerator.GenerateElementStackPanel(listElement, Orientation.Vertical);

            var textBox = new TextBox
            {
                DataContext = listElement,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true
            };
            textBox.SpellCheck.IsEnabled = true;
            textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBox.SetBinding(TextBox.TextProperty, new Binding("ListText") {Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
            textBox.MinHeight = 25;
            stackPanel.Children.Add(textBox);

            return stackPanel;
        }
    }
}