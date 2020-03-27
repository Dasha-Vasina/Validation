using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ConsoleApplication2.StructureValidation.Validators;

namespace ConsoleApplication2.StructureValidation
{

    public class StructureValidator
    {
        private readonly Dictionary<string, IStructureValidator> _validators = new Dictionary<string, IStructureValidator>
        {
            {"schema", new SchemaValidator()},
            {"element", new ElementValidator()},
            {"sequence", new SequenceValidator()},
            {"complexType", new ComplexTypeValidator()},
            {"simpleType", new SimpleTypeValidator()},
            {"restriction", new RestrictionValidator()},
            {"pattern", new PatternValidator()},
            {"enumeration", new EnumerationValidator()},
            {"attribute", new AttributeValidator()},
        };

        public IStructureValidator GetValidator(XElement element)
        {
            var elementName = element.Name.LocalName;
            if (!_validators.ContainsKey(elementName))
            {
                throw new Exception($"Structure validator for element {element} not found");
            }

            return _validators[elementName];
        }

        public bool Validate(string path)
        {
            var docFile = XDocument.Load(path);

            var schema = docFile.Root;

            return Validate(schema);
        }

        public event Action<XElement> OnError; 

        public bool Validate(XElement element)
        {
            var validator = GetValidator(element);

            var result = validator.ValidateParent(element);

            if (!result)
            {
                OnError?.Invoke(element);
                return false;
            }

            var childs = element.Elements();
            foreach (var child in childs)
            {
                if (!Validate(child))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
