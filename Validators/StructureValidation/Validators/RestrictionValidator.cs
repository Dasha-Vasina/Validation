using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class RestrictionValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] { "simpleType" };
        }
    }
}