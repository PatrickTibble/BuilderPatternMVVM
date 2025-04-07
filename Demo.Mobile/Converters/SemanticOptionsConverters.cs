using Demo.Abstraction.Models;

namespace Demo.Mobile.Converters
{
    internal abstract class SemanticOptionsConverters<T> : BaseValueConverter<SemanticOptions, T>
    {
    }

    internal class HeadingLevelConverter : SemanticOptionsConverters<SemanticHeadingLevel>
    {
        protected override SemanticHeadingLevel Convert(SemanticOptions value)
        {
            return value switch
            {
                SemanticOptions.Level1 => SemanticHeadingLevel.Level1,
                SemanticOptions.Level2 => SemanticHeadingLevel.Level2,
                _ => SemanticHeadingLevel.Level4
            };
        }
    }

    internal class HeadingLevelToFontSizeConverter : SemanticOptionsConverters<double>
    {
        protected override double Convert(SemanticOptions value)
        {
            return value switch
            {
                SemanticOptions.Level1 => 32,
                SemanticOptions.Level2 => 24,
                _ => 32,
            };
        }
    }
}
