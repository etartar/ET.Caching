using ET.Caching.Core.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace ET.Caching.InMemory.Concrete
{
    internal class InMemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Set<T>(string key, T value, TimeSpan expireTime)
        {
            _memoryCache.Set(key, value, expireTime);
        }

        public void Remove<T>(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
