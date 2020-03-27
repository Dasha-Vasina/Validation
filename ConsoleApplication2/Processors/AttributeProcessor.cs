using System.Xml.Linq;
using ConsoleApplication2.Types;

namespace ConsoleApplication2.Processors
{
    public class AttributeProcessor : IXsdElementProcessor
    {
        private readonly IXmlValidator _validator;

        public AttributeProcessor(IXmlValidator validator)
        {
            _validator = validator;
        }

        public void Process(XElement attributeElement)
        {
            var attribute = AttributeValidation.Parse(attributeElement);
        }
    }
}