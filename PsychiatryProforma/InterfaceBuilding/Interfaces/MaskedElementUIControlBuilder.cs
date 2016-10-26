using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;
using Syncfusion.Windows.Shared;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class MaskedElementUIControlBuilder : IElementUIControlBuilder
    {
        public FrameworkElement GenerateControl(Element element)
        {
            MaskedElement maskedElement = element as MaskedElement;

            StackPanel stackPanel = new StackPanel() {Orientation = Orientation.Horizontal};
            stackPanel.Children.Add(HelperElementGenerator.GenerateLabelForElement(maskedElement));
            stackPanel.Children.Add(GenerateMaskedTextBox(maskedElement));
            stackPanel.Children.Add(HelperElementGenerator.GenerateExtraTextBox(maskedElement));
            return stackPanel;
        }

        private static FrameworkElement GenerateMaskedTextBox(MaskedElement maskedElement)
        {
            MaskedTextBox maskedTextBox = new MaskedTextBox();
            maskedTextBox.DataContext = maskedElement;
            maskedTextBox.SetBinding(MaskedTextBox.MaskProperty, new Binding("Mask"));
            maskedTextBox.SetBinding(MaskedTextBox.TextProperty, new Binding("Value") {Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
            maskedTextBox.SetBinding(MaskedTextBox.WatermarkTextProperty, new Binding("Prompt"));
            maskedTextBox.Height = 25;
            maskedTextBox.MinWidth = 100;
            return maskedTextBox;
        }
    }
}