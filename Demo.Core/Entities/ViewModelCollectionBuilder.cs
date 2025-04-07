using Demo.Abstraction.Entities;
using Demo.Abstraction.Models;
using Demo.Core.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Demo.Core.Entities
{
    internal class ViewModelCollectionBuilder : IViewModelCollectionBuilder
    {
        private List<INotifyPropertyChanged> _items = [];

        public IViewModelCollectionBuilder AddButtonRow(string text, ICommand command)
        {
            _items.Add(new ButtonRowViewModel
            {
                Text = text,
                Command = command
            });

            return this;
        }

        public IViewModelCollectionBuilder AddImageRow(Images image)
        {
            _items.Add(new ImageRowViewModel
            {
                Source = image
            });

            return this;
        }

        public IViewModelCollectionBuilder AddPrimaryPageFooter(string version, string copyright)
        {
            _items.Add(new PrimaryFooterViewModel
            {
                Version = version,
                Copyright = copyright
            });
            return this;
        }

        public IViewModelCollectionBuilder AddPrimaryPageHeader(string headerTitle)
        {
            _items.Add(new PrimaryHeaderViewModel
            {
                AppTitle = headerTitle
            });
            return this;
        }

        public IViewModelCollectionBuilder AddTextRow(string text)
        {
            _items.Add(new TextRowViewModel
            {
                Text = text
            });
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
                bindable.AddBinding(propertyName, () => propertyChanged(binding));
            }

            return this;
        }

        public IViewModelCollectionBuilder WithOneWayBinding<T>(IBindable bindable, string propertyName, Action<T> propertyChanged)
        {
            if (_items.LastOrDefault() is T binding)
            {
                bindable.AddBinding(propertyName, () => propertyChanged(binding));
            }

            return this;
        }

        public IViewModelCollectionBuilder WithSemanticProperties(SemanticOptions level, string semanticDescription)
        {
            if (_items.LastOrDefault() is ISemanticViewModel vm)
            {
                vm.SemanticLevel = level;
                vm.SemanticDescription = semanticDescription;
            }

            return this;
        }

        public IViewModelCollectionBuilder WithLayoutOptions(LayoutOptions layoutOptions)
        {
            if (_items.LastOrDefault() is ILayoutOptions layout)
            {
                layout.LayoutOptions = layoutOptions;
            }
            return this;
        }
    }
}
