using Demo.Abstraction.Entities;
using Demo.Abstraction.Services;
using System.ComponentModel;

namespace Demo.Mobile.Services
{
    public class NavigationService : INavigationService
    {
        private static INavigation _nav => Application.Current?.Windows[0].Navigation ?? throw new ArgumentNullException($"Unable to find navigation for current window");

        private readonly IMainThreadInvoker _invoker;
        private readonly IViewLocator<Page> _pageLocator;

        public NavigationService(
            IMainThreadInvoker invoker,
            IViewLocator<Page> locator)
        {
            _invoker = invoker;
            _pageLocator = locator;
        }

        public Task DismissModalAsync(CancellationToken token)
            => _nav.PopModalAsync().WaitAsync(token);

        public Task GoBackAsync(CancellationToken token)
            => _nav.PopAsync().WaitAsync(token);

        public Task PushAsync<TPageModel>(IDictionary<string, object>? navigationParameters, CancellationToken token)
            where TPageModel : INotifyPropertyChanged
            => InternalNavigateToAsync<TPageModel>(false, navigationParameters, token);

        public Task ShowModalAsync<TPageModel>(IDictionary<string, object>? navigationParameters, CancellationToken token)
            where TPageModel : INotifyPropertyChanged
            => InternalNavigateToAsync<TPageModel>(true, navigationParameters, token);

        private Task InternalNavigateToAsync<TPageModel>(bool isModal, IDictionary<string, object>? navigationParameters, CancellationToken token)
            where TPageModel : INotifyPropertyChanged
        {
            var page = _pageLocator.LocateFor<TPageModel>();
            ArgumentNullException.ThrowIfNull(page);

            _invoker.BeginInvokeOnMainThread(() =>
            {
                if (isModal)
                {
                    return _nav.PushModalAsync(page);
                }
                return _nav.PushAsync(page);
            });

            if (page.BindingContext is IPrepare preparable)
            {
                preparable.Prepare(navigationParameters);
            }

            if (page.BindingContext is IInitialize initContext)
            {
                return initContext.InitializeAsync(navigationParameters, token);
            }

            return Task.CompletedTask;
        }
    }
}
