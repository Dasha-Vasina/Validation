using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public class Sequence : Content
    {
        private readonly XsdValidator _validator;
        private readonly List<string> _elements;

        public Sequence(XsdValidator validator)
        {
            _validator = validator;
            _elements = new List<string>();
        }

        public void Add(XElement element)
        {
            var elementNameAttribute = element.Attribute("name");

            if (elementNameAttribute != null)
            {
                _elements.Add(elementNameAttribute.Value);
                return;

            }

            var elementRefAttribute = element.Attribute("ref");
            if (elementRefAttribute != null)
            {
                _elements.Add(elementRefAttribute.Value);
                return;
            }

            throw new Exception("Для элемента должно быть указан атрибут name или ref");
        }

        public override void Validate(XElement element)
        {
            var elementsChild = element.Elements();

            var notSupportedElements = elementsChild.Select(e => e.Name.LocalName).Except(_elements).ToArray();

            if (notSupportedElements.Length > 0)
            {
                throw new Exception($"Elements '{string.Join(",", notSupportedElements)}' can't exist in {element}");
            }

            foreach (var child in elementsChild)
            {
                var type = _validator.GetTypeByName(child.Name.LocalName);
                type.Validate(child);
            }
        }
    }
}