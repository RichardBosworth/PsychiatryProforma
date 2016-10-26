using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    public class MaskedElement : ExtraTextElement
    {
        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string Mask { get; set; }

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string Prompt { get; set; }

        [YAXDontSerialize]
        public string Value { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(ExtraText))
            {
                return $"{Name}: {Value} - {ExtraText}";
            }
            else
            {
                return $"{Name}: {Value}";
            }
        }
    }
}