using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ConsoleApplication2.Types;

namespace ConsoleApplication2.Processors
{
    public class ComplexTypeProcessor : TypeProcessor, IXsdElementProcessor
    {
        private readonly IXmlValidator _validator;

        public ComplexTypeProcessor(IXmlValidator validator)
        {
            _validator = validator;
        }

        public override IType Process(string typeName, XElement complexTypeElement)
        {
            if (complexTypeElement == null) throw new ArgumentNullException(nameof(complexTypeElement));

            var type = new ComplexType(typeName);

            ExtractData(complexTypeElement, type);

            return type;
        }

        private Content GetContent(IEnumerable<XElement> innerElements)
        {
            var sequenceElement = innerElements.Single(e => e.Name.LocalName == "sequence");

            var sequenceElements = sequenceElement.Elements().Where(e => e.Name.LocalName == "element");

            var sequence = new Sequence(_validator);
            foreach (var sequenceInnerElement in sequenceElements)
            {
                sequence.Add(sequenceInnerElement);
                _validator.Add(sequenceInnerElement);
            }

            return sequence;
        }

        public void Process(XElement typeElement)
        {
            var nameAttribute = typeElement.Attribute("name");

            if (nameAttribute == null)
            {
                throw new Exception("Для определения элемента complexType в schema необходимо указать атрибут 'name'");
            }

            var type = new ComplexType(nameAttribute.Value);

            ExtractData(typeElement, type);

            _validator.AddType(type);
        }

        private void ExtractData(XElement complexTypeElement, ComplexType type)
        {
            var innerElements = complexTypeElement.Elements();

            var sequenceElement = innerElements.SingleOrDefault(e => e.Name.LocalName == "sequence");

            if (sequenceElement == null)
            {
                throw new Exception($"Не найден элемент sequence для complexType {complexTypeElement}");
            }

            // Get content
            var content = GetContent(innerElements);

            type.Content = content;

            // Get attributes
            var attributeDescriptions = innerElements.Where(e => e.Name.LocalName == "attribute");

            var attributes = attributeDescriptions.Select(a => AttributeValidation.Parse(a)).ToArray();

            type.Attributes.AddRange(attributes);
        }
    }
}