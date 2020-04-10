using System;
using System.IO;

namespace Validators
{
    public interface IValidator
    {
        event Action<String> OnValidationError;
        void Load(string validationText);
        void Load(Stream validationFileStream);
        bool Validate(string xmlText);
        bool Validate(Stream xmlFileStream);
    }
}
