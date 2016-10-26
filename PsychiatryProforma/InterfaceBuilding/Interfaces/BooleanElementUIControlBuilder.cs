using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class BooleanElementUIControlBuilder : IElementUIControlBuilder
    {
        public FrameworkElement GenerateControl(Element element)
        {
            var booleanElement = element as BooleanElement;

            StackPanel stackPanel = new StackPanel() {Orientation = Orientation.Horizontal};

            var checkBox = new CheckBox() {Margin = new Thickness(10,0,0,0)};
            checkBox.DataContext = booleanElement;
            checkBox.SetBinding(ContentControl.ContentProperty, new Binding("Name"));
            checkBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("Value"));

            stackPanel.Children.Add(checkBox);
            stackPanel.Children.Add(HelperElementGenerator.GenerateExtraTextBox(element));

            return stackPanel;
        }
    }
}