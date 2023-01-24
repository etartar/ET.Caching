using ET.Caching.Core.Abstract;
using ET.Caching.Redis.Concrete;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;

namespace ET.Caching.Redis
{
    public static class RedisCacheServiceRegistration
    {
        public static IServiceCollection AddRedisCacheServices(this IServiceCollection services, Action<RedisCacheOptions> redisSettings)
        {
            services.AddStackExchangeRedisCache(redisSettings);
            services.AddTransient<IAsyncCacheManager, RedisCacheManager>();
            return services;
        }
    }
}
