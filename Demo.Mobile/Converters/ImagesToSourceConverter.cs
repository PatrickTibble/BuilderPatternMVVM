using Demo.Abstraction.Models;

namespace Demo.Mobile.Converters
{
    internal class ImagesToSourceConverter : BaseValueConverter<Images, ImageSource>
    {
        protected override ImageSource Convert(Images value)
        {
            return value switch
            {
                Images.DotNetBot => "dotnet_bot.png",
                _ => throw new ArgumentException($"No Image Source mapped to {value}")
            };
        }
    }
}
