using System.Xml.Linq;

namespace ConsoleApplication2.StructureValidation.Validators
{
    public interface IStructureValidator
    {
        bool ValidateParent(XElement element);
    }
}
