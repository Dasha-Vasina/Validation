using System.Collections.Generic;

namespace ConsoleApplication2.StructureValidation.Validators
{
    internal class SequenceValidator : StructureValidatorBase
    {
        protected override IEnumerable<string> GetParents()
        {
            return new[] { "complexType" };
        }
    }
}