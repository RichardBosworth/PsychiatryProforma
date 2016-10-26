using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using YAXLib;
using static System.String;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    [YAXSerializeAs("Group")]
    public class GroupElement : Element
    {
        public GroupElement()
        {
        }

        public GroupElement(string name) : base(name)
        {
        }

        [ YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public List<Element> SubElements { get; set; } = new List<Element>();

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public bool SubGroup { get; set; }

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string SubGroupSeparator { get; set; } = ";";

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public double Spacing { get; set; } = 15;

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public bool Enabled { get; set; } = true;

        public override string ToString()
        {
            if (!Enabled)
            {
                return Empty;
            }

            var stringBuilder = new StringBuilder();

            if (!SubGroup)
            {
                ExportAsMain(stringBuilder);
            }
            else
            {
                ExportAsSubgroup(stringBuilder);
            }

            return stringBuilder.ToString();
        }

        private void ExportAsSubgroup(StringBuilder stringBuilder)
        {
            if (!IsNullOrWhiteSpace(Name))
            {
                stringBuilder.Append($"{Name}:  ");
            }

            var elements = SubElements.Where(element => !IsNullOrWhiteSpace(element.ToString())).ToList();
            for (int i = 0; i < elements.Count; i++)
            {
                if (i<elements.Count-1)
                {
                    AppendSubgroupItem(stringBuilder, elements[i], $"{SubGroupSeparator} ");
                }
                else
                {
                    AppendSubgroupItem(stringBuilder, elements[i], ". ");
                }
            }

        }

        private void AppendSubgroupItem(StringBuilder stringBuilder, Element element, string separatorString)
        {
            stringBuilder.Append(element);
            stringBuilder.Append(separatorString);
        }

        private void ExportAsMain(StringBuilder stringBuilder)
        {
            if (!IsNullOrWhiteSpace(Name))
            {
                stringBuilder.AppendLine($"{Name}:");
            }
            stringBuilder.AppendLine();

            var enumerable = SubElements.Where(element => !IsNullOrWhiteSpace(element.ToString()));
            foreach (var element in enumerable)
            {
                stringBuilder.AppendLine($"{element}");
                stringBuilder.AppendLine();
            }
        }
    }
}