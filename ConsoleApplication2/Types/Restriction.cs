using System;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public abstract class Restriction
    {
        public static Restriction GetRestriction(XElement element)
        {
            switch (element.Name.LocalName)
            {
                case "pattern":
                    return new PatternRestriction(element);
                case "enumeration":
                    return new EnumerationRestriction(element);
                default:
                    throw new Exception($"Restriction for element {element} not found");
            }
        }

        public abstract void Validate(XElement element);
    }
}