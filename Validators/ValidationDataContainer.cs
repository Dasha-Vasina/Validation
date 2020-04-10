using System;
using System.Collections.Generic;
using ConsoleApplication2;
using ConsoleApplication2.Types;

namespace Validators
{
    internal class ValidationDataContainer
    {
        private readonly Dictionary<string, string> _elements;
        private readonly Dictionary<string, IType> _types;
        private readonly Dictionary<string, List<AttributeValidation>> _attributes;

        public ValidationDataContainer()
        {
            _types = new Dictionary<string, IType>
            {
                {"xs:string", new StringType()},
                {"xs:integer", new IntegerType()},
            };

            _elements = new Dictionary<string, string>();
            _attributes = new Dictionary<string, List<AttributeValidation>>();
        }

        public void AddType(IType type)
        {
            _types.Add(type.Name, type);
        }

        public void AddElement(Element element)
        {
            _elements.Add(element.Name, element.Type);
        }

        public IType GetElementType(string elementName)
        {
            if (!_elements.ContainsKey(elementName))
            {
                throw new Exception($"Элемента '{elementName}' не присутствует в XSD схеме");
            }
            var elementType = _elements[elementName];

            var type = _types[elementType];

            return type;
        }

        public IEnumerable<AttributeValidation> GetElementAttributes(string elementName)
        {
            if (_attributes.ContainsKey(elementName))
            {
                return _attributes[elementName];
            }

            return new AttributeValidation[] { };
        }

        public void AddAttribute(string element, AttributeValidation attribute)
        {
            if (!_attributes.ContainsKey(element))
            {
                _attributes.Add(element, new List<AttributeValidation>());
            }
            _attributes[element].Add(attribute);
        }
    }
}