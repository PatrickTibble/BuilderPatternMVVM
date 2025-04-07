using Demo.Core.ViewModels;
using Demo.Mobile.Views;

namespace Demo.Mobile.Templates
{
    public class BuildableTemplateSelector : DataTemplateSelector
    {
        private readonly IReadOnlyDictionary<Type, DataTemplate> _templates = new Dictionary<Type, DataTemplate>()
        {
            { typeof(PrimaryHeaderViewModel), new DataTemplate(typeof(PrimaryHeaderRow)) },
            { typeof(PrimaryFooterViewModel), new DataTemplate(typeof(PrimaryFooterRow)) }
        };

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var key = item.GetType();
            if (_templates.TryGetValue(key, out var template))
            {
                return template;
            }

            throw new ArgumentException($"Unable to resolve DateTemplate for type {key.Name}");
        }
    }
}
