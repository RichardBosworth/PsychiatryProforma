using System.Collections.Generic;
using PsychiatryProforma.InterfaceBuilding.Model;
using YAXLib;

namespace PsychiatryProforma.Expansions
{
    public class TextExpansionLibrary : List<TextExpansion>
    {
    }

    public class TextExpansion
    {
        [YAXAttributeForClass]
        public string ContractedText { get; set; }

        [YAXCollection(YAXCollectionSerializationTypes.Recursive, EachElementName = "ExportVariation"), YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public ExportVariations ExportVariations { get; set; } = new ExportVariations();

        public override string ToString()
        {
            return $"ContractedText: {ContractedText}";
        }
    }
}