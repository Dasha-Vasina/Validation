using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public class ElementSettings
    {
        public ElementSettings(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public int Max { get; set; }
        public int Min { get; set; }

        public void Validate(XElement element)
        {
            var count = element.Elements().Count(e => e.Name.LocalName == Name);

            if (Min > 0 && count < Min)
            {
                throw new Exception($"Количество элементов {Name} должно быть не меньше {Min}. Корневой элемент {element}");
            }

            if (Max > 0 && count > Max)
            {
                throw new Exception($"Количество элементов {Name} должно быть не больше {Max}. Корневой элемент {element}");
            }
        }
    }

    public class Sequence : Content
    {
        private readonly IXmlValidator _validator;
        private readonly List<string> _elements;
        private readonly Dictionary<string, ElementSettings> _settings;

        public Sequence(IXmlValidator validator)
        {
            _validator = validator;
            _elements = new List<string>();
            _settings = new Dictionary<string, ElementSettings>();
        }

        public void Add(XElement element)
        {
            var elementNameAttribute = element.Attribute("name");

            if (elementNameAttribute != null)
            {
                Add(elementNameAttribute.Value);
                return;

            }

            var elementRefAttribute = element.Attribute("ref");
            if (elementRefAttribute != null)
            {
                Add(elementRefAttribute.Value);
                return;
            }

            throw new Exception("Для элемента должно быть указан атрибут name или ref");
        }

        public void Add(string elementName, int minimum = 0, int maximum = -1)
        {
            _elements.Add(elementName);
            _settings.Add(elementName, new ElementSettings(elementName) { Min = minimum, Max = maximum});
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
                var name = child.Name.LocalName;
                var type = _validator.GetElementType(name);
                type.Validate(child);
            }

            foreach (var elementSettings in _settings.Values)
            {
                elementSettings.Validate(element);
            }
        }
    }
}