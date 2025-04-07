using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Entities;
using Demo.Core.Entities;
using System.ComponentModel;

namespace Demo.Core.PageModels
{
    public abstract partial class BuildablePageModel : BaseObservable, IPrepare
    {
        [ObservableProperty]
        private IList<INotifyPropertyChanged> _headers = [];

        [ObservableProperty]
        private IList<INotifyPropertyChanged> _items = [];

        [ObservableProperty]
        private IList<INotifyPropertyChanged> _footers = [];

        public virtual void Prepare(IDictionary<string, object>? prepParameters)
        {
            Headers = CreateOptionalHeaders(Resolver.Resolve<IViewModelCollectionBuilder>());
            Items = CreateItems(Resolver.Resolve<IViewModelCollectionBuilder>());
            Footers = CreateOptionalFooters(Resolver.Resolve<IViewModelCollectionBuilder>());
        }

        protected virtual IList<INotifyPropertyChanged> CreateOptionalHeaders(IViewModelCollectionBuilder builder)
        {
            return [];
        }

        protected virtual IList<INotifyPropertyChanged> CreateOptionalFooters(IViewModelCollectionBuilder builder)
        {
            return [];
        }

        protected abstract IList<INotifyPropertyChanged> CreateItems(IViewModelCollectionBuilder builder);
    }
}
