using System;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public enum AttributeUsage
    {
        /// <summary>
        /// ������� �� ���������� (�������� �� ���������)
        /// </summary>
        Optional,

        /// <summary>
        /// ������� �������� ��� �������������
        /// </summary>
        Prohibited,

        /// <summary>
        /// ������� ����������
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
                throw new Exception($"������� '{Name}' �������� � �������� {element}");
            }

            if (Use == AttributeUsage.Required && attribute == null)
            {
                throw new Exception($"������� '{Name}' ���������� ��� �������� {element}");
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
                        throw new Exception($"�������� {useAttribute.Value} ��� ����������� �������� �����������");
                }
            }

            return attribute;
        }
    }
}