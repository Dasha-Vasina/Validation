using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class ElementValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] {"schema", "sequence"};
        }
    }
}