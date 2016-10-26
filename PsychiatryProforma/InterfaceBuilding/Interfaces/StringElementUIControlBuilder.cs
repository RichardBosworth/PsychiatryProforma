using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class StringElementUIControlBuilder : IElementUIControlBuilder
    {
        public FrameworkElement GenerateControl(Element element)
        {
            var stringElement = element as StringElement;

            var stackPanel = HelperElementGenerator.GenerateElementStackPanel(stringElement, Orientation.Vertical);

            var textBox = GenerateTextbox(stringElement);
            if (stringElement.Complex)
            {
                MakeComplex(textBox);
            }
            else
            {
                textBox.Height = 25;
            }

            stackPanel.Children.Add(textBox);
            return stackPanel;
        }

        private TextBox GenerateTextbox(StringElement stringElement)
        {
            var textBox = new TextBox();
            textBox.DataContext = stringElement;
            textBox.SpellCheck.IsEnabled = true;
            textBox.SetBinding(TextBox.TextProperty, new Binding("Value") {Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
            return textBox;
        }

        private static void MakeComplex(TextBox textBox)
        {
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.AcceptsReturn = true;
            textBox.MinHeight = 100;
            textBox.MaxHeight = 500;
            textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
    }
}