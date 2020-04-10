using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class SimpleTypeValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] { "element", "schema" };
        }
    }
}