using System;

namespace StoryTeller.Conversion
{
    public class EnumerationConversion : IConversionProvider
    {
        public Func<string, object> ConverterFor(Type type)
        {
            if (type.IsEnum)
            {
                return x => Enum.Parse(type, x);
            }

            return null;
        }
    }
}