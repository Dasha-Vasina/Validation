using System.Xml.Linq;

namespace ConsoleApplication2.Processors
{
    public class SchemaProcessing : IXsdElementProcessor
    {
        private readonly IXmlValidator _validator;

        public SchemaProcessing(IXmlValidator validator)
        {
            _validator = validator;
        }

        public void Process(XElement elementToProcess)
        {
            var elements = elementToProcess.Elements();

            foreach (var node in elements)
            {
                _validator.Add(node);
            }
        }
    }
}