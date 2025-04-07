using Demo.Abstraction.Entities;
using Demo.Core.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Demo.Core.Entities
{
    internal class ViewModelCollectionBuilder : IViewModelCollectionBuilder
    {
        private List<INotifyPropertyChanged> _items = [];

        public IViewModelCollectionBuilder AddPrimaryPageFooter(string version, string copyright)
        {
            _items.Add(new PrimaryFooterViewModel(version, copyright));
            return this;
        }

        public IViewModelCollectionBuilder AddPrimaryPageHeader(string headerTitle)
        {
            _items.Add(new PrimaryHeaderViewModel(headerTitle));
            return this;
        }

        public IList<INotifyPropertyChanged> Build()
        {
            var items = new ObservableCollection<INotifyPropertyChanged>(_items);
            _items.Clear();
            return items;
        }

        public IViewModelCollectionBuilder WithTwoWayBinding<T>(IBindable source, string propertyName, Action<T> sourcePropertyChanged, Action<T> targetPropertyChanged)
        {
            return this
                .WithOneWayToSourceBinding(propertyName, targetPropertyChanged)
                .WithOneWayBinding(source, propertyName, sourcePropertyChanged);
        }

        public IViewModelCollectionBuilder WithOneWayToSourceBinding<T>(string propertyName, Action<T> propertyChanged)
        {
            if (_items.LastOrDefault() is IBindable bindable
                && bindable is T binding)
            {
                bindable.AddBinding(propertyName, propertyChanged);
            }

            return this;
        }

        public IViewModelCollectionBuilder WithOneWayBinding<T>(IBindable bindable, string propertyName, Action<T> propertyChanged)
        {
            if (_items.LastOrDefault() is T binding)
            {
                bindable.AddBinding(propertyName, propertyChanged);
            }

            return this;
        }
    }
}
