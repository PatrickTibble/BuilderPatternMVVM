namespace Demo.Mobile.Converters
{
    internal abstract class BaseLayoutOptionsConverter<T> : BaseValueConverter<Abstraction.Models.LayoutOptions, T>
    {
    }

    internal class LayoutOptionsConverter : BaseLayoutOptionsConverter<LayoutOptions>
    {
        protected override LayoutOptions Convert(Abstraction.Models.LayoutOptions value)
        {
            return value switch
            {
                Abstraction.Models.LayoutOptions.StartAndExpand => LayoutOptions.StartAndExpand,
                Abstraction.Models.LayoutOptions.Start => LayoutOptions.Start,
                Abstraction.Models.LayoutOptions.Center => LayoutOptions.Center,
                Abstraction.Models.LayoutOptions.CenterAndExpand => LayoutOptions.CenterAndExpand,
                Abstraction.Models.LayoutOptions.End => LayoutOptions.End,
                Abstraction.Models.LayoutOptions.EndAndExpand => LayoutOptions.EndAndExpand,
                Abstraction.Models.LayoutOptions.Fill => LayoutOptions.Fill,
                Abstraction.Models.LayoutOptions.FillAndExpand => LayoutOptions.FillAndExpand,

                _ => throw new ArgumentException()
            };
        }
    }

    internal class TextAlignmentConverter : BaseLayoutOptionsConverter<TextAlignment>
    {
        protected override TextAlignment Convert(Abstraction.Models.LayoutOptions value)
        {
            return value switch
            {
                Abstraction.Models.LayoutOptions.StartAndExpand => TextAlignment.Start,
                Abstraction.Models.LayoutOptions.Start => TextAlignment.Start,
                Abstraction.Models.LayoutOptions.Center => TextAlignment.Center,
                Abstraction.Models.LayoutOptions.CenterAndExpand => TextAlignment.Center,
                Abstraction.Models.LayoutOptions.End => TextAlignment.End,
                Abstraction.Models.LayoutOptions.EndAndExpand => TextAlignment.End,
                Abstraction.Models.LayoutOptions.Fill => TextAlignment.Start,
                Abstraction.Models.LayoutOptions.FillAndExpand => TextAlignment.Start,
                _ => throw new ArgumentException()
            };
        }
    }
}
