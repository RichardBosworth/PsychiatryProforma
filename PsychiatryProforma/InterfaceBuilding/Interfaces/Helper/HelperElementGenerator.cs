using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;
using Syncfusion.Windows.Shared;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public static class HelperElementGenerator
    {
        public static Label GenerateLabelForElement(Element element)
        {
            Label label = new Label();
            label.Content = $"{element.Name}:";
            return label;   
        }

        public static TextBox GenerateExtraTextBox(Element element)
        {
            var textBox = new MaskedTextBox() {Width = 250, DataContext = element, Margin = new Thickness(10, 0,0,0)};
            textBox.SetBinding(MaskedTextBox.TextProperty, new Binding("ExtraText") { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
            textBox.WatermarkText = "Enter any extra details...";
            textBox.Height = 25;
            return textBox;
        }

        public static StackPanel GenerateElementStackPanel(Element element, Orientation orientation)
        {
            StackPanel stackPanel = new StackPanel() {HorizontalAlignment = HorizontalAlignment.Stretch, Margin = new Thickness(10, 0, 20, 0)};
            stackPanel.Orientation = orientation;

            stackPanel.Children.Add(GenerateLabelForElement(element));

            return stackPanel;
        }
    }
}