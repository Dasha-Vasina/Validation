using System.Xml.Linq;

namespace ConsoleApplication2.StructureValidation.Validators
{
    class SchemaValidator : IStructureValidator
    {
        public bool ValidateParent(XElement element)
        {
            return element.Parent == null;
        }
    }
}
