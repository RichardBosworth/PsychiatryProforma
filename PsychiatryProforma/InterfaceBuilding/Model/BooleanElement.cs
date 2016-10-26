using System.Xml.Serialization;
using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    [XmlInclude(typeof(BooleanElement))]
    public class BooleanElement : ExtraTextElement
    {
        public BooleanElement()
        {
        }

        public BooleanElement(string name) : base(name)
        {
        }

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public bool Value { get; set; }

        [YAXCollection(YAXCollectionSerializationTypes.Recursive, EachElementName = "ExportVariation"), YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public ExportVariations ExportVariations { get; set; } = new ExportVariations();

        public override string ToString()
        {
            if (Value)
            {
                var variationText = ExportVariations.SelectVariation();
                return !string.IsNullOrWhiteSpace(ExtraText) ? $"{variationText} - {ExtraText}" : variationText;
            }
            return string.Empty;
        }
    }
}