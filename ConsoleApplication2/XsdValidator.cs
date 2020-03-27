using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ConsoleApplication2.Processors;
using ConsoleApplication2.Types;

namespace ConsoleApplication2
{
    public class XsdValidator
    {
        private readonly Dictionary<string, IXsdElementProcessor> _processors;
        private readonly Dictionary<string, string> _elements = new Dictionary<string, string>();
        private readonly Dictionary<string, IType> _types;

        public XsdValidator()
        {
            _types = new Dictionary<string, IType>
            {
                {"xs:string", new StringType()},
                {"xs:integer", new IntegerType()},
            };

            _processors = new Dictionary<string, IXsdElementProcessor>
            {
                { "schema", new SchemaProcessing(this)},
                { "element", new ElementProcessor(this)},
                { "attribute", new AttributeProcessor(this)},
                { "simpleType", new SimpleTypeProcessor(this)},
                { "complexType", new ComplexTypeProcessor(this)},

            };
        }

        public void Load(string path)
        {
            var docFile = XDocument.Load(path);

            var schema = docFile.Root;

            //TODO: Check - it element is schema

            ProcessElement(new SchemaProcessing(this), schema);
        }


        public void ProcessElement(XElement element)
        {
            var elementName = element.Name.LocalName;
            if (!_processors.ContainsKey(elementName))
            {
                throw new Exception($"Обработчика для элемента {elementName} не найдено");
            }

            var processor = _processors[elementName];
            ProcessElement(processor, element);
        }

        public void ProcessElement(IXsdElementProcessor processor, XElement element)
        {
            processor.Process(element);
        }

        public void Validate(string path)
        {
            var docFile = XDocument.Load(path);

            var root = docFile.Root;

            Validate(root);
        }

        public void Validate(XElement element)
        {
            var elementName = element.Name.LocalName;

            var type = GetTypeByName(elementName);

            type.Validate(element);

            foreach (var childNode in element.Elements())
            {
                Validate(childNode);
            }
        }

        public void AddType(IType type)
        {
            _types.Add(type.Name, type);
        }

        public void AddElement(Element element)
        {
            _elements.Add(element.Name, element.Type);
        }

        public IType GetTypeByName(string elementName)
        {
            if (!_elements.ContainsKey(elementName))
            {
                throw new Exception($"Элемента '{elementName}' не присутствует в XSD схеме");
            }
            var elementType = _elements[elementName];

            var type = _types[elementType];

            return type;
        }
    }
}