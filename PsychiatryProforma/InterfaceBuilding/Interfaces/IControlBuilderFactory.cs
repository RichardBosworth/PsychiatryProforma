using System.Security.Cryptography.X509Certificates;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    /// <summary>
    /// Provides functionality to select the factories needed to build a control.
    /// </summary>
    public interface IControlBuilderFactory 
    {
        IElementUIControlBuilder SelectFactory(Element element);
    }
}