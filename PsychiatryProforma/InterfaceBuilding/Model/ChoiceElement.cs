using System.Collections.Generic;
using System.Linq;
using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    [YAXSerializeAs("Choice")]
    public class ChoiceElement : ExtraTextElement
    {
        public ChoiceElement(string name) : base(name)
        {
        }

        public ChoiceElement()
        {
        }

        [YAXCollection(YAXCollectionSerializationTypes.Recursive, EachElementName = "Choice")]
        public List<Choice> Choices { get; set; } = new List<Choice>();

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public int SelectedChoiceIndex { get; set; }

        public override string ToString()
        {
            var choiceText = Choices.ElementAt(SelectedChoiceIndex).ExportVariations.SelectVariation();

            var separatorText = "";
            if (!string.IsNullOrWhiteSpace(choiceText))
            {
                separatorText = ", ";
            }

            return !string.IsNullOrWhiteSpace(ExtraText) ? $"{choiceText}{separatorText}{ExtraText}" : choiceText;
        }
    }

    public class Choice
    {
        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string Name { get; set; }

        [YAXCollection(YAXCollectionSerializationTypes.Recursive, EachElementName = "ExportVariation"), YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public ExportVariations ExportVariations { get; set; } = new ExportVariations();
    }
}