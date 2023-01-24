namespace ET.Caching.Core.Abstract
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan expireTime);
        void Remove<T>(string key);
    }
}
