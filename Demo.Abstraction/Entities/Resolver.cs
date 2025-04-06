using Microsoft.Extensions.DependencyInjection;

namespace Demo.Abstraction.Entities
{
    public static class Resolver
    {
        private static Func<IServiceProvider>? _providerFunc;

        public static void SetServiceProvider(Func<IServiceProvider> providerRetrievalFunc)
        {
            _providerFunc = providerRetrievalFunc;
        }

        public static T Resolve<T>()
            where T : notnull
        {
            var provider = _providerFunc?.Invoke();
            ArgumentNullException.ThrowIfNull(provider);

            return provider.GetRequiredService<T>();
        }
    }
}
