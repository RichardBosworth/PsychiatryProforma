using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;
using Syncfusion.Windows.Shared;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class LabResultElementUIControlBuilder : IElementUIControlBuilder
    {
        public FrameworkElement GenerateControl(Element element)
        {
            var labResultElement = element as LabResultElement;

            var stackPanel = HelperElementGenerator.GenerateElementStackPanel(labResultElement, Orientation.Horizontal);

            TextBox textBox = new TextBox();
            textBox.DataContext = labResultElement;
            textBox.SetBinding(TextBox.TextProperty, new Binding("Value") { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
            textBox.Height = 25;
            textBox.MinWidth = 50;
            stackPanel.Children.Add(textBox);

            Label unitsLabel = new Label();
            unitsLabel.Content = labResultElement.Units;
            stackPanel.Children.Add(unitsLabel);

            Label rangeLabel = new Label();
            rangeLabel.Content = $"({labResultElement.LowValue} {labResultElement.Units} - {labResultElement.HighValue} {labResultElement.Units})";
            stackPanel.Children.Add(rangeLabel);

            return stackPanel;
        }
    }
}