using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ConsoleApplication2.Types
{
    public class PatternRestriction : Restriction
    {
        private readonly Regex _patternRegex;
        private readonly string _pattern;

        public PatternRestriction(XElement element)
        {
            _pattern = element.Attribute("value")?.Value ?? string.Empty;
            _patternRegex = new Regex(_pattern);

        }

        public override void Validate(XElement element)
        {
            if (!_patternRegex.IsMatch(element.Value))
            {
                throw new Exception($"Element {element} pattern ({_pattern}) match failed");
            }
        }
    }
}