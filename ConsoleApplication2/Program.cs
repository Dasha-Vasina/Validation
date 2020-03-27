using System;
using System.Xml.Linq;
using ConsoleApplication2.StructureValidation;

namespace ConsoleApplication2
{
    internal class Program
    {
        public IValidator Validator { get; }

        public Program(IValidator validator)
        {
            Validator = validator;
        }

        public static void Main(string[] args)
        {
            Console.Write("Путь до файла валидации (XSD, DTD): ");

            var validationFilePath = Console.ReadLine();

            var validatorType = GetValidator();

            var program = new Program(validatorType);

            if (validatorType is XsdValidator)
            {
                var structureValidator = new StructureValidator();
                structureValidator.OnError += wrongElement =>
                {
                    Console.WriteLine("Ошибка структуры XSD");
                    Console.WriteLine(wrongElement);
                };

                var structureValidatorResult = structureValidator.Validate(validationFilePath);

                if (!structureValidatorResult)
                {
                    Console.WriteLine("Неправильная вложенность елементов");
                    Console.ReadKey();
                }
            }


            Console.Write("Путь до XML файла: ");

            var xmlPath = Console.ReadLine();

            program.Validator.OnValidationError += error =>
            {
                Console.WriteLine("Ошибка валидации XML");
                Console.WriteLine(error);
            };

            var result = false;
            try
            {
                program.Validator.Load(validationFilePath);
                result = program.Validator.Validate(xmlPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(result ? "Валидация успешна" : "Валидация завершилась с ошибками");
            Console.ReadKey();
        }

        private static IValidator GetValidator()
        {
            while (true)
            {
                Console.WriteLine("Укажите тип валидации:");
                Console.WriteLine("1 - XSD");
                Console.WriteLine("2 - DTD");
                Console.Write("Тип валидации:");

                var type = Console.ReadLine();

                switch (type)
                {
                    case "1":
                        return new XsdValidator();
                    case "2":
                        return new DtdValidator();
                    default:
                        Console.WriteLine("Тип не найден\n");
                        break;
                }
            }
        }

        private static void StructureValidatorOnOnError(XElement wrongElement)
        {
            Console.WriteLine(wrongElement);
        }
    }
}