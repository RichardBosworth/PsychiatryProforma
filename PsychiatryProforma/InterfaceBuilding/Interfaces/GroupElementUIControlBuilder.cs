using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class GroupElementUIControlBuilder : IElementUIControlBuilder
    {
        public FrameworkElement GenerateControl(Element element)
        {
            // Generate a stack layout control.
            var groupElement = element as GroupElement;
            var stackPanel = new StackPanel {Margin = new Thickness(10, 40, 0, 40)};
            stackPanel.DataContext = element;

            // Generate the group label.
            if (!string.IsNullOrWhiteSpace(element.Name))
            {
                var headingLabel = GenerateHeadingLabel();
                var headerStackPanel = new StackPanel {Orientation = Orientation.Horizontal};

                var checkBox = new CheckBox();
                checkBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("Enabled") {Mode = BindingMode.TwoWay});
                checkBox.VerticalAlignment = VerticalAlignment.Center;
                headerStackPanel.Children.Add(checkBox);

                headerStackPanel.Children.Add(headingLabel);
                stackPanel.Children.Add(headerStackPanel);
            }

            // Generate the sub-elements.
            var controlsPanel = new StackPanel {Margin = new Thickness(groupElement.Spacing * 0.75,groupElement.Spacing/2,0,groupElement.Spacing/2)};
            foreach (var subElement in ((GroupElement) element).SubElements)
            {
                IControlBuilderFactory controlBuilderFactory = new ControlBuilderFactory();
                var control = controlBuilderFactory.SelectFactory(subElement).GenerateControl(subElement);
                control.Margin = new Thickness(0, 5, 0, 5);
                controlsPanel.Children.Add(control);
            }
            stackPanel.Children.Add(controlsPanel);

            // Return the stack panel.
            return stackPanel;
        }

        private static Label GenerateHeadingLabel()
        {
            var headingLabel = new Label();
            headingLabel.SetBinding(ContentControl.ContentProperty, new Binding("Name") {Mode = BindingMode.OneWay, StringFormat = "{}:"});
            headingLabel.FontSize = 20;
            headingLabel.VerticalAlignment = VerticalAlignment.Center;
            return headingLabel;
        }
    }
}