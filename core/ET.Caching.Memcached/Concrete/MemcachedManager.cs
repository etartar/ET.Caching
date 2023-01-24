using Enyim.Caching;
using ET.Caching.Core.Abstract;

namespace ET.Caching.Memcached.Concrete
{
    internal class MemcachedManager : IAsyncCacheManager
    {
        private readonly IMemcachedClient _memcachedClient;

        public MemcachedManager(IMemcachedClient memcachedClient)
        {
            _memcachedClient = memcachedClient;
        }

        public T Get<T>(string key)
        {
            T returnData = default(T);

            var data = _memcachedClient.Get<T>(key);
            if (data != null)
            {
                returnData = data;
            }

            return returnData;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            T returnData = default(T);

            var data = await _memcachedClient.GetValueAsync<T>(key);
            if (data != null)
            {
                returnData = data;
            }

            return returnData;
        }

        public void Set<T>(string key, T value, TimeSpan expireTime)
        {
            _memcachedClient.Set(key, value, expireTime);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expireTime)
        {
            await _memcachedClient.SetAsync(key, value, expireTime);
        }

        public void Remove<T>(string key)
        {
            _memcachedClient.Remove(key);
        }

        public async Task RemoveAsync<T>(string key)
        {
            await _memcachedClient.RemoveAsync(key);
        }
    }
}
