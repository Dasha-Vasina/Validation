using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ConsoleApplication2.Processors;
using ConsoleApplication2.Types;

namespace ConsoleApplication2
{
    public class XsdValidator : ValidatorBase
    {
        private readonly Dictionary<string, IXsdElementProcessor> _processors;

        public XsdValidator()
        {
            _processors = new Dictionary<string, IXsdElementProcessor>
            {
                { "schema", new SchemaProcessing(this)},
                { "element", new ElementProcessor(this)},
                { "attribute", new AttributeProcessor(this)},
                { "simpleType", new SimpleTypeProcessor(this)},
                { "complexType", new ComplexTypeProcessor(this)},
            };
        }

        public override void Load(string path)
        {
            var docFile = XDocument.Load(path);

            var schema = docFile.Root;

            ProcessElement(new SchemaProcessing(this), schema);
        }
        
        public override void Add(XElement element)
        {
            var elementName = element.Name.LocalName;
            if (!_processors.ContainsKey(elementName))
            {
                throw new Exception($"Обработчика для элемента {elementName} не найдено");
            }

            var processor = _processors[elementName];
            ProcessElement(processor, element);
        }

        private void ProcessElement(IXsdElementProcessor processor, XElement element)
        {
            processor.Process(element);
        }

        protected override void ValidateInternal(string path)
        {
            var docFile = XDocument.Load(path);

            var root = docFile.Root;

            Validate(root);
        }

        private void Validate(XElement element)
        {
            var elementName = element.Name.LocalName;

            var type = GetElementType(elementName);

            type.Validate(element);

            foreach (var childNode in element.Elements())
            {
                Validate(childNode);
            }
        }
    }
}