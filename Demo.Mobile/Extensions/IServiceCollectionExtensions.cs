using Demo.Abstraction.Services;
using Demo.Mobile.Services;

namespace Demo.Mobile.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterPlatformLayer(this IServiceCollection services)
        {
            var locator = new MauiPageLocator();
            services
                .AddSingleton<IMainThreadInvoker, MainThreadInvoker>()
                .AddSingleton<INavigationService, NavigationService>()
                .AddSingleton<IViewLocator<Page>>(locator);

            return services;
        }
    }
}
