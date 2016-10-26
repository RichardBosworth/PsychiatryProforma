using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    public class LabelElement : Element
    {
        [YAXAttributeForClass]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string Text { get; set; }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}