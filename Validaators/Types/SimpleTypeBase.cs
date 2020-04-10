using System;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public abstract class SimpleTypeBase : IType
    {
        protected SimpleTypeBase(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public virtual void Validate(XElement element)
        {
            var innerElementsCount = element.Elements().Count();
            if (innerElementsCount > 0)
            {
                throw new Exception($"Ожидается простой тип. Ошибка валидации элемента {element}");
            }
        }
    }
}
