namespace Leanwork.CodePack
{
    public class NullCache : ICacheManager
    {
        public T Get<T>(string key)
        {
            return default(T);
        }

        public void Set(string key, object data, int cacheTime)
        {
        }

        public bool IsSet(string key)
        {
            return false;
        }

        public void Remove(string key)
        {
        }

        public void RemoveByPattern(string pattern)
        {
        }

        public void Clear()
        {
        }
    }
}