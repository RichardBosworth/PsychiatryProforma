using System.Xml.Serialization;
using PsychiatryProforma.Expansions;
using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    [XmlInclude(typeof(StringElement))]
    public class StringElement : Element
    {
        public StringElement()
        {
        }

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public bool Complex { get; set; }

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }

        public StringElement(string name) : base(name)
        {
        }
    }
}