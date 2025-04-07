using Demo.Abstraction.Entities;
using Demo.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            return services
                .AddTransient<IViewModelCollectionBuilder, ViewModelCollectionBuilder>();
        }
    }
}
