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
            System.Diagnostics.Debug.Assert(_providerFunc != null, "Provider Retrieval Function isn't set.");
            var provider = _providerFunc?.Invoke();

            System.Diagnostics.Debug.Assert(provider != null, $"Unable to retrieve ServiceProvider.");

            return provider.GetRequiredService<T>();
        }
    }
}
