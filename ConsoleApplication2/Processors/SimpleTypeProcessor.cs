using System;
using System.Linq;
using System.Xml.Linq;
using ConsoleApplication2.Types;

namespace ConsoleApplication2.Processors
{
    public class SimpleTypeProcessor : TypeProcessor, IXsdElementProcessor
    {
        private readonly XsdValidator _validator;

        public SimpleTypeProcessor(XsdValidator validator)
        {
            _validator = validator;
        }

        public override IType Process(string name, XElement typeElement)
        {
            var type = new SimpleType(name);

            ExtractData(typeElement, type);

            return type;
        }

        public void Process(XElement typeElement)
        {
            var nameAttribute = typeElement.Attribute("name");

            if (nameAttribute == null)
            {
                throw new Exception("Для определения элемента simpleType в schema необходимо указать атрибут 'name'");
            }

            var type = new SimpleType(nameAttribute.Value);

            ExtractData(typeElement, type);

            _validator.AddType(type);
        }

        private void ExtractData(XElement typeElement, SimpleType type)
        {
            var restriction = typeElement.Elements().SingleOrDefault(e => e.Name.LocalName.Contains("restriction"));
            if (restriction == null)
            {
                throw new Exception($"Element 'restriction' not found in type {typeElement.Name.NamespaceName}");
            }

            var baseTypeAttribute = restriction.Attribute("base");

            if (baseTypeAttribute == null)
            {
                throw new Exception($"Element 'restriction' must have attribute 'base'");
            }

            type.BaseType = baseTypeAttribute.Value;

            foreach (var restrictionElement in restriction.Elements())
            {
                var processedRestriction = Restriction.GetRestriction(restrictionElement);
                type.AddRestriction(processedRestriction);
            }
        }
    }
}