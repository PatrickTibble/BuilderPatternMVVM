using Demo.Abstraction.Entities;
using Demo.Abstraction.Services;
using System.ComponentModel;

namespace Demo.Mobile.Services
{
    public class MauiPageLocator : IViewLocator<Page>
    {
        private readonly Dictionary<Type, Type> _lookupTable = [];

        public Page LocateFor<TObservable>() where TObservable : INotifyPropertyChanged
        {
            var key = typeof(TObservable);
            if (_lookupTable.TryGetValue(key, out var pageType))
            {
                var page = (Page?)Activator.CreateInstance(pageType);
                if (page != null)
                {
                    var bindingContext = Resolver.Resolve<TObservable>();
                    page.BindingContext = bindingContext;
                    return page;
                }
                throw new ArgumentException($"Unable to create Page for {pageType.Name}");
            }

            throw new ArgumentException($"No Page registered for {key}");
        }

        public void Register<TView, TObservable>()
            where TView : Page
            where TObservable : INotifyPropertyChanged
        {
            _lookupTable.Add(typeof(TObservable), typeof(TView));
        }
    }
}
