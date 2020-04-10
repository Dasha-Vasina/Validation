using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public abstract class Content
    {
        public abstract void Validate(XElement element);
    }
}