using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class AttributeValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] {"complexType", "schema" };
        }
    }
}