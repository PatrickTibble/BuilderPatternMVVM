using Demo.Abstraction.Services;
using Demo.Core.PageModels;
using Demo.Mobile.Pages;
using Demo.Mobile.Services;
using System.ComponentModel;

namespace Demo.Mobile.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterPlatformLayer(this IServiceCollection services)
        {
            services
                .RegisterPlatformServices()
                .RegisterForNavigation();

            return services;
        }

        private static IServiceCollection RegisterPlatformServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IPlatformService, PlatformService>()
                .AddSingleton<IMainThreadInvoker, MainThreadInvoker>()
                .AddSingleton<INavigationService, NavigationService>();
        }

        private static IServiceCollection RegisterForNavigation(this IServiceCollection services)
        {
            var locator = new MauiPageLocator();
            return services
                .AddSingleton<IViewLocator<Page>>(locator)
                .RegisterShared<Page, BuildablePage, ShellPageModel>(locator);
        }

        public static IServiceCollection RegisterShared<TBaseView, TView, TObservable>(this IServiceCollection services, IViewLocator<TBaseView> locator)
            where TView : TBaseView
            where TObservable : class, INotifyPropertyChanged
        {
            locator.Register<TView, TObservable>();
            return services.AddTransient<TObservable>();
        }
    }
}
