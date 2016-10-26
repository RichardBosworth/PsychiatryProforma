using System;
using System.Linq;
using System.Text;
using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    /// <summary>
    /// Represents a list.
    /// </summary>
    public class ListElement : Element
    {
        private string _listText;

        public ListElement()
        {
        }

        public ListElement(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets and sets the text of the list (new lines represent a new list item).
        /// </summary>
        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string ListText
        {
            get { return _listText; }
            set
            {
                _listText = value;
                if (value.Contains("\\n"))
                {
                    _listText = value.Replace("\\n", "\n");
                }
            }
        }

        [YAXAttributeForClass, YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public bool Numbered { get; set; }

        public override string ToString()
        {
            //Split the text at each new line.
            if (ListText != null)
            {
                var lines = ListText.Split('\n');

                // Remove lines with whitespace.
                var linesWithInput = lines.Where(lineContent => !String.IsNullOrWhiteSpace(lineContent)).ToList();
            
                // Generate the list.
                StringBuilder stringBuilder = new StringBuilder();

                if (Numbered)
                {
                    for (int i = 0; i < linesWithInput.Count(); i++)
                    {
                        stringBuilder.AppendLine($"{i + 1}. {linesWithInput[i]}");
                    }
                }
                else
                {
                    foreach (var line in linesWithInput)
                    {
                        stringBuilder.AppendLine($"• {line}");
                    }
                }

                return stringBuilder.ToString();
            }

            return String.Empty;
        }
    }
}