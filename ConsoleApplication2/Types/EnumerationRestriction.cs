using System;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public class EnumerationRestriction : Restriction
    {
        public string Value { get; }
        public EnumerationRestriction(XElement element)
        {
            Value = element.Attribute("value")?.Value;
        }

        public override void Validate(XElement element)
        {
            if (element.Value != Value)
            {
                throw new Exception($"Element {element} not in enumeration {Value}");
            }
        }
    }
}