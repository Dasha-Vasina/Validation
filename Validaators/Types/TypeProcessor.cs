using System;
using System.Xml.Linq;
using ConsoleApplication2.Processors;

namespace ConsoleApplication2.Types
{
    public abstract class TypeProcessor
    {
        public abstract IType Process(string name, XElement typeElement);
        public static TypeProcessor GetProcessor(XElement typeElement, IXmlValidator validator)
        {
            switch (typeElement.Name.LocalName)
            {
                case "simpleType":
                    return new SimpleTypeProcessor(validator);
                case "complexType":
                    return new ComplexTypeProcessor(validator);
                default: throw new Exception("Type not found");
            }
        }
    }
}
