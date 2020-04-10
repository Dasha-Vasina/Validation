using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public class ComplexType : IType
    {
        public Content Content { get; set; }
        public ComplexType(string name, Content content, IEnumerable<AttributeValidation> attributes)
        {
            Content = content;
            Name = name;
            Attributes = new List<AttributeValidation>(attributes);
        }

        public ComplexType(string name)
        {
            Name = name;
            Attributes = new List<AttributeValidation>();
        }

        public void Validate(XElement element)
        {
            Content.Validate(element);

            foreach (var attribute in Attributes)
            {
                attribute.Validate(element);
            }
        }

        public List<AttributeValidation> Attributes { get; }
        public string Name { get; }
    }
}