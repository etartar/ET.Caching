using Enyim.Caching.Configuration;
using ET.Caching.Core.Abstract;
using ET.Caching.Memcached.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ET.Caching.Memcached
{
    public static class MemcachedServiceRegistration
    {
        public static IServiceCollection AddMemcachedServices(this IServiceCollection services, Action<MemcachedClientOptions> memcachedSettings)
        {
            services.AddEnyimMemcached(memcachedSettings);
            services.AddTransient<ICacheManager, MemcachedManager>();
            return services;
        }
    }
}
