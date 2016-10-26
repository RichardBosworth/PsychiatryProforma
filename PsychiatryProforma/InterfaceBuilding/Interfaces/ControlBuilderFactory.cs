using System;
using System.Collections.Generic;
using System.Linq;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma.InterfaceBuilding.Interfaces
{
    public class ControlBuilderFactory : IControlBuilderFactory 
    {
        private readonly Dictionary<Type, Type> _linkingDictionary;

        public ControlBuilderFactory()
        {
            _linkingDictionary = new Dictionary<Type, Type>();
            _linkingDictionary.Add(typeof(GroupElement), typeof(GroupElementUIControlBuilder));
            _linkingDictionary.Add(typeof(ChoiceElement), typeof(ChoiceElementUIControlBuilder));
            _linkingDictionary.Add(typeof(BooleanElement), typeof(BooleanElementUIControlBuilder));
            _linkingDictionary.Add(typeof(StringElement), typeof(StringElementUIControlBuilder));
            _linkingDictionary.Add(typeof(ListElement), typeof(ListElementUIControlBuilder));
            _linkingDictionary.Add(typeof(MaskedElement), typeof(MaskedElementUIControlBuilder));
            _linkingDictionary.Add(typeof(LabResultElement), typeof(LabResultElementUIControlBuilder));
            _linkingDictionary.Add(typeof(LabelElement), typeof(LabelElementUIControlBuilder));
        }

        public IElementUIControlBuilder SelectFactory(Element element)
        {
            var elementType = element.GetType();
            var selectedPair = _linkingDictionary.Single(pair => pair.Key == elementType);
            var factory = Activator.CreateInstance(selectedPair.Value);
            return factory as IElementUIControlBuilder;
        }
    }
}