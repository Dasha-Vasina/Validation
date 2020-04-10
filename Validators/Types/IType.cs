using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public interface IType
    {
        string Name { get; }
        void Validate(XElement element);
    }
}