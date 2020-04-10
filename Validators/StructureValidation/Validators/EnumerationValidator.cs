using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class EnumerationValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] { "restriction" };
        }
    }
}