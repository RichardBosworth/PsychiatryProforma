using System.Windows;
using System.Windows.Controls;
using PsychiatryProforma.InterfaceBuilding.Model;
using Syncfusion.Windows.Tools.Controls;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public interface IElementUIControlBuilder
    {
        FrameworkElement GenerateControl(Element element);
    }
}