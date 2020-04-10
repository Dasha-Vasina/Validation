using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal abstract class StructureValidatorBase : IStructureValidator
    {
        protected abstract IEnumerable<string> GetParents();

        public bool ValidateParent(XElement element)
        {
            if (element.Parent == null)
                return false;

            var parents = GetParents();

            return parents.Contains(element.Parent.Name.LocalName);
        }

    }
}