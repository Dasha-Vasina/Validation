using System.Xml.Linq;

namespace ConsoleApplication2.Processors
{
    public interface IXsdElementProcessor
    {
        void Process(XElement elementToProcess);
    }
}