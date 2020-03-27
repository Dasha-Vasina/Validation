using System;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    internal class IntegerType : SimpleTypeBase
    {
        public IntegerType() : base("xs:integer")
        {
        }
        public override void Validate(XElement element)
        {
            base.Validate(element);

            if (!int.TryParse(element.Value, out var value))
            {
                throw new Exception($"ќжидаетс€ целочисленный тип дл€ элемента {element}");
            }
        }
    }
}