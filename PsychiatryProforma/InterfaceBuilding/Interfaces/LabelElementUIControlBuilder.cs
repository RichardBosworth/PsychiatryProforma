using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class LabelElementUIControlBuilder : IElementUIControlBuilder
    {
        public FrameworkElement GenerateControl(Element element)
        {
            var label = new Label();
            label.DataContext = element;
            label.SetBinding(ContentControl.ContentProperty, new Binding("Text") {Mode = BindingMode.OneWay});
            return label;
        }
    }
}