using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public class SimpleType : SimpleTypeBase
    {

        private readonly List<Restriction> _restrictions;

        public string BaseType { get; set; }

        public SimpleType(string name) : base(name)
        {
            _restrictions = new List<Restriction>();
        }

        public override void Validate(XElement element)
        {
            base.Validate(element);

            var enumRestrictions = _restrictions.OfType<EnumerationRestriction>().ToArray();

            if (enumRestrictions.Length > 0)
            {
                var success = false;

                foreach (var enumRestriction in enumRestrictions)
                {
                    try
                    {
                        enumRestriction.Validate(element);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    success = true;
                    break;
                }

                if (!success)
                {
                    throw new Exception($"Значение элемента ({element.Value}) не входят в следующую коллекцию перечислений ({string.Join(",", enumRestrictions.Select(e => e.Value))})");
                }
            }

            var otherRestrictions = _restrictions.Except(enumRestrictions).ToArray();

            if (otherRestrictions.Length == 0)
            {
                return;
            }

            foreach (var restriction in otherRestrictions)
            {
                restriction.Validate(element);
            }
        }

        public void AddRestriction(Restriction restriction)
        {
            _restrictions.Add(restriction);
        }
    }
}