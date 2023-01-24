using ET.Caching.Core.Abstract;
using ET.Caching.InMemory.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ET.Caching.InMemory
{
    public static class InMemoryCacheServiceRegistration
    {
        public static IServiceCollection AddInMemoryCacheServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddTransient<ICacheManager, InMemoryCacheManager>();

            return services;
        }
    }
}
