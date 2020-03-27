using System.Xml.Linq;
using ConsoleApplication2.Types;

namespace ConsoleApplication2.Processors
{
    public class AttributeProcessor : IXsdElementProcessor
    {
        private readonly XsdValidator _validator;

        public AttributeProcessor(XsdValidator validator)
        {
            _validator = validator;
        }

        public void Process(XElement attributeElement)
        {
            var attribute = AttributeValidation.Parse(attributeElement);
        }
    }
}