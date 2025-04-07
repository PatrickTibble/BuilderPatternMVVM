using System.Globalization;

namespace Demo.Mobile.Converters
{
    internal abstract class BaseValueConverter<Tin, Tout> : IValueConverter, IMarkupExtension
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Tin tin)
            {
                return Convert(tin);
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Tout tout)
            {
                return ConvertBack(tout);
            }
            return null;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
            => this;

        protected abstract Tout Convert(Tin? value);        

        protected virtual Tin ConvertBack(Tout? value)
        {
            throw new NotImplementedException();
        }
    }
}
