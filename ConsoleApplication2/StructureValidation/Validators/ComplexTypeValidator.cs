using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class ComplexTypeValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] { "element", "schema" };
        }
    }
}