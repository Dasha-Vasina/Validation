using System;
using System.Linq;
using System.Xml.Linq;
using ConsoleApplication2.Types;

namespace ConsoleApplication2.Processors
{
    public class ElementProcessor : IXsdElementProcessor
    {
        private readonly IXmlValidator _validator;

        public ElementProcessor(IXmlValidator validator)
        {
            _validator = validator;
        }

        public void Process(XElement elementToProcess)
        {
            //Get ref
            var elementRefAttribute = elementToProcess.Attribute("ref");
            if (elementRefAttribute != null)
            {
                return;
            }

            //Get name
            var elemNameAttribute = elementToProcess.Attribute("name");
            var elementName = elemNameAttribute.Value;

            //Get type
            var elementTypeName = GetElementType(elementToProcess);

            if (elementTypeName != null)
            {
                var processedElement = new Element(elementName, elementTypeName);
                _validator.AddElement(processedElement);
                return;
                //TODO: may be return
            }

            var innerElements = elementToProcess.Elements();

            var typeElementsCount = innerElements.Count(e => e.Name.LocalName.Contains("Type"));

            if (typeElementsCount == 0)
            {
                throw new Exception($"Не указан вложенный элемент simpleType или complexType для элемента {elementToProcess}");
            }

            if (typeElementsCount > 1)
            {
                throw new Exception($"Указано более одного вложенного типа simpleType или complexType для элемента {elementToProcess}");
            }

            var typeElement = innerElements.SingleOrDefault(e => e.Name.LocalName.Contains("Type"));

            if (typeElement == null)
            {
                throw new Exception("Указан вложенный элемент типа, при заданном атребибуте 'type'");
            }


            var typeProcessor = TypeProcessor.GetProcessor(typeElement, _validator);

            var type = typeProcessor.Process($"{elementName}Type", typeElement);

            _validator.AddType(type);
            _validator.AddElement(new Element(elementName, type.Name));
        }

        private static string GetElementType(XElement element)
        {
            var typeAttribute = element.Attribute("type");
            return typeAttribute?.Value;
        }
    }
}