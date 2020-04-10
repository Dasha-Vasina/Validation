using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class PatternValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] { "restriction" };
        }
    }
}