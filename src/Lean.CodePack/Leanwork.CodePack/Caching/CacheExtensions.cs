using System;

namespace Leanwork.CodePack
{
    public static class CacheExtensions
    {
        /// <summary>
        /// Get Cache Time (default time 10 minutes)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="key"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            var cacheTime = 10; //10 min
            return Get(cacheManager, key, cacheTime, acquire);
        }

        /// <summary>
        /// Get Cache Time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="key"></param>
        /// <param name="cacheTime"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();

                cacheManager.Set(key, result, cacheTime);

                return result;
            }
        }
    }
}
