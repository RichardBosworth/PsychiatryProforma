using System.Xml.Serialization;
using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    [XmlInclude(typeof(ExtraTextElement))]
    public class ExtraTextElement : Element
    {
        public ExtraTextElement()
        {
        }

        [YAXErrorIfMissed(YAXExceptionTypes.Ignore), YAXAttributeForClass]
        public string ExtraText { get; set; }

        public ExtraTextElement(string name) : base(name)
        {
        }
    }
}