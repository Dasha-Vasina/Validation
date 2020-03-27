using System;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public enum AttributeUsage
    {
        /// <summary>
        /// Атрибут не обязателен (значение по умолчанию)
        /// </summary>
        Optional,

        /// <summary>
        /// Атрибут запрещен для использования
        /// </summary>
        Prohibited,

        /// <summary>
        /// Атрибут обязателен
        /// </summary>
        Required
    }

    public class AttributeValidation
    {
        public string Name { get; set; }
        public AttributeUsage Use { get; set; } = AttributeUsage.Optional;

        public void Validate(XElement element)
        {
            var attribute = element.Attribute(Name);

            if (Use == AttributeUsage.Prohibited && attribute != null)
            {
                throw new Exception($"Атрибут '{Name}' запрещен в элементе {element}");
            }

            if (Use == AttributeUsage.Required && attribute == null)
            {
                throw new Exception($"Атрибут '{Name}' обязателен для элемента {element}");
            }
        }

        public static AttributeValidation Parse(XElement attributeElement)
        {
            var name = attributeElement.Attribute("name")?.Value;
            
            var attribute = new AttributeValidation()
            {
                Name =  name
            };

            var useAttribute = attributeElement.Attribute("use");

            if (useAttribute != null)
            {
                switch (useAttribute.Value)
                {
                    case "optional":
                        attribute.Use = AttributeUsage.Optional;
                        break;
                    case "prohibited":
                        attribute.Use = AttributeUsage.Prohibited;
                        break;
                    case "required":
                        attribute.Use = AttributeUsage.Required;
                        break;
                    default:
                        throw new Exception($"Значение {useAttribute.Value} для определения атрибута недопустимо");
                }
            }

            return attribute;
        }
    }
}