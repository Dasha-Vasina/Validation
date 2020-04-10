using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using ConsoleApplication2.Types;
using Validators;

namespace ConsoleApplication2
{
    public abstract class ValidatorBase : IXmlValidator, IValidator
    {
        private readonly ValidationDataContainer _container;
        public event Action<String> OnValidationError;

        public ValidatorBase()
        {
            _container = new ValidationDataContainer();
        }
        public abstract void Add(XElement element);

        public void AddType(IType type)
        {
            _container.AddType(type);
        }

        public void AddElement(Element element)
        {
            _container.AddElement(element);
        }
        public void AddAttribute(string element, AttributeValidation attribute)
        {
            _container.AddAttribute(element, attribute);
        }

        public abstract void Load(string validatorText);
        public abstract void Load(Stream stream);

        public bool Validate(string path)
        {
            try
            {
                var docFile = XDocument.Parse(path);

                ValidateInternal(docFile);
            }
            catch (Exception e)
            {
                OnValidationError?.Invoke(e.Message);
                return false;
            }

            return true;
        }

        public bool Validate(Stream stream)
        {
            try
            {
                var docFile = XDocument.Load(stream);

                ValidateInternal(docFile);
            }
            catch (Exception e)
            {
                OnValidationError?.Invoke(e.Message);
                return false;
            }

            return true;
        }

        protected abstract void ValidateInternal(XDocument document);

        public IType GetElementType(string elementName)
        {
            return _container.GetElementType(elementName);
        }

        public IEnumerable<AttributeValidation> GetElementAttributes(string elementName)
        {
            return _container.GetElementAttributes(elementName);
        }
    }
}