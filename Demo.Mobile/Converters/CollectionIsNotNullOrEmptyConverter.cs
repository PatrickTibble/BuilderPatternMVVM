using System.Collections;

namespace Demo.Mobile.Converters
{
    internal class CollectionIsNotNullOrEmptyConverter : BaseValueConverter<IList, bool>
    {
        protected override bool Convert(IList? value)
        {
            return value?.Count > 0;
        }
    }
}
