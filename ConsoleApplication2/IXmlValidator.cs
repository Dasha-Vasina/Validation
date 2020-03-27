using System.Collections.Generic;
using System.Xml.Linq;
using ConsoleApplication2.Types;

namespace ConsoleApplication2
{
    public interface IXmlValidator
    {
        IType GetElementType(string elementName);
        IEnumerable<AttributeValidation> GetElementAttributes(string elementName);
        void AddType(IType type);
        void AddElement(Element processedElement);
        void AddAttribute(string element, AttributeValidation attribute);
        void Add(XElement element);
    }
}
