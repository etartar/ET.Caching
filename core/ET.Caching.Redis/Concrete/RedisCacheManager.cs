using ET.Caching.Core.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace ET.Caching.Redis.Concrete
{
    internal class RedisCacheManager : IAsyncCacheManager
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public T Get<T>(string key)
        {
            T returnData = default(T);

            byte[] cachedData = _distributedCache.Get(key);
            if (cachedData != null)
            {
                var serializedData = Encoding.UTF8.GetString(cachedData);
                returnData = JsonSerializer.Deserialize<T>(serializedData);
            }

            return returnData;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            T returnData = default(T);

            byte[] cachedData = await _distributedCache.GetAsync(key);
            if (cachedData != null)
            {
                var serializedData = Encoding.UTF8.GetString(cachedData);
                returnData = JsonSerializer.Deserialize<T>(serializedData);
            }

            return returnData;
        }

        public void Set<T>(string key, T value, TimeSpan expireTime)
        {
            var serializedData = JsonSerializer.Serialize(value);
            var byteValue = Encoding.UTF8.GetBytes(serializedData);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expireTime
            };

            _distributedCache.Set(key, byteValue, options);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expireTime)
        {
            var serializedData = JsonSerializer.Serialize(value);
            var byteValue = Encoding.UTF8.GetBytes(serializedData);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expireTime
            };

            await _distributedCache.SetAsync(key, byteValue, options);
        }

        public void Remove<T>(string key)
        {
            _distributedCache.Remove(key);
        }

        public async Task RemoveAsync<T>(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}
