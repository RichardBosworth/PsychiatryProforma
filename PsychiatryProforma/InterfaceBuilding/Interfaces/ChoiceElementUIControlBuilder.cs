using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class ChoiceElementUIControlBuilder : IElementUIControlBuilder
    {
        private static FrameworkElement GenerateComboBox(ChoiceElement element)
        {
            // Generate the combo box.
            var comboBox = new ComboBox();
            comboBox.DataContext = element;

            // Add automatic choices for custom details
            var customChoice = new Choice()
                               {
                                   ExportVariations = new ExportVariations() { {""} },
                                   Name = "Custom..."
                               };
            element.Choices.Add(customChoice);

            // Generate a temporary view model from the choices.
            var temporaryChoicesList = from choice in element.Choices
                select choice.Name;


            comboBox.SetBinding(ItemsControl.ItemsSourceProperty, new Binding {Source = temporaryChoicesList});
            comboBox.SetBinding(Selector.SelectedIndexProperty, new Binding("SelectedChoiceIndex") {Mode = BindingMode.TwoWay});

            return comboBox;
        }

        public FrameworkElement GenerateControl(Element element)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };

            stackPanel.Children.Add(HelperElementGenerator.GenerateLabelForElement(element));
            stackPanel.Children.Add(GenerateComboBox(element as ChoiceElement));
            stackPanel.Children.Add(HelperElementGenerator.GenerateExtraTextBox(element));

            return stackPanel;
        }

        
    }
}