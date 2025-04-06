using CommunityToolkit.Mvvm.ComponentModel;
using Demo.Abstraction.Entities;

namespace Demo.Core.Entities
{
    public abstract partial class BaseObservable : ObservableObject, IInitialize, ILoadable
    {
        [ObservableProperty]
        private bool _isLoading;

        public virtual Task InitializeAsync(IDictionary<string, object>? initializationParameters, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
