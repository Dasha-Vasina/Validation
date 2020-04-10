using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    interface IValidator
    {
        event Action<String> OnValidationError;
        void Load(string path);
        bool Validate(string path);
    }
}
