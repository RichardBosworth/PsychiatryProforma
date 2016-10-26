using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    public class LabResultElement : Element
    {
        public LabResultElement()
        {
        }

        public LabResultElement(string name) : base(name)
        {
        }

        [YAXAttributeForClass]
        public double Value { get; set; }

        [YAXAttributeForClass]
        public double HighValue { get; set; }

        [YAXAttributeForClass]
        public double LowValue { get; set; }

        [YAXAttributeForClass]
        public string NormalValueText { get; set; }

        [YAXAttributeForClass]
        public string AboveHighValueText { get; set; }

        [YAXAttributeForClass]
        public string BelowLowValueText { get; set; }

        [YAXAttributeForClass]
        public string Units { get; set; }

        public override string ToString()
        {
            string valueExplanationText = NormalValueText;
            if (Value > HighValue)
            {
                valueExplanationText = AboveHighValueText;
            }
            if (Value < LowValue)
            {
                valueExplanationText = BelowLowValueText;
            }

            return $"{Name}: {Value} {Units} ({LowValue} {Units} - {HighValue} {Units}) - {valueExplanationText}.";
        }
    }
}