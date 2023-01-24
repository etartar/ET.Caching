namespace ET.Caching.Core.Abstract
{
    public interface IAsyncCacheManager : ICacheManager
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan expireTime);
        Task RemoveAsync<T>(string key);
    }
}
