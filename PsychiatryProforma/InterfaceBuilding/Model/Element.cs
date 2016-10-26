using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    /// <summary>
    ///     Provides properties and methods relevant to all elements.
    /// </summary>
    public class Element
    {
        public Element()
        {
        }

        public Element(string name)
        {
            Name = name;
        }

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string Name { get; set; }
    }
}