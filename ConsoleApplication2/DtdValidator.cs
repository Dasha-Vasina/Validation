using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleApplication2.Processors;
using ConsoleApplication2.Types;

namespace ConsoleApplication2
{
    public class DtdValidator : ValidatorBase
    {
        private string _rootElement;

        public override void Load(string path)
        {
            string fileContent;

            using (StreamReader file = new StreamReader(path))
            {
                fileContent = file.ReadToEnd();
            }

            var rootElementRegex = new Regex(@"<!DOCTYPE\s(?<name>.*)\[(?<innerContent>.*)\]>", RegexOptions.Singleline);
            var rootElementMatch =  rootElementRegex.Match(fileContent);

            if (!rootElementMatch.Success)
            {
                throw new Exception("Не обнаружен элемент DOCTYPE или имя корневого элемента");
            }

            _rootElement = rootElementMatch.Groups["name"].Value;

            var innerContent = rootElementMatch.Groups["innerContent"].Value;

            var elementStrings = GetElementStrings(innerContent);

            foreach (var elementString in elementStrings)
            {
                ProcessElement(elementString);
            }

            var attributeStrings = GetAttributeStrings(innerContent);

            foreach (var attributeString in attributeStrings)
            {
                ProcessAttribute(attributeString);
            }
        }

        private void ProcessElement(string elementString)
        {
            var elementRegex = new Regex(@"^<!ELEMENT\s(?<name>.*?)\s\((?<content>.*)\)>$", RegexOptions.Multiline);
            var elementMatch = elementRegex.Match(elementString);
            if (!elementMatch.Success)
            {
                throw new Exception($"Не удалось получить данные для элемента {elementString}");
            }

            var name = elementMatch.Groups["name"].Value;
            var content = elementMatch.Groups["content"].Value;

            var typeName = ExtractType(name, content);

            AddElement(new Element(name, typeName));
        }

        private void ProcessAttribute(string attributeString)
        {
            var attributeRegex = new Regex(@"^<!ATTLIST\s+(?<elementName>.*?)\s+(?<name>.*?)\s+(?<type>.*?)\s+(?<value>.+?)>$", RegexOptions.Multiline);
            var attributeMatch = attributeRegex.Match(attributeString);
            if (!attributeMatch.Success)
            {
                throw new Exception($"Не удалось получить данные для элемента {attributeString}");
            }

            var parentElement = attributeMatch.Groups["elementName"].Value;
            var name = attributeMatch.Groups["name"].Value;
            var type = attributeMatch.Groups["type"].Value;
            var value = attributeMatch.Groups["value"].Value;

            var attribute = new AttributeValidation {Name = name};

            if (value == "#REQUIRED")
            {
                attribute.Use = AttributeUsage.Required;
            }

            AddAttribute(parentElement, attribute);
        }

        private string ExtractType(string elementName, string content)
        {
            if (content.Trim() == "#PCDATA")
            {
                return "xs:string";
            }

            var elements = content.Split(',').Select(e => e.Trim()).ToArray();
            var type = new ComplexType($"{elementName}Type");
            var sequence = new Sequence(this);

            foreach (var element in elements)
            {
                if(element.EndsWith("+"))
                    sequence.Add(element.TrimEnd('+'), minimum: 1);
                else if (element.EndsWith("*"))
                {
                    sequence.Add(element.TrimEnd('*'));
                }
                else
                {
                    sequence.Add(element, 1, 1);
                }
            }

            type.Content = sequence;

            AddType(type);

            return type.Name;
        }

        private IEnumerable<string> GetElementStrings(string data)
        {
            var elementsRegex = new Regex(@"<!ELEMENT.+?>", RegexOptions.Multiline);
            var elementMatches = elementsRegex.Matches(data);

            return from Match match in elementMatches select match.Value;
        }

        private IEnumerable<string> GetAttributeStrings(string data)
        {
            var attributesRegex = new Regex(@"<!ATTLIST.+?>", RegexOptions.Multiline);
            var attributeMatches = attributesRegex.Matches(data);

            return from Match match in attributeMatches select match.Value;
        }

        protected override void ValidateInternal(string path)
        {
            var docFile = XDocument.Load(path);

            var root = docFile.Root;

            Validate(root);
        }

        public void Validate(XElement element)
        {
            var elementName = element.Name.LocalName;

            var type = GetElementType(elementName);

            type.Validate(element);

            var attributes = GetElementAttributes(elementName);

            foreach (var attributeValidation in attributes)
            {
                attributeValidation.Validate(element);
            }

            foreach (var childNode in element.Elements())
            {
                Validate(childNode);
            }
        }

        public override void Add(XElement element)
        {
            // For same interface
        }
    }
}
