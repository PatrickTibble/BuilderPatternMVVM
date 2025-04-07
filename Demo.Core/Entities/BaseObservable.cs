using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Entities;
using System.ComponentModel;

namespace Demo.Core.Entities
{
    public abstract partial class BaseObservable : ObservableObject, IInitialize, ILoadable, IBindable
    {
        [ObservableProperty]
        private bool _isLoading;

        public IDictionary<string, IList<Action>> BindingSet { get; } = new Dictionary<string, IList<Action>>();

        public virtual Task InitializeAsync(IDictionary<string, object>? initializationParameters, CancellationToken token)
        {
            return Task.CompletedTask;
        }

        public void AddBinding(string propertyName, Action propertyChanged)
        {
            if (!(BindingSet.TryGetValue(propertyName, out var list) && list.Count > 0))
            {
                list = new List<Action>();
                BindingSet.Add(propertyName, list);
            }

            list.Add(propertyChanged);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (!string.IsNullOrEmpty(e.PropertyName) && BindingSet.TryGetValue(e.PropertyName, out var bindings))
            {
                foreach (var bindingAction in bindings)
                {
                    bindingAction();
                }
            }
        }
    }
}
