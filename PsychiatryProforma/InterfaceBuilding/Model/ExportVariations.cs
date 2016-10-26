using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PsychiatryProforma.InterfaceBuilding.Model
{
    [XmlInclude(typeof(ExportVariations))]
    public class ExportVariations : BindingList<string>
    {
        public string SelectVariation()
        {
            var randomIndex = new Random().Next(0, Count);
            return this[randomIndex];
        }

        public override string ToString()
        {
            return SelectVariation();
        }
    }
}