using System;
using System.Xml.Linq;
using ConsoleApplication2.StructureValidation;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var validator = new XsdValidator();

            var xsdPath = @"C:\Users\Pavel\Downloads\ТЗ\shipbuilding_rental4.xsd";

            var structureValidator = new  StructureValidator();
            structureValidator.OnError += StructureValidatorOnOnError;
            var structureValidatorResult = structureValidator.Validate(xsdPath);

            if (!structureValidatorResult)
            {
                Console.WriteLine("Неправильная вложенность елементов");
                Console.ReadKey();
            }

            validator.Load(xsdPath);

            try
            {
                validator.Validate(@"C:\Users\Pavel\Downloads\ТЗ\shipbuilding_rental3.xml");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void StructureValidatorOnOnError(XElement wrongElement)
        {
            Console.WriteLine(wrongElement);
        }
    }
}